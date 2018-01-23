﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.Sprites.SpriteUtility
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting;

namespace UnityEditor.Sprites
{
  /// <summary>
  ///   <para>Helper utilities for accessing Sprite data.</para>
  /// </summary>
  public sealed class SpriteUtility
  {
    /// <summary>
    ///   <para>Returns the generated Sprite texture. If Sprite is packed, it is possible to query for both source and atlas textures.</para>
    /// </summary>
    /// <param name="getAtlasData">If Sprite is packed, it is possible to access data as if it was on the atlas texture.</param>
    /// <param name="sprite"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern Texture2D GetSpriteTexture(Sprite sprite, bool getAtlasData);

    /// <summary>
    ///   <para>Returns the generated Sprite mesh positions.</para>
    /// </summary>
    /// <param name="getAtlasData">If Sprite is packed, it is possible to access data as if it was on the atlas texture.</param>
    /// <param name="sprite"></param>
    [Obsolete("Use Sprite.vertices API instead. This data is the same for packed and unpacked sprites.")]
    public static Vector2[] GetSpriteMesh(Sprite sprite, bool getAtlasData)
    {
      return sprite.vertices;
    }

    /// <summary>
    ///   <para>Returns the generated Sprite mesh uvs.</para>
    /// </summary>
    /// <param name="sprite">If Sprite is packed, it is possible to access data as if it was on the atlas texture.</param>
    /// <param name="getAtlasData"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern Vector2[] GetSpriteUVs(Sprite sprite, bool getAtlasData);

    /// <summary>
    ///   <para>Returns the generated Sprite mesh indices.</para>
    /// </summary>
    /// <param name="sprite">If Sprite is packed, it is possible to access data as if it was on the atlas texture.</param>
    /// <param name="getAtlasData"></param>
    [Obsolete("Use Sprite.triangles API instead. This data is the same for packed and unpacked sprites.")]
    public static ushort[] GetSpriteIndices(Sprite sprite, bool getAtlasData)
    {
      return sprite.triangles;
    }

    internal static void GenerateOutline(Texture2D texture, Rect rect, float detail, byte alphaTolerance, bool holeDetection, out Vector2[][] paths)
    {
      SpriteUtility.INTERNAL_CALL_GenerateOutline(texture, ref rect, detail, alphaTolerance, holeDetection, out paths);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_GenerateOutline(Texture2D texture, ref Rect rect, float detail, byte alphaTolerance, bool holeDetection, out Vector2[][] paths);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void GenerateOutlineFromSprite(Sprite sprite, float detail, byte alphaTolerance, bool holeDetection, out Vector2[][] paths);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern Vector2[] GeneratePolygonOutlineVerticesOfSize(int sides, int width, int height);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void CreateSpritePolygonAssetAtPath(string pathName, int sides);
  }
}
