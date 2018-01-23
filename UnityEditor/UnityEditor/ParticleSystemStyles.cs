﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.ParticleSystemStyles
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using UnityEngine;

namespace UnityEditor
{
  internal class ParticleSystemStyles
  {
    public GUIStyle label = ParticleSystemStyles.FindStyle("ShurikenLabel");
    public GUIStyle editableLabel = ParticleSystemStyles.FindStyle("ShurikenEditableLabel");
    public GUIStyle numberField = ParticleSystemStyles.FindStyle("ShurikenValue");
    public GUIStyle objectField = ParticleSystemStyles.FindStyle("ShurikenObjectField");
    public GUIStyle effectBgStyle = ParticleSystemStyles.FindStyle("ShurikenEffectBg");
    public GUIStyle emitterHeaderStyle = ParticleSystemStyles.FindStyle("ShurikenEmitterTitle");
    public GUIStyle moduleHeaderStyle = ParticleSystemStyles.FindStyle("ShurikenModuleTitle");
    public GUIStyle moduleBgStyle = ParticleSystemStyles.FindStyle("ShurikenModuleBg");
    public GUIStyle plus = ParticleSystemStyles.FindStyle("ShurikenPlus");
    public GUIStyle minus = ParticleSystemStyles.FindStyle("ShurikenMinus");
    public GUIStyle checkmark = ParticleSystemStyles.FindStyle("ShurikenCheckMark");
    public GUIStyle checkmarkMixed = ParticleSystemStyles.FindStyle("ShurikenCheckMarkMixed");
    public GUIStyle minMaxCurveStateDropDown = ParticleSystemStyles.FindStyle("ShurikenDropdown");
    public GUIStyle toggle = ParticleSystemStyles.FindStyle("ShurikenToggle");
    public GUIStyle toggleMixed = ParticleSystemStyles.FindStyle("ShurikenToggleMixed");
    public GUIStyle popup = ParticleSystemStyles.FindStyle("ShurikenPopUp");
    public GUIStyle selectionMarker = ParticleSystemStyles.FindStyle("IN ThumbnailShadow");
    public GUIStyle toolbarButtonLeftAlignText = new GUIStyle(ParticleSystemStyles.FindStyle("ToolbarButton"));
    public GUIStyle modulePadding = new GUIStyle();
    private static ParticleSystemStyles s_ParticleSystemStyles;
    public Texture2D warningIcon;

    private ParticleSystemStyles()
    {
      this.emitterHeaderStyle.clipping = TextClipping.Clip;
      this.emitterHeaderStyle.padding.right = 45;
      this.warningIcon = EditorGUIUtility.LoadIcon("console.infoicon.sml");
      this.toolbarButtonLeftAlignText.alignment = TextAnchor.MiddleLeft;
      this.modulePadding.padding = new RectOffset(3, 3, 4, 2);
    }

    public static ParticleSystemStyles Get()
    {
      if (ParticleSystemStyles.s_ParticleSystemStyles == null)
        ParticleSystemStyles.s_ParticleSystemStyles = new ParticleSystemStyles();
      return ParticleSystemStyles.s_ParticleSystemStyles;
    }

    private static GUIStyle FindStyle(string styleName)
    {
      return (GUIStyle) styleName;
    }
  }
}
