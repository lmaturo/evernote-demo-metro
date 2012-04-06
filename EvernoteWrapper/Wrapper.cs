using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

using Thrift;
using Thrift.Transport;
using Thrift.Protocol;
using Evernote.EDAM.UserStore;
using Evernote.EDAM.NoteStore;
using Evernote.EDAM.Type;
using Evernote.EDAM.Limits;
using Evernote.EDAM.Error;

namespace EvernoteWrapper
{
    public sealed class Wrapper
    {
        private static String EDAM_NOTE_PREAMBLE = 
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<!DOCTYPE en-note SYSTEM \"http://xml.evernote.com/pub/enml2.dtd\">" +
            "<en-note>";
        private static String EDAM_NOTE_POSTAMBLE = "</en-note>";

        private static String APP_NAME = "EvernoteMetroSample";
        private static String USER_AGENT = "Evernote Metro Sample 1.0";

        private String evernoteHost = "sandbox.evernote.com";

        // Replace these with your API key values
        private String consumerKey = "your key";
        private String consumerSecret = "your secret";

        private UserStore.Client userStore;
        private String authToken;
        private DateTime tokenExpires;
        private String noteStoreUrl;

        // Base-64 encoded Evernote icon that we can add into a new note 
        private String imgBase64 = "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";

        public Wrapper()
        {
            Uri userStoreUrl = new Uri("https://" + evernoteHost + "/edam/user");
            TTransport userStoreTransport = new THttpClient(userStoreUrl);
            TProtocol userStoreProtocol = new TBinaryProtocol(userStoreTransport);
            userStore = new UserStore.Client(userStoreProtocol);
        }

        /// <summary>
        /// Updated cached authentication information with the values in the specified
        /// AuthenticationResult.
        /// </summary>
        private void updateAuth(AuthenticationResult result)
        {
            authToken = result.AuthenticationToken;
            noteStoreUrl = result.NoteStoreUrl;

            // Calculate the token expiration time, accounting for clock skew 
            long durationMillis = result.Expiration - result.CurrentTime;
            TimeSpan duration = TimeSpan.FromMilliseconds(durationMillis);
            tokenExpires = DateTime.UtcNow.Add(duration);
        }

        /// <summary>
        /// Make sure we have a valid auth token. Refreshes if possible, otherwise re-authenticates
        /// using username and password. Throws an TApplicationException, TTransportException, 
        /// EDAMUserException or EDAMSystemException if an error occurs.
        /// </summary>
        /// <returns>
        /// True if a valid auth token was obtained, false if the Evernote service won't speak to us 
        /// because our protocol version is out-of-date.
        /// </returns>
        private bool auth(String username, String password)
        {
            if (authToken != null)
            {
                // See if our authToken is going to expire in the next 15 minutes
                if (tokenExpires <= DateTime.UtcNow.AddMinutes(-15))
                {
                    // We have an authToken that doesn't expire for at least 15 minutes
                    return true;
                }
                else if (tokenExpires <= DateTime.UtcNow)
                {
                    // We have an authToken that we can refresh
                    try
                    {
                        updateAuth(userStore.refreshAuthentication(authToken));
                        return true;
                    }
                    catch (EDAMUserException)
                    {
                        // Maybe we can't refresh it ... fall through and authenticate again
                    }
                }
            }

            // We need to authenticate - first make sure we're allowed to speak to the service
            if (!userStore.checkVersion(APP_NAME,
                Evernote.EDAM.UserStore.Constants.EDAM_VERSION_MAJOR,
                Evernote.EDAM.UserStore.Constants.EDAM_VERSION_MINOR))
            {
                return false;
            }

            updateAuth(userStore.authenticate(username, password, consumerKey, consumerSecret));
            return true;
        }

        /// <summary>
        /// Create a new note in the account of the user with the specified Evernote username and password.
        /// </summary>
        /// <returns>true if the note was created successfully, false otherwise.</returns>
        public bool createNote(String username, String password)
        {
            try
            {
                try
                {
                    if (!auth(username, password))
                    {
                        // This is an unrecoverable error - our protocol version is out of date
                        return false;
                    }
                }
                catch (EDAMUserException eux)
                {
                    // I'm showing some of the most common error codes here that we might want to handle separately.
                    // For the full list, see 
                    // http://dev.evernote.com/documentation/reference/UserStore.html#Fn_UserStore_authenticate
                    if (eux.ErrorCode == EDAMErrorCode.INVALID_AUTH)
                    {
                        if (eux.Parameter == "username" || eux.Parameter == "password")
                        {
                            // We failed to authenticate because the username or password was invalid
                            // This is a recoverable error that the user can fix
                        }
                        else
                        {
                            // Our API key was invalid, or something else wonky happened
                            // The user can't help us recover from this
                        }
                    }
                    else if (eux.ErrorCode == EDAMErrorCode.PERMISSION_DENIED)
                    {
                        if (eux.Parameter == "User.active")
                        {
                            // The credentials were correct, but this user account is not active
                        }
                    }
                    else
                    {
                        // We failed to authenticate for some other reason
                    }
                    return false;
                }

                THttpClient noteStoreTransport = new THttpClient(new Uri(noteStoreUrl));
                noteStoreTransport.CustomHeaders[HttpRequestHeader.UserAgent.ToString()] = USER_AGENT;
                TProtocol noteStoreProtocol = new TBinaryProtocol(noteStoreTransport);
                NoteStore.Client noteStore = new NoteStore.Client(noteStoreProtocol);

                // The bytes of the image we want to send up to the service
                // In this test, we use an image hardcoded as a base64-encoded string
                IBuffer imageBuffer = CryptographicBuffer.DecodeFromBase64String(imgBase64);
                byte[] imageBytes = WindowsRuntimeBufferExtensions.ToArray(imageBuffer);
                
                HashAlgorithmProvider provider = HashAlgorithmProvider.OpenAlgorithm("MD5");
                IBuffer hashBuffer = provider.HashData(imageBuffer);
                byte[] hash = WindowsRuntimeBufferExtensions.ToArray(hashBuffer);
                String hashHex = CryptographicBuffer.EncodeToHexString(hashBuffer);

                Data data = new Data();
                data.Size = imageBytes.Length;
                data.BodyHash = hash;
                data.Body = imageBytes;

                Resource resource = new Resource();
                resource.Mime = "image/png";
                resource.Data = data;

                Note note = new Note();
                note.Title = "Hello, World!";
                note.Content = EDAM_NOTE_PREAMBLE + 
                    "<h2>This note is created by Skitch for Metro!</h2>" + 
                    "<br />" +
                    "<en-media type=\"image/png\" hash=\"" + hashHex + "\"/>" +
                    EDAM_NOTE_POSTAMBLE;
                note.Resources = new List<Resource>();
                note.Resources.Add(resource);

                try
                {
                    noteStore.createNote(authToken, note);
                    return true;
                }
                catch (EDAMUserException ex)
                {
                    // Handle note creation failure
                }
            }
            catch (TApplicationException tax)
            {
                // Handle generic Thrift error
            }
            catch (TTransportException ttx)
            {
                // Handle networking error
            }
            catch (EDAMSystemException esx)
            {
                // Handle unrecoverable Evernote error (i.e., error not caused by bad user input)
            }

            return false;
        }

    }
}
