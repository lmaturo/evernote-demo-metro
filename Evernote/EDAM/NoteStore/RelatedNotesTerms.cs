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
  public partial class RelatedNotesTerms : TBase
  {
    private string _text;
    private RelatedNotesFields _field;
    private double _scoreBoost;
    private int _slop;
    private RelatedNotesRequirement _requirement;

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

    public RelatedNotesFields Field
    {
      get
      {
        return _field;
      }
      set
      {
        __isset.field = true;
        this._field = value;
      }
    }

    public double ScoreBoost
    {
      get
      {
        return _scoreBoost;
      }
      set
      {
        __isset.scoreBoost = true;
        this._scoreBoost = value;
      }
    }

    public int Slop
    {
      get
      {
        return _slop;
      }
      set
      {
        __isset.slop = true;
        this._slop = value;
      }
    }

    public RelatedNotesRequirement Requirement
    {
      get
      {
        return _requirement;
      }
      set
      {
        __isset.requirement = true;
        this._requirement = value;
      }
    }


    public Isset __isset;
    #if !NETFX_CORE
    [Serializable]
    #endif
    public struct Isset {
      public bool text;
      public bool field;
      public bool scoreBoost;
      public bool slop;
      public bool requirement;
    }

    public RelatedNotesTerms() {
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
          case 2:
            if (field.Type == TType.I32) {
              Field = (RelatedNotesFields)iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Double) {
              ScoreBoost = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.I32) {
              Slop = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.I32) {
              Requirement = (RelatedNotesRequirement)iprot.ReadI32();
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
      TStruct struc = new TStruct("RelatedNotesTerms");
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
      if (__isset.field) {
        field.Name = "field";
        field.Type = TType.I32;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32((int)Field);
        oprot.WriteFieldEnd();
      }
      if (__isset.scoreBoost) {
        field.Name = "scoreBoost";
        field.Type = TType.Double;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(ScoreBoost);
        oprot.WriteFieldEnd();
      }
      if (__isset.slop) {
        field.Name = "slop";
        field.Type = TType.I32;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Slop);
        oprot.WriteFieldEnd();
      }
      if (__isset.requirement) {
        field.Name = "requirement";
        field.Type = TType.I32;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32((int)Requirement);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("RelatedNotesTerms(");
      sb.Append("Text: ");
      sb.Append(Text);
      sb.Append(",Field: ");
      sb.Append(Field);
      sb.Append(",ScoreBoost: ");
      sb.Append(ScoreBoost);
      sb.Append(",Slop: ");
      sb.Append(Slop);
      sb.Append(",Requirement: ");
      sb.Append(Requirement);
      sb.Append(")");
      return sb.ToString();
    }

  }

}