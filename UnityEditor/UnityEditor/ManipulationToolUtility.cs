﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.ManipulationToolUtility
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using UnityEngine;

namespace UnityEditor
{
  internal class ManipulationToolUtility
  {
    public static ManipulationToolUtility.HandleDragChange handleDragChange;

    public static Vector3 minDragDifference { get; set; }

    public static void SetMinDragDifferenceForPos(Vector3 position)
    {
      ManipulationToolUtility.minDragDifference = Vector3.one * (HandleUtility.GetHandleSize(position) / 80f);
    }

    public static void SetMinDragDifferenceForPos(Vector3 position, float multiplier)
    {
      ManipulationToolUtility.minDragDifference = Vector3.one * (float) ((double) HandleUtility.GetHandleSize(position) * (double) multiplier / 80.0);
    }

    public static void DisableMinDragDifference()
    {
      ManipulationToolUtility.minDragDifference = Vector3.zero;
    }

    public static void DisableMinDragDifferenceForAxis(int axis)
    {
      Vector2 minDragDifference = (Vector2) ManipulationToolUtility.minDragDifference;
      minDragDifference[axis] = 0.0f;
      ManipulationToolUtility.minDragDifference = (Vector3) minDragDifference;
    }

    public static void DisableMinDragDifferenceBasedOnSnapping(Vector3 positionBeforeSnapping, Vector3 positionAfterSnapping)
    {
      for (int axis = 0; axis < 3; ++axis)
      {
        if ((double) positionBeforeSnapping[axis] != (double) positionAfterSnapping[axis])
          ManipulationToolUtility.DisableMinDragDifferenceForAxis(axis);
      }
    }

    public static void BeginDragging(string handleName)
    {
      if (ManipulationToolUtility.handleDragChange == null)
        return;
      ManipulationToolUtility.handleDragChange(handleName, true);
    }

    public static void EndDragging(string handleName)
    {
      if (ManipulationToolUtility.handleDragChange == null)
        return;
      ManipulationToolUtility.handleDragChange(handleName, false);
    }

    public static void DetectDraggingBasedOnMouseDownUp(string handleName, EventType typeBefore)
    {
      if (typeBefore == EventType.MouseDrag && Event.current.type != EventType.MouseDrag)
      {
        ManipulationToolUtility.BeginDragging(handleName);
      }
      else
      {
        if (typeBefore != EventType.MouseUp || Event.current.type == EventType.MouseUp)
          return;
        ManipulationToolUtility.EndDragging(handleName);
      }
    }

    public delegate void HandleDragChange(string handleName, bool dragging);
  }
}
