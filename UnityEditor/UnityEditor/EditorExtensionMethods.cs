﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.EditorExtensionMethods
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityEditor
{
  internal static class EditorExtensionMethods
  {
    internal static bool MainActionKeyForControl(this Event evt, int controlId)
    {
      if (GUIUtility.keyboardControl != controlId)
        return false;
      bool flag = evt.alt || evt.shift || evt.command || evt.control;
      if (evt.type != EventType.KeyDown || (int) evt.character != 32 || flag)
        return evt.type == EventType.KeyDown && (evt.keyCode == KeyCode.Space || evt.keyCode == KeyCode.Return || evt.keyCode == KeyCode.KeypadEnter) && !flag;
      evt.Use();
      return false;
    }

    internal static bool IsArrayOrList(this System.Type listType)
    {
      return listType.IsArray || listType.IsGenericType && listType.GetGenericTypeDefinition() == typeof (List<>);
    }

    internal static System.Type GetArrayOrListElementType(this System.Type listType)
    {
      if (listType.IsArray)
        return listType.GetElementType();
      if (listType.IsGenericType && listType.GetGenericTypeDefinition() == typeof (List<>))
        return listType.GetGenericArguments()[0];
      return (System.Type) null;
    }

    internal static List<Enum> EnumGetNonObsoleteValues(this System.Type type)
    {
      string[] names = Enum.GetNames(type);
      Enum[] array = Enum.GetValues(type).Cast<Enum>().ToArray<Enum>();
      List<Enum> enumList = new List<Enum>();
      for (int index = 0; index < names.Length; ++index)
      {
        object[] customAttributes = type.GetMember(names[index])[0].GetCustomAttributes(typeof (ObsoleteAttribute), false);
        bool flag = false;
        foreach (object obj in customAttributes)
        {
          if (obj is ObsoleteAttribute)
            flag = true;
        }
        if (!flag)
          enumList.Add(array[index]);
      }
      return enumList;
    }
  }
}
