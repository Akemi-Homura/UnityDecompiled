﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.AssetStorePreviewManager
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System.Collections.Generic;
using UnityEngine;

namespace UnityEditor
{
  internal sealed class AssetStorePreviewManager
  {
    private static AssetStorePreviewManager s_SharedAssetStorePreviewManager = (AssetStorePreviewManager) null;
    private static RenderTexture s_RenderTexture = (RenderTexture) null;
    private static bool s_NeedsRepaint = false;
    private int m_MaxCachedAssetStoreImages = 10;
    private int m_Aborted = 0;
    private int m_Success = 0;
    internal int Requested = 0;
    internal int CacheHit = 0;
    private int m_CacheRemove = 0;
    private int m_ConvertedThisTick = 0;
    private AssetStorePreviewManager.CachedAssetStoreImage m_DummyItem = new AssetStorePreviewManager.CachedAssetStoreImage();
    private Dictionary<string, AssetStorePreviewManager.CachedAssetStoreImage> m_CachedAssetStoreImages;
    private const double kQueryDelay = 0.2;
    private const int kMaxConcurrentDownloads = 15;
    private const int kMaxConvertionsPerTick = 1;

    private AssetStorePreviewManager()
    {
    }

    internal static AssetStorePreviewManager Instance
    {
      get
      {
        if (AssetStorePreviewManager.s_SharedAssetStorePreviewManager == null)
        {
          AssetStorePreviewManager.s_SharedAssetStorePreviewManager = new AssetStorePreviewManager();
          AssetStorePreviewManager.s_SharedAssetStorePreviewManager.m_DummyItem.lastUsed = -1.0;
        }
        return AssetStorePreviewManager.s_SharedAssetStorePreviewManager;
      }
    }

    private static Dictionary<string, AssetStorePreviewManager.CachedAssetStoreImage> CachedAssetStoreImages
    {
      get
      {
        if (AssetStorePreviewManager.Instance.m_CachedAssetStoreImages == null)
          AssetStorePreviewManager.Instance.m_CachedAssetStoreImages = new Dictionary<string, AssetStorePreviewManager.CachedAssetStoreImage>();
        return AssetStorePreviewManager.Instance.m_CachedAssetStoreImages;
      }
    }

    public static int MaxCachedImages
    {
      get
      {
        return AssetStorePreviewManager.Instance.m_MaxCachedAssetStoreImages;
      }
      set
      {
        AssetStorePreviewManager.Instance.m_MaxCachedAssetStoreImages = value;
      }
    }

    public static bool CacheFull
    {
      get
      {
        return AssetStorePreviewManager.CachedAssetStoreImages.Count >= AssetStorePreviewManager.MaxCachedImages;
      }
    }

    public static int Downloading
    {
      get
      {
        int num = 0;
        foreach (KeyValuePair<string, AssetStorePreviewManager.CachedAssetStoreImage> cachedAssetStoreImage in AssetStorePreviewManager.CachedAssetStoreImages)
        {
          if (cachedAssetStoreImage.Value.client != null)
            ++num;
        }
        return num;
      }
    }

    public static string StatsString()
    {
      return string.Format("Reqs: {0}, Ok: {1}, Abort: {2}, CacheDel: {3}, Cache: {4}/{5}, CacheHit: {6}", (object) AssetStorePreviewManager.Instance.Requested, (object) AssetStorePreviewManager.Instance.m_Success, (object) AssetStorePreviewManager.Instance.m_Aborted, (object) AssetStorePreviewManager.Instance.m_CacheRemove, (object) AssetStorePreviewManager.CachedAssetStoreImages.Count, (object) AssetStorePreviewManager.Instance.m_MaxCachedAssetStoreImages, (object) AssetStorePreviewManager.Instance.CacheHit);
    }

    public static AssetStorePreviewManager.CachedAssetStoreImage TextureFromUrl(string url, string label, int textureSize, GUIStyle labelStyle, GUIStyle iconStyle, bool onlyCached)
    {
      if (string.IsNullOrEmpty(url))
        return AssetStorePreviewManager.Instance.m_DummyItem;
      bool flag1 = true;
      AssetStorePreviewManager.CachedAssetStoreImage cached;
      if (AssetStorePreviewManager.CachedAssetStoreImages.TryGetValue(url, out cached))
      {
        cached.lastUsed = EditorApplication.timeSinceStartup;
        bool flag2 = cached.requestedWidth == textureSize;
        bool flag3 = (Object) cached.image != (Object) null && cached.image.width == textureSize;
        bool flag4 = cached.requestedWidth == -1;
        if ((flag3 || flag2 || onlyCached) && !flag4)
        {
          ++AssetStorePreviewManager.Instance.CacheHit;
          bool flag5 = cached.client != null || cached.label == null;
          bool flag6 = AssetStorePreviewManager.Instance.m_ConvertedThisTick > 1;
          AssetStorePreviewManager.s_NeedsRepaint = AssetStorePreviewManager.s_NeedsRepaint || flag6;
          return flag5 || flag6 ? cached : AssetStorePreviewManager.RenderEntry(cached, labelStyle, iconStyle);
        }
        flag1 = false;
        if (AssetStorePreviewManager.Downloading >= 15)
          return !((Object) cached.image == (Object) null) ? cached : AssetStorePreviewManager.Instance.m_DummyItem;
      }
      else
      {
        if (onlyCached || AssetStorePreviewManager.Downloading >= 15)
          return AssetStorePreviewManager.Instance.m_DummyItem;
        cached = new AssetStorePreviewManager.CachedAssetStoreImage();
        cached.image = (Texture2D) null;
        cached.lastUsed = EditorApplication.timeSinceStartup;
      }
      if ((Object) cached.image == (Object) null)
        cached.lastFetched = EditorApplication.timeSinceStartup;
      cached.requestedWidth = textureSize;
      cached.label = label;
      AsyncHTTPClient asyncHttpClient = AssetStorePreviewManager.SetupTextureDownload(cached, url, "previewSize-" + (object) textureSize);
      AssetStorePreviewManager.ExpireCacheEntries();
      if (flag1)
        AssetStorePreviewManager.CachedAssetStoreImages.Add(url, cached);
      asyncHttpClient.Begin();
      ++AssetStorePreviewManager.Instance.Requested;
      return cached;
    }

    private static AsyncHTTPClient SetupTextureDownload(AssetStorePreviewManager.CachedAssetStoreImage cached, string url, string tag)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      AssetStorePreviewManager.\u003CSetupTextureDownload\u003Ec__AnonStorey0 downloadCAnonStorey0 = new AssetStorePreviewManager.\u003CSetupTextureDownload\u003Ec__AnonStorey0();
      // ISSUE: reference to a compiler-generated field
      downloadCAnonStorey0.cached = cached;
      // ISSUE: reference to a compiler-generated field
      downloadCAnonStorey0.url = url;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      downloadCAnonStorey0.client = new AsyncHTTPClient(downloadCAnonStorey0.url);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      downloadCAnonStorey0.cached.client = downloadCAnonStorey0.client;
      // ISSUE: reference to a compiler-generated field
      downloadCAnonStorey0.client.tag = tag;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      downloadCAnonStorey0.client.doneCallback = new AsyncHTTPClient.DoneCallback(downloadCAnonStorey0.\u003C\u003Em__0);
      // ISSUE: reference to a compiler-generated field
      return downloadCAnonStorey0.client;
    }

    private static void ExpireCacheEntries()
    {
      while (AssetStorePreviewManager.CacheFull)
      {
        string key = (string) null;
        AssetStorePreviewManager.CachedAssetStoreImage cachedAssetStoreImage1 = (AssetStorePreviewManager.CachedAssetStoreImage) null;
        foreach (KeyValuePair<string, AssetStorePreviewManager.CachedAssetStoreImage> cachedAssetStoreImage2 in AssetStorePreviewManager.CachedAssetStoreImages)
        {
          if (cachedAssetStoreImage1 == null || cachedAssetStoreImage1.lastUsed > cachedAssetStoreImage2.Value.lastUsed)
          {
            cachedAssetStoreImage1 = cachedAssetStoreImage2.Value;
            key = cachedAssetStoreImage2.Key;
          }
        }
        AssetStorePreviewManager.CachedAssetStoreImages.Remove(key);
        ++AssetStorePreviewManager.Instance.m_CacheRemove;
        if (cachedAssetStoreImage1 == null)
        {
          Debug.LogError((object) "Null entry found while removing cache entry");
          break;
        }
        if (cachedAssetStoreImage1.client != null)
        {
          cachedAssetStoreImage1.client.Abort();
          cachedAssetStoreImage1.client = (AsyncHTTPClient) null;
        }
        if ((Object) cachedAssetStoreImage1.image != (Object) null)
          Object.DestroyImmediate((Object) cachedAssetStoreImage1.image);
      }
    }

    private static AssetStorePreviewManager.CachedAssetStoreImage RenderEntry(AssetStorePreviewManager.CachedAssetStoreImage cached, GUIStyle labelStyle, GUIStyle iconStyle)
    {
      if (cached.label == null || (Object) cached.image == (Object) null)
        return cached;
      Texture2D image = cached.image;
      cached.image = new Texture2D(cached.requestedWidth, cached.requestedWidth, TextureFormat.RGB24, false, true);
      AssetStorePreviewManager.ScaleImage(cached.requestedWidth, cached.requestedWidth, image, cached.image, iconStyle);
      Object.DestroyImmediate((Object) image);
      cached.label = (string) null;
      ++AssetStorePreviewManager.Instance.m_ConvertedThisTick;
      return cached;
    }

    internal static void ScaleImage(int w, int h, Texture2D inimage, Texture2D outimage, GUIStyle bgStyle)
    {
      SavedRenderTargetState renderTargetState = new SavedRenderTargetState();
      if ((Object) AssetStorePreviewManager.s_RenderTexture != (Object) null && (AssetStorePreviewManager.s_RenderTexture.width != w || AssetStorePreviewManager.s_RenderTexture.height != h))
      {
        Object.DestroyImmediate((Object) AssetStorePreviewManager.s_RenderTexture);
        AssetStorePreviewManager.s_RenderTexture = (RenderTexture) null;
      }
      if ((Object) AssetStorePreviewManager.s_RenderTexture == (Object) null)
      {
        AssetStorePreviewManager.s_RenderTexture = RenderTexture.GetTemporary(w, h, 16, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
        AssetStorePreviewManager.s_RenderTexture.hideFlags = HideFlags.HideAndDontSave;
      }
      RenderTexture renderTexture = AssetStorePreviewManager.s_RenderTexture;
      RenderTexture.active = renderTexture;
      Rect rect = new Rect(0.0f, 0.0f, (float) w, (float) h);
      EditorGUIUtility.SetRenderTextureNoViewport(renderTexture);
      GL.LoadOrtho();
      GL.LoadPixelMatrix(0.0f, (float) w, (float) h, 0.0f);
      ShaderUtil.rawViewportRect = new Rect(0.0f, 0.0f, (float) w, (float) h);
      ShaderUtil.rawScissorRect = new Rect(0.0f, 0.0f, (float) w, (float) h);
      GL.Clear(true, true, new Color(0.0f, 0.0f, 0.0f, 0.0f));
      Rect screenRect = rect;
      if (inimage.width > inimage.height)
      {
        float num = screenRect.height * ((float) inimage.height / (float) inimage.width);
        screenRect.height = (float) (int) num;
        screenRect.y += (float) (int) ((double) num * 0.5);
      }
      else if (inimage.width < inimage.height)
      {
        float num = screenRect.width * ((float) inimage.width / (float) inimage.height);
        screenRect.width = (float) (int) num;
        screenRect.x += (float) (int) ((double) num * 0.5);
      }
      if (bgStyle != null && bgStyle.normal != null && (Object) bgStyle.normal.background != (Object) null)
        Graphics.DrawTexture(rect, (Texture) bgStyle.normal.background);
      Graphics.DrawTexture(screenRect, (Texture) inimage);
      outimage.ReadPixels(rect, 0, 0, false);
      outimage.Apply();
      outimage.hideFlags = HideFlags.HideAndDontSave;
      renderTargetState.Restore();
    }

    public static bool CheckRepaint()
    {
      bool needsRepaint = AssetStorePreviewManager.s_NeedsRepaint;
      AssetStorePreviewManager.s_NeedsRepaint = false;
      return needsRepaint;
    }

    public static void AbortSize(int size)
    {
      AsyncHTTPClient.AbortByTag("previewSize-" + size.ToString());
      foreach (KeyValuePair<string, AssetStorePreviewManager.CachedAssetStoreImage> cachedAssetStoreImage in AssetStorePreviewManager.CachedAssetStoreImages)
      {
        if (cachedAssetStoreImage.Value.requestedWidth == size)
        {
          cachedAssetStoreImage.Value.requestedWidth = -1;
          cachedAssetStoreImage.Value.client = (AsyncHTTPClient) null;
        }
      }
    }

    public static void AbortOlderThan(double timestamp)
    {
      foreach (KeyValuePair<string, AssetStorePreviewManager.CachedAssetStoreImage> cachedAssetStoreImage1 in AssetStorePreviewManager.CachedAssetStoreImages)
      {
        AssetStorePreviewManager.CachedAssetStoreImage cachedAssetStoreImage2 = cachedAssetStoreImage1.Value;
        if (cachedAssetStoreImage2.lastUsed < timestamp && cachedAssetStoreImage2.client != null)
        {
          cachedAssetStoreImage2.requestedWidth = -1;
          cachedAssetStoreImage2.client.Abort();
          cachedAssetStoreImage2.client = (AsyncHTTPClient) null;
        }
      }
      AssetStorePreviewManager.Instance.m_ConvertedThisTick = 0;
    }

    public class CachedAssetStoreImage
    {
      private const double kFadeTime = 0.5;
      public Texture2D image;
      public double lastUsed;
      public double lastFetched;
      public int requestedWidth;
      public string label;
      internal AsyncHTTPClient client;

      public Color color
      {
        get
        {
          return Color.Lerp(new Color(1f, 1f, 1f, 0.0f), new Color(1f, 1f, 1f, 1f), Mathf.Min(1f, (float) ((EditorApplication.timeSinceStartup - this.lastFetched) / 0.5)));
        }
      }
    }
  }
}
