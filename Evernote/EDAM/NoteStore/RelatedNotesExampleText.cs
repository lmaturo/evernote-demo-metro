/**
 * Autogenerated by Thrift
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
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
namespace Evernote.EDAM.NoteStore
{

  #if !NETFX_CORE
  [Serializable]
  #endif
  public partial class RelatedNotesExampleText : TBase
  {
    private string _text;

    public string Text
    {
      get
      {
        return _text;
      }
      set
      {
        __isset.text = true;
        this._text = value;
      }
    }


    public Isset __isset;
    #if !NETFX_CORE
    [Serializable]
    #endif
    public struct Isset {
      public bool text;
    }

    public RelatedNotesExampleText() {
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
            if (field.Type == TType.String) {
              Text = iprot.ReadString();
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
      TStruct struc = new TStruct("RelatedNotesExampleText");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Text != null && __isset.text) {
        field.Name = "text";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Text);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("RelatedNotesExampleText(");
      sb.Append("Text: ");
      sb.Append(Text);
      sb.Append(")");
      return sb.ToString();
    }

  }

}