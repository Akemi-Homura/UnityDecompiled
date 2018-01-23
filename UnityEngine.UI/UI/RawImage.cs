﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.RawImage
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 95F4B50A-137D-4022-9C58-045B696814A0
// Assembly location: C:\Program Files\Unity 5\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

using UnityEngine.Serialization;

namespace UnityEngine.UI
{
  /// <summary>
  ///   <para>Displays a Texture2D for the UI System.</para>
  /// </summary>
  [AddComponentMenu("UI/Raw Image", 12)]
  public class RawImage : MaskableGraphic
  {
    [SerializeField]
    private Rect m_UVRect = new Rect(0.0f, 0.0f, 1f, 1f);
    [FormerlySerializedAs("m_Tex")]
    [SerializeField]
    private Texture m_Texture;

    protected RawImage()
    {
      this.useLegacyMeshGeneration = false;
    }

    /// <summary>
    ///   <para>The RawImage's texture. (ReadOnly).</para>
    /// </summary>
    public override Texture mainTexture
    {
      get
      {
        if (!((Object) this.m_Texture == (Object) null))
          return this.m_Texture;
        if ((Object) this.material != (Object) null && (Object) this.material.mainTexture != (Object) null)
          return this.material.mainTexture;
        return (Texture) Graphic.s_WhiteTexture;
      }
    }

    /// <summary>
    ///   <para>The RawImage's texture.</para>
    /// </summary>
    public Texture texture
    {
      get
      {
        return this.m_Texture;
      }
      set
      {
        if ((Object) this.m_Texture == (Object) value)
          return;
        this.m_Texture = value;
        this.SetVerticesDirty();
        this.SetMaterialDirty();
      }
    }

    /// <summary>
    ///   <para>The RawImage texture coordinates.</para>
    /// </summary>
    public Rect uvRect
    {
      get
      {
        return this.m_UVRect;
      }
      set
      {
        if (this.m_UVRect == value)
          return;
        this.m_UVRect = value;
        this.SetVerticesDirty();
      }
    }

    /// <summary>
    ///   <para>Adjusts the raw image size to make it pixel-perfect.</para>
    /// </summary>
    public override void SetNativeSize()
    {
      Texture mainTexture = this.mainTexture;
      if (!((Object) mainTexture != (Object) null))
        return;
      int num1 = Mathf.RoundToInt((float) mainTexture.width * this.uvRect.width);
      int num2 = Mathf.RoundToInt((float) mainTexture.height * this.uvRect.height);
      this.rectTransform.anchorMax = this.rectTransform.anchorMin;
      this.rectTransform.sizeDelta = new Vector2((float) num1, (float) num2);
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
      Texture mainTexture = this.mainTexture;
      vh.Clear();
      if (!((Object) mainTexture != (Object) null))
        return;
      Rect pixelAdjustedRect = this.GetPixelAdjustedRect();
      Vector4 vector4 = new Vector4(pixelAdjustedRect.x, pixelAdjustedRect.y, pixelAdjustedRect.x + pixelAdjustedRect.width, pixelAdjustedRect.y + pixelAdjustedRect.height);
      float num1 = (float) mainTexture.width * mainTexture.texelSize.x;
      float num2 = (float) mainTexture.height * mainTexture.texelSize.y;
      Color color = this.color;
      vh.AddVert(new Vector3(vector4.x, vector4.y), (Color32) color, new Vector2(this.m_UVRect.xMin * num1, this.m_UVRect.yMin * num2));
      vh.AddVert(new Vector3(vector4.x, vector4.w), (Color32) color, new Vector2(this.m_UVRect.xMin * num1, this.m_UVRect.yMax * num2));
      vh.AddVert(new Vector3(vector4.z, vector4.w), (Color32) color, new Vector2(this.m_UVRect.xMax * num1, this.m_UVRect.yMax * num2));
      vh.AddVert(new Vector3(vector4.z, vector4.y), (Color32) color, new Vector2(this.m_UVRect.xMax * num1, this.m_UVRect.yMin * num2));
      vh.AddTriangle(0, 1, 2);
      vh.AddTriangle(2, 3, 0);
    }
  }
}
