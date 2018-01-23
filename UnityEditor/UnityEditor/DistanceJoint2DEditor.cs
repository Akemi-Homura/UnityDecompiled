﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.DistanceJoint2DEditor
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using UnityEngine;

namespace UnityEditor
{
  [CanEditMultipleObjects]
  [CustomEditor(typeof (DistanceJoint2D))]
  internal class DistanceJoint2DEditor : AnchoredJoint2DEditor
  {
    public new void OnSceneGUI()
    {
      DistanceJoint2D target = (DistanceJoint2D) this.target;
      if (!target.enabled)
        return;
      Vector3 anchor = Joint2DEditor.TransformPoint(target.transform, (Vector3) target.anchor);
      Vector3 vector3 = (Vector3) target.connectedAnchor;
      if ((bool) ((Object) target.connectedBody))
        vector3 = Joint2DEditor.TransformPoint(target.connectedBody.transform, vector3);
      Joint2DEditor.DrawDistanceGizmo(anchor, vector3, target.distance);
      base.OnSceneGUI();
    }
  }
}
