﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.SpriteState
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 95F4B50A-137D-4022-9C58-045B696814A0
// Assembly location: C:\Program Files\Unity 5\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

using System;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
  /// <summary>
  ///   <para>Structure to store the state of a sprite transition on a Selectable.</para>
  /// </summary>
  [Serializable]
  public struct SpriteState : IEquatable<SpriteState>
  {
    [FormerlySerializedAs("highlightedSprite")]
    [FormerlySerializedAs("m_SelectedSprite")]
    [SerializeField]
    private Sprite m_HighlightedSprite;
    [FormerlySerializedAs("pressedSprite")]
    [SerializeField]
    private Sprite m_PressedSprite;
    [FormerlySerializedAs("disabledSprite")]
    [SerializeField]
    private Sprite m_DisabledSprite;

    /// <summary>
    ///   <para>Highlighted sprite.</para>
    /// </summary>
    public Sprite highlightedSprite
    {
      get
      {
        return this.m_HighlightedSprite;
      }
      set
      {
        this.m_HighlightedSprite = value;
      }
    }

    /// <summary>
    ///   <para>Pressed sprite.</para>
    /// </summary>
    public Sprite pressedSprite
    {
      get
      {
        return this.m_PressedSprite;
      }
      set
      {
        this.m_PressedSprite = value;
      }
    }

    /// <summary>
    ///   <para>Disabled sprite.</para>
    /// </summary>
    public Sprite disabledSprite
    {
      get
      {
        return this.m_DisabledSprite;
      }
      set
      {
        this.m_DisabledSprite = value;
      }
    }

    public bool Equals(SpriteState other)
    {
      return (UnityEngine.Object) this.highlightedSprite == (UnityEngine.Object) other.highlightedSprite && (UnityEngine.Object) this.pressedSprite == (UnityEngine.Object) other.pressedSprite && (UnityEngine.Object) this.disabledSprite == (UnityEngine.Object) other.disabledSprite;
    }
  }
}
