﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.Light
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Script interface for.</para>
  /// </summary>
  [RequireComponent(typeof (Transform))]
  [RequireComponent(typeof (Transform))]
  public sealed class Light : Behaviour
  {
    private int m_BakedIndex;

    /// <summary>
    ///   <para>How this light casts shadows</para>
    /// </summary>
    public extern LightShadows shadows { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Strength of light's shadows.</para>
    /// </summary>
    public extern float shadowStrength { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The resolution of the shadow map.</para>
    /// </summary>
    public extern LightShadowResolution shadowResolution { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("Shadow softness is removed in Unity 5.0+")]
    public extern float shadowSoftness { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("Shadow softness is removed in Unity 5.0+")]
    public extern float shadowSoftnessFade { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The size of a directional light's cookie.</para>
    /// </summary>
    public extern float cookieSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The cookie texture projected by the light.</para>
    /// </summary>
    public extern Texture cookie { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>How to render the light.</para>
    /// </summary>
    public extern LightRenderMode renderMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("bakedIndex has been removed please use bakingOutput.isBaked instead.")]
    public int bakedIndex
    {
      get
      {
        return this.m_BakedIndex;
      }
      set
      {
        this.m_BakedIndex = value;
      }
    }

    /// <summary>
    ///   <para>The size of the area light.</para>
    /// </summary>
    public Vector2 areaSize
    {
      get
      {
        Vector2 vector2;
        this.INTERNAL_get_areaSize(out vector2);
        return vector2;
      }
      set
      {
        this.INTERNAL_set_areaSize(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_areaSize(out Vector2 value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_areaSize(ref Vector2 value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetFalloffTable(float[] input);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SetAllLightsFalloffToInverseSquared();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SetAllLightsFalloffToUnityLegacy();

    /// <summary>
    ///   <para>This property describes what part of a light's contribution can be baked.</para>
    /// </summary>
    public extern LightmapBakeType lightmapBakeType { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Add a command buffer to be executed at a specified place.</para>
    /// </summary>
    /// <param name="evt">When to execute the command buffer during rendering.</param>
    /// <param name="buffer">The buffer to execute.</param>
    /// <param name="shadowPassMask">A mask specifying which shadow passes to execute the buffer for.</param>
    public void AddCommandBuffer(LightEvent evt, CommandBuffer buffer)
    {
      this.AddCommandBuffer(evt, buffer, ShadowMapPass.All);
    }

    /// <summary>
    ///   <para>Add a command buffer to be executed at a specified place.</para>
    /// </summary>
    /// <param name="evt">When to execute the command buffer during rendering.</param>
    /// <param name="buffer">The buffer to execute.</param>
    /// <param name="shadowPassMask">A mask specifying which shadow passes to execute the buffer for.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void AddCommandBuffer(LightEvent evt, CommandBuffer buffer, ShadowMapPass shadowPassMask);

    /// <summary>
    ///   <para>Remove command buffer from execution at a specified place.</para>
    /// </summary>
    /// <param name="evt">When to execute the command buffer during rendering.</param>
    /// <param name="buffer">The buffer to execute.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void RemoveCommandBuffer(LightEvent evt, CommandBuffer buffer);

    /// <summary>
    ///   <para>Remove command buffers from execution at a specified place.</para>
    /// </summary>
    /// <param name="evt">When to execute the command buffer during rendering.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void RemoveCommandBuffers(LightEvent evt);

    /// <summary>
    ///   <para>Remove all command buffers set on this light.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void RemoveAllCommandBuffers();

    /// <summary>
    ///   <para>Get command buffers to be executed at a specified place.</para>
    /// </summary>
    /// <param name="evt">When to execute the command buffer during rendering.</param>
    /// <returns>
    ///   <para>Array of command buffers.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern CommandBuffer[] GetCommandBuffers(LightEvent evt);

    /// <summary>
    ///   <para>Number of command buffers set up on this light (Read Only).</para>
    /// </summary>
    public extern int commandBufferCount { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [Obsolete("Use QualitySettings.pixelLightCount instead.")]
    public static extern int pixelLightCount { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern Light[] GetLights(LightType type, int layer);

    [Obsolete("light.shadowConstantBias was removed, use light.shadowBias", true)]
    public float shadowConstantBias
    {
      get
      {
        return 0.0f;
      }
      set
      {
      }
    }

    [Obsolete("light.shadowObjectSizeBias was removed, use light.shadowBias", true)]
    public float shadowObjectSizeBias
    {
      get
      {
        return 0.0f;
      }
      set
      {
      }
    }

    [Obsolete("light.attenuate was removed; all lights always attenuate now", true)]
    public bool attenuate
    {
      get
      {
        return true;
      }
      set
      {
      }
    }

    /// <summary>
    ///   <para>The type of the light.</para>
    /// </summary>
    public extern LightType type { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The angle of the light's spotlight cone in degrees.</para>
    /// </summary>
    public extern float spotAngle { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The color of the light.</para>
    /// </summary>
    public Color color
    {
      get
      {
        Color ret;
        this.get_color_Injected(out ret);
        return ret;
      }
      set
      {
        this.set_color_Injected(ref value);
      }
    }

    /// <summary>
    ///   <para>
    ///     The color temperature of the light.
    ///     Correlated Color Temperature (abbreviated as CCT) is multiplied with the color filter when calculating the final color of a light source. The color temperature of the electromagnetic radiation emitted from an ideal black body is defined as its surface temperature in Kelvin. White is 6500K according to the D65 standard. Candle light is 1800K.
    ///     If you want to use lightsUseCCT, lightsUseLinearIntensity has to be enabled to ensure physically correct output.
    ///     See Also: GraphicsSettings.lightsUseLinearIntensity, GraphicsSettings.lightsUseCCT.
    ///   </para>
    /// </summary>
    public extern float colorTemperature { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The Intensity of a light is multiplied with the Light color.</para>
    /// </summary>
    public extern float intensity { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The multiplier that defines the strength of the bounce lighting.</para>
    /// </summary>
    public extern float bounceIntensity { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The custom resolution of the shadow map.</para>
    /// </summary>
    public extern int shadowCustomResolution { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Shadow mapping constant bias.</para>
    /// </summary>
    public extern float shadowBias { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Shadow mapping normal-based bias.</para>
    /// </summary>
    public extern float shadowNormalBias { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Near plane value to use for shadow frustums.</para>
    /// </summary>
    public extern float shadowNearPlane { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The range of the light.</para>
    /// </summary>
    public extern float range { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The to use for this light.</para>
    /// </summary>
    public extern Flare flare { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>This property describes the output of the last Global Illumination bake.</para>
    /// </summary>
    public LightBakingOutput bakingOutput
    {
      get
      {
        LightBakingOutput ret;
        this.get_bakingOutput_Injected(out ret);
        return ret;
      }
      set
      {
        this.set_bakingOutput_Injected(ref value);
      }
    }

    /// <summary>
    ///   <para>This is used to light certain objects in the scene selectively.</para>
    /// </summary>
    public extern int cullingMask { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("Light.lightmappingMode has been deprecated. Use Light.lightmapBakeType instead (UnityUpgradable) -> lightmapBakeType", true)]
    public LightmappingMode lightmappingMode
    {
      get
      {
        return LightmappingMode.Realtime;
      }
      set
      {
      }
    }

    /// <summary>
    ///   <para>Is the light contribution already stored in lightmaps and/or lightprobes (Read Only).</para>
    /// </summary>
    [Obsolete("Light.isBaked is no longer supported. Use Light.bakingOutput.isBaked (and other members of Light.bakingOutput) instead.", false)]
    public bool isBaked
    {
      get
      {
        return this.bakingOutput.isBaked;
      }
    }

    [Obsolete("Light.alreadyLightmapped is no longer supported. Use Light.bakingOutput instead. Allowing to describe mixed light on top of realtime and baked ones.", false)]
    public bool alreadyLightmapped
    {
      get
      {
        return this.bakingOutput.isBaked;
      }
      set
      {
        this.bakingOutput = new LightBakingOutput()
        {
          probeOcclusionLightIndex = -1,
          occlusionMaskChannel = -1,
          lightmapBakeType = !value ? LightmapBakeType.Realtime : LightmapBakeType.Baked,
          isBaked = value
        };
      }
    }

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void get_color_Injected(out Color ret);

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void set_color_Injected(ref Color value);

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void get_bakingOutput_Injected(out LightBakingOutput ret);

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void set_bakingOutput_Injected(ref LightBakingOutput value);
  }
}
