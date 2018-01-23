﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.ModelInspector
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using UnityEngine;

namespace UnityEditor
{
  [CustomEditor(typeof (Mesh))]
  [CanEditMultipleObjects]
  internal class ModelInspector : Editor
  {
    public Vector2 previewDir = new Vector2(-120f, 20f);
    private PreviewRenderUtility m_PreviewUtility;
    private Material m_Material;
    private Material m_WireMaterial;

    internal static Material CreateWireframeMaterial()
    {
      Shader builtin = Shader.FindBuiltin("Internal-Colored.shader");
      if (!(bool) ((Object) builtin))
      {
        Debug.LogWarning((object) "Could not find Colored builtin shader");
        return (Material) null;
      }
      Material material = new Material(builtin);
      material.hideFlags = HideFlags.HideAndDontSave;
      material.SetColor("_Color", new Color(0.0f, 0.0f, 0.0f, 0.3f));
      material.SetInt("_ZWrite", 0);
      material.SetFloat("_ZBias", -1f);
      return material;
    }

    private void Init()
    {
      if (this.m_PreviewUtility != null)
        return;
      this.m_PreviewUtility = new PreviewRenderUtility();
      this.m_PreviewUtility.camera.fieldOfView = 30f;
      this.m_Material = EditorGUIUtility.GetBuiltinExtraResource(typeof (Material), "Default-Material.mat") as Material;
      this.m_WireMaterial = ModelInspector.CreateWireframeMaterial();
    }

    public override void OnPreviewSettings()
    {
      if (!ShaderUtil.hardwareSupportsRectRenderTexture)
        return;
      GUI.enabled = true;
      this.Init();
    }

    internal static void RenderMeshPreview(Mesh mesh, PreviewRenderUtility previewUtility, Material litMaterial, Material wireMaterial, Vector2 direction, int meshSubset)
    {
      if ((Object) mesh == (Object) null || previewUtility == null)
        return;
      Bounds bounds = mesh.bounds;
      float magnitude = bounds.extents.magnitude;
      float num = 4f * magnitude;
      previewUtility.camera.transform.position = -Vector3.forward * num;
      previewUtility.camera.transform.rotation = Quaternion.identity;
      previewUtility.camera.nearClipPlane = num - magnitude * 1.1f;
      previewUtility.camera.farClipPlane = num + magnitude * 1.1f;
      previewUtility.lights[0].intensity = 1.4f;
      previewUtility.lights[0].transform.rotation = Quaternion.Euler(40f, 40f, 0.0f);
      previewUtility.lights[1].intensity = 1.4f;
      previewUtility.ambientColor = new Color(0.1f, 0.1f, 0.1f, 0.0f);
      ModelInspector.RenderMeshPreviewSkipCameraAndLighting(mesh, bounds, previewUtility, litMaterial, wireMaterial, (MaterialPropertyBlock) null, direction, meshSubset);
    }

    internal static void RenderMeshPreviewSkipCameraAndLighting(Mesh mesh, Bounds bounds, PreviewRenderUtility previewUtility, Material litMaterial, Material wireMaterial, MaterialPropertyBlock customProperties, Vector2 direction, int meshSubset)
    {
      if ((Object) mesh == (Object) null || previewUtility == null)
        return;
      Quaternion rot = Quaternion.Euler(direction.y, 0.0f, 0.0f) * Quaternion.Euler(0.0f, direction.x, 0.0f);
      Vector3 pos = rot * -bounds.center;
      bool fog = RenderSettings.fog;
      Unsupported.SetRenderSettingsUseFogNoDirty(false);
      int subMeshCount = mesh.subMeshCount;
      if ((Object) litMaterial != (Object) null)
      {
        previewUtility.camera.clearFlags = CameraClearFlags.Nothing;
        if (meshSubset < 0 || meshSubset >= subMeshCount)
        {
          for (int subMeshIndex = 0; subMeshIndex < subMeshCount; ++subMeshIndex)
            previewUtility.DrawMesh(mesh, pos, rot, litMaterial, subMeshIndex, customProperties);
        }
        else
          previewUtility.DrawMesh(mesh, pos, rot, litMaterial, meshSubset, customProperties);
        previewUtility.Render(false, true);
      }
      if ((Object) wireMaterial != (Object) null)
      {
        previewUtility.camera.clearFlags = CameraClearFlags.Nothing;
        GL.wireframe = true;
        if (meshSubset < 0 || meshSubset >= subMeshCount)
        {
          for (int subMeshIndex = 0; subMeshIndex < subMeshCount; ++subMeshIndex)
            previewUtility.DrawMesh(mesh, pos, rot, wireMaterial, subMeshIndex, customProperties);
        }
        else
          previewUtility.DrawMesh(mesh, pos, rot, wireMaterial, meshSubset, customProperties);
        previewUtility.Render(false, true);
        GL.wireframe = false;
      }
      Unsupported.SetRenderSettingsUseFogNoDirty(fog);
    }

    private void DoRenderPreview()
    {
      ModelInspector.RenderMeshPreview(this.target as Mesh, this.m_PreviewUtility, this.m_Material, this.m_WireMaterial, this.previewDir, -1);
    }

    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
      if (!ShaderUtil.hardwareSupportsRectRenderTexture)
        return (Texture2D) null;
      this.Init();
      this.m_PreviewUtility.BeginStaticPreview(new Rect(0.0f, 0.0f, (float) width, (float) height));
      this.DoRenderPreview();
      return this.m_PreviewUtility.EndStaticPreview();
    }

    public override bool HasPreviewGUI()
    {
      return this.target != (Object) null;
    }

    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
      if (!ShaderUtil.hardwareSupportsRectRenderTexture)
      {
        if (Event.current.type != EventType.Repaint)
          return;
        EditorGUI.DropShadowLabel(new Rect(r.x, r.y, r.width, 40f), "Mesh preview requires\nrender texture support");
      }
      else
      {
        this.Init();
        this.previewDir = PreviewGUI.Drag2D(this.previewDir, r);
        if (Event.current.type != EventType.Repaint)
          return;
        this.m_PreviewUtility.BeginPreview(r, background);
        this.DoRenderPreview();
        this.m_PreviewUtility.EndAndDrawPreview(r);
      }
    }

    internal override void OnAssetStoreInspectorGUI()
    {
      this.OnInspectorGUI();
    }

    public void OnDestroy()
    {
      if (this.m_PreviewUtility != null)
      {
        this.m_PreviewUtility.Cleanup();
        this.m_PreviewUtility = (PreviewRenderUtility) null;
      }
      if (!(bool) ((Object) this.m_WireMaterial))
        return;
      Object.DestroyImmediate((Object) this.m_WireMaterial, true);
    }

    public override string GetInfoString()
    {
      Mesh target = this.target as Mesh;
      string str = target.vertexCount.ToString() + " verts, " + (object) InternalMeshUtil.GetPrimitiveCount(target) + " tris";
      int subMeshCount = target.subMeshCount;
      if (subMeshCount > 1)
        str = str + ", " + (object) subMeshCount + " submeshes";
      int blendShapeCount = target.blendShapeCount;
      if (blendShapeCount > 1)
        str = str + ", " + (object) blendShapeCount + " blendShapes";
      return str + "\n" + InternalMeshUtil.GetVertexFormat(target);
    }
  }
}
