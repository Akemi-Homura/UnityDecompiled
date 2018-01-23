﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.AnimationClipCurveData
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace UnityEditor
{
  /// <summary>
  ///   <para>An AnimationClipCurveData object contains all the information needed to identify a specific curve in an AnimationClip. The curve animates a specific property of a component  material attached to a game object  animated bone.</para>
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public sealed class AnimationClipCurveData
  {
    /// <summary>
    ///   <para>The path of the game object / bone being animated.</para>
    /// </summary>
    public string path;
    /// <summary>
    ///   <para>The type of the component / material being animated.</para>
    /// </summary>
    public System.Type type;
    /// <summary>
    ///   <para>The name of the property being animated.</para>
    /// </summary>
    public string propertyName;
    /// <summary>
    ///   <para>The actual animation curve.</para>
    /// </summary>
    public AnimationCurve curve;
    internal int classID;
    internal int scriptInstanceID;

    public AnimationClipCurveData()
    {
    }

    public AnimationClipCurveData(EditorCurveBinding binding)
    {
      this.path = binding.path;
      this.type = binding.type;
      this.propertyName = binding.propertyName;
      this.curve = (AnimationCurve) null;
      this.classID = binding.m_ClassID;
      this.scriptInstanceID = binding.m_ScriptInstanceID;
    }
  }
}
