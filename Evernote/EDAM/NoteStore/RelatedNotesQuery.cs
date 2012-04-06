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
  public partial class RelatedNotesQuery : TBase
  {
    private RelatedNotesExampleText _exampleText;

    public RelatedNotesExampleText ExampleText
    {
      get
      {
        return _exampleText;
      }
      set
      {
        __isset.exampleText = true;
        this._exampleText = value;
      }
    }


    public Isset __isset;
    #if !NETFX_CORE
    [Serializable]
    #endif
    public struct Isset {
      public bool exampleText;
    }

    public RelatedNotesQuery() {
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
          case 2:
            if (field.Type == TType.Struct) {
              ExampleText = new RelatedNotesExampleText();
              ExampleText.Read(iprot);
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
      TStruct struc = new TStruct("RelatedNotesQuery");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (ExampleText != null && __isset.exampleText) {
        field.Name = "exampleText";
        field.Type = TType.Struct;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        ExampleText.Write(oprot);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("RelatedNotesQuery(");
      sb.Append("ExampleText: ");
      sb.Append(ExampleText== null ? "<null>" : ExampleText.ToString());
      sb.Append(")");
      return sb.ToString();
    }

  }

}