﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.PreviewWindow
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using UnityEngine;

namespace UnityEditor
{
  internal class PreviewWindow : InspectorWindow
  {
    [SerializeField]
    private InspectorWindow m_ParentInspectorWindow;

    public void SetParentInspector(InspectorWindow inspector)
    {
      this.m_ParentInspectorWindow = inspector;
      this.CreateTracker();
    }

    protected override void OnEnable()
    {
      base.OnEnable();
      this.titleContent = EditorGUIUtility.TextContent("Preview");
      this.minSize = new Vector2(260f, 220f);
    }

    protected override void OnDisable()
    {
      base.OnDisable();
      this.m_ParentInspectorWindow.Repaint();
    }

    protected override void CreateTracker()
    {
      if (!((Object) this.m_ParentInspectorWindow != (Object) null))
        return;
      this.m_Tracker = this.m_ParentInspectorWindow.tracker;
    }

    public override Editor GetLastInteractedEditor()
    {
      return this.m_ParentInspectorWindow.GetLastInteractedEditor();
    }

    protected override void OnGUI()
    {
      if (!(bool) ((Object) this.m_ParentInspectorWindow))
      {
        this.Close();
        GUIUtility.ExitGUI();
      }
      Editor.m_AllowMultiObjectAccess = true;
      this.CreatePreviewables();
      this.AssignAssetEditor(this.tracker.activeEditors);
      IPreviewable thatControlsPreview = this.GetEditorThatControlsPreview(this.GetEditorsWithPreviews(this.tracker.activeEditors));
      bool flag = thatControlsPreview != null && thatControlsPreview.HasPreviewGUI();
      Rect rect1 = EditorGUILayout.BeginHorizontal(GUIContent.none, InspectorWindow.styles.preToolbar, GUILayout.Height(17f));
      GUILayout.FlexibleSpace();
      Rect lastRect = GUILayoutUtility.GetLastRect();
      string text = string.Empty;
      if (thatControlsPreview != null)
        text = thatControlsPreview.GetPreviewTitle().text;
      GUI.Label(lastRect, text, InspectorWindow.styles.preToolbar2);
      if (flag)
        thatControlsPreview.OnPreviewSettings();
      EditorGUILayout.EndHorizontal();
      Event current = Event.current;
      if (current.type == EventType.MouseUp && current.button == 1 && rect1.Contains(current.mousePosition))
      {
        this.Close();
        current.Use();
      }
      else
      {
        Rect rect2 = GUILayoutUtility.GetRect(0.0f, 10240f, 64f, 10240f);
        if (Event.current.type == EventType.Repaint)
          InspectorWindow.styles.preBackground.Draw(rect2, false, false, false, false);
        if (thatControlsPreview == null || !thatControlsPreview.HasPreviewGUI())
          return;
        thatControlsPreview.DrawPreview(rect2);
      }
    }

    public override void AddItemsToMenu(GenericMenu menu)
    {
    }

    protected override void ShowButton(Rect r)
    {
    }
  }
}
