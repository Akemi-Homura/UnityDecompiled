﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.DrawGizmo
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System;

namespace UnityEditor
{
  /// <summary>
  ///   <para>The DrawGizmo attribute allows you to supply a gizmo renderer for any Component.</para>
  /// </summary>
  public sealed class DrawGizmo : Attribute
  {
    public System.Type drawnType;
    public GizmoType drawOptions;

    /// <summary>
    ///   <para>Defines when the gizmo should be invoked for drawing.</para>
    /// </summary>
    /// <param name="gizmo">Flags to denote when the gizmo should be drawn.</param>
    public DrawGizmo(GizmoType gizmo)
    {
      this.drawOptions = gizmo;
    }

    /// <summary>
    ///   <para>Same as above. drawnGizmoType determines of what type the object we are drawing the gizmo of has to be.</para>
    /// </summary>
    /// <param name="gizmo">Flags to denote when the gizmo should be drawn.</param>
    /// <param name="drawnGizmoType">Type of object for which the gizmo should be drawn.</param>
    public DrawGizmo(GizmoType gizmo, System.Type drawnGizmoType)
    {
      this.drawnType = drawnGizmoType;
      this.drawOptions = gizmo;
    }
  }
}
