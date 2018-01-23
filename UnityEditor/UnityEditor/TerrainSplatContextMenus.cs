﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.TerrainSplatContextMenus
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using UnityEngine;

namespace UnityEditor
{
  internal class TerrainSplatContextMenus
  {
    [MenuItem("CONTEXT/TerrainEngineSplats/Add Texture...")]
    internal static void AddSplat(MenuCommand item)
    {
      TerrainSplatEditor.ShowTerrainSplatEditor("Add Terrain Texture", "Add", (Terrain) item.context, -1);
    }

    [MenuItem("CONTEXT/TerrainEngineSplats/Edit Texture...")]
    internal static void EditSplat(MenuCommand item)
    {
      Terrain context = (Terrain) item.context;
      string title = "Edit Terrain Texture";
      switch (context.materialType)
      {
        case Terrain.MaterialType.BuiltInStandard:
          title += " (Standard)";
          break;
        case Terrain.MaterialType.BuiltInLegacyDiffuse:
          title += " (Diffuse)";
          break;
        case Terrain.MaterialType.BuiltInLegacySpecular:
          title += " (Specular)";
          break;
        case Terrain.MaterialType.Custom:
          title += " (Custom)";
          break;
      }
      TerrainSplatEditor.ShowTerrainSplatEditor(title, "Apply", (Terrain) item.context, item.userData);
    }

    [MenuItem("CONTEXT/TerrainEngineSplats/Edit Texture...", true)]
    internal static bool EditSplatCheck(MenuCommand item)
    {
      Terrain context = (Terrain) item.context;
      return item.userData >= 0 && item.userData < context.terrainData.splatPrototypes.Length;
    }

    [MenuItem("CONTEXT/TerrainEngineSplats/Remove Texture")]
    internal static void RemoveSplat(MenuCommand item)
    {
      TerrainEditorUtility.RemoveSplatTexture(((Terrain) item.context).terrainData, item.userData);
    }

    [MenuItem("CONTEXT/TerrainEngineSplats/Remove Texture", true)]
    internal static bool RemoveSplatCheck(MenuCommand item)
    {
      Terrain context = (Terrain) item.context;
      return item.userData >= 0 && item.userData < context.terrainData.splatPrototypes.Length;
    }
  }
}
