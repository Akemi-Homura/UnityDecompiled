﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.MaterialPropertyDrawer
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using UnityEngine;

namespace UnityEditor
{
  /// <summary>
  ///   <para>Base class to derive custom material property drawers from.</para>
  /// </summary>
  public abstract class MaterialPropertyDrawer
  {
    public virtual void OnGUI(Rect position, MaterialProperty prop, GUIContent label, MaterialEditor editor)
    {
      this.OnGUI(position, prop, label.text, editor);
    }

    /// <summary>
    ///   <para>Override this method to make your own GUI for the property.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the property GUI.</param>
    /// <param name="prop">The MaterialProperty to make the custom GUI for.</param>
    /// <param name="label">The label of this property.</param>
    /// <param name="editor">Current material editor.</param>
    public virtual void OnGUI(Rect position, MaterialProperty prop, string label, MaterialEditor editor)
    {
      EditorGUI.LabelField(position, new GUIContent(label), EditorGUIUtility.TempContent("No GUI Implemented"));
    }

    /// <summary>
    ///   <para>Override this method to specify how tall the GUI for this property is in pixels.</para>
    /// </summary>
    /// <param name="prop">The MaterialProperty to make the custom GUI for.</param>
    /// <param name="label">The label of this property.</param>
    /// <param name="editor">Current material editor.</param>
    public virtual float GetPropertyHeight(MaterialProperty prop, string label, MaterialEditor editor)
    {
      return 16f;
    }

    /// <summary>
    ///   <para>Apply extra initial values to the material.</para>
    /// </summary>
    /// <param name="prop">The MaterialProperty to apply values for.</param>
    public virtual void Apply(MaterialProperty prop)
    {
    }
  }
}
