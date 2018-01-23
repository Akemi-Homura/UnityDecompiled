﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.AI.NavMeshPath
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.AI
{
  /// <summary>
  ///   <para>A path as calculated by the navigation system.</para>
  /// </summary>
  [MovedFrom("UnityEngine")]
  [StructLayout(LayoutKind.Sequential)]
  public sealed class NavMeshPath
  {
    internal IntPtr m_Ptr;
    internal Vector3[] m_corners;

    /// <summary>
    ///   <para>NavMeshPath constructor.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern NavMeshPath();

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void DestroyNavMeshPath();

    ~NavMeshPath()
    {
      this.DestroyNavMeshPath();
      this.m_Ptr = IntPtr.Zero;
    }

    /// <summary>
    ///   <para>Calculate the corners for the path.</para>
    /// </summary>
    /// <param name="results">Array to store path corners.</param>
    /// <returns>
    ///   <para>The number of corners along the path - including start and end points.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int GetCornersNonAlloc(Vector3[] results);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern Vector3[] CalculateCornersInternal();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void ClearCornersInternal();

    /// <summary>
    ///   <para>Erase all corner points from path.</para>
    /// </summary>
    public void ClearCorners()
    {
      this.ClearCornersInternal();
      this.m_corners = (Vector3[]) null;
    }

    private void CalculateCorners()
    {
      if (this.m_corners != null)
        return;
      this.m_corners = this.CalculateCornersInternal();
    }

    /// <summary>
    ///   <para>Corner points of the path. (Read Only)</para>
    /// </summary>
    public Vector3[] corners
    {
      get
      {
        this.CalculateCorners();
        return this.m_corners;
      }
    }

    /// <summary>
    ///   <para>Status of the path. (Read Only)</para>
    /// </summary>
    public extern NavMeshPathStatus status { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }
  }
}
