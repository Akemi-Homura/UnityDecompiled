﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.TextAssetInspector
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System;
using UnityEngine;

namespace UnityEditor
{
  [CustomEditor(typeof (TextAsset))]
  [CanEditMultipleObjects]
  internal class TextAssetInspector : Editor
  {
    private const int kMaxChars = 7000;
    [NonSerialized]
    private GUIStyle m_TextStyle;

    public override void OnInspectorGUI()
    {
      if (this.m_TextStyle == null)
        this.m_TextStyle = (GUIStyle) "ScriptText";
      bool enabled = GUI.enabled;
      GUI.enabled = true;
      TextAsset target = this.target as TextAsset;
      if ((UnityEngine.Object) target != (UnityEngine.Object) null)
      {
        string str;
        if (this.targets.Length > 1)
        {
          str = this.targetTitle;
        }
        else
        {
          str = target.ToString();
          if (str.Length > 7000)
            str = str.Substring(0, 7000) + "...\n\n<...etc...>";
        }
        Rect rect = GUILayoutUtility.GetRect(EditorGUIUtility.TempContent(str), this.m_TextStyle);
        rect.x = 0.0f;
        rect.y -= 3f;
        rect.width = GUIClip.visibleRect.width + 1f;
        GUI.Box(rect, str, this.m_TextStyle);
      }
      GUI.enabled = enabled;
    }
  }
}
