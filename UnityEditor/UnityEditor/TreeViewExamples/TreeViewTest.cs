﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.TreeViewExamples.TreeViewTest
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.Profiling;

namespace UnityEditor.TreeViewExamples
{
  internal class TreeViewTest
  {
    private BackendData m_BackendData;
    private TreeViewController m_TreeView;
    private EditorWindow m_EditorWindow;
    private bool m_Lazy;
    private TreeViewColumnHeader m_ColumnHeader;
    private GUIStyle m_HeaderStyle;
    private GUIStyle m_HeaderStyleRightAligned;

    public TreeViewTest(EditorWindow editorWindow, bool lazy)
    {
      this.m_EditorWindow = editorWindow;
      this.m_Lazy = lazy;
    }

    public int GetNumItemsInData()
    {
      return this.m_BackendData.IDCounter;
    }

    public int GetNumItemsInTree()
    {
      LazyTestDataSource data1 = this.m_TreeView.data as LazyTestDataSource;
      if (data1 != null)
        return data1.itemCounter;
      TestDataSource data2 = this.m_TreeView.data as TestDataSource;
      if (data2 != null)
        return data2.itemCounter;
      return -1;
    }

    public void Init(Rect rect, BackendData backendData)
    {
      if (this.m_TreeView != null)
        return;
      this.m_BackendData = backendData;
      TreeViewStateWithColumns stateWithColumns = new TreeViewStateWithColumns();
      stateWithColumns.columnWidths = new float[6]
      {
        250f,
        90f,
        93f,
        98f,
        74f,
        78f
      };
      this.m_TreeView = new TreeViewController(this.m_EditorWindow, (TreeViewState) stateWithColumns);
      ITreeViewGUI gui = (ITreeViewGUI) new TestGUI(this.m_TreeView);
      ITreeViewDragging dragging = (ITreeViewDragging) new TestDragging(this.m_TreeView, this.m_BackendData);
      ITreeViewDataSource data = !this.m_Lazy ? (ITreeViewDataSource) new TestDataSource(this.m_TreeView, this.m_BackendData) : (ITreeViewDataSource) new LazyTestDataSource(this.m_TreeView, this.m_BackendData);
      this.m_TreeView.Init(rect, data, gui, dragging);
      this.m_ColumnHeader = new TreeViewColumnHeader();
      this.m_ColumnHeader.columnWidths = stateWithColumns.columnWidths;
      this.m_ColumnHeader.minColumnWidth = 30f;
      this.m_ColumnHeader.columnRenderer += new Action<int, Rect>(this.OnColumnRenderer);
    }

    private void OnColumnRenderer(int column, Rect rect)
    {
      if (this.m_HeaderStyle == null)
      {
        this.m_HeaderStyle = new GUIStyle(EditorStyles.toolbarButton);
        this.m_HeaderStyle.padding.left = 4;
        this.m_HeaderStyle.alignment = TextAnchor.MiddleLeft;
        this.m_HeaderStyleRightAligned = new GUIStyle(EditorStyles.toolbarButton);
        this.m_HeaderStyleRightAligned.padding.right = 4;
        this.m_HeaderStyleRightAligned.alignment = TextAnchor.MiddleRight;
      }
      string[] strArray = new string[8]{ "Name", "Date Modified", "Size", "Kind", "Author", "Platform", "Faster", "Slower" };
      GUI.Label(rect, strArray[column], column % 2 != 0 ? this.m_HeaderStyleRightAligned : this.m_HeaderStyle);
    }

    public void OnGUI(Rect rect)
    {
      int controlId = GUIUtility.GetControlID(FocusType.Keyboard, rect);
      Rect rect1 = new Rect(rect.x, rect.y, rect.width, 17f);
      Rect screenRect = new Rect(rect.x, rect.yMax - 20f, rect.width, 20f);
      GUI.Label(rect1, "", EditorStyles.toolbar);
      this.m_ColumnHeader.OnGUI(rect1);
      Profiler.BeginSample("TREEVIEW");
      rect.y += rect1.height;
      rect.height -= rect1.height + screenRect.height;
      this.m_TreeView.OnEvent();
      this.m_TreeView.OnGUI(rect, controlId);
      Profiler.EndSample();
      GUILayout.BeginArea(screenRect, this.GetHeader(), EditorStyles.helpBox);
      GUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      this.m_BackendData.m_RecursiveFindParentsBelow = GUILayout.Toggle(this.m_BackendData.m_RecursiveFindParentsBelow, GUIContent.Temp("Recursive"));
      if (GUILayout.Button("Ping", EditorStyles.miniButton, new GUILayoutOption[0]))
      {
        int id = this.GetNumItemsInData() / 2;
        this.m_TreeView.Frame(id, true, true);
        this.m_TreeView.SetSelection(new int[1]{ id }, false);
      }
      if (GUILayout.Button("Frame", EditorStyles.miniButton, new GUILayoutOption[0]))
      {
        int id = this.GetNumItemsInData() / 10;
        this.m_TreeView.Frame(id, true, false);
        this.m_TreeView.SetSelection(new int[1]{ id }, false);
      }
      GUILayout.EndHorizontal();
      GUILayout.EndArea();
    }

    private string GetHeader()
    {
      return (!this.m_Lazy ? (object) "FULL: " : (object) "LAZY: ").ToString() + "GUI items: " + (object) this.GetNumItemsInTree() + "  (data items: " + (object) this.GetNumItemsInData() + ")";
    }
  }
}
