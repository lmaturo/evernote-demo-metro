/**
 * Autogenerated by Thrift Compiler (0.8.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using Thrift.Protocol;
using Thrift.Transport;
namespace Evernote.EDAM.UserStore
{

  #if !SILVERLIGHT && !NETFX_CORE
  [Serializable]
  #endif
  public partial class BootstrapInfo : TBase
  {
    private List<BootstrapProfile> _profiles;
    private string _country;

    public List<BootstrapProfile> Profiles
    {
      get
      {
        return _profiles;
      }
      set
      {
        __isset.profiles = true;
        this._profiles = value;
      }
    }

    public string Country
    {
      get
      {
        return _country;
      }
      set
      {
        __isset.country = true;
        this._country = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT && !NETFX_CORE
    [Serializable]
    #endif
    public struct Isset {
      public bool profiles;
      public bool country;
    }

    public BootstrapInfo() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.List) {
              {
                Profiles = new List<BootstrapProfile>();
                TList _list0 = iprot.ReadListBegin();
                for( int _i1 = 0; _i1 < _list0.Count; ++_i1)
                {
                  BootstrapProfile _elem2 = new BootstrapProfile();
                  _elem2 = new BootstrapProfile();
                  _elem2.Read(iprot);
                  Profiles.Add(_elem2);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              Country = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("BootstrapInfo");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Profiles != null && __isset.profiles) {
        field.Name = "profiles";
        field.Type = TType.List;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, Profiles.Count));
          foreach (BootstrapProfile _iter3 in Profiles)
          {
            _iter3.Write(oprot);
            oprot.WriteListEnd();
          }
        }
        oprot.WriteFieldEnd();
      }
      if (Country != null && __isset.country) {
        field.Name = "country";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Country);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("BootstrapInfo(");
      sb.Append("Profiles: ");
      sb.Append(Profiles);
      sb.Append(",Country: ");
      sb.Append(Country);
      sb.Append(")");
      return sb.ToString();
    }

  }

}