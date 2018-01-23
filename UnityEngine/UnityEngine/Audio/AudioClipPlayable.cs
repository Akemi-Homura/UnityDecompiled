﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.Audio.AudioClipPlayable
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine.Playables;
using UnityEngine.Scripting;

namespace UnityEngine.Audio
{
  /// <summary>
  ///   <para>An implementation of IPlayable that controls an AudioClip.</para>
  /// </summary>
  [RequiredByNativeCode]
  public struct AudioClipPlayable : IPlayable, IEquatable<AudioClipPlayable>
  {
    private PlayableHandle m_Handle;

    internal AudioClipPlayable(PlayableHandle handle)
    {
      if (handle.IsValid() && !handle.IsPlayableOfType<AudioClipPlayable>())
        throw new InvalidCastException("Can't set handle: the playable is not an AudioClipPlayable.");
      this.m_Handle = handle;
    }

    /// <summary>
    ///   <para>Creates an AudioClipPlayable in the PlayableGraph.</para>
    /// </summary>
    /// <param name="graph">The PlayableGraph that will contain the new AnimationLayerMixerPlayable.</param>
    /// <param name="clip">The AudioClip that will be added in the PlayableGraph.</param>
    /// <param name="looping">True if the clip should loop, false otherwise.</param>
    /// <returns>
    ///   <para>A AudioClipPlayable linked to the PlayableGraph.</para>
    /// </returns>
    public static AudioClipPlayable Create(PlayableGraph graph, AudioClip clip, bool looping)
    {
      AudioClipPlayable playable = new AudioClipPlayable(AudioClipPlayable.CreateHandle(graph, clip, looping));
      if ((UnityEngine.Object) clip != (UnityEngine.Object) null)
        playable.SetDuration<AudioClipPlayable>((double) clip.length);
      return playable;
    }

    private static PlayableHandle CreateHandle(PlayableGraph graph, AudioClip clip, bool looping)
    {
      PlayableHandle handle = PlayableHandle.Null;
      if (!AudioClipPlayable.InternalCreateAudioClipPlayable(ref graph, clip, looping, ref handle))
        return PlayableHandle.Null;
      return handle;
    }

    public PlayableHandle GetHandle()
    {
      return this.m_Handle;
    }

    public static implicit operator Playable(AudioClipPlayable playable)
    {
      return new Playable(playable.GetHandle());
    }

    public static explicit operator AudioClipPlayable(Playable playable)
    {
      return new AudioClipPlayable(playable.GetHandle());
    }

    public bool Equals(AudioClipPlayable other)
    {
      return this.GetHandle() == other.GetHandle();
    }

    public AudioClip GetClip()
    {
      return AudioClipPlayable.GetClipInternal(ref this.m_Handle);
    }

    public void SetClip(AudioClip value)
    {
      AudioClipPlayable.SetClipInternal(ref this.m_Handle, value);
    }

    public bool GetLooped()
    {
      return AudioClipPlayable.GetLoopedInternal(ref this.m_Handle);
    }

    public void SetLooped(bool value)
    {
      AudioClipPlayable.SetLoopedInternal(ref this.m_Handle, value);
    }

    [Obsolete("IsPlaying() has been deprecated. Use IsChannelPlaying() instead (UnityUpgradable) -> IsChannelPlaying()", true)]
    public bool IsPlaying()
    {
      return this.IsChannelPlaying();
    }

    public bool IsChannelPlaying()
    {
      return AudioClipPlayable.GetIsChannelPlayingInternal(ref this.m_Handle);
    }

    public double GetStartDelay()
    {
      return AudioClipPlayable.GetStartDelayInternal(ref this.m_Handle);
    }

    internal void SetStartDelay(double value)
    {
      this.ValidateStartDelayInternal(value);
      AudioClipPlayable.SetStartDelayInternal(ref this.m_Handle, value);
    }

    public double GetPauseDelay()
    {
      return AudioClipPlayable.GetPauseDelayInternal(ref this.m_Handle);
    }

    internal void GetPauseDelay(double value)
    {
      double pauseDelayInternal = AudioClipPlayable.GetPauseDelayInternal(ref this.m_Handle);
      if (this.m_Handle.GetPlayState() == PlayState.Playing && (value < 0.05 || pauseDelayInternal != 0.0 && pauseDelayInternal < 0.05))
        throw new ArgumentException("AudioClipPlayable.pauseDelay: Setting new delay when existing delay is too small or 0.0 (" + (object) pauseDelayInternal + "), audio system will not be able to change in time");
      AudioClipPlayable.SetPauseDelayInternal(ref this.m_Handle, value);
    }

    public void Seek(double startTime, double startDelay)
    {
      this.Seek(startTime, startDelay, 0.0);
    }

    public void Seek(double startTime, double startDelay, [DefaultValue(0)] double duration)
    {
      this.ValidateStartDelayInternal(startDelay);
      AudioClipPlayable.SetStartDelayInternal(ref this.m_Handle, startDelay);
      if (duration > 0.0)
      {
        this.m_Handle.SetDuration(duration + startTime);
        AudioClipPlayable.SetPauseDelayInternal(ref this.m_Handle, startDelay + duration);
      }
      else
      {
        this.m_Handle.SetDuration(double.MaxValue);
        AudioClipPlayable.SetPauseDelayInternal(ref this.m_Handle, 0.0);
      }
      this.m_Handle.SetTime(startTime);
      this.m_Handle.Play();
    }

    private void ValidateStartDelayInternal(double startDelay)
    {
      double startDelayInternal = AudioClipPlayable.GetStartDelayInternal(ref this.m_Handle);
      if (!this.IsChannelPlaying() || startDelay >= 0.05 && (startDelayInternal < 1E-05 || startDelayInternal >= 0.05))
        return;
      Debug.LogWarning((object) ("AudioClipPlayable.StartDelay: Setting new delay when existing delay is too small or 0.0 (" + (object) startDelayInternal + "), audio system will not be able to change in time"));
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern AudioClip GetClipInternal(ref PlayableHandle hdl);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SetClipInternal(ref PlayableHandle hdl, AudioClip clip);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool GetLoopedInternal(ref PlayableHandle hdl);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SetLoopedInternal(ref PlayableHandle hdl, bool looped);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool GetIsChannelPlayingInternal(ref PlayableHandle hdl);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern double GetStartDelayInternal(ref PlayableHandle hdl);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SetStartDelayInternal(ref PlayableHandle hdl, double delay);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern double GetPauseDelayInternal(ref PlayableHandle hdl);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SetPauseDelayInternal(ref PlayableHandle hdl, double delay);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool InternalCreateAudioClipPlayable(ref PlayableGraph graph, AudioClip clip, bool looping, ref PlayableHandle handle);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool ValidateType(ref PlayableHandle hdl);
  }
}
