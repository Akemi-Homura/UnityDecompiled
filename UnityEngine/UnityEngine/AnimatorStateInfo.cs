﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.AnimatorStateInfo
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Information about the current or next state.</para>
  /// </summary>
  [RequiredByNativeCode]
  public struct AnimatorStateInfo
  {
    private int m_Name;
    private int m_Path;
    private int m_FullPath;
    private float m_NormalizedTime;
    private float m_Length;
    private float m_Speed;
    private float m_SpeedMultiplier;
    private int m_Tag;
    private int m_Loop;

    /// <summary>
    ///   <para>Does name match the name of the active state in the statemachine?</para>
    /// </summary>
    /// <param name="name"></param>
    public bool IsName(string name)
    {
      int hash = Animator.StringToHash(name);
      return hash == this.m_FullPath || hash == this.m_Name || hash == this.m_Path;
    }

    /// <summary>
    ///   <para>The full path hash for this state.</para>
    /// </summary>
    public int fullPathHash
    {
      get
      {
        return this.m_FullPath;
      }
    }

    /// <summary>
    ///   <para>The hashed name of the State.</para>
    /// </summary>
    [Obsolete("Use AnimatorStateInfo.fullPathHash instead.")]
    public int nameHash
    {
      get
      {
        return this.m_Path;
      }
    }

    /// <summary>
    ///   <para>The hash is generated using Animator::StringToHash. The string to pass doest not include the parent layer's name.</para>
    /// </summary>
    public int shortNameHash
    {
      get
      {
        return this.m_Name;
      }
    }

    /// <summary>
    ///   <para>Normalized time of the State.</para>
    /// </summary>
    public float normalizedTime
    {
      get
      {
        return this.m_NormalizedTime;
      }
    }

    /// <summary>
    ///   <para>Current duration of the state.</para>
    /// </summary>
    public float length
    {
      get
      {
        return this.m_Length;
      }
    }

    /// <summary>
    ///   <para>The playback speed of the animation. 1 is the normal playback speed.</para>
    /// </summary>
    public float speed
    {
      get
      {
        return this.m_Speed;
      }
    }

    /// <summary>
    ///   <para>The speed multiplier for this state.</para>
    /// </summary>
    public float speedMultiplier
    {
      get
      {
        return this.m_SpeedMultiplier;
      }
    }

    /// <summary>
    ///   <para>The Tag of the State.</para>
    /// </summary>
    public int tagHash
    {
      get
      {
        return this.m_Tag;
      }
    }

    /// <summary>
    ///   <para>Does tag match the tag of the active state in the statemachine.</para>
    /// </summary>
    /// <param name="tag"></param>
    public bool IsTag(string tag)
    {
      return Animator.StringToHash(tag) == this.m_Tag;
    }

    /// <summary>
    ///   <para>Is the state looping.</para>
    /// </summary>
    public bool loop
    {
      get
      {
        return this.m_Loop != 0;
      }
    }
  }
}
