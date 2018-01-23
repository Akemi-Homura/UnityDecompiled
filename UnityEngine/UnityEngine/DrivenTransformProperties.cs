﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.DrivenTransformProperties
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System;

namespace UnityEngine
{
  /// <summary>
  ///   <para>An enumeration of transform properties that can be driven on a RectTransform by an object.</para>
  /// </summary>
  [Flags]
  public enum DrivenTransformProperties
  {
    None = 0,
    All = -1,
    AnchoredPositionX = 2,
    AnchoredPositionY = 4,
    AnchoredPositionZ = 8,
    Rotation = 16, // 0x00000010
    ScaleX = 32, // 0x00000020
    ScaleY = 64, // 0x00000040
    ScaleZ = 128, // 0x00000080
    AnchorMinX = 256, // 0x00000100
    AnchorMinY = 512, // 0x00000200
    AnchorMaxX = 1024, // 0x00000400
    AnchorMaxY = 2048, // 0x00000800
    SizeDeltaX = 4096, // 0x00001000
    SizeDeltaY = 8192, // 0x00002000
    PivotX = 16384, // 0x00004000
    PivotY = 32768, // 0x00008000
    AnchoredPosition = AnchoredPositionY | AnchoredPositionX, // 0x00000006
    AnchoredPosition3D = AnchoredPosition | AnchoredPositionZ, // 0x0000000E
    Scale = ScaleZ | ScaleY | ScaleX, // 0x000000E0
    AnchorMin = AnchorMinY | AnchorMinX, // 0x00000300
    AnchorMax = AnchorMaxY | AnchorMaxX, // 0x00000C00
    Anchors = AnchorMax | AnchorMin, // 0x00000F00
    SizeDelta = SizeDeltaY | SizeDeltaX, // 0x00003000
    Pivot = PivotY | PivotX, // 0x0000C000
  }
}
