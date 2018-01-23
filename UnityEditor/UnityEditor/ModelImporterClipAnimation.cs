﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.ModelImporterClipAnimation
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEditor
{
  /// <summary>
  ///   <para>Animation clips to split animation into.</para>
  /// </summary>
  [UsedByNativeCode]
  [NativeType(CodegenOptions = CodegenOptions.Custom, IntermediateScriptingStructName = "MonoClipAnimationInfo")]
  [Serializable]
  [StructLayout(LayoutKind.Sequential)]
  public sealed class ModelImporterClipAnimation
  {
    private int m_MaskType = 3;
    private string m_TakeName;
    private string m_Name;
    private float m_FirstFrame;
    private float m_LastFrame;
    private WrapMode m_WrapMode;
    private int m_Loop;
    private float m_OrientationOffsetY;
    private float m_Level;
    private float m_CycleOffset;
    private float m_AdditiveReferencePoseFrame;
    private int m_HasAdditiveReferencePose;
    private int m_LoopTime;
    private int m_LoopBlend;
    private int m_LoopBlendOrientation;
    private int m_LoopBlendPositionY;
    private int m_LoopBlendPositionXZ;
    private int m_KeepOriginalOrientation;
    private int m_KeepOriginalPositionY;
    private int m_KeepOriginalPositionXZ;
    private int m_HeightFromFeet;
    private int m_Mirror;
    private AvatarMask m_MaskSource;
    private int[] m_BodyMask;
    private AnimationEvent[] m_AnimationEvents;
    private ClipAnimationInfoCurve[] m_AdditionnalCurves;
    private TransformMaskElement[] m_TransformMask;
    private bool m_MaskNeedsUpdating;

    /// <summary>
    ///   <para>Take name.</para>
    /// </summary>
    public string takeName
    {
      get
      {
        return this.m_TakeName;
      }
      set
      {
        this.m_TakeName = value;
      }
    }

    /// <summary>
    ///   <para>Clip name.</para>
    /// </summary>
    public string name
    {
      get
      {
        return this.m_Name;
      }
      set
      {
        this.m_Name = value;
      }
    }

    /// <summary>
    ///   <para>First frame of the clip.</para>
    /// </summary>
    public float firstFrame
    {
      get
      {
        return this.m_FirstFrame;
      }
      set
      {
        this.m_FirstFrame = value;
      }
    }

    /// <summary>
    ///   <para>Last frame of the clip.</para>
    /// </summary>
    public float lastFrame
    {
      get
      {
        return this.m_LastFrame;
      }
      set
      {
        this.m_LastFrame = value;
      }
    }

    /// <summary>
    ///   <para>The wrap mode of the animation.</para>
    /// </summary>
    public WrapMode wrapMode
    {
      get
      {
        return this.m_WrapMode;
      }
      set
      {
        this.m_WrapMode = value;
      }
    }

    /// <summary>
    ///   <para>Is the clip a looping animation?</para>
    /// </summary>
    public bool loop
    {
      get
      {
        return this.m_Loop != 0;
      }
      set
      {
        this.m_Loop = !value ? 0 : 1;
      }
    }

    /// <summary>
    ///   <para>Offset in degrees to the root rotation.</para>
    /// </summary>
    public float rotationOffset
    {
      get
      {
        return this.m_OrientationOffsetY;
      }
      set
      {
        this.m_OrientationOffsetY = value;
      }
    }

    /// <summary>
    ///   <para>Offset to the vertical root position.</para>
    /// </summary>
    public float heightOffset
    {
      get
      {
        return this.m_Level;
      }
      set
      {
        this.m_Level = value;
      }
    }

    /// <summary>
    ///   <para>Offset to the cycle of a looping animation, if a different time in it is desired to be the start.</para>
    /// </summary>
    public float cycleOffset
    {
      get
      {
        return this.m_CycleOffset;
      }
      set
      {
        this.m_CycleOffset = value;
      }
    }

    /// <summary>
    ///   <para>Enable to make the clip loop.</para>
    /// </summary>
    public bool loopTime
    {
      get
      {
        return this.m_LoopTime != 0;
      }
      set
      {
        this.m_LoopTime = !value ? 0 : 1;
      }
    }

    /// <summary>
    ///   <para>Enable to make the motion loop seamlessly.</para>
    /// </summary>
    public bool loopPose
    {
      get
      {
        return this.m_LoopBlend != 0;
      }
      set
      {
        this.m_LoopBlend = !value ? 0 : 1;
      }
    }

    /// <summary>
    ///   <para>Enable to make root rotation be baked into the movement of the bones. Disable to make root rotation be stored as root motion.</para>
    /// </summary>
    public bool lockRootRotation
    {
      get
      {
        return this.m_LoopBlendOrientation != 0;
      }
      set
      {
        this.m_LoopBlendOrientation = !value ? 0 : 1;
      }
    }

    /// <summary>
    ///   <para>Enable to make vertical root motion be baked into the movement of the bones. Disable to make vertical root motion be stored as root motion.</para>
    /// </summary>
    public bool lockRootHeightY
    {
      get
      {
        return this.m_LoopBlendPositionY != 0;
      }
      set
      {
        this.m_LoopBlendPositionY = !value ? 0 : 1;
      }
    }

    /// <summary>
    ///   <para>Enable to make horizontal root motion be baked into the movement of the bones. Disable to make horizontal root motion be stored as root motion.</para>
    /// </summary>
    public bool lockRootPositionXZ
    {
      get
      {
        return this.m_LoopBlendPositionXZ != 0;
      }
      set
      {
        this.m_LoopBlendPositionXZ = !value ? 0 : 1;
      }
    }

    /// <summary>
    ///   <para>Keeps the vertical position as it is authored in the source file.</para>
    /// </summary>
    public bool keepOriginalOrientation
    {
      get
      {
        return this.m_KeepOriginalOrientation != 0;
      }
      set
      {
        this.m_KeepOriginalOrientation = !value ? 0 : 1;
      }
    }

    /// <summary>
    ///   <para>Keeps the vertical position as it is authored in the source file.</para>
    /// </summary>
    public bool keepOriginalPositionY
    {
      get
      {
        return this.m_KeepOriginalPositionY != 0;
      }
      set
      {
        this.m_KeepOriginalPositionY = !value ? 0 : 1;
      }
    }

    /// <summary>
    ///   <para>Keeps the vertical position as it is authored in the source file.</para>
    /// </summary>
    public bool keepOriginalPositionXZ
    {
      get
      {
        return this.m_KeepOriginalPositionXZ != 0;
      }
      set
      {
        this.m_KeepOriginalPositionXZ = !value ? 0 : 1;
      }
    }

    /// <summary>
    ///   <para>Keeps the feet aligned with the root transform position.</para>
    /// </summary>
    public bool heightFromFeet
    {
      get
      {
        return this.m_HeightFromFeet != 0;
      }
      set
      {
        this.m_HeightFromFeet = !value ? 0 : 1;
      }
    }

    /// <summary>
    ///   <para>Mirror left and right in this clip.</para>
    /// </summary>
    public bool mirror
    {
      get
      {
        return this.m_Mirror != 0;
      }
      set
      {
        this.m_Mirror = !value ? 0 : 1;
      }
    }

    /// <summary>
    ///   <para>Define mask type.</para>
    /// </summary>
    public ClipAnimationMaskType maskType
    {
      get
      {
        return (ClipAnimationMaskType) this.m_MaskType;
      }
      set
      {
        this.m_MaskType = (int) value;
      }
    }

    /// <summary>
    ///   <para>The AvatarMask used to mask transforms during the import process.</para>
    /// </summary>
    public AvatarMask maskSource
    {
      get
      {
        return this.m_MaskSource;
      }
      set
      {
        this.m_MaskSource = value;
      }
    }

    /// <summary>
    ///   <para>AnimationEvents that will be added during the import process.</para>
    /// </summary>
    public AnimationEvent[] events
    {
      get
      {
        return this.m_AnimationEvents;
      }
      set
      {
        this.m_AnimationEvents = value;
      }
    }

    /// <summary>
    ///   <para>Additionnal curves that will be that will be added during the import process.</para>
    /// </summary>
    public ClipAnimationInfoCurve[] curves
    {
      get
      {
        return this.m_AdditionnalCurves;
      }
      set
      {
        this.m_AdditionnalCurves = value;
      }
    }

    /// <summary>
    ///         <para>Returns true when the source AvatarMask has changed. This only happens when  ModelImporterClipAnimation.maskType is set to ClipAnimationMaskType.CopyFromOther
    /// To force a reload of the mask, simply set  ModelImporterClipAnimation.maskSource to the desired AvatarMask.</para>
    ///       </summary>
    public bool maskNeedsUpdating
    {
      get
      {
        return this.m_MaskNeedsUpdating;
      }
    }

    /// <summary>
    ///   <para>The additive reference pose frame.</para>
    /// </summary>
    public float additiveReferencePoseFrame
    {
      get
      {
        return this.m_AdditiveReferencePoseFrame;
      }
      set
      {
        this.m_AdditiveReferencePoseFrame = value;
      }
    }

    /// <summary>
    ///   <para>Enable to defines an additive reference pose.</para>
    /// </summary>
    public bool hasAdditiveReferencePose
    {
      get
      {
        return this.m_HasAdditiveReferencePose != 0;
      }
      set
      {
        this.m_HasAdditiveReferencePose = !value ? 0 : 1;
      }
    }

    public void ConfigureMaskFromClip(ref AvatarMask mask)
    {
      mask.transformCount = this.m_TransformMask.Length;
      for (int index = 0; index < mask.transformCount; ++index)
      {
        mask.SetTransformPath(index, this.m_TransformMask[index].path);
        mask.SetTransformActive(index, (double) this.m_TransformMask[index].weight > 0.0);
      }
      for (int index = 0; index < this.m_BodyMask.Length; ++index)
        mask.SetHumanoidBodyPartActive((AvatarMaskBodyPart) index, this.m_BodyMask[index] != 0);
    }

    /// <summary>
    ///   <para>Copy the mask settings from an AvatarMask to the clip configuration.</para>
    /// </summary>
    /// <param name="mask">AvatarMask from which the mask settings will be imported.</param>
    public void ConfigureClipFromMask(AvatarMask mask)
    {
      this.m_TransformMask = new TransformMaskElement[mask.transformCount];
      for (int index = 0; index < mask.transformCount; ++index)
      {
        this.m_TransformMask[index].path = mask.GetTransformPath(index);
        this.m_TransformMask[index].weight = !mask.GetTransformActive(index) ? 0.0f : 1f;
      }
      this.m_BodyMask = new int[13];
      for (int index = 0; index < 13; ++index)
        this.m_BodyMask[index] = !mask.GetHumanoidBodyPartActive((AvatarMaskBodyPart) index) ? 0 : 1;
    }

    public override bool Equals(object o)
    {
      ModelImporterClipAnimation importerClipAnimation = o as ModelImporterClipAnimation;
      return importerClipAnimation != null && this.takeName == importerClipAnimation.takeName && (this.name == importerClipAnimation.name && (double) this.firstFrame == (double) importerClipAnimation.firstFrame) && ((double) this.lastFrame == (double) importerClipAnimation.lastFrame && this.m_WrapMode == importerClipAnimation.m_WrapMode && (this.m_Loop == importerClipAnimation.m_Loop && this.loopPose == importerClipAnimation.loopPose)) && (this.lockRootRotation == importerClipAnimation.lockRootRotation && this.lockRootHeightY == importerClipAnimation.lockRootHeightY && (this.lockRootPositionXZ == importerClipAnimation.lockRootPositionXZ && this.mirror == importerClipAnimation.mirror) && (this.maskType == importerClipAnimation.maskType && (UnityEngine.Object) this.maskSource == (UnityEngine.Object) importerClipAnimation.maskSource && (double) this.additiveReferencePoseFrame == (double) importerClipAnimation.additiveReferencePoseFrame)) && this.hasAdditiveReferencePose == importerClipAnimation.hasAdditiveReferencePose;
    }

    public override int GetHashCode()
    {
      return this.name.GetHashCode();
    }
  }
}
