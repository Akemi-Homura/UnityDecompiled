﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.OcclusionAreaEditor
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using UnityEngine;

namespace UnityEditor
{
  [CustomEditor(typeof (OcclusionArea))]
  internal class OcclusionAreaEditor : Editor
  {
    private SerializedObject m_Object;
    private SerializedProperty m_Size;
    private SerializedProperty m_Center;

    private void OnEnable()
    {
      this.m_Object = new SerializedObject(this.target);
      this.m_Size = this.serializedObject.FindProperty("m_Size");
      this.m_Center = this.serializedObject.FindProperty("m_Center");
    }

    private void OnDisable()
    {
      this.m_Object.Dispose();
      this.m_Object = (SerializedObject) null;
    }

    private void OnSceneGUI()
    {
      this.m_Object.Update();
      OcclusionArea target = (OcclusionArea) this.target;
      Color color = Handles.color;
      Handles.color = new Color(145f, 244f, 139f, (float) byte.MaxValue) / (float) byte.MaxValue;
      Vector3 p = target.transform.TransformPoint(this.m_Center.vector3Value);
      Vector3 a1 = this.m_Size.vector3Value * 0.5f;
      Vector3 a2 = this.m_Size.vector3Value * 0.5f;
      Vector3 lossyScale = target.transform.lossyScale;
      Vector3 b = new Vector3(1f / lossyScale.x, 1f / lossyScale.y, 1f / lossyScale.z);
      Vector3 a3 = Vector3.Scale(a1, lossyScale);
      Vector3 a4 = Vector3.Scale(a2, lossyScale);
      bool changed = GUI.changed;
      a3.x = this.SizeSlider(p, -Vector3.right, a3.x);
      a3.y = this.SizeSlider(p, -Vector3.up, a3.y);
      a3.z = this.SizeSlider(p, -Vector3.forward, a3.z);
      a4.x = this.SizeSlider(p, Vector3.right, a4.x);
      a4.y = this.SizeSlider(p, Vector3.up, a4.y);
      a4.z = this.SizeSlider(p, Vector3.forward, a4.z);
      if (GUI.changed)
      {
        this.m_Center.vector3Value += Vector3.Scale(Quaternion.Inverse(target.transform.rotation) * (a4 - a3) * 0.5f, b);
        Vector3 vector3 = Vector3.Scale(a3, b);
        this.m_Size.vector3Value = Vector3.Scale(a4, b) + vector3;
        this.serializedObject.ApplyModifiedProperties();
      }
      GUI.changed |= changed;
      Handles.color = color;
    }

    private float SizeSlider(Vector3 p, Vector3 d, float r)
    {
      Vector3 position1 = p + d * r;
      Color color = Handles.color;
      if ((double) Vector3.Dot(position1 - Camera.current.transform.position, d) >= 0.0)
        Handles.color = new Color(Handles.color.r, Handles.color.g, Handles.color.b, Handles.color.a * Handles.backfaceAlphaMultiplier);
      float handleSize = HandleUtility.GetHandleSize(position1);
      bool changed = GUI.changed;
      GUI.changed = false;
      Vector3 position2 = position1;
      Vector3 direction = d;
      double num1 = (double) handleSize * 0.100000001490116;
      // ISSUE: reference to a compiler-generated field
      if (OcclusionAreaEditor.\u003C\u003Ef__mg\u0024cache0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        OcclusionAreaEditor.\u003C\u003Ef__mg\u0024cache0 = new Handles.CapFunction(Handles.CylinderHandleCap);
      }
      // ISSUE: reference to a compiler-generated field
      Handles.CapFunction fMgCache0 = OcclusionAreaEditor.\u003C\u003Ef__mg\u0024cache0;
      double num2 = 0.0;
      Vector3 vector3 = Handles.Slider(position2, direction, (float) num1, fMgCache0, (float) num2);
      if (GUI.changed)
        r = Vector3.Dot(vector3 - p, d);
      GUI.changed |= changed;
      Handles.color = color;
      return r;
    }
  }
}
