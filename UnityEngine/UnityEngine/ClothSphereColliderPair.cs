﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.ClothSphereColliderPair
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>A pair of SphereColliders used to define shapes for Cloth objects to collide against.</para>
  /// </summary>
  [UsedByNativeCode]
  public struct ClothSphereColliderPair
  {
    private SphereCollider m_First;
    private SphereCollider m_Second;

    /// <summary>
    ///   <para>Creates a ClothSphereColliderPair. If only one SphereCollider is given, the ClothSphereColliderPair will define a simple sphere. If two SphereColliders are given, the ClothSphereColliderPair defines a conic capsule shape, composed of the two spheres and the cone connecting the two.</para>
    /// </summary>
    /// <param name="a">The first SphereCollider of a ClothSphereColliderPair.</param>
    /// <param name="b">The second SphereCollider of a ClothSphereColliderPair.</param>
    public ClothSphereColliderPair(SphereCollider a)
    {
      this.m_First = (SphereCollider) null;
      this.m_Second = (SphereCollider) null;
      this.first = a;
      this.second = (SphereCollider) null;
    }

    /// <summary>
    ///   <para>Creates a ClothSphereColliderPair. If only one SphereCollider is given, the ClothSphereColliderPair will define a simple sphere. If two SphereColliders are given, the ClothSphereColliderPair defines a conic capsule shape, composed of the two spheres and the cone connecting the two.</para>
    /// </summary>
    /// <param name="a">The first SphereCollider of a ClothSphereColliderPair.</param>
    /// <param name="b">The second SphereCollider of a ClothSphereColliderPair.</param>
    public ClothSphereColliderPair(SphereCollider a, SphereCollider b)
    {
      this.m_First = (SphereCollider) null;
      this.m_Second = (SphereCollider) null;
      this.first = a;
      this.second = b;
    }

    /// <summary>
    ///   <para>The first SphereCollider of a ClothSphereColliderPair.</para>
    /// </summary>
    public SphereCollider first
    {
      get
      {
        return this.m_First;
      }
      set
      {
        this.m_First = value;
      }
    }

    /// <summary>
    ///   <para>The second SphereCollider of a ClothSphereColliderPair.</para>
    /// </summary>
    public SphereCollider second
    {
      get
      {
        return this.m_Second;
      }
      set
      {
        this.m_Second = value;
      }
    }
  }
}
