﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.ProceduralMaterialInspector
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditorInternal;
using UnityEngine;

namespace UnityEditor
{
  [CustomEditor(typeof (ProceduralMaterial))]
  [CanEditMultipleObjects]
  internal class ProceduralMaterialInspector : MaterialEditor
  {
    private static ProceduralMaterial m_Material = (ProceduralMaterial) null;
    private static SubstanceImporter m_Importer = (SubstanceImporter) null;
    private static string[] kMaxTextureSizeStrings = new string[7]{ "32", "64", "128", "256", "512", "1024", "2048" };
    private static int[] kMaxTextureSizeValues = new int[7]{ 32, 64, 128, 256, 512, 1024, 2048 };
    private static string[] kMaxLoadBehaviorStrings = new string[6]{ "Do nothing", "Do nothing and cache", "Build on level load", "Build on level load and cache", "Bake and keep Substance", "Bake and discard Substance" };
    private static int[] kMaxLoadBehaviorValues = new int[6]{ 0, 5, 1, 4, 2, 3 };
    private static string[] kTextureFormatStrings = new string[4]{ "Compressed", "Compressed - No Alpha", "RAW", "RAW - No Alpha" };
    private static int[] kTextureFormatValues = new int[4]{ 0, 2, 1, 3 };
    private static bool m_UndoWasPerformed = false;
    private static Dictionary<ProceduralMaterial, float> m_GeneratingSince = new Dictionary<ProceduralMaterial, float>();
    private bool m_AllowTextureSizeModification = false;
    private bool m_ShowTexturesSection = false;
    private bool m_ShowHSLInputs = true;
    private bool m_MightHaveModified = false;
    private bool m_ReimportOnDisable = true;
    private Vector2 m_ScrollPos = new Vector2();
    private ProceduralMaterialInspector.Styles m_Styles;
    protected List<ProceduralMaterialInspector.ProceduralPlatformSetting> m_PlatformSettings;

    public void DisableReimportOnDisable()
    {
      this.m_ReimportOnDisable = false;
    }

    public void ReimportSubstances()
    {
      string[] strArray = new string[this.targets.GetLength(0)];
      int num = 0;
      foreach (ProceduralMaterial target in this.targets)
        strArray[num++] = AssetDatabase.GetAssetPath((UnityEngine.Object) target);
      for (int index = 0; index < num; ++index)
      {
        SubstanceImporter atPath = AssetImporter.GetAtPath(strArray[index]) as SubstanceImporter;
        if ((bool) ((UnityEngine.Object) atPath) && EditorUtility.IsDirty(atPath.GetInstanceID()))
          AssetDatabase.ImportAsset(strArray[index], ImportAssetOptions.ForceUncompressedImport);
      }
    }

    public override void Awake()
    {
      base.Awake();
      this.m_ShowTexturesSection = EditorPrefs.GetBool("ProceduralShowTextures", false);
      this.m_ReimportOnDisable = true;
      if (ProceduralMaterialInspector.m_UndoWasPerformed)
      {
        ProceduralMaterialInspector.m_UndoWasPerformed = false;
        this.OnShaderChanged();
      }
      ProceduralMaterialInspector.m_UndoWasPerformed = false;
    }

    public override void OnEnable()
    {
      base.OnEnable();
      Undo.undoRedoPerformed += new Undo.UndoRedoCallback(((MaterialEditor) this).UndoRedoPerformed);
    }

    public void ReimportSubstancesIfNeeded()
    {
      if (!this.m_MightHaveModified || ProceduralMaterialInspector.m_UndoWasPerformed || (EditorApplication.isPlaying || InternalEditorUtility.ignoreInspectorChanges))
        return;
      this.ReimportSubstances();
    }

    public override void OnDisable()
    {
      if ((bool) ((UnityEngine.Object) (this.target as ProceduralMaterial)) && this.m_PlatformSettings != null && this.HasModified())
      {
        if (EditorUtility.DisplayDialog("Unapplied import settings", "Unapplied import settings for '" + AssetDatabase.GetAssetPath(this.target) + "'", "Apply", "Revert"))
        {
          this.Apply();
          this.ReimportSubstances();
        }
        this.ResetValues();
      }
      if (this.m_ReimportOnDisable)
        this.ReimportSubstancesIfNeeded();
      Undo.undoRedoPerformed -= new Undo.UndoRedoCallback(((MaterialEditor) this).UndoRedoPerformed);
      base.OnDisable();
    }

    public override void UndoRedoPerformed()
    {
      ProceduralMaterialInspector.m_UndoWasPerformed = true;
      if ((UnityEngine.Object) ProceduralMaterialInspector.m_Material != (UnityEngine.Object) null)
        ProceduralMaterialInspector.m_Material.RebuildTextures();
      base.UndoRedoPerformed();
    }

    protected override void OnShaderChanged()
    {
      foreach (ProceduralMaterial target in this.targets)
      {
        SubstanceImporter atPath = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath((UnityEngine.Object) target)) as SubstanceImporter;
        if ((UnityEngine.Object) atPath != (UnityEngine.Object) null && (UnityEngine.Object) target != (UnityEngine.Object) null)
          atPath.OnShaderModified(target);
      }
    }

    internal void DisplayRestrictedInspector()
    {
      this.m_MightHaveModified = false;
      if (this.m_Styles == null)
        this.m_Styles = new ProceduralMaterialInspector.Styles();
      ProceduralMaterial target = this.target as ProceduralMaterial;
      if ((UnityEngine.Object) ProceduralMaterialInspector.m_Material != (UnityEngine.Object) target)
        ProceduralMaterialInspector.m_Material = target;
      this.ProceduralProperties();
      GUILayout.Space(15f);
      this.GeneratedTextures();
    }

    internal override void OnAssetStoreInspectorGUI()
    {
      this.DisplayRestrictedInspector();
    }

    internal override bool IsEnabled()
    {
      return this.IsOpenForEdit();
    }

    internal override void OnHeaderTitleGUI(Rect titleRect, string header)
    {
      ProceduralMaterial target = this.target as ProceduralMaterial;
      ProceduralMaterialInspector.m_Importer = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(this.target)) as SubstanceImporter;
      if ((UnityEngine.Object) ProceduralMaterialInspector.m_Importer == (UnityEngine.Object) null)
        return;
      string name1 = target.name;
      string name2 = EditorGUI.DelayedTextField(titleRect, name1, EditorStyles.textField);
      if (!(name2 != target.name))
        return;
      if (ProceduralMaterialInspector.m_Importer.RenameMaterial(target, name2))
      {
        AssetDatabase.ImportAsset(ProceduralMaterialInspector.m_Importer.assetPath, ImportAssetOptions.ForceUncompressedImport);
        GUIUtility.ExitGUI();
      }
      else
      {
        string name3 = target.name;
      }
    }

    public override void OnInspectorGUI()
    {
      using (new EditorGUI.DisabledScope(AnimationMode.InAnimationMode()))
      {
        this.m_MightHaveModified = true;
        if (this.m_Styles == null)
          this.m_Styles = new ProceduralMaterialInspector.Styles();
        ProceduralMaterial target = this.target as ProceduralMaterial;
        ProceduralMaterialInspector.m_Importer = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(this.target)) as SubstanceImporter;
        if ((UnityEngine.Object) ProceduralMaterialInspector.m_Importer == (UnityEngine.Object) null)
        {
          this.DisplayRestrictedInspector();
        }
        else
        {
          if ((UnityEngine.Object) ProceduralMaterialInspector.m_Material != (UnityEngine.Object) target)
            ProceduralMaterialInspector.m_Material = target;
          if (!this.isVisible || (UnityEngine.Object) target.shader == (UnityEngine.Object) null)
            return;
          if (this.PropertiesGUI())
          {
            this.OnShaderChanged();
            this.PropertiesChanged();
          }
          GUILayout.Space(5f);
          this.ProceduralProperties();
          GUILayout.Space(15f);
          this.GeneratedTextures();
        }
      }
    }

    private void ProceduralProperties()
    {
      GUILayout.Label("Procedural Properties", EditorStyles.boldLabel, new GUILayoutOption[1]
      {
        GUILayout.ExpandWidth(true)
      });
      foreach (ProceduralMaterial target in this.targets)
      {
        if (target.isProcessing)
        {
          this.Repaint();
          SceneView.RepaintAll();
          GameView.RepaintAll();
          break;
        }
      }
      if (this.targets.Length > 1)
      {
        GUILayout.Label("Procedural properties do not support multi-editing.", EditorStyles.wordWrappedLabel, new GUILayoutOption[0]);
      }
      else
      {
        EditorGUIUtility.labelWidth = 0.0f;
        EditorGUIUtility.fieldWidth = 0.0f;
        if ((UnityEngine.Object) ProceduralMaterialInspector.m_Importer != (UnityEngine.Object) null)
        {
          if (!ProceduralMaterial.isSupported)
            GUILayout.Label("Procedural Materials are not supported on " + (object) EditorUserBuildSettings.activeBuildTarget + ". Textures will be baked.", EditorStyles.helpBox, new GUILayoutOption[1]
            {
              GUILayout.ExpandWidth(true)
            });
          bool changed = GUI.changed;
          using (new EditorGUI.DisabledScope(EditorApplication.isPlaying))
          {
            EditorGUI.BeginChangeCheck();
            bool generated = EditorGUILayout.Toggle(this.m_Styles.generateAllOutputsContent, ProceduralMaterialInspector.m_Importer.GetGenerateAllOutputs(ProceduralMaterialInspector.m_Material), new GUILayoutOption[0]);
            if (EditorGUI.EndChangeCheck())
              ProceduralMaterialInspector.m_Importer.SetGenerateAllOutputs(ProceduralMaterialInspector.m_Material, generated);
            EditorGUI.BeginChangeCheck();
            bool mode = EditorGUILayout.Toggle(this.m_Styles.mipmapContent, ProceduralMaterialInspector.m_Importer.GetGenerateMipMaps(ProceduralMaterialInspector.m_Material), new GUILayoutOption[0]);
            if (EditorGUI.EndChangeCheck())
              ProceduralMaterialInspector.m_Importer.SetGenerateMipMaps(ProceduralMaterialInspector.m_Material, mode);
          }
          if (ProceduralMaterialInspector.m_Material.HasProceduralProperty("$time"))
          {
            EditorGUI.BeginChangeCheck();
            int animation_update_rate = EditorGUILayout.IntField(this.m_Styles.animatedContent, ProceduralMaterialInspector.m_Importer.GetAnimationUpdateRate(ProceduralMaterialInspector.m_Material), new GUILayoutOption[0]);
            if (EditorGUI.EndChangeCheck())
              ProceduralMaterialInspector.m_Importer.SetAnimationUpdateRate(ProceduralMaterialInspector.m_Material, animation_update_rate);
          }
          GUI.changed = changed;
        }
        this.InputOptions(ProceduralMaterialInspector.m_Material);
      }
    }

    private void GeneratedTextures()
    {
      if (this.targets.Length > 1)
        return;
      foreach (ProceduralPropertyDescription propertyDescription in ProceduralMaterialInspector.m_Material.GetProceduralPropertyDescriptions())
      {
        if (propertyDescription.name == "$outputsize")
        {
          this.m_AllowTextureSizeModification = true;
          break;
        }
      }
      string content = "Generated Textures";
      if (ProceduralMaterialInspector.ShowIsGenerating(this.target as ProceduralMaterial))
        content += " (Generating...)";
      EditorGUI.BeginChangeCheck();
      this.m_ShowTexturesSection = EditorGUILayout.Foldout(this.m_ShowTexturesSection, content, true);
      if (EditorGUI.EndChangeCheck())
        EditorPrefs.SetBool("ProceduralShowTextures", this.m_ShowTexturesSection);
      if (!this.m_ShowTexturesSection)
        return;
      this.ShowProceduralTexturesGUI(ProceduralMaterialInspector.m_Material);
      this.ShowGeneratedTexturesGUI(ProceduralMaterialInspector.m_Material);
      if ((UnityEngine.Object) ProceduralMaterialInspector.m_Importer != (UnityEngine.Object) null)
      {
        if (this.HasProceduralTextureProperties((Material) ProceduralMaterialInspector.m_Material))
          this.OffsetScaleGUI(ProceduralMaterialInspector.m_Material);
        GUILayout.Space(5f);
        using (new EditorGUI.DisabledScope(EditorApplication.isPlaying))
          this.ShowTextureSizeGUI();
      }
    }

    public static bool ShowIsGenerating(ProceduralMaterial mat)
    {
      if (!ProceduralMaterialInspector.m_GeneratingSince.ContainsKey(mat))
        ProceduralMaterialInspector.m_GeneratingSince[mat] = 0.0f;
      if (mat.isProcessing)
        return (double) Time.realtimeSinceStartup > (double) ProceduralMaterialInspector.m_GeneratingSince[mat] + 0.400000005960464;
      ProceduralMaterialInspector.m_GeneratingSince[mat] = Time.realtimeSinceStartup;
      return false;
    }

    public override string GetInfoString()
    {
      Texture[] generatedTextures = (this.target as ProceduralMaterial).GetGeneratedTextures();
      if (generatedTextures.Length == 0)
        return string.Empty;
      return generatedTextures[0].width.ToString() + "x" + (object) generatedTextures[0].height;
    }

    public bool HasProceduralTextureProperties(Material material)
    {
      Shader shader = material.shader;
      int propertyCount = ShaderUtil.GetPropertyCount(shader);
      for (int propertyIdx = 0; propertyIdx < propertyCount; ++propertyIdx)
      {
        if (ShaderUtil.GetPropertyType(shader, propertyIdx) == ShaderUtil.ShaderPropertyType.TexEnv)
        {
          string propertyName = ShaderUtil.GetPropertyName(shader, propertyIdx);
          Texture texture = material.GetTexture(propertyName);
          if (SubstanceImporter.IsProceduralTextureSlot(material, texture, propertyName))
            return true;
        }
      }
      return false;
    }

    protected void RecordForUndo(ProceduralMaterial material, SubstanceImporter importer, string message)
    {
      if ((bool) ((UnityEngine.Object) importer))
        Undo.RecordObjects(new UnityEngine.Object[2]
        {
          (UnityEngine.Object) material,
          (UnityEngine.Object) importer
        }, message);
      else
        Undo.RecordObject((UnityEngine.Object) material, message);
    }

    protected void OffsetScaleGUI(ProceduralMaterial material)
    {
      if ((UnityEngine.Object) ProceduralMaterialInspector.m_Importer == (UnityEngine.Object) null || this.targets.Length > 1)
        return;
      Vector2 materialScale = ProceduralMaterialInspector.m_Importer.GetMaterialScale(material);
      Vector2 materialOffset = ProceduralMaterialInspector.m_Importer.GetMaterialOffset(material);
      Vector4 scaleOffset = new Vector4(materialScale.x, materialScale.y, materialOffset.x, materialOffset.y);
      GUILayout.BeginHorizontal();
      GUILayout.Space(10f);
      Rect rect = GUILayoutUtility.GetRect(100f, 10000f, 32f, 32f);
      GUILayout.EndHorizontal();
      EditorGUI.BeginChangeCheck();
      Vector4 vector4 = MaterialEditor.TextureScaleOffsetProperty(rect, scaleOffset);
      if (!EditorGUI.EndChangeCheck())
        return;
      this.RecordForUndo(material, ProceduralMaterialInspector.m_Importer, "Modify " + material.name + "'s Tiling/Offset");
      ProceduralMaterialInspector.m_Importer.SetMaterialScale(material, new Vector2(vector4.x, vector4.y));
      ProceduralMaterialInspector.m_Importer.SetMaterialOffset(material, new Vector2(vector4.z, vector4.w));
    }

    protected void InputOptions(ProceduralMaterial material)
    {
      EditorGUI.BeginChangeCheck();
      this.InputsGUI();
      if (!EditorGUI.EndChangeCheck())
        return;
      material.RebuildTextures();
    }

    [MenuItem("CONTEXT/ProceduralMaterial/Reset", false, -100)]
    public static void ResetSubstance(MenuCommand command)
    {
      ProceduralMaterialInspector.m_Importer = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(command.context)) as SubstanceImporter;
      ProceduralMaterialInspector.m_Importer.ResetMaterial(command.context as ProceduralMaterial);
    }

    private static void ExportBitmaps(ProceduralMaterial material, bool alphaRemap)
    {
      string exportPath = EditorUtility.SaveFolderPanel("Set bitmap export path...", "", "");
      if (exportPath == "")
        return;
      SubstanceImporter atPath = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath((UnityEngine.Object) material)) as SubstanceImporter;
      if (!(bool) ((UnityEngine.Object) atPath))
        return;
      atPath.ExportBitmaps(material, exportPath, alphaRemap);
    }

    [MenuItem("CONTEXT/ProceduralMaterial/Export Bitmaps (remapped alpha channels)", false)]
    public static void ExportBitmapsAlphaRemap(MenuCommand command)
    {
      ProceduralMaterialInspector.ExportBitmaps(command.context as ProceduralMaterial, true);
    }

    [MenuItem("CONTEXT/ProceduralMaterial/Export Bitmaps (original alpha channels)", false)]
    public static void ExportBitmapsNoAlphaRemap(MenuCommand command)
    {
      ProceduralMaterialInspector.ExportBitmaps(command.context as ProceduralMaterial, false);
    }

    [MenuItem("CONTEXT/ProceduralMaterial/Export Preset", false)]
    public static void ExportPreset(MenuCommand command)
    {
      string exportPath = EditorUtility.SaveFolderPanel("Set preset export path...", "", "");
      if (exportPath == "")
        return;
      ProceduralMaterial context = command.context as ProceduralMaterial;
      SubstanceImporter atPath = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath((UnityEngine.Object) context)) as SubstanceImporter;
      if (!(bool) ((UnityEngine.Object) atPath))
        return;
      atPath.ExportPreset(context, exportPath);
    }

    protected void ShowProceduralTexturesGUI(ProceduralMaterial material)
    {
      if (this.targets.Length > 1)
        return;
      EditorGUILayout.Space();
      Shader shader = material.shader;
      if ((UnityEngine.Object) shader == (UnityEngine.Object) null)
        return;
      EditorGUILayout.BeginHorizontal();
      GUILayout.Space(4f);
      GUILayout.FlexibleSpace();
      float pixels = 10f;
      bool flag = true;
      for (int propertyIdx = 0; propertyIdx < ShaderUtil.GetPropertyCount(shader); ++propertyIdx)
      {
        if (ShaderUtil.GetPropertyType(shader, propertyIdx) == ShaderUtil.ShaderPropertyType.TexEnv)
        {
          string propertyName = ShaderUtil.GetPropertyName(shader, propertyIdx);
          Texture texture = material.GetTexture(propertyName);
          if (SubstanceImporter.IsProceduralTextureSlot((Material) material, texture, propertyName))
          {
            string propertyDescription = ShaderUtil.GetPropertyDescription(shader, propertyIdx);
            System.Type typeFromDimension = MaterialEditor.GetTextureTypeFromDimension(ShaderUtil.GetTexDim(shader, propertyIdx));
            GUIStyle style = (GUIStyle) "ObjectPickerResultsGridLabel";
            if (flag)
              flag = false;
            else
              GUILayout.Space(pixels);
            GUILayout.BeginVertical(GUILayout.Height((float) (72.0 + (double) style.fixedHeight + (double) style.fixedHeight + 8.0)));
            Rect rect = GUILayoutUtility.GetRect(72f, 72f);
            ProceduralMaterialInspector.DoObjectPingField(rect, rect, GUIUtility.GetControlID(12354, FocusType.Keyboard, rect), (UnityEngine.Object) texture, typeFromDimension);
            this.ShowAlphaSourceGUI(material, texture as ProceduralTexture, ref rect);
            rect.height = style.fixedHeight;
            GUI.Label(rect, propertyDescription, style);
            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();
          }
        }
      }
      GUILayout.Space(4f);
      EditorGUILayout.EndHorizontal();
    }

    protected void ShowGeneratedTexturesGUI(ProceduralMaterial material)
    {
      if (this.targets.Length > 1 || (UnityEngine.Object) ProceduralMaterialInspector.m_Importer != (UnityEngine.Object) null && !ProceduralMaterialInspector.m_Importer.GetGenerateAllOutputs(ProceduralMaterialInspector.m_Material))
        return;
      GUIStyle guiStyle = (GUIStyle) "ObjectPickerResultsGridLabel";
      EditorGUILayout.Space();
      GUILayout.FlexibleSpace();
      this.m_ScrollPos = EditorGUILayout.BeginScrollView(this.m_ScrollPos, GUILayout.Height((float) (64.0 + (double) guiStyle.fixedHeight + (double) guiStyle.fixedHeight + 16.0)));
      EditorGUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      float pixels = 10f;
      foreach (Texture generatedTexture in material.GetGeneratedTextures())
      {
        ProceduralTexture tex = generatedTexture as ProceduralTexture;
        if ((UnityEngine.Object) tex != (UnityEngine.Object) null)
        {
          GUILayout.Space(pixels);
          GUILayout.BeginVertical(GUILayout.Height((float) (64.0 + (double) guiStyle.fixedHeight + 8.0)));
          Rect rect = GUILayoutUtility.GetRect(64f, 64f);
          ProceduralMaterialInspector.DoObjectPingField(rect, rect, GUIUtility.GetControlID(12354, FocusType.Keyboard, rect), (UnityEngine.Object) tex, typeof (Texture));
          this.ShowAlphaSourceGUI(material, tex, ref rect);
          GUILayout.EndVertical();
          GUILayout.Space(pixels);
          GUILayout.FlexibleSpace();
        }
      }
      EditorGUILayout.EndHorizontal();
      EditorGUILayout.EndScrollView();
    }

    private void ShowAlphaSourceGUI(ProceduralMaterial material, ProceduralTexture tex, ref Rect rect)
    {
      GUIStyle guiStyle = (GUIStyle) "ObjectPickerResultsGridLabel";
      float num1 = 10f;
      rect.y = rect.yMax + 2f;
      if ((UnityEngine.Object) ProceduralMaterialInspector.m_Importer != (UnityEngine.Object) null)
      {
        using (new EditorGUI.DisabledScope(EditorApplication.isPlaying))
        {
          if (tex.GetProceduralOutputType() != ProceduralOutputType.Normal)
          {
            if (tex.hasAlpha)
            {
              rect.height = guiStyle.fixedHeight;
              string[] displayedOptions = new string[12]{ "Source (A)", "Diffuse (A)", "Normal (A)", "Height (A)", "Emissive (A)", "Specular (A)", "Opacity (A)", "Smoothness (A)", "Amb. Occlusion (A)", "Detail Mask (A)", "Metallic (A)", "Roughness (A)" };
              EditorGUILayout.Space();
              EditorGUILayout.Space();
              EditorGUI.BeginChangeCheck();
              int num2 = EditorGUI.Popup(rect, (int) ProceduralMaterialInspector.m_Importer.GetTextureAlphaSource(material, tex.name), displayedOptions);
              if (EditorGUI.EndChangeCheck())
              {
                this.RecordForUndo(material, ProceduralMaterialInspector.m_Importer, "Modify " + material.name + "'s Alpha Modifier");
                ProceduralMaterialInspector.m_Importer.SetTextureAlphaSource(material, tex.name, (ProceduralOutputType) num2);
              }
              rect.y = rect.yMax + 2f;
            }
          }
        }
      }
      rect.width += num1;
    }

    internal static void DoObjectPingField(Rect position, Rect dropRect, int id, UnityEngine.Object obj, System.Type objType)
    {
      Event current = Event.current;
      EventType eventType = current.type;
      if (!GUI.enabled && GUIClip.enabled && Event.current.rawType == EventType.MouseDown)
        eventType = Event.current.rawType;
      bool flag = EditorGUIUtility.HasObjectThumbnail(objType) && (double) position.height > 16.0;
      switch (eventType)
      {
        case EventType.MouseDown:
          if (Event.current.button != 0 || !position.Contains(Event.current.mousePosition))
            break;
          UnityEngine.Object target = obj;
          Component component = target as Component;
          if ((bool) ((UnityEngine.Object) component))
            target = (UnityEngine.Object) component.gameObject;
          if (Event.current.clickCount == 1)
          {
            GUIUtility.keyboardControl = id;
            if ((bool) target)
              EditorGUIUtility.PingObject(target);
            current.Use();
          }
          else if (Event.current.clickCount == 2)
          {
            if ((bool) target)
            {
              AssetDatabase.OpenAsset(target);
              GUIUtility.ExitGUI();
            }
            current.Use();
          }
          break;
        case EventType.Repaint:
          GUIContent content = EditorGUIUtility.ObjectContent(obj, objType);
          if (flag)
          {
            GUIStyle objectFieldThumb = EditorStyles.objectFieldThumb;
            objectFieldThumb.Draw(position, GUIContent.none, id, DragAndDrop.activeControlID == id);
            if (obj != (UnityEngine.Object) null)
            {
              EditorGUI.DrawPreviewTexture(objectFieldThumb.padding.Remove(position), content.image);
              break;
            }
            (GUIStyle) (objectFieldThumb.name + "Overlay").Draw(position, content, id);
            break;
          }
          EditorStyles.objectField.Draw(position, content, id, DragAndDrop.activeControlID == id);
          break;
      }
    }

    internal void ResetValues()
    {
      this.BuildTargetList();
      if (!this.HasModified())
        return;
      Debug.LogError((object) "Impossible");
    }

    internal void Apply()
    {
      foreach (ProceduralMaterialInspector.ProceduralPlatformSetting platformSetting in this.m_PlatformSettings)
        platformSetting.Apply();
    }

    internal bool HasModified()
    {
      foreach (ProceduralMaterialInspector.ProceduralPlatformSetting platformSetting in this.m_PlatformSettings)
      {
        if (platformSetting.HasChanged())
          return true;
      }
      return false;
    }

    public void BuildTargetList()
    {
      List<BuildPlatform> validPlatforms = BuildPlatforms.instance.GetValidPlatforms();
      this.m_PlatformSettings = new List<ProceduralMaterialInspector.ProceduralPlatformSetting>();
      this.m_PlatformSettings.Add(new ProceduralMaterialInspector.ProceduralPlatformSetting(this.targets, "", BuildTarget.StandaloneWindows, (Texture2D) null));
      foreach (BuildPlatform buildPlatform in validPlatforms)
        this.m_PlatformSettings.Add(new ProceduralMaterialInspector.ProceduralPlatformSetting(this.targets, buildPlatform.name, buildPlatform.defaultTarget, buildPlatform.smallIcon));
    }

    public void ShowTextureSizeGUI()
    {
      if (this.m_PlatformSettings == null)
        this.BuildTargetList();
      this.TextureSizeGUI();
    }

    protected void TextureSizeGUI()
    {
      ProceduralMaterialInspector.ProceduralPlatformSetting platformSetting1 = this.m_PlatformSettings[EditorGUILayout.BeginPlatformGrouping(BuildPlatforms.instance.GetValidPlatforms().ToArray(), this.m_Styles.defaultPlatform) + 1];
      ProceduralMaterialInspector.ProceduralPlatformSetting proceduralPlatformSetting = platformSetting1;
      bool flag = true;
      if (platformSetting1.name != "")
      {
        EditorGUI.BeginChangeCheck();
        flag = GUILayout.Toggle(platformSetting1.overridden, "Override for " + platformSetting1.name);
        if (EditorGUI.EndChangeCheck())
        {
          if (flag)
            platformSetting1.SetOverride(this.m_PlatformSettings[0]);
          else
            platformSetting1.ClearOverride(this.m_PlatformSettings[0]);
        }
      }
      using (new EditorGUI.DisabledScope(!flag))
      {
        if (!this.m_AllowTextureSizeModification)
          GUILayout.Label("This ProceduralMaterial was published with a fixed size.", EditorStyles.wordWrappedLabel, new GUILayoutOption[0]);
        using (new EditorGUI.DisabledScope(!this.m_AllowTextureSizeModification))
        {
          EditorGUI.BeginChangeCheck();
          proceduralPlatformSetting.maxTextureWidth = EditorGUILayout.IntPopup(this.m_Styles.targetWidth.text, proceduralPlatformSetting.maxTextureWidth, ProceduralMaterialInspector.kMaxTextureSizeStrings, ProceduralMaterialInspector.kMaxTextureSizeValues, new GUILayoutOption[0]);
          proceduralPlatformSetting.maxTextureHeight = EditorGUILayout.IntPopup(this.m_Styles.targetHeight.text, proceduralPlatformSetting.maxTextureHeight, ProceduralMaterialInspector.kMaxTextureSizeStrings, ProceduralMaterialInspector.kMaxTextureSizeValues, new GUILayoutOption[0]);
          if (EditorGUI.EndChangeCheck())
          {
            if (proceduralPlatformSetting.isDefault)
            {
              foreach (ProceduralMaterialInspector.ProceduralPlatformSetting platformSetting2 in this.m_PlatformSettings)
              {
                if (!platformSetting2.isDefault && !platformSetting2.overridden)
                {
                  platformSetting2.maxTextureWidth = proceduralPlatformSetting.maxTextureWidth;
                  platformSetting2.maxTextureHeight = proceduralPlatformSetting.maxTextureHeight;
                }
              }
            }
          }
        }
        EditorGUI.BeginChangeCheck();
        int textureFormat = proceduralPlatformSetting.textureFormat;
        if (textureFormat < 0 || textureFormat >= ProceduralMaterialInspector.kTextureFormatStrings.Length)
          Debug.LogError((object) "Invalid TextureFormat");
        int num = EditorGUILayout.IntPopup(this.m_Styles.textureFormat.text, textureFormat, ProceduralMaterialInspector.kTextureFormatStrings, ProceduralMaterialInspector.kTextureFormatValues, new GUILayoutOption[0]);
        if (EditorGUI.EndChangeCheck())
        {
          proceduralPlatformSetting.textureFormat = num;
          if (proceduralPlatformSetting.isDefault)
          {
            foreach (ProceduralMaterialInspector.ProceduralPlatformSetting platformSetting2 in this.m_PlatformSettings)
            {
              if (!platformSetting2.isDefault && !platformSetting2.overridden)
                platformSetting2.textureFormat = proceduralPlatformSetting.textureFormat;
            }
          }
        }
        EditorGUI.BeginChangeCheck();
        proceduralPlatformSetting.m_LoadBehavior = EditorGUILayout.IntPopup(this.m_Styles.loadBehavior.text, proceduralPlatformSetting.m_LoadBehavior, ProceduralMaterialInspector.kMaxLoadBehaviorStrings, ProceduralMaterialInspector.kMaxLoadBehaviorValues, new GUILayoutOption[0]);
        if (EditorGUI.EndChangeCheck() && proceduralPlatformSetting.isDefault)
        {
          foreach (ProceduralMaterialInspector.ProceduralPlatformSetting platformSetting2 in this.m_PlatformSettings)
          {
            if (!platformSetting2.isDefault && !platformSetting2.overridden)
              platformSetting2.m_LoadBehavior = proceduralPlatformSetting.m_LoadBehavior;
          }
        }
        GUILayout.Space(5f);
        using (new EditorGUI.DisabledScope(!this.HasModified()))
        {
          GUILayout.BeginHorizontal();
          GUILayout.FlexibleSpace();
          if (GUILayout.Button("Revert"))
            this.ResetValues();
          if (GUILayout.Button("Apply"))
          {
            this.Apply();
            this.ReimportSubstances();
            this.ResetValues();
          }
          GUILayout.EndHorizontal();
        }
        GUILayout.Space(5f);
        EditorGUILayout.EndPlatformGrouping();
      }
    }

    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
      base.OnPreviewGUI(r, background);
      if (!ProceduralMaterialInspector.ShowIsGenerating(this.target as ProceduralMaterial) || (double) r.width <= 50.0)
        return;
      EditorGUI.DropShadowLabel(new Rect(r.x, r.y, r.width, 20f), "Generating...");
    }

    public void InputsGUI()
    {
      List<string> stringList = new List<string>();
      Dictionary<string, List<ProceduralPropertyDescription>> dictionary1 = new Dictionary<string, List<ProceduralPropertyDescription>>();
      Dictionary<string, List<ProceduralPropertyDescription>> dictionary2 = new Dictionary<string, List<ProceduralPropertyDescription>>();
      ProceduralPropertyDescription[] propertyDescriptions = ProceduralMaterialInspector.m_Material.GetProceduralPropertyDescriptions();
      ProceduralPropertyDescription hInput = (ProceduralPropertyDescription) null;
      ProceduralPropertyDescription sInput = (ProceduralPropertyDescription) null;
      ProceduralPropertyDescription lInput = (ProceduralPropertyDescription) null;
      foreach (ProceduralPropertyDescription input in propertyDescriptions)
      {
        if (input.name == "$randomseed")
          this.InputSeedGUI(input);
        else if ((input.name.Length <= 0 || (int) input.name[0] != 36) && ProceduralMaterialInspector.m_Material.IsProceduralPropertyVisible(input.name))
        {
          string group = input.group;
          if (group != string.Empty && !stringList.Contains(group))
            stringList.Add(group);
          if (input.name == "Hue_Shift" && input.type == ProceduralPropertyType.Float && group == string.Empty)
            hInput = input;
          if (input.name == "Saturation" && input.type == ProceduralPropertyType.Float && group == string.Empty)
            sInput = input;
          if (input.name == "Luminosity" && input.type == ProceduralPropertyType.Float && group == string.Empty)
            lInput = input;
          if (input.type == ProceduralPropertyType.Texture)
          {
            if (!dictionary2.ContainsKey(group))
              dictionary2.Add(group, new List<ProceduralPropertyDescription>());
            dictionary2[group].Add(input);
          }
          else
          {
            if (!dictionary1.ContainsKey(group))
              dictionary1.Add(group, new List<ProceduralPropertyDescription>());
            dictionary1[group].Add(input);
          }
        }
      }
      bool flag1 = false;
      if (hInput != null && sInput != null && lInput != null)
        flag1 = true;
      List<ProceduralPropertyDescription> propertyDescriptionList1;
      if (dictionary1.TryGetValue(string.Empty, out propertyDescriptionList1))
      {
        foreach (ProceduralPropertyDescription input in propertyDescriptionList1)
        {
          if (!flag1 || input != hInput && input != sInput && input != lInput)
            this.InputGUI(input);
        }
      }
      foreach (string str in stringList)
      {
        string key = (this.target as ProceduralMaterial).name + str;
        GUILayout.Space(5f);
        bool foldout = EditorPrefs.GetBool(key, true);
        EditorGUI.BeginChangeCheck();
        bool flag2 = EditorGUILayout.Foldout(foldout, str, true);
        if (EditorGUI.EndChangeCheck())
          EditorPrefs.SetBool(key, flag2);
        if (flag2)
        {
          ++EditorGUI.indentLevel;
          List<ProceduralPropertyDescription> propertyDescriptionList2;
          if (dictionary1.TryGetValue(str, out propertyDescriptionList2))
          {
            foreach (ProceduralPropertyDescription input in propertyDescriptionList2)
              this.InputGUI(input);
          }
          List<ProceduralPropertyDescription> propertyDescriptionList3;
          if (dictionary2.TryGetValue(str, out propertyDescriptionList3))
          {
            GUILayout.Space(2f);
            foreach (ProceduralPropertyDescription input in propertyDescriptionList3)
              this.InputGUI(input);
          }
          --EditorGUI.indentLevel;
        }
      }
      if (flag1)
        this.InputHSLGUI(hInput, sInput, lInput);
      List<ProceduralPropertyDescription> propertyDescriptionList4;
      if (!dictionary2.TryGetValue(string.Empty, out propertyDescriptionList4))
        return;
      GUILayout.Space(5f);
      foreach (ProceduralPropertyDescription input in propertyDescriptionList4)
        this.InputGUI(input);
    }

    private void InputGUI(ProceduralPropertyDescription input)
    {
      ProceduralPropertyType type = input.type;
      GUIContent guiContent = new GUIContent(input.label, input.name);
      switch (type)
      {
        case ProceduralPropertyType.Boolean:
          EditorGUI.BeginChangeCheck();
          bool flag = EditorGUILayout.Toggle(guiContent, ProceduralMaterialInspector.m_Material.GetProceduralBoolean(input.name), new GUILayoutOption[0]);
          if (!EditorGUI.EndChangeCheck())
            break;
          this.RecordForUndo(ProceduralMaterialInspector.m_Material, ProceduralMaterialInspector.m_Importer, "Modified property " + input.name + " for material " + ProceduralMaterialInspector.m_Material.name);
          ProceduralMaterialInspector.m_Material.SetProceduralBoolean(input.name, flag);
          break;
        case ProceduralPropertyType.Float:
          EditorGUI.BeginChangeCheck();
          float num1;
          if (input.hasRange)
          {
            float minimum = input.minimum;
            float maximum = input.maximum;
            num1 = EditorGUILayout.Slider(guiContent, ProceduralMaterialInspector.m_Material.GetProceduralFloat(input.name), minimum, maximum, new GUILayoutOption[0]);
          }
          else
            num1 = EditorGUILayout.FloatField(guiContent, ProceduralMaterialInspector.m_Material.GetProceduralFloat(input.name), new GUILayoutOption[0]);
          if (!EditorGUI.EndChangeCheck())
            break;
          this.RecordForUndo(ProceduralMaterialInspector.m_Material, ProceduralMaterialInspector.m_Importer, "Modified property " + input.name + " for material " + ProceduralMaterialInspector.m_Material.name);
          ProceduralMaterialInspector.m_Material.SetProceduralFloat(input.name, num1);
          break;
        case ProceduralPropertyType.Vector2:
        case ProceduralPropertyType.Vector3:
        case ProceduralPropertyType.Vector4:
          int num2 = type != ProceduralPropertyType.Vector2 ? (type != ProceduralPropertyType.Vector3 ? 4 : 3) : 2;
          Vector4 vector4 = ProceduralMaterialInspector.m_Material.GetProceduralVector(input.name);
          EditorGUI.BeginChangeCheck();
          if (input.hasRange)
          {
            float minimum = input.minimum;
            float maximum = input.maximum;
            EditorGUILayout.BeginVertical();
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space((float) (EditorGUI.indentLevel * 15));
            GUILayout.Label(guiContent);
            EditorGUILayout.EndHorizontal();
            ++EditorGUI.indentLevel;
            for (int index = 0; index < num2; ++index)
              vector4[index] = EditorGUILayout.Slider(new GUIContent(input.componentLabels[index]), vector4[index], minimum, maximum, new GUILayoutOption[0]);
            --EditorGUI.indentLevel;
            EditorGUILayout.EndVertical();
          }
          else
          {
            switch (num2)
            {
              case 2:
                vector4 = (Vector4) EditorGUILayout.Vector2Field(input.name, (Vector2) vector4);
                break;
              case 3:
                vector4 = (Vector4) EditorGUILayout.Vector3Field(input.name, (Vector3) vector4);
                break;
              case 4:
                vector4 = EditorGUILayout.Vector4Field(input.name, vector4);
                break;
            }
          }
          if (!EditorGUI.EndChangeCheck())
            break;
          this.RecordForUndo(ProceduralMaterialInspector.m_Material, ProceduralMaterialInspector.m_Importer, "Modified property " + input.name + " for material " + ProceduralMaterialInspector.m_Material.name);
          ProceduralMaterialInspector.m_Material.SetProceduralVector(input.name, vector4);
          break;
        case ProceduralPropertyType.Color3:
        case ProceduralPropertyType.Color4:
          EditorGUI.BeginChangeCheck();
          Color color = EditorGUILayout.ColorField(guiContent, ProceduralMaterialInspector.m_Material.GetProceduralColor(input.name), new GUILayoutOption[0]);
          if (!EditorGUI.EndChangeCheck())
            break;
          this.RecordForUndo(ProceduralMaterialInspector.m_Material, ProceduralMaterialInspector.m_Importer, "Modified property " + input.name + " for material " + ProceduralMaterialInspector.m_Material.name);
          ProceduralMaterialInspector.m_Material.SetProceduralColor(input.name, color);
          break;
        case ProceduralPropertyType.Enum:
          GUIContent[] displayedOptions = new GUIContent[input.enumOptions.Length];
          for (int index = 0; index < displayedOptions.Length; ++index)
            displayedOptions[index] = new GUIContent(input.enumOptions[index]);
          EditorGUI.BeginChangeCheck();
          int num3 = EditorGUILayout.Popup(guiContent, ProceduralMaterialInspector.m_Material.GetProceduralEnum(input.name), displayedOptions, new GUILayoutOption[0]);
          if (!EditorGUI.EndChangeCheck())
            break;
          this.RecordForUndo(ProceduralMaterialInspector.m_Material, ProceduralMaterialInspector.m_Importer, "Modified property " + input.name + " for material " + ProceduralMaterialInspector.m_Material.name);
          ProceduralMaterialInspector.m_Material.SetProceduralEnum(input.name, num3);
          break;
        case ProceduralPropertyType.Texture:
          EditorGUILayout.BeginHorizontal();
          GUILayout.Space((float) (EditorGUI.indentLevel * 15));
          GUILayout.Label(guiContent);
          GUILayout.FlexibleSpace();
          Rect rect = GUILayoutUtility.GetRect(64f, 64f, new GUILayoutOption[1]{ GUILayout.ExpandWidth(false) });
          EditorGUI.BeginChangeCheck();
          Texture2D texture2D = EditorGUI.DoObjectField(rect, rect, GUIUtility.GetControlID(12354, FocusType.Keyboard, rect), (UnityEngine.Object) ProceduralMaterialInspector.m_Material.GetProceduralTexture(input.name), typeof (Texture2D), (SerializedProperty) null, (EditorGUI.ObjectFieldValidator) null, false) as Texture2D;
          EditorGUILayout.EndHorizontal();
          if (!EditorGUI.EndChangeCheck())
            break;
          this.RecordForUndo(ProceduralMaterialInspector.m_Material, ProceduralMaterialInspector.m_Importer, "Modified property " + input.name + " for material " + ProceduralMaterialInspector.m_Material.name);
          ProceduralMaterialInspector.m_Material.SetProceduralTexture(input.name, texture2D);
          break;
        case ProceduralPropertyType.String:
          EditorGUI.BeginChangeCheck();
          string str = EditorGUILayout.TextField(guiContent, ProceduralMaterialInspector.m_Material.GetProceduralString(input.name), new GUILayoutOption[0]);
          if (!EditorGUI.EndChangeCheck())
            break;
          this.RecordForUndo(ProceduralMaterialInspector.m_Material, ProceduralMaterialInspector.m_Importer, "Modified property " + input.name + " for material " + ProceduralMaterialInspector.m_Material.name);
          ProceduralMaterialInspector.m_Material.SetProceduralString(input.name, str);
          break;
      }
    }

    private void InputHSLGUI(ProceduralPropertyDescription hInput, ProceduralPropertyDescription sInput, ProceduralPropertyDescription lInput)
    {
      GUILayout.Space(5f);
      this.m_ShowHSLInputs = EditorPrefs.GetBool("ProceduralShowHSL", true);
      EditorGUI.BeginChangeCheck();
      this.m_ShowHSLInputs = EditorGUILayout.Foldout(this.m_ShowHSLInputs, this.m_Styles.hslContent, true);
      if (EditorGUI.EndChangeCheck())
        EditorPrefs.SetBool("ProceduralShowHSL", this.m_ShowHSLInputs);
      if (!this.m_ShowHSLInputs)
        return;
      ++EditorGUI.indentLevel;
      this.InputGUI(hInput);
      this.InputGUI(sInput);
      this.InputGUI(lInput);
      --EditorGUI.indentLevel;
    }

    private void InputSeedGUI(ProceduralPropertyDescription input)
    {
      Rect controlRect = EditorGUILayout.GetControlRect();
      EditorGUI.BeginChangeCheck();
      float num = (float) this.RandomIntField(controlRect, this.m_Styles.randomSeedContent, (int) ProceduralMaterialInspector.m_Material.GetProceduralFloat(input.name), 0, 9999);
      if (!EditorGUI.EndChangeCheck())
        return;
      this.RecordForUndo(ProceduralMaterialInspector.m_Material, ProceduralMaterialInspector.m_Importer, "Modified random seed for material " + ProceduralMaterialInspector.m_Material.name);
      ProceduralMaterialInspector.m_Material.SetProceduralFloat(input.name, num);
    }

    internal int RandomIntField(Rect position, GUIContent label, int val, int min, int max)
    {
      position = EditorGUI.PrefixLabel(position, 0, label);
      return this.RandomIntField(position, val, min, max);
    }

    internal int RandomIntField(Rect position, int val, int min, int max)
    {
      position.width = (float) ((double) position.width - (double) EditorGUIUtility.fieldWidth - 5.0);
      if (GUI.Button(position, this.m_Styles.randomizeButtonContent, EditorStyles.miniButton))
        val = UnityEngine.Random.Range(min, max + 1);
      position.x += position.width + 5f;
      position.width = EditorGUIUtility.fieldWidth;
      val = Mathf.Clamp(EditorGUI.IntField(position, val), min, max);
      return val;
    }

    private class Styles
    {
      public GUIContent hslContent = new GUIContent("HSL Adjustment", "Hue_Shift, Saturation, Luminosity");
      public GUIContent randomSeedContent = new GUIContent("Random Seed", "$randomseed : the overall random aspect of the texture.");
      public GUIContent randomizeButtonContent = new GUIContent("Randomize");
      public GUIContent generateAllOutputsContent = new GUIContent("Generate all outputs", "Force the generation of all Substance outputs.");
      public GUIContent animatedContent = new GUIContent("Animation update rate", "Set the animation update rate in millisecond");
      public GUIContent defaultPlatform = EditorGUIUtility.TextContent("Default");
      public GUIContent targetWidth = new GUIContent("Target Width");
      public GUIContent targetHeight = new GUIContent("Target Height");
      public GUIContent textureFormat = EditorGUIUtility.TextContent("Format");
      public GUIContent loadBehavior = new GUIContent("Load Behavior");
      public GUIContent mipmapContent = new GUIContent("Generate Mip Maps");
    }

    [Serializable]
    protected class ProceduralPlatformSetting
    {
      private UnityEngine.Object[] targets;
      public string name;
      public bool m_Overridden;
      public int maxTextureWidth;
      public int maxTextureHeight;
      public int m_TextureFormat;
      public int m_LoadBehavior;
      public BuildTarget target;
      public Texture2D icon;

      public ProceduralPlatformSetting(UnityEngine.Object[] objects, string _name, BuildTarget _target, Texture2D _icon)
      {
        this.targets = objects;
        this.m_Overridden = false;
        this.target = _target;
        this.name = _name;
        this.icon = _icon;
        this.m_Overridden = false;
        if (this.name != "")
        {
          foreach (ProceduralMaterial target in this.targets)
          {
            SubstanceImporter atPath = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath((UnityEngine.Object) target)) as SubstanceImporter;
            if ((UnityEngine.Object) atPath != (UnityEngine.Object) null && atPath.GetPlatformTextureSettings(target.name, this.name, out this.maxTextureWidth, out this.maxTextureHeight, out this.m_TextureFormat, out this.m_LoadBehavior))
            {
              this.m_Overridden = true;
              break;
            }
          }
        }
        if (this.m_Overridden || this.targets.Length <= 0)
          return;
        SubstanceImporter atPath1 = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(this.targets[0])) as SubstanceImporter;
        if ((UnityEngine.Object) atPath1 != (UnityEngine.Object) null)
          atPath1.GetPlatformTextureSettings((this.targets[0] as ProceduralMaterial).name, "", out this.maxTextureWidth, out this.maxTextureHeight, out this.m_TextureFormat, out this.m_LoadBehavior);
      }

      public bool isDefault
      {
        get
        {
          return this.name == "";
        }
      }

      public int textureFormat
      {
        get
        {
          return this.m_TextureFormat;
        }
        set
        {
          this.m_TextureFormat = value;
        }
      }

      public bool overridden
      {
        get
        {
          return this.m_Overridden;
        }
      }

      public void SetOverride(ProceduralMaterialInspector.ProceduralPlatformSetting master)
      {
        this.m_Overridden = true;
      }

      public void ClearOverride(ProceduralMaterialInspector.ProceduralPlatformSetting master)
      {
        this.m_TextureFormat = master.textureFormat;
        this.maxTextureWidth = master.maxTextureWidth;
        this.maxTextureHeight = master.maxTextureHeight;
        this.m_LoadBehavior = master.m_LoadBehavior;
        this.m_Overridden = false;
      }

      public bool HasChanged()
      {
        ProceduralMaterialInspector.ProceduralPlatformSetting proceduralPlatformSetting = new ProceduralMaterialInspector.ProceduralPlatformSetting(this.targets, this.name, this.target, (Texture2D) null);
        return proceduralPlatformSetting.m_Overridden != this.m_Overridden || proceduralPlatformSetting.maxTextureWidth != this.maxTextureWidth || (proceduralPlatformSetting.maxTextureHeight != this.maxTextureHeight || proceduralPlatformSetting.textureFormat != this.textureFormat) || proceduralPlatformSetting.m_LoadBehavior != this.m_LoadBehavior;
      }

      public void Apply()
      {
        foreach (ProceduralMaterial target in this.targets)
        {
          SubstanceImporter atPath = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath((UnityEngine.Object) target)) as SubstanceImporter;
          if (this.name != "")
          {
            if (this.m_Overridden)
              atPath.SetPlatformTextureSettings(target, this.name, this.maxTextureWidth, this.maxTextureHeight, this.m_TextureFormat, this.m_LoadBehavior);
            else
              atPath.ClearPlatformTextureSettings(target.name, this.name);
          }
          else
            atPath.SetPlatformTextureSettings(target, this.name, this.maxTextureWidth, this.maxTextureHeight, this.m_TextureFormat, this.m_LoadBehavior);
        }
      }
    }
  }
}
