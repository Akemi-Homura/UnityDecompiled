﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.PolygonCollider2D
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System.Runtime.CompilerServices;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine
{
  public sealed class PolygonCollider2D : Collider2D
  {
    public extern int pathCount { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int GetTotalPointCount();

    public extern bool autoTiling { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    public extern Vector2[] points { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern Vector2[] GetPath(int index);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetPath(int index, Vector2[] points);

    public void CreatePrimitive(int sides, [DefaultValue("Vector2.one")] Vector2 scale, [DefaultValue("Vector2.zero")] Vector2 offset)
    {
      PolygonCollider2D.INTERNAL_CALL_CreatePrimitive(this, sides, ref scale, ref offset);
    }

    [ExcludeFromDocs]
    public void CreatePrimitive(int sides, Vector2 scale)
    {
      Vector2 zero = Vector2.zero;
      PolygonCollider2D.INTERNAL_CALL_CreatePrimitive(this, sides, ref scale, ref zero);
    }

    [ExcludeFromDocs]
    public void CreatePrimitive(int sides)
    {
      Vector2 zero = Vector2.zero;
      Vector2 one = Vector2.one;
      PolygonCollider2D.INTERNAL_CALL_CreatePrimitive(this, sides, ref one, ref zero);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_CreatePrimitive(PolygonCollider2D self, int sides, ref Vector2 scale, ref Vector2 offset);
  }
}
