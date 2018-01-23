﻿// Decompiled with JetBrains decompiler
// Type: UnityEditorInternal.JSONParser
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace UnityEditorInternal
{
  internal class JSONParser
  {
    private static char[] endcodes = new char[2]{ '\\', '"' };
    private string json;
    private int line;
    private int linechar;
    private int len;
    private int idx;
    private int pctParsed;
    private char cur;

    public JSONParser(string jsondata)
    {
      this.json = jsondata + "    ";
      this.line = 1;
      this.linechar = 1;
      this.len = this.json.Length;
      this.idx = 0;
      this.pctParsed = 0;
    }

    public static JSONValue SimpleParse(string jsondata)
    {
      JSONParser jsonParser = new JSONParser(jsondata);
      try
      {
        return jsonParser.Parse();
      }
      catch (JSONParseException ex)
      {
        Debug.LogError((object) ex.Message);
      }
      return new JSONValue((object) null);
    }

    public JSONValue Parse()
    {
      this.cur = this.json[this.idx];
      return this.ParseValue();
    }

    private char Next()
    {
      if ((int) this.cur == 10)
      {
        ++this.line;
        this.linechar = 0;
      }
      ++this.idx;
      if (this.idx >= this.len)
        throw new JSONParseException("End of json while parsing at " + this.PosMsg());
      ++this.linechar;
      int num = (int) ((double) this.idx * 100.0 / (double) this.len);
      if (num != this.pctParsed)
        this.pctParsed = num;
      this.cur = this.json[this.idx];
      return this.cur;
    }

    private void SkipWs()
    {
      string str = " \n\t\r";
      while (str.IndexOf(this.cur) != -1)
      {
        int num = (int) this.Next();
      }
    }

    private string PosMsg()
    {
      return "line " + this.line.ToString() + ", column " + this.linechar.ToString();
    }

    private JSONValue ParseValue()
    {
      this.SkipWs();
      char cur = this.cur;
      switch (cur)
      {
        case '-':
        case '0':
        case '1':
        case '2':
        case '3':
        case '4':
        case '5':
        case '6':
        case '7':
        case '8':
        case '9':
          return this.ParseNumber();
        default:
          if ((int) cur == 34)
            return this.ParseString();
          if ((int) cur == 91)
            return this.ParseArray();
          if ((int) cur == 102 || (int) cur == 110 || (int) cur == 116)
            return this.ParseConstant();
          if ((int) cur == 123)
            return this.ParseDict();
          throw new JSONParseException("Cannot parse json value starting with '" + this.json.Substring(this.idx, 5) + "' at " + this.PosMsg());
      }
    }

    private JSONValue ParseArray()
    {
      int num1 = (int) this.Next();
      this.SkipWs();
      List<JSONValue> jsonValueList = new List<JSONValue>();
      while ((int) this.cur != 93)
      {
        jsonValueList.Add(this.ParseValue());
        this.SkipWs();
        if ((int) this.cur == 44)
        {
          int num2 = (int) this.Next();
          this.SkipWs();
        }
      }
      int num3 = (int) this.Next();
      return new JSONValue((object) jsonValueList);
    }

    private JSONValue ParseDict()
    {
      int num1 = (int) this.Next();
      this.SkipWs();
      Dictionary<string, JSONValue> dictionary = new Dictionary<string, JSONValue>();
      while ((int) this.cur != 125)
      {
        JSONValue jsonValue = this.ParseValue();
        if (!jsonValue.IsString())
          throw new JSONParseException("Key not string type at " + this.PosMsg());
        this.SkipWs();
        if ((int) this.cur != 58)
          throw new JSONParseException("Missing dict entry delimiter ':' at " + this.PosMsg());
        int num2 = (int) this.Next();
        dictionary.Add(jsonValue.AsString(), this.ParseValue());
        this.SkipWs();
        if ((int) this.cur == 44)
        {
          int num3 = (int) this.Next();
          this.SkipWs();
        }
      }
      int num4 = (int) this.Next();
      return new JSONValue((object) dictionary);
    }

    private JSONValue ParseString()
    {
      string str1 = "";
      int num1 = (int) this.Next();
      int index1;
      for (; this.idx < this.len; this.idx = index1 + 1)
      {
        int index2 = this.json.IndexOfAny(JSONParser.endcodes, this.idx);
        if (index2 < 0)
          throw new JSONParseException("missing '\"' to end string at " + this.PosMsg());
        str1 += this.json.Substring(this.idx, index2 - this.idx);
        if ((int) this.json[index2] == 34)
        {
          this.cur = this.json[index2];
          this.idx = index2;
          break;
        }
        index1 = index2 + 1;
        if (index1 >= this.len)
          throw new JSONParseException("End of json while parsing while parsing string at " + this.PosMsg());
        char ch = this.json[index1];
        switch (ch)
        {
          case 'r':
            str1 += (string) (object) '\r';
            break;
          case 't':
            str1 += (string) (object) '\t';
            break;
          case 'u':
            string str2 = "";
            if (index1 + 4 >= this.len)
              throw new JSONParseException("End of json while parsing while parsing unicode char near " + this.PosMsg());
            string s = str2 + (object) this.json[index1 + 1] + (object) this.json[index1 + 2] + (object) this.json[index1 + 3] + (object) this.json[index1 + 4];
            try
            {
              int num2 = int.Parse(s, NumberStyles.AllowHexSpecifier);
              str1 += (string) (object) (char) num2;
            }
            catch (FormatException ex)
            {
              throw new JSONParseException("Invalid unicode escape char near " + this.PosMsg());
            }
            index1 += 4;
            break;
          default:
            if ((int) ch != 34 && (int) ch != 47 && (int) ch != 92)
            {
              switch (ch)
              {
                case 'b':
                  str1 += (string) (object) '\b';
                  continue;
                case 'f':
                  str1 += (string) (object) '\f';
                  continue;
                case 'n':
                  str1 += (string) (object) '\n';
                  continue;
                default:
                  throw new JSONParseException("Invalid escape char '" + (object) ch + "' near " + this.PosMsg());
              }
            }
            else
            {
              str1 += (string) (object) ch;
              break;
            }
        }
      }
      if (this.idx >= this.len)
        throw new JSONParseException("End of json while parsing while parsing string near " + this.PosMsg());
      this.cur = this.json[this.idx];
      int num3 = (int) this.Next();
      return new JSONValue((object) str1);
    }

    private JSONValue ParseNumber()
    {
      string str = "";
      if ((int) this.cur == 45)
      {
        str = "-";
        int num = (int) this.Next();
      }
      while ((int) this.cur >= 48 && (int) this.cur <= 57)
      {
        str += (string) (object) this.cur;
        int num = (int) this.Next();
      }
      if ((int) this.cur == 46)
      {
        int num1 = (int) this.Next();
        str += (string) (object) '.';
        while ((int) this.cur >= 48 && (int) this.cur <= 57)
        {
          str += (string) (object) this.cur;
          int num2 = (int) this.Next();
        }
      }
      if ((int) this.cur != 101)
      {
        if ((int) this.cur != 69)
          goto label_14;
      }
      str += "e";
      int num3 = (int) this.Next();
      if ((int) this.cur != 45 && (int) this.cur != 43)
      {
        str += (string) (object) this.cur;
        int num1 = (int) this.Next();
      }
      while ((int) this.cur >= 48 && (int) this.cur <= 57)
      {
        str += (string) (object) this.cur;
        int num1 = (int) this.Next();
      }
label_14:
      try
      {
        return new JSONValue((object) Convert.ToSingle(str));
      }
      catch (Exception ex)
      {
        throw new JSONParseException("Cannot convert string to float : '" + str + "' at " + this.PosMsg());
      }
    }

    private JSONValue ParseConstant()
    {
      string str = "" + (object) this.cur + (object) this.Next() + (object) this.Next() + (object) this.Next();
      int num1 = (int) this.Next();
      if (str == "true")
        return new JSONValue((object) true);
      if (str == "fals")
      {
        if ((int) this.cur == 101)
        {
          int num2 = (int) this.Next();
          return new JSONValue((object) false);
        }
      }
      else if (str == "null")
        return new JSONValue((object) null);
      throw new JSONParseException("Invalid token at " + this.PosMsg());
    }
  }
}
