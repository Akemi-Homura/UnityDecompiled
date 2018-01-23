﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.Animations.AnimationLayerMixerPlayable
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine.Playables;
using UnityEngine.Scripting;

namespace UnityEngine.Animations
{
  /// <summary>
  ///   <para>An implementation of IPlayable that controls an animation layer mixer.</para>
  /// </summary>
  [RequiredByNativeCode]
  public struct AnimationLayerMixerPlayable : IPlayable, IEquatable<AnimationLayerMixerPlayable>
  {
    private static readonly AnimationLayerMixerPlayable m_NullPlayable = new AnimationLayerMixerPlayable(PlayableHandle.Null);
    private PlayableHandle m_Handle;

    internal AnimationLayerMixerPlayable(PlayableHandle handle)
    {
      if (handle.IsValid() && !handle.IsPlayableOfType<AnimationLayerMixerPlayable>())
        throw new InvalidCastException("Can't set handle: the playable is not an AnimationLayerMixerPlayable.");
      this.m_Handle = handle;
    }

    /// <summary>
    ///   <para>Returns an invalid AnimationLayerMixerPlayable.</para>
    /// </summary>
    public static AnimationLayerMixerPlayable Null
    {
      get
      {
        return AnimationLayerMixerPlayable.m_NullPlayable;
      }
    }

    /// <summary>
    ///   <para>Creates an AnimationLayerMixerPlayable in the PlayableGraph.</para>
    /// </summary>
    /// <param name="graph">The PlayableGraph that will contain the new AnimationLayerMixerPlayable.</param>
    /// <param name="inputCount">The number of layers.</param>
    /// <returns>
    ///   <para>A new AnimationLayerMixerPlayable linked to the PlayableGraph.</para>
    /// </returns>
    public static AnimationLayerMixerPlayable Create(PlayableGraph graph, int inputCount = 0)
    {
      return new AnimationLayerMixerPlayable(AnimationLayerMixerPlayable.CreateHandle(graph, inputCount));
    }

    private static PlayableHandle CreateHandle(PlayableGraph graph, int inputCount = 0)
    {
      PlayableHandle handle = PlayableHandle.Null;
      if (!AnimationLayerMixerPlayable.CreateHandleInternal(graph, ref handle))
        return PlayableHandle.Null;
      handle.SetInputCount(inputCount);
      return handle;
    }

    public PlayableHandle GetHandle()
    {
      return this.m_Handle;
    }

    public static implicit operator Playable(AnimationLayerMixerPlayable playable)
    {
      return new Playable(playable.GetHandle());
    }

    public static explicit operator AnimationLayerMixerPlayable(Playable playable)
    {
      return new AnimationLayerMixerPlayable(playable.GetHandle());
    }

    public bool Equals(AnimationLayerMixerPlayable other)
    {
      return this.GetHandle() == other.GetHandle();
    }

    /// <summary>
    ///   <para>Returns true if the layer is additive, false otherwise.</para>
    /// </summary>
    /// <param name="layerIndex">The layer index.</param>
    /// <returns>
    ///   <para>True if the layer is additive, false otherwise.</para>
    /// </returns>
    public bool IsLayerAdditive(uint layerIndex)
    {
      if ((long) layerIndex >= (long) this.m_Handle.GetInputCount())
        throw new ArgumentOutOfRangeException(nameof (layerIndex), string.Format("layerIndex {0} must be in the range of 0 to {1}.", (object) layerIndex, (object) (this.m_Handle.GetInputCount() - 1)));
      return AnimationLayerMixerPlayable.IsLayerAdditiveInternal(ref this.m_Handle, layerIndex);
    }

    /// <summary>
    ///   <para>Specifies whether a layer is additive or not. Additive layers blend with previous layers.</para>
    /// </summary>
    /// <param name="layerIndex">The layer index.</param>
    /// <param name="value">Whether the layer is additive or not. Set to true for an additive blend, or false for a regular blend.</param>
    public void SetLayerAdditive(uint layerIndex, bool value)
    {
      if ((long) layerIndex >= (long) this.m_Handle.GetInputCount())
        throw new ArgumentOutOfRangeException(nameof (layerIndex), string.Format("layerIndex {0} must be in the range of 0 to {1}.", (object) layerIndex, (object) (this.m_Handle.GetInputCount() - 1)));
      AnimationLayerMixerPlayable.SetLayerAdditiveInternal(ref this.m_Handle, layerIndex, value);
    }

    /// <summary>
    ///   <para>Sets the mask for the current layer.</para>
    /// </summary>
    /// <param name="layerIndex">The layer index.</param>
    /// <param name="mask">The AvatarMask used to create the new LayerMask.</param>
    public void SetLayerMaskFromAvatarMask(uint layerIndex, AvatarMask mask)
    {
      if ((long) layerIndex >= (long) this.m_Handle.GetInputCount())
        throw new ArgumentOutOfRangeException(nameof (layerIndex), string.Format("layerIndex {0} must be in the range of 0 to {1}.", (object) layerIndex, (object) (this.m_Handle.GetInputCount() - 1)));
      if ((UnityEngine.Object) mask == (UnityEngine.Object) null)
        throw new ArgumentNullException(nameof (mask));
      AnimationLayerMixerPlayable.SetLayerMaskFromAvatarMaskInternal(ref this.m_Handle, layerIndex, mask);
    }

    private static bool CreateHandleInternal(PlayableGraph graph, ref PlayableHandle handle)
    {
      return AnimationLayerMixerPlayable.CreateHandleInternal_Injected(ref graph, ref handle);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool IsLayerAdditiveInternal(ref PlayableHandle handle, uint layerIndex);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SetLayerAdditiveInternal(ref PlayableHandle handle, uint layerIndex, bool value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SetLayerMaskFromAvatarMaskInternal(ref PlayableHandle handle, uint layerIndex, AvatarMask mask);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool CreateHandleInternal_Injected(ref PlayableGraph graph, ref PlayableHandle handle);
  }
}
