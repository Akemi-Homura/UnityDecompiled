﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.SkinnedMeshRenderer
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>The Skinned Mesh filter.</para>
  /// </summary>
  public class SkinnedMeshRenderer : Renderer
  {
    /// <summary>
    ///   <para>The bones used to skin the mesh.</para>
    /// </summary>
    public extern Transform[] bones { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The maximum number of bones affecting a single vertex.</para>
    /// </summary>
    public extern SkinQuality quality { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>If enabled, the Skinned Mesh will be updated when offscreen. If disabled, this also disables updating animations.</para>
    /// </summary>
    public extern bool updateWhenOffscreen { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    public extern Transform rootBone { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    internal extern Transform actualRootBone { [MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The mesh used for skinning.</para>
    /// </summary>
    public extern Mesh sharedMesh { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Specifies whether skinned motion vectors should be used for this renderer.</para>
    /// </summary>
    public extern bool skinnedMotionVectors { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Returns weight of BlendShape on this renderer.</para>
    /// </summary>
    /// <param name="index"></param>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern float GetBlendShapeWeight(int index);

    /// <summary>
    ///   <para>Sets the weight in percent of a BlendShape on this Renderer.</para>
    /// </summary>
    /// <param name="index">The index of the BlendShape to modify.</param>
    /// <param name="value">The weight in percent for this BlendShape.</param>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetBlendShapeWeight(int index, float value);

    /// <summary>
    ///   <para>Creates a snapshot of SkinnedMeshRenderer and stores it in mesh.</para>
    /// </summary>
    /// <param name="mesh">A static mesh that will receive the snapshot of the skinned mesh.</param>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void BakeMesh(Mesh mesh);

    private Bounds GetLocalAABB()
    {
      Bounds ret;
      this.GetLocalAABB_Injected(out ret);
      return ret;
    }

    private void SetLocalAABB(Bounds b)
    {
      this.SetLocalAABB_Injected(ref b);
    }

    /// <summary>
    ///   <para>AABB of this Skinned Mesh in its local space.</para>
    /// </summary>
    public Bounds localBounds
    {
      get
      {
        return this.GetLocalAABB();
      }
      set
      {
        this.SetLocalAABB(value);
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void GetLocalAABB_Injected(out Bounds ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetLocalAABB_Injected(ref Bounds b);
  }
}
