﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.ObjectListAreaState
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEditor
{
  [Serializable]
  internal class ObjectListAreaState
  {
    public List<int> m_SelectedInstanceIDs = new List<int>();
    public List<int> m_ExpandedInstanceIDs = new List<int>();
    public RenameOverlay m_RenameOverlay = new RenameOverlay();
    public CreateAssetUtility m_CreateAssetUtility = new CreateAssetUtility();
    public int m_NewAssetIndexInList = -1;
    public int m_GridSize = 64;
    public int m_LastClickedInstanceID;
    public bool m_HadKeyboardFocusLastEvent;
    public Vector2 m_ScrollPosition;

    public void OnAwake()
    {
      this.m_NewAssetIndexInList = -1;
      this.m_RenameOverlay.Clear();
      this.m_CreateAssetUtility = new CreateAssetUtility();
    }
  }
}
