﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.ReflectionProbe
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>The reflection probe is used to capture the surroundings into a texture which is passed to the shaders and used for reflections.</para>
  /// </summary>
  public sealed class ReflectionProbe : Behaviour
  {
    [Obsolete("type property has been deprecated. Starting with Unity 5.4, the only supported reflection probe type is Cube.", true)]
    public extern ReflectionProbeType type { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Should this reflection probe use HDR rendering?</para>
    /// </summary>
    public extern bool hdr { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The size of the box area in which reflections will be applied to the objects. Measured in the probes's local space.</para>
    /// </summary>
    public Vector3 size
    {
      get
      {
        Vector3 vector3;
        this.INTERNAL_get_size(out vector3);
        return vector3;
      }
      set
      {
        this.INTERNAL_set_size(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_size(out Vector3 value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_size(ref Vector3 value);

    /// <summary>
    ///   <para>The center of the box area in which reflections will be applied to the objects. Measured in the probes's local space.</para>
    /// </summary>
    public Vector3 center
    {
      get
      {
        Vector3 vector3;
        this.INTERNAL_get_center(out vector3);
        return vector3;
      }
      set
      {
        this.INTERNAL_set_center(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_center(out Vector3 value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_center(ref Vector3 value);

    /// <summary>
    ///   <para>The near clipping plane distance when rendering the probe.</para>
    /// </summary>
    public extern float nearClipPlane { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The far clipping plane distance when rendering the probe.</para>
    /// </summary>
    public extern float farClipPlane { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Shadow drawing distance when rendering the probe.</para>
    /// </summary>
    public extern float shadowDistance { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Resolution of the underlying reflection texture in pixels.</para>
    /// </summary>
    public extern int resolution { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>This is used to render parts of the reflecion probe's surrounding selectively.</para>
    /// </summary>
    public extern int cullingMask { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>How the reflection probe clears the background.</para>
    /// </summary>
    public extern ReflectionProbeClearFlags clearFlags { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The color with which the texture of reflection probe will be cleared.</para>
    /// </summary>
    public Color backgroundColor
    {
      get
      {
        Color color;
        this.INTERNAL_get_backgroundColor(out color);
        return color;
      }
      set
      {
        this.INTERNAL_set_backgroundColor(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_backgroundColor(out Color value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_backgroundColor(ref Color value);

    /// <summary>
    ///   <para>The intensity modifier that is applied to the texture of reflection probe in the shader.</para>
    /// </summary>
    public extern float intensity { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Distance around probe used for blending (used in deferred probes).</para>
    /// </summary>
    public extern float blendDistance { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Should this reflection probe use box projection?</para>
    /// </summary>
    public extern bool boxProjection { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The bounding volume of the reflection probe (Read Only).</para>
    /// </summary>
    public Bounds bounds
    {
      get
      {
        Bounds bounds;
        this.INTERNAL_get_bounds(out bounds);
        return bounds;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_bounds(out Bounds value);

    /// <summary>
    ///   <para>Should reflection probe texture be generated in the Editor (ReflectionProbeMode.Baked) or should probe use custom specified texure (ReflectionProbeMode.Custom)?</para>
    /// </summary>
    public extern ReflectionProbeMode mode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Reflection probe importance.</para>
    /// </summary>
    public extern int importance { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///         <para>Sets the way the probe will refresh.
    /// 
    /// See Also: ReflectionProbeRefreshMode.</para>
    ///       </summary>
    public extern ReflectionProbeRefreshMode refreshMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///         <para>Sets this probe time-slicing mode
    /// 
    /// See Also: ReflectionProbeTimeSlicingMode.</para>
    ///       </summary>
    public extern ReflectionProbeTimeSlicingMode timeSlicingMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Reference to the baked texture of the reflection probe's surrounding.</para>
    /// </summary>
    public extern Texture bakedTexture { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Reference to the baked texture of the reflection probe's surrounding. Use this to assign custom reflection texture.</para>
    /// </summary>
    public extern Texture customBakedTexture { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Texture which is passed to the shader of the objects in the vicinity of the reflection probe (Read Only).</para>
    /// </summary>
    public extern Texture texture { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>HDR decode values of the reflection probe texture.</para>
    /// </summary>
    public Vector4 textureHDRDecodeValues
    {
      get
      {
        Vector4 vector4;
        this.INTERNAL_get_textureHDRDecodeValues(out vector4);
        return vector4;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_textureHDRDecodeValues(out Vector4 value);

    /// <summary>
    ///   <para>Refreshes the probe's cubemap.</para>
    /// </summary>
    /// <param name="targetTexture">Target RendeTexture in which rendering should be done. Specifying null will update the probe's default texture.</param>
    /// <returns>
    ///   <para>
    ///     An integer representing a RenderID which can subsequently be used to check if the probe has finished rendering while rendering in time-slice mode.
    /// 
    ///     See Also: IsFinishedRendering
    ///     See Also: timeSlicingMode
    ///   </para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int RenderProbe([DefaultValue("null")] RenderTexture targetTexture);

    [ExcludeFromDocs]
    public int RenderProbe()
    {
      return this.RenderProbe((RenderTexture) null);
    }

    /// <summary>
    ///   <para>Checks if a probe has finished a time-sliced render.</para>
    /// </summary>
    /// <param name="renderId">An integer representing the RenderID as returned by the RenderProbe method.</param>
    /// <returns>
    ///   <para>
    ///     True if the render has finished, false otherwise.
    /// 
    ///     See Also: timeSlicingMode
    ///   </para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool IsFinishedRendering(int renderId);

    /// <summary>
    ///   <para>Utility method to blend 2 cubemaps into a target render texture.</para>
    /// </summary>
    /// <param name="src">Cubemap to blend from.</param>
    /// <param name="dst">Cubemap to blend to.</param>
    /// <param name="blend">Blend weight.</param>
    /// <param name="target">RenderTexture which will hold the result of the blend.</param>
    /// <returns>
    ///   <para>Returns trues if cubemaps were blended, false otherwise.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool BlendCubemap(Texture src, Texture dst, float blend, RenderTexture target);

    public static extern int minBakedCubemapResolution { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public static extern int maxBakedCubemapResolution { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>HDR decode values of the default reflection probe texture.</para>
    /// </summary>
    public static Vector4 defaultTextureHDRDecodeValues
    {
      get
      {
        Vector4 vector4;
        ReflectionProbe.INTERNAL_get_defaultTextureHDRDecodeValues(out vector4);
        return vector4;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_get_defaultTextureHDRDecodeValues(out Vector4 value);

    /// <summary>
    ///   <para>Texture which is used outside of all reflection probes (Read Only).</para>
    /// </summary>
    public static extern Texture defaultTexture { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }
  }
}
