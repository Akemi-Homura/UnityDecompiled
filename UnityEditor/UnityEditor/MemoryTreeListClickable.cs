﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.MemoryTreeListClickable
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using UnityEngine;

namespace UnityEditor
{
  internal class MemoryTreeListClickable : MemoryTreeList
  {
    public MemoryTreeListClickable(EditorWindow editorWindow, MemoryTreeList detailview)
      : base(editorWindow, detailview)
    {
    }

    protected override void SetupSplitter()
    {
      float[] relativeSizes = new float[3];
      int[] minSizes = new int[3];
      relativeSizes[0] = 300f;
      minSizes[0] = 100;
      relativeSizes[1] = 70f;
      minSizes[1] = 50;
      relativeSizes[2] = 70f;
      minSizes[2] = 50;
      this.m_Splitter = new SplitterState(relativeSizes, minSizes, (int[]) null);
    }

    protected override void DrawHeader()
    {
      GUILayout.Label("Name", MemoryTreeList.styles.header, new GUILayoutOption[0]);
      GUILayout.Label("Memory", MemoryTreeList.styles.header, new GUILayoutOption[0]);
      GUILayout.Label("Ref count", MemoryTreeList.styles.header, new GUILayoutOption[0]);
    }

    protected override void DrawData(Rect rect, MemoryElement memoryElement, int indent, int row, bool selected)
    {
      if (Event.current.type != EventType.Repaint)
        return;
      string text = memoryElement.name;
      if (memoryElement.ChildCount() > 0 && indent < 3)
        text = text + " (" + memoryElement.AccumulatedChildCount().ToString() + ")";
      int index1 = 0;
      rect.xMax = (float) this.m_Splitter.realSizes[index1];
      MemoryTreeList.styles.numberLabel.Draw(rect, text, false, false, false, selected);
      rect.x = rect.xMax;
      int num1;
      rect.width = (float) this.m_Splitter.realSizes[num1 = index1 + 1] - 4f;
      MemoryTreeList.styles.numberLabel.Draw(rect, EditorUtility.FormatBytes(memoryElement.totalMemory), false, false, false, selected);
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Rect& local = @rect;
      // ISSUE: explicit reference operation
      double x = (double) (^local).x;
      int[] realSizes = this.m_Splitter.realSizes;
      int index2 = num1;
      int index3 = index2 + 1;
      double num2 = (double) realSizes[index2];
      // ISSUE: explicit reference operation
      (^local).x = (float) (x + num2);
      rect.width = (float) this.m_Splitter.realSizes[index3] - 4f;
      if (memoryElement.ReferenceCount() > 0)
      {
        MemoryTreeList.styles.numberLabel.Draw(rect, memoryElement.ReferenceCount().ToString(), false, false, false, selected);
      }
      else
      {
        if (!selected)
          return;
        MemoryTreeList.styles.numberLabel.Draw(rect, "", false, false, false, selected);
      }
    }
  }
}
