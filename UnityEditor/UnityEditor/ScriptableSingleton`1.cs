﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.ScriptableSingleton`1
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System.IO;
using UnityEditorInternal;
using UnityEngine;

namespace UnityEditor
{
  public class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject
  {
    private static T s_Instance;

    protected ScriptableSingleton()
    {
      if ((Object) ScriptableSingleton<T>.s_Instance != (Object) null)
        Debug.LogError((object) "ScriptableSingleton already exists. Did you query the singleton in a constructor?");
      else
        ScriptableSingleton<T>.s_Instance = (object) this as T;
    }

    public static T instance
    {
      get
      {
        if ((Object) ScriptableSingleton<T>.s_Instance == (Object) null)
          ScriptableSingleton<T>.CreateAndLoad();
        return ScriptableSingleton<T>.s_Instance;
      }
    }

    private static void CreateAndLoad()
    {
      string filePath = ScriptableSingleton<T>.GetFilePath();
      if (!string.IsNullOrEmpty(filePath))
        InternalEditorUtility.LoadSerializedFileAndForget(filePath);
      if (!((Object) ScriptableSingleton<T>.s_Instance == (Object) null))
        return;
      ScriptableObject.CreateInstance<T>().hideFlags = HideFlags.HideAndDontSave;
    }

    protected virtual void Save(bool saveAsText)
    {
      if ((Object) ScriptableSingleton<T>.s_Instance == (Object) null)
      {
        Debug.Log((object) "Cannot save ScriptableSingleton: no instance!");
      }
      else
      {
        string filePath = ScriptableSingleton<T>.GetFilePath();
        if (string.IsNullOrEmpty(filePath))
          return;
        string directoryName = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directoryName))
          Directory.CreateDirectory(directoryName);
        InternalEditorUtility.SaveToSerializedFileAndForget((Object[]) new T[1]
        {
          ScriptableSingleton<T>.s_Instance
        }, filePath, saveAsText);
      }
    }

    private static string GetFilePath()
    {
      foreach (object customAttribute in typeof (T).GetCustomAttributes(true))
      {
        if (customAttribute is FilePathAttribute)
          return (customAttribute as FilePathAttribute).filepath;
      }
      return (string) null;
    }
  }
}
