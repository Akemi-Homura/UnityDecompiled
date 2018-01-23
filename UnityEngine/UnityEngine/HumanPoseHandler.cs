﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.HumanPoseHandler
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>A handler that lets you read or write a HumanPose from or to a humanoid avatar skeleton hierarchy.</para>
  /// </summary>
  public sealed class HumanPoseHandler : IDisposable
  {
    internal IntPtr m_Ptr;

    /// <summary>
    ///   <para>Creates a human pose handler from an avatar and a root transform.</para>
    /// </summary>
    /// <param name="avatar">The avatar that defines the humanoid rig on skeleton hierarchy with root as the top most parent.</param>
    /// <param name="root">The top most node of the skeleton hierarchy defined in humanoid avatar.</param>
    public HumanPoseHandler(Avatar avatar, Transform root)
    {
      this.m_Ptr = IntPtr.Zero;
      if ((Object) root == (Object) null)
        throw new ArgumentNullException("HumanPoseHandler root Transform is null");
      if ((Object) avatar == (Object) null)
        throw new ArgumentNullException("HumanPoseHandler avatar is null");
      if (!avatar.isValid)
        throw new ArgumentException("HumanPoseHandler avatar is invalid");
      if (!avatar.isHuman)
        throw new ArgumentException("HumanPoseHandler avatar is not human");
      this.Internal_HumanPoseHandler(avatar, root);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void Dispose();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void Internal_HumanPoseHandler(Avatar avatar, Transform root);

    private bool Internal_GetHumanPose(ref Vector3 bodyPosition, ref Quaternion bodyRotation, float[] muscles)
    {
      return HumanPoseHandler.INTERNAL_CALL_Internal_GetHumanPose(this, ref bodyPosition, ref bodyRotation, muscles);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool INTERNAL_CALL_Internal_GetHumanPose(HumanPoseHandler self, ref Vector3 bodyPosition, ref Quaternion bodyRotation, float[] muscles);

    public void GetHumanPose(ref HumanPose humanPose)
    {
      humanPose.Init();
      if (this.Internal_GetHumanPose(ref humanPose.bodyPosition, ref humanPose.bodyRotation, humanPose.muscles))
        return;
      Debug.LogWarning((object) "HumanPoseHandler is not initialized properly");
    }

    private bool Internal_SetHumanPose(ref Vector3 bodyPosition, ref Quaternion bodyRotation, float[] muscles)
    {
      return HumanPoseHandler.INTERNAL_CALL_Internal_SetHumanPose(this, ref bodyPosition, ref bodyRotation, muscles);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool INTERNAL_CALL_Internal_SetHumanPose(HumanPoseHandler self, ref Vector3 bodyPosition, ref Quaternion bodyRotation, float[] muscles);

    public void SetHumanPose(ref HumanPose humanPose)
    {
      humanPose.Init();
      if (this.Internal_SetHumanPose(ref humanPose.bodyPosition, ref humanPose.bodyRotation, humanPose.muscles))
        return;
      Debug.LogWarning((object) "HumanPoseHandler is not initialized properly");
    }
  }
}
