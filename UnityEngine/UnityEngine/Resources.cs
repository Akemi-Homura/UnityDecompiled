﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.Resources
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting;
using UnityEngineInternal;

namespace UnityEngine
{
  /// <summary>
  ///   <para>The Resources class allows you to find and access Objects including assets.</para>
  /// </summary>
  public sealed class Resources
  {
    internal static T[] ConvertObjects<T>(Object[] rawObjects) where T : Object
    {
      if (rawObjects == null)
        return (T[]) null;
      T[] objArray = new T[rawObjects.Length];
      for (int index = 0; index < objArray.Length; ++index)
        objArray[index] = (T) rawObjects[index];
      return objArray;
    }

    /// <summary>
    ///   <para>Returns a list of all objects of Type type.</para>
    /// </summary>
    /// <param name="type">Type of the class to match while searching.</param>
    /// <returns>
    ///   <para>An array of objects whose class is type or is derived from type.</para>
    /// </returns>
    [TypeInferenceRule(TypeInferenceRules.ArrayOfTypeReferencedByFirstArgument)]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern Object[] FindObjectsOfTypeAll(System.Type type);

    public static T[] FindObjectsOfTypeAll<T>() where T : Object
    {
      return Resources.ConvertObjects<T>(Resources.FindObjectsOfTypeAll(typeof (T)));
    }

    /// <summary>
    ///   <para>Loads an asset stored at path in a Resources folder.</para>
    /// </summary>
    /// <param name="path">Pathname of the target folder. When using the empty string (i.e., ""), the function will load the entire contents of the Resources folder.</param>
    public static Object Load(string path)
    {
      return Resources.Load(path, typeof (Object));
    }

    public static T Load<T>(string path) where T : Object
    {
      return (T) Resources.Load(path, typeof (T));
    }

    /// <summary>
    ///   <para>Loads an asset stored at path in a Resources folder.</para>
    /// </summary>
    /// <param name="path">Pathname of the target folder. When using the empty string (i.e., ""), the function will load the entire contents of the Resources folder.</param>
    /// <param name="systemTypeInstance">Type filter for objects returned.</param>
    [TypeInferenceRule(TypeInferenceRules.TypeReferencedBySecondArgument)]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern Object Load(string path, System.Type systemTypeInstance);

    /// <summary>
    ///   <para>Asynchronously loads an asset stored at path in a Resources folder.</para>
    /// </summary>
    /// <param name="path">Pathname of the target folder. When using the empty string (i.e., ""), the function will load the entire contents of the Resources folder.</param>
    public static ResourceRequest LoadAsync(string path)
    {
      return Resources.LoadAsync(path, typeof (Object));
    }

    public static ResourceRequest LoadAsync<T>(string path) where T : Object
    {
      return Resources.LoadAsync(path, typeof (T));
    }

    /// <summary>
    ///   <para>Asynchronously loads an asset stored at path in a Resources folder.</para>
    /// </summary>
    /// <param name="path">Pathname of the target folder. When using the empty string (i.e., ""), the function will load the entire contents of the Resources folder.</param>
    /// <param name="systemTypeInstance">Type filter for objects returned.</param>
    /// <param name="type"></param>
    public static ResourceRequest LoadAsync(string path, System.Type type)
    {
      ResourceRequest resourceRequest = Resources.LoadAsyncInternal(path, type);
      resourceRequest.m_Path = path;
      resourceRequest.m_Type = type;
      return resourceRequest;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern ResourceRequest LoadAsyncInternal(string path, System.Type type);

    /// <summary>
    ///   <para>Loads all assets in a folder or file at path in a Resources folder.</para>
    /// </summary>
    /// <param name="path">Pathname of the target folder. When using the empty string (i.e., ""), the function will load the entire contents of the Resources folder.</param>
    /// <param name="systemTypeInstance">Type filter for objects returned.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern Object[] LoadAll(string path, System.Type systemTypeInstance);

    /// <summary>
    ///   <para>Loads all assets in a folder or file at path in a Resources folder.</para>
    /// </summary>
    /// <param name="path">Pathname of the target folder. When using the empty string (i.e., ""), the function will load the entire contents of the Resources folder.</param>
    /// <param name="systemTypeInstance">Type filter for objects returned.</param>
    public static Object[] LoadAll(string path)
    {
      return Resources.LoadAll(path, typeof (Object));
    }

    public static T[] LoadAll<T>(string path) where T : Object
    {
      return Resources.ConvertObjects<T>(Resources.LoadAll(path, typeof (T)));
    }

    [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern Object GetBuiltinResource(System.Type type, string path);

    public static T GetBuiltinResource<T>(string path) where T : Object
    {
      return (T) Resources.GetBuiltinResource(typeof (T), path);
    }

    /// <summary>
    ///   <para>Unloads assetToUnload from memory.</para>
    /// </summary>
    /// <param name="assetToUnload"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void UnloadAsset(Object assetToUnload);

    /// <summary>
    ///   <para>Unloads assets that are not used.</para>
    /// </summary>
    /// <returns>
    ///   <para>Object on which you can yield to wait until the operation completes.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern AsyncOperation UnloadUnusedAssets();

    /// <summary>
    ///   <para>Returns a resource at an asset path (Editor Only).</para>
    /// </summary>
    /// <param name="assetPath">Pathname of the target asset.</param>
    /// <param name="type">Type filter for objects returned.</param>
    [TypeInferenceRule(TypeInferenceRules.TypeReferencedBySecondArgument)]
    [Obsolete("Use AssetDatabase.LoadAssetAtPath instead (UnityUpgradable) -> * [UnityEditor] UnityEditor.AssetDatabase.LoadAssetAtPath(*)", true)]
    public static Object LoadAssetAtPath(string assetPath, System.Type type)
    {
      return (Object) null;
    }

    [Obsolete("Use AssetDatabase.LoadAssetAtPath<T>() instead (UnityUpgradable) -> * [UnityEditor] UnityEditor.AssetDatabase.LoadAssetAtPath<T>(*)", true)]
    public static T LoadAssetAtPath<T>(string assetPath) where T : Object
    {
      return (T) null;
    }
  }
}
