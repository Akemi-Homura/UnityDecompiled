﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.ExportRawHeightmap
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System;
using System.IO;
using UnityEngine;

namespace UnityEditor
{
  internal class ExportRawHeightmap : TerrainWizard
  {
    public ExportRawHeightmap.Depth m_Depth = ExportRawHeightmap.Depth.Bit16;
    public ExportRawHeightmap.ByteOrder m_ByteOrder = ExportRawHeightmap.ByteOrder.Windows;
    public bool m_FlipVertically = false;

    public void OnEnable()
    {
      this.minSize = new Vector2(400f, 200f);
    }

    internal void OnWizardCreate()
    {
      if ((UnityEngine.Object) this.m_Terrain == (UnityEngine.Object) null)
      {
        this.isValid = false;
        this.errorString = "Terrain does not exist";
      }
      string path = EditorUtility.SaveFilePanel("Save Raw Heightmap", "", "terrain", "raw");
      if (!(path != ""))
        return;
      this.WriteRaw(path);
    }

    internal override void OnWizardUpdate()
    {
      base.OnWizardUpdate();
      if (!(bool) ((UnityEngine.Object) this.terrainData))
        return;
      this.helpString = "Width " + (object) this.terrainData.heightmapWidth + "\nHeight " + (object) this.terrainData.heightmapHeight;
    }

    private void WriteRaw(string path)
    {
      int heightmapWidth = this.terrainData.heightmapWidth;
      int heightmapHeight = this.terrainData.heightmapHeight;
      float[,] heights = this.terrainData.GetHeights(0, 0, heightmapWidth, heightmapHeight);
      byte[] buffer = new byte[heightmapWidth * heightmapHeight * (int) this.m_Depth];
      if (this.m_Depth == ExportRawHeightmap.Depth.Bit16)
      {
        float num1 = 65536f;
        for (int index1 = 0; index1 < heightmapHeight; ++index1)
        {
          for (int index2 = 0; index2 < heightmapWidth; ++index2)
          {
            int num2 = index2 + index1 * heightmapWidth;
            int index3 = !this.m_FlipVertically ? index1 : heightmapHeight - 1 - index1;
            byte[] bytes = BitConverter.GetBytes((ushort) Mathf.Clamp(Mathf.RoundToInt(heights[index3, index2] * num1), 0, (int) ushort.MaxValue));
            if (this.m_ByteOrder == ExportRawHeightmap.ByteOrder.Mac == BitConverter.IsLittleEndian)
            {
              buffer[num2 * 2] = bytes[1];
              buffer[num2 * 2 + 1] = bytes[0];
            }
            else
            {
              buffer[num2 * 2] = bytes[0];
              buffer[num2 * 2 + 1] = bytes[1];
            }
          }
        }
      }
      else
      {
        float num1 = 256f;
        for (int index1 = 0; index1 < heightmapHeight; ++index1)
        {
          for (int index2 = 0; index2 < heightmapWidth; ++index2)
          {
            int index3 = index2 + index1 * heightmapWidth;
            int index4 = !this.m_FlipVertically ? index1 : heightmapHeight - 1 - index1;
            byte num2 = (byte) Mathf.Clamp(Mathf.RoundToInt(heights[index4, index2] * num1), 0, (int) byte.MaxValue);
            buffer[index3] = num2;
          }
        }
      }
      FileStream fileStream = new FileStream(path, System.IO.FileMode.Create);
      fileStream.Write(buffer, 0, buffer.Length);
      fileStream.Close();
    }

    private new void InitializeDefaults(Terrain terrain)
    {
      this.m_Terrain = terrain;
      this.helpString = "Width " + (object) terrain.terrainData.heightmapWidth + " Height " + (object) terrain.terrainData.heightmapHeight;
      this.OnWizardUpdate();
    }

    internal enum Depth
    {
      Bit8 = 1,
      Bit16 = 2,
    }

    internal enum ByteOrder
    {
      Mac = 1,
      Windows = 2,
    }
  }
}
