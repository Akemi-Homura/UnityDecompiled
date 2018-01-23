﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.DoubleCurvePresetsContentsForPopupWindow
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEditor
{
  internal class DoubleCurvePresetsContentsForPopupWindow : PopupWindowContent
  {
    private bool m_WantsToClose = false;
    private PresetLibraryEditor<DoubleCurvePresetLibrary> m_CurveLibraryEditor;
    private PresetLibraryEditorState m_CurveLibraryEditorState;
    private DoubleCurve m_DoubleCurve;
    private Action<DoubleCurve> m_PresetSelectedCallback;

    public DoubleCurvePresetsContentsForPopupWindow(DoubleCurve doubleCurveToSave, Action<DoubleCurve> presetSelectedCallback)
    {
      this.m_DoubleCurve = doubleCurveToSave;
      this.m_PresetSelectedCallback = presetSelectedCallback;
    }

    public DoubleCurve doubleCurveToSave
    {
      get
      {
        return this.m_DoubleCurve;
      }
      set
      {
        this.m_DoubleCurve = value;
      }
    }

    public override void OnClose()
    {
      this.m_CurveLibraryEditorState.TransferEditorPrefsState(false);
    }

    public PresetLibraryEditor<DoubleCurvePresetLibrary> GetPresetLibraryEditor()
    {
      return this.m_CurveLibraryEditor;
    }

    private bool IsSingleCurve(DoubleCurve doubleCurve)
    {
      return doubleCurve.minCurve == null || doubleCurve.minCurve.length == 0;
    }

    private string GetEditorPrefBaseName()
    {
      return PresetLibraryLocations.GetParticleCurveLibraryExtension(this.m_DoubleCurve.IsSingleCurve(), this.m_DoubleCurve.signedRange);
    }

    public void InitIfNeeded()
    {
      if (this.m_CurveLibraryEditorState == null)
      {
        this.m_CurveLibraryEditorState = new PresetLibraryEditorState(this.GetEditorPrefBaseName());
        this.m_CurveLibraryEditorState.TransferEditorPrefsState(true);
      }
      if (this.m_CurveLibraryEditor != null)
        return;
      this.m_CurveLibraryEditor = new PresetLibraryEditor<DoubleCurvePresetLibrary>(new ScriptableObjectSaveLoadHelper<DoubleCurvePresetLibrary>(PresetLibraryLocations.GetParticleCurveLibraryExtension(this.m_DoubleCurve.IsSingleCurve(), this.m_DoubleCurve.signedRange), SaveType.Text), this.m_CurveLibraryEditorState, new Action<int, object>(this.ItemClickedCallback));
      this.m_CurveLibraryEditor.addDefaultPresets += new Action<PresetLibrary>(this.AddDefaultPresetsToLibrary);
      this.m_CurveLibraryEditor.presetsWasReordered = new Action(this.PresetsWasReordered);
      this.m_CurveLibraryEditor.previewAspect = 4f;
      this.m_CurveLibraryEditor.minMaxPreviewHeight = new Vector2(24f, 24f);
      this.m_CurveLibraryEditor.showHeader = true;
    }

    private void PresetsWasReordered()
    {
      InspectorWindow.RepaintAllInspectors();
    }

    public override void OnGUI(Rect rect)
    {
      this.InitIfNeeded();
      this.m_CurveLibraryEditor.OnGUI(rect, (object) this.m_DoubleCurve);
      if (!this.m_WantsToClose)
        return;
      this.editorWindow.Close();
    }

    private void ItemClickedCallback(int clickCount, object presetObject)
    {
      DoubleCurve doubleCurve = presetObject as DoubleCurve;
      if (doubleCurve == null)
        Debug.LogError((object) ("Incorrect object passed " + presetObject));
      this.m_PresetSelectedCallback(doubleCurve);
    }

    public override Vector2 GetWindowSize()
    {
      return new Vector2(240f, 330f);
    }

    private void AddDefaultPresetsToLibrary(PresetLibrary presetLibrary)
    {
      DoubleCurvePresetLibrary curvePresetLibrary = presetLibrary as DoubleCurvePresetLibrary;
      if ((UnityEngine.Object) curvePresetLibrary == (UnityEngine.Object) null)
      {
        Debug.Log((object) ("Incorrect preset library, should be a DoubleCurvePresetLibrary but was a " + (object) presetLibrary.GetType()));
      }
      else
      {
        bool signedRange = this.m_DoubleCurve.signedRange;
        List<DoubleCurve> doubleCurveList = new List<DoubleCurve>();
        foreach (DoubleCurve doubleCurve in !this.IsSingleCurve(this.m_DoubleCurve) ? (!signedRange ? DoubleCurvePresetsContentsForPopupWindow.GetUnsignedDoubleCurveDefaults() : DoubleCurvePresetsContentsForPopupWindow.GetSignedDoubleCurveDefaults()) : DoubleCurvePresetsContentsForPopupWindow.GetUnsignedSingleCurveDefaults(signedRange))
          curvePresetLibrary.Add((object) doubleCurve, "");
      }
    }

    private static List<DoubleCurve> GetUnsignedSingleCurveDefaults(bool signedRange)
    {
      return new List<DoubleCurve>() { new DoubleCurve((AnimationCurve) null, new AnimationCurve(CurveEditorWindow.GetConstantKeys(1f)), signedRange), new DoubleCurve((AnimationCurve) null, new AnimationCurve(CurveEditorWindow.GetLinearKeys()), signedRange), new DoubleCurve((AnimationCurve) null, new AnimationCurve(CurveEditorWindow.GetLinearMirrorKeys()), signedRange), new DoubleCurve((AnimationCurve) null, new AnimationCurve(CurveEditorWindow.GetEaseInKeys()), signedRange), new DoubleCurve((AnimationCurve) null, new AnimationCurve(CurveEditorWindow.GetEaseInMirrorKeys()), signedRange), new DoubleCurve((AnimationCurve) null, new AnimationCurve(CurveEditorWindow.GetEaseOutKeys()), signedRange), new DoubleCurve((AnimationCurve) null, new AnimationCurve(CurveEditorWindow.GetEaseOutMirrorKeys()), signedRange), new DoubleCurve((AnimationCurve) null, new AnimationCurve(CurveEditorWindow.GetEaseInOutKeys()), signedRange), new DoubleCurve((AnimationCurve) null, new AnimationCurve(CurveEditorWindow.GetEaseInOutMirrorKeys()), signedRange) };
    }

    private static List<DoubleCurve> GetUnsignedDoubleCurveDefaults()
    {
      return new List<DoubleCurve>() { new DoubleCurve(new AnimationCurve(CurveEditorWindow.GetConstantKeys(0.0f)), new AnimationCurve(CurveEditorWindow.GetConstantKeys(1f)), false) };
    }

    private static List<DoubleCurve> GetSignedDoubleCurveDefaults()
    {
      return new List<DoubleCurve>() { new DoubleCurve(new AnimationCurve(CurveEditorWindow.GetConstantKeys(-1f)), new AnimationCurve(CurveEditorWindow.GetConstantKeys(1f)), true) };
    }
  }
}
