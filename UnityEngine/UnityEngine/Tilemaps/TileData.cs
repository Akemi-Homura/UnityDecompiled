﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.Tilemaps.TileData
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Tilemaps
{
  [RequiredByNativeCode]
  [NativeType(Header = "Modules/Tilemap/TilemapScripting.h")]
  public struct TileData
  {
    private Sprite m_Sprite;
    private Color m_Color;
    private Matrix4x4 m_Transform;
    private GameObject m_GameObject;
    private TileFlags m_Flags;
    private Tile.ColliderType m_ColliderType;

    public Sprite sprite
    {
      get
      {
        return this.m_Sprite;
      }
      set
      {
        this.m_Sprite = value;
      }
    }

    public Color color
    {
      get
      {
        return this.m_Color;
      }
      set
      {
        this.m_Color = value;
      }
    }

    public Matrix4x4 transform
    {
      get
      {
        return this.m_Transform;
      }
      set
      {
        this.m_Transform = value;
      }
    }

    public GameObject gameObject
    {
      get
      {
        return this.m_GameObject;
      }
      set
      {
        this.m_GameObject = value;
      }
    }

    public TileFlags flags
    {
      get
      {
        return this.m_Flags;
      }
      set
      {
        this.m_Flags = value;
      }
    }

    public Tile.ColliderType colliderType
    {
      get
      {
        return this.m_ColliderType;
      }
      set
      {
        this.m_ColliderType = value;
      }
    }
  }
}
