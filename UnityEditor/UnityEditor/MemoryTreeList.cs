﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.MemoryTreeList
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System.Collections.Generic;
using UnityEngine;

namespace UnityEditor
{
  internal class MemoryTreeList
  {
    protected MemoryElement m_Root = (MemoryElement) null;
    private static MemoryTreeList.Styles m_Styles;
    private bool m_RequiresRefresh;
    private const float kIndentPx = 16f;
    private const float kBaseIndent = 4f;
    protected const float kSmallMargin = 4f;
    protected const float kRowHeight = 16f;
    protected const float kNameColumnSize = 300f;
    protected const float kColumnSize = 70f;
    protected const float kFoldoutSize = 14f;
    public MemoryElementSelection m_MemorySelection;
    protected EditorWindow m_EditorWindow;
    protected SplitterState m_Splitter;
    protected MemoryTreeList m_DetailView;
    protected int m_ControlID;
    protected Vector2 m_ScrollPosition;
    protected float m_SelectionOffset;
    protected float m_VisibleHeight;

    public MemoryTreeList(EditorWindow editorWindow, MemoryTreeList detailview)
    {
      this.m_MemorySelection = new MemoryElementSelection();
      this.m_EditorWindow = editorWindow;
      this.m_DetailView = detailview;
      this.m_ControlID = GUIUtility.GetPermanentControlID();
      this.SetupSplitter();
    }

    protected static MemoryTreeList.Styles styles
    {
      get
      {
        return MemoryTreeList.m_Styles ?? (MemoryTreeList.m_Styles = new MemoryTreeList.Styles());
      }
    }

    public bool RequiresRefresh
    {
      get
      {
        return this.m_RequiresRefresh;
      }
      set
      {
        this.m_RequiresRefresh = value;
      }
    }

    protected virtual void SetupSplitter()
    {
      float[] relativeSizes = new float[1];
      int[] minSizes = new int[1];
      relativeSizes[0] = 300f;
      minSizes[0] = 100;
      this.m_Splitter = new SplitterState(relativeSizes, minSizes, (int[]) null);
    }

    public void OnGUI()
    {
      GUILayout.BeginVertical();
      SplitterGUILayout.BeginHorizontalSplit(this.m_Splitter, EditorStyles.toolbar, new GUILayoutOption[0]);
      this.DrawHeader();
      SplitterGUILayout.EndHorizontalSplit();
      if (this.m_Root == null)
      {
        GUILayout.EndVertical();
      }
      else
      {
        this.HandleKeyboard();
        this.m_ScrollPosition = GUILayout.BeginScrollView(this.m_ScrollPosition, MemoryTreeList.styles.background);
        int row = 0;
        foreach (MemoryElement child in this.m_Root.children)
        {
          this.DrawItem(child, ref row, 1);
          ++row;
        }
        GUILayoutUtility.GetRect(0.0f, (float) ((double) row * 16.0), new GUILayoutOption[1]
        {
          GUILayout.ExpandWidth(true)
        });
        if (Event.current.type == EventType.Repaint)
          this.m_VisibleHeight = GUIClip.visibleRect.height;
        GUILayout.EndScrollView();
        GUILayout.EndVertical();
      }
    }

    private static float Clamp(float value, float min, float max)
    {
      return (double) value >= (double) min ? ((double) value <= (double) max ? value : max) : min;
    }

    private bool FindNamedChild(string name, List<MemoryElement> list, out MemoryElement outChild)
    {
      foreach (MemoryElement memoryElement in list)
      {
        if (memoryElement.name == name)
        {
          outChild = memoryElement;
          return true;
        }
      }
      outChild = (MemoryElement) null;
      return false;
    }

    private void RestoreViewState(MemoryElement oldRoot, MemoryElement newRoot)
    {
      foreach (MemoryElement child in newRoot.children)
      {
        child.ExpandChildren();
        if (child.ChildCount() != 0)
        {
          MemoryElement outChild = (MemoryElement) null;
          if (this.FindNamedChild(child.name, oldRoot.children, out outChild))
          {
            child.expanded = outChild.expanded;
            if (child.expanded)
              this.RestoreViewState(outChild, child);
          }
        }
      }
    }

    public void SetRoot(MemoryElement root)
    {
      MemoryElement root1 = this.m_Root;
      this.m_Root = root;
      if (this.m_Root != null)
        this.m_Root.ExpandChildren();
      if (this.m_DetailView != null)
        this.m_DetailView.SetRoot((MemoryElement) null);
      if (root1 == null || this.m_Root == null)
        return;
      this.RestoreViewState(root1, this.m_Root);
    }

    public MemoryElement GetRoot()
    {
      return this.m_Root;
    }

    protected static void DrawBackground(int row, bool selected)
    {
      Rect rect = MemoryTreeList.GenerateRect(row);
      GUIStyle guiStyle = row % 2 != 0 ? MemoryTreeList.styles.entryOdd : MemoryTreeList.styles.entryEven;
      if (Event.current.type != EventType.Repaint)
        return;
      guiStyle.Draw(rect, GUIContent.none, false, false, selected, false);
    }

    protected virtual void DrawHeader()
    {
      GUILayout.Label("Referenced By:", MemoryTreeList.styles.header, new GUILayoutOption[0]);
    }

    protected static Rect GenerateRect(int row)
    {
      return new Rect(1f, 16f * (float) row, GUIClip.visibleRect.width, 16f);
    }

    protected virtual void DrawData(Rect rect, MemoryElement memoryElement, int indent, int row, bool selected)
    {
      if (Event.current.type != EventType.Repaint)
        return;
      string text = memoryElement.name + "(" + memoryElement.memoryInfo.className + ")";
      MemoryTreeList.styles.numberLabel.Draw(rect, text, false, false, false, selected);
    }

    protected void DrawRecursiveData(MemoryElement element, ref int row, int indent)
    {
      if (element.ChildCount() == 0)
        return;
      element.ExpandChildren();
      foreach (MemoryElement child in element.children)
      {
        ++row;
        this.DrawItem(child, ref row, indent);
      }
    }

    protected virtual void DrawItem(MemoryElement memoryElement, ref int row, int indent)
    {
      bool selected = this.m_MemorySelection.isSelected(memoryElement);
      MemoryTreeList.DrawBackground(row, selected);
      Rect rect = MemoryTreeList.GenerateRect(row);
      rect.x = (float) (4.0 + (double) indent * 16.0 - 14.0);
      Rect position = rect;
      position.width = 14f;
      if (memoryElement.ChildCount() > 0)
        memoryElement.expanded = GUI.Toggle(position, memoryElement.expanded, GUIContent.none, MemoryTreeList.styles.foldout);
      rect.x += 14f;
      if (selected)
        this.m_SelectionOffset = (float) row * 16f;
      if (Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition))
        this.RowClicked(Event.current, memoryElement);
      this.DrawData(rect, memoryElement, indent, row, selected);
      if (!memoryElement.expanded)
        return;
      this.DrawRecursiveData(memoryElement, ref row, indent + 1);
    }

    protected void RowClicked(Event evt, MemoryElement memoryElement)
    {
      this.m_MemorySelection.SetSelection(memoryElement);
      GUIUtility.keyboardControl = this.m_ControlID;
      if (evt.clickCount == 2 && memoryElement.memoryInfo != null && memoryElement.memoryInfo.instanceId != 0)
      {
        Selection.instanceIDs = new int[0];
        Selection.activeInstanceID = memoryElement.memoryInfo.instanceId;
      }
      evt.Use();
      if (memoryElement.memoryInfo != null)
        EditorGUIUtility.PingObject(memoryElement.memoryInfo.instanceId);
      if (this.m_DetailView != null)
        this.m_DetailView.SetRoot(memoryElement.memoryInfo != null ? new MemoryElement(memoryElement.memoryInfo, false) : (MemoryElement) null);
      this.m_EditorWindow.Repaint();
    }

    protected void HandleKeyboard()
    {
      Event current = Event.current;
      if (current.GetTypeForControl(this.m_ControlID) != EventType.KeyDown || this.m_ControlID != GUIUtility.keyboardControl || this.m_MemorySelection.Selected == null)
        return;
      KeyCode keyCode = current.keyCode;
      switch (keyCode)
      {
        case KeyCode.UpArrow:
          this.m_MemorySelection.MoveUp();
          break;
        case KeyCode.DownArrow:
          this.m_MemorySelection.MoveDown();
          break;
        case KeyCode.RightArrow:
          if (this.m_MemorySelection.Selected.ChildCount() > 0)
          {
            this.m_MemorySelection.Selected.expanded = true;
            break;
          }
          break;
        case KeyCode.LeftArrow:
          if (this.m_MemorySelection.Selected.expanded)
          {
            this.m_MemorySelection.Selected.expanded = false;
            break;
          }
          this.m_MemorySelection.MoveParent();
          break;
        case KeyCode.Home:
          this.m_MemorySelection.MoveFirst();
          break;
        case KeyCode.End:
          this.m_MemorySelection.MoveLast();
          break;
        case KeyCode.PageUp:
          int num1 = Mathf.RoundToInt(this.m_VisibleHeight / 16f);
          for (int index = 0; index < num1; ++index)
            this.m_MemorySelection.MoveUp();
          break;
        case KeyCode.PageDown:
          int num2 = Mathf.RoundToInt(this.m_VisibleHeight / 16f);
          for (int index = 0; index < num2; ++index)
            this.m_MemorySelection.MoveDown();
          break;
        default:
          if (keyCode != KeyCode.Return)
            return;
          if (this.m_MemorySelection.Selected.memoryInfo != null)
          {
            Selection.instanceIDs = new int[0];
            Selection.activeInstanceID = this.m_MemorySelection.Selected.memoryInfo.instanceId;
            break;
          }
          break;
      }
      this.RowClicked(current, this.m_MemorySelection.Selected);
      this.EnsureVisible();
      this.m_EditorWindow.Repaint();
    }

    private void RecursiveFindSelected(MemoryElement element, ref int row)
    {
      if (this.m_MemorySelection.isSelected(element))
        this.m_SelectionOffset = (float) row * 16f;
      ++row;
      if (!element.expanded || element.ChildCount() == 0)
        return;
      element.ExpandChildren();
      foreach (MemoryElement child in element.children)
        this.RecursiveFindSelected(child, ref row);
    }

    protected void EnsureVisible()
    {
      int row = 0;
      this.RecursiveFindSelected(this.m_Root, ref row);
      this.m_ScrollPosition.y = MemoryTreeList.Clamp(this.m_ScrollPosition.y, this.m_SelectionOffset - this.m_VisibleHeight, this.m_SelectionOffset - 16f);
    }

    internal class Styles
    {
      public GUIStyle background = (GUIStyle) "OL Box";
      public GUIStyle header = (GUIStyle) "OL title";
      public GUIStyle entryEven = (GUIStyle) "OL EntryBackEven";
      public GUIStyle entryOdd = (GUIStyle) "OL EntryBackOdd";
      public GUIStyle numberLabel = (GUIStyle) "OL Label";
      public GUIStyle foldout = (GUIStyle) "IN foldout";
    }
  }
}
