﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.RelativeJoint2DEditor
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using UnityEngine;

namespace UnityEditor
{
  [CanEditMultipleObjects]
  [CustomEditor(typeof (RelativeJoint2D))]
  internal class RelativeJoint2DEditor : Joint2DEditor
  {
    public void OnSceneGUI()
    {
      RelativeJoint2D target1 = (RelativeJoint2D) this.target;
      if (!target1.enabled)
        return;
      Vector3 target2 = (Vector3) target1.target;
      Vector3 vector3_1 = !(bool) ((Object) target1.connectedBody) ? Vector3.zero : target1.connectedBody.transform.position;
      Handles.color = Color.green;
      Joint2DEditor.DrawAALine(target2, vector3_1);
      float num1 = HandleUtility.GetHandleSize(vector3_1) * 0.16f;
      Vector3 vector3_2 = Vector3.left * num1;
      Vector3 vector3_3 = Vector3.up * num1;
      Joint2DEditor.DrawAALine(vector3_1 - vector3_2, vector3_1 + vector3_2);
      Joint2DEditor.DrawAALine(vector3_1 - vector3_3, vector3_1 + vector3_3);
      float num2 = HandleUtility.GetHandleSize(target2) * 0.16f;
      Vector3 vector3_4 = Vector3.left * num2;
      Vector3 vector3_5 = Vector3.up * num2;
      Joint2DEditor.DrawAALine(target2 - vector3_4, target2 + vector3_4);
      Joint2DEditor.DrawAALine(target2 - vector3_5, target2 + vector3_5);
    }
  }
}
