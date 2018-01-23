﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.ParticleSystemInspector
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityEditor
{
  [CustomEditor(typeof (ParticleSystem))]
  [CanEditMultipleObjects]
  internal class ParticleSystemInspector : Editor, ParticleEffectUIOwner
  {
    private GUIContent m_PreviewTitle = new GUIContent("Particle System Curves");
    private GUIContent showWindowText = new GUIContent("Open Editor...");
    private GUIContent closeWindowText = new GUIContent("Close Editor");
    private GUIContent hideWindowText = new GUIContent("Hide Editor");
    private ParticleEffectUI m_ParticleEffectUI;
    private static GUIContent m_PlayBackTitle;

    public static GUIContent playBackTitle
    {
      get
      {
        if (ParticleSystemInspector.m_PlayBackTitle == null)
          ParticleSystemInspector.m_PlayBackTitle = new GUIContent("Particle Effect");
        return ParticleSystemInspector.m_PlayBackTitle;
      }
    }

    private bool selectedInParticleSystemWindow
    {
      get
      {
        return (!((UnityEngine.Object) ParticleSystemEditorUtils.lockedParticleSystem == (UnityEngine.Object) null) ? (UnityEngine.Object) ParticleSystemEditorUtils.lockedParticleSystem.gameObject : (UnityEngine.Object) Selection.activeGameObject) == (UnityEngine.Object) (this.target as ParticleSystem).gameObject;
      }
    }

    public Editor customEditor
    {
      get
      {
        return (Editor) this;
      }
    }

    public void OnEnable()
    {
      EditorApplication.hierarchyWindowChanged += new EditorApplication.CallbackFunction(this.HierarchyOrProjectWindowWasChanged);
      EditorApplication.projectWindowChanged += new EditorApplication.CallbackFunction(this.HierarchyOrProjectWindowWasChanged);
      SceneView.onSceneGUIDelegate += new SceneView.OnSceneFunc(this.OnSceneViewGUI);
      Undo.undoRedoPerformed += new Undo.UndoRedoCallback(this.UndoRedoPerformed);
    }

    public void OnDisable()
    {
      SceneView.onSceneGUIDelegate -= new SceneView.OnSceneFunc(this.OnSceneViewGUI);
      EditorApplication.projectWindowChanged -= new EditorApplication.CallbackFunction(this.HierarchyOrProjectWindowWasChanged);
      EditorApplication.hierarchyWindowChanged -= new EditorApplication.CallbackFunction(this.HierarchyOrProjectWindowWasChanged);
      Undo.undoRedoPerformed -= new Undo.UndoRedoCallback(this.UndoRedoPerformed);
      if (this.m_ParticleEffectUI == null)
        return;
      this.m_ParticleEffectUI.Clear();
    }

    private void HierarchyOrProjectWindowWasChanged()
    {
      if (!(this.target != (UnityEngine.Object) null) || !this.ShouldShowInspector())
        return;
      this.Init(true);
    }

    private void UndoRedoPerformed()
    {
      this.Init(true);
      if (this.m_ParticleEffectUI == null)
        return;
      this.m_ParticleEffectUI.UndoRedoPerformed();
    }

    private void Init(bool forceInit)
    {
      IEnumerable<ParticleSystem> particleSystems = this.targets.OfType<ParticleSystem>().Where<ParticleSystem>((Func<ParticleSystem, bool>) (p => (UnityEngine.Object) p != (UnityEngine.Object) null));
      if (particleSystems == null || !particleSystems.Any<ParticleSystem>())
        this.m_ParticleEffectUI = (ParticleEffectUI) null;
      else if (this.m_ParticleEffectUI == null)
      {
        this.m_ParticleEffectUI = new ParticleEffectUI((ParticleEffectUIOwner) this);
        this.m_ParticleEffectUI.InitializeIfNeeded(particleSystems);
      }
      else
      {
        if (!forceInit)
          return;
        this.m_ParticleEffectUI.InitializeIfNeeded(particleSystems);
      }
    }

    private void ShowEdiorButtonGUI()
    {
      GUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      if (this.m_ParticleEffectUI == null || !this.m_ParticleEffectUI.multiEdit)
      {
        bool particleSystemWindow = this.selectedInParticleSystemWindow;
        GameObject gameObject = (this.target as ParticleSystem).gameObject;
        ParticleSystemWindow instance = ParticleSystemWindow.GetInstance();
        if ((bool) ((UnityEngine.Object) instance))
          instance.customEditor = (Editor) this;
        if (GUILayout.Button(!(bool) ((UnityEngine.Object) instance) || !instance.IsVisible() || !particleSystemWindow ? this.showWindowText : (instance.GetNumTabs() <= 1 ? this.closeWindowText : this.hideWindowText), EditorStyles.miniButton, new GUILayoutOption[1]{ GUILayout.Width(110f) }))
        {
          if ((bool) ((UnityEngine.Object) instance) && instance.IsVisible() && particleSystemWindow)
          {
            if (!instance.ShowNextTabIfPossible())
              instance.Close();
          }
          else
          {
            if (!particleSystemWindow)
            {
              ParticleSystemEditorUtils.lockedParticleSystem = (ParticleSystem) null;
              Selection.activeGameObject = gameObject;
            }
            if ((bool) ((UnityEngine.Object) instance))
            {
              if (!particleSystemWindow)
                instance.Clear();
              instance.Focus();
            }
            else
            {
              this.Clear();
              ParticleSystemWindow.CreateWindow();
              ParticleSystemWindow.GetInstance().customEditor = (Editor) this;
              GUIUtility.ExitGUI();
            }
          }
        }
      }
      GUILayout.EndHorizontal();
    }

    public override bool UseDefaultMargins()
    {
      return false;
    }

    public override void OnInspectorGUI()
    {
      EditorGUILayout.BeginVertical(EditorStyles.inspectorDefaultMargins, new GUILayoutOption[0]);
      this.ShowEdiorButtonGUI();
      if (this.ShouldShowInspector())
      {
        if (this.m_ParticleEffectUI == null)
          this.Init(true);
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical(EditorStyles.inspectorFullWidthMargins, new GUILayoutOption[0]);
        this.m_ParticleEffectUI.OnGUI();
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical(EditorStyles.inspectorDefaultMargins, new GUILayoutOption[0]);
      }
      else
        this.Clear();
      EditorGUILayout.EndVertical();
    }

    private void Clear()
    {
      if (this.m_ParticleEffectUI != null)
        this.m_ParticleEffectUI.Clear();
      this.m_ParticleEffectUI = (ParticleEffectUI) null;
    }

    private bool ShouldShowInspector()
    {
      ParticleSystemWindow instance = ParticleSystemWindow.GetInstance();
      return !(bool) ((UnityEngine.Object) instance) || !instance.IsVisible() || !this.selectedInParticleSystemWindow;
    }

    public void OnSceneViewGUI(SceneView sceneView)
    {
      if (!this.ShouldShowInspector())
        return;
      this.Init(false);
      if (this.m_ParticleEffectUI != null)
        this.m_ParticleEffectUI.OnSceneViewGUI();
    }

    public override bool HasPreviewGUI()
    {
      return this.ShouldShowInspector();
    }

    public override void DrawPreview(Rect previewArea)
    {
      ObjectPreview.DrawPreview((IPreviewable) this, previewArea, new UnityEngine.Object[1]
      {
        this.targets[0]
      });
    }

    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
      if (this.m_ParticleEffectUI == null)
        return;
      this.m_ParticleEffectUI.GetParticleSystemCurveEditor().OnGUI(r);
    }

    public override GUIContent GetPreviewTitle()
    {
      return this.m_PreviewTitle;
    }

    public override void OnPreviewSettings()
    {
    }
  }
}
