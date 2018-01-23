﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.UI.LayoutElementEditor
// Assembly: UnityEditor.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDF3271B-B3CA-41C7-8FD7-FD00990E91BF
// Assembly location: C:\Program Files\Unity 5\Editor\Data\UnityExtensions\Unity\GUISystem\Editor\UnityEditor.UI.dll

using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityEditor.UI
{
  /// <summary>
  ///   <para>Editor for the LayoutElement component.</para>
  /// </summary>
  [CustomEditor(typeof (LayoutElement), true)]
  [CanEditMultipleObjects]
  public class LayoutElementEditor : Editor
  {
    private SerializedProperty m_IgnoreLayout;
    private SerializedProperty m_MinWidth;
    private SerializedProperty m_MinHeight;
    private SerializedProperty m_PreferredWidth;
    private SerializedProperty m_PreferredHeight;
    private SerializedProperty m_FlexibleWidth;
    private SerializedProperty m_FlexibleHeight;
    private SerializedProperty m_LayoutPriority;

    protected virtual void OnEnable()
    {
      this.m_IgnoreLayout = this.serializedObject.FindProperty("m_IgnoreLayout");
      this.m_MinWidth = this.serializedObject.FindProperty("m_MinWidth");
      this.m_MinHeight = this.serializedObject.FindProperty("m_MinHeight");
      this.m_PreferredWidth = this.serializedObject.FindProperty("m_PreferredWidth");
      this.m_PreferredHeight = this.serializedObject.FindProperty("m_PreferredHeight");
      this.m_FlexibleWidth = this.serializedObject.FindProperty("m_FlexibleWidth");
      this.m_FlexibleHeight = this.serializedObject.FindProperty("m_FlexibleHeight");
      this.m_LayoutPriority = this.serializedObject.FindProperty("m_LayoutPriority");
    }

    /// <summary>
    ///   <para>See: Editor.OnInspectorGUI.</para>
    /// </summary>
    public override void OnInspectorGUI()
    {
      this.serializedObject.Update();
      EditorGUILayout.PropertyField(this.m_IgnoreLayout);
      if (!this.m_IgnoreLayout.boolValue)
      {
        EditorGUILayout.Space();
        this.LayoutElementField(this.m_MinWidth, 0.0f);
        this.LayoutElementField(this.m_MinHeight, 0.0f);
        this.LayoutElementField(this.m_PreferredWidth, (Func<RectTransform, float>) (t => t.rect.width));
        this.LayoutElementField(this.m_PreferredHeight, (Func<RectTransform, float>) (t => t.rect.height));
        this.LayoutElementField(this.m_FlexibleWidth, 1f);
        this.LayoutElementField(this.m_FlexibleHeight, 1f);
      }
      EditorGUILayout.PropertyField(this.m_LayoutPriority);
      this.serializedObject.ApplyModifiedProperties();
    }

    private void LayoutElementField(SerializedProperty property, float defaultValue)
    {
      this.LayoutElementField(property, (Func<RectTransform, float>) (_ => defaultValue));
    }

    private void LayoutElementField(SerializedProperty property, Func<RectTransform, float> defaultValue)
    {
      Rect controlRect = EditorGUILayout.GetControlRect();
      GUIContent label = EditorGUI.BeginProperty(controlRect, (GUIContent) null, property);
      Rect rect = EditorGUI.PrefixLabel(controlRect, label);
      Rect position1 = rect;
      position1.width = 16f;
      Rect position2 = rect;
      position2.xMin += 16f;
      EditorGUI.BeginChangeCheck();
      bool flag = EditorGUI.ToggleLeft(position1, GUIContent.none, (double) property.floatValue >= 0.0);
      if (EditorGUI.EndChangeCheck())
        property.floatValue = !flag ? -1f : defaultValue((this.target as LayoutElement).transform as RectTransform);
      if (!property.hasMultipleDifferentValues && (double) property.floatValue >= 0.0)
      {
        EditorGUIUtility.labelWidth = 4f;
        EditorGUI.BeginChangeCheck();
        float b = EditorGUI.FloatField(position2, new GUIContent(" "), property.floatValue);
        if (EditorGUI.EndChangeCheck())
          property.floatValue = Mathf.Max(0.0f, b);
        EditorGUIUtility.labelWidth = 0.0f;
      }
      EditorGUI.EndProperty();
    }
  }
}
