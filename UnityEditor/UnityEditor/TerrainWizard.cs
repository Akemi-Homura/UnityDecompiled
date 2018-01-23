﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.TerrainWizard
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using UnityEngine;

namespace UnityEditor
{
  internal class TerrainWizard : ScriptableWizard
  {
    internal const int kMaxResolution = 4097;
    protected Terrain m_Terrain;

    protected TerrainData terrainData
    {
      get
      {
        if ((Object) this.m_Terrain != (Object) null)
          return this.m_Terrain.terrainData;
        return (TerrainData) null;
      }
    }

    internal virtual void OnWizardUpdate()
    {
      this.isValid = true;
      this.errorString = "";
      if (!((Object) this.m_Terrain == (Object) null) && !((Object) this.m_Terrain.terrainData == (Object) null))
        return;
      this.isValid = false;
      this.errorString = "Terrain does not exist";
    }

    internal void InitializeDefaults(Terrain terrain)
    {
      this.m_Terrain = terrain;
      this.OnWizardUpdate();
    }

    internal void FlushHeightmapModification()
    {
      this.m_Terrain.Flush();
    }

    internal static T DisplayTerrainWizard<T>(string title, string button) where T : TerrainWizard
    {
      T[] objectsOfTypeAll = UnityEngine.Resources.FindObjectsOfTypeAll<T>();
      if (objectsOfTypeAll.Length <= 0)
        return ScriptableWizard.DisplayWizard<T>(title, button);
      T obj = objectsOfTypeAll[0];
      obj.titleContent = EditorGUIUtility.TextContent(title);
      obj.createButtonName = button;
      obj.otherButtonName = "";
      obj.Focus();
      return obj;
    }
  }
}
