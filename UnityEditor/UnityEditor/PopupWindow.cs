﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.PopupWindow
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using UnityEngine;

namespace UnityEditor
{
  /// <summary>
  ///   <para>Class used to display popup windows that inherit from PopupWindowContent.</para>
  /// </summary>
  public class PopupWindow : EditorWindow
  {
    private Vector2 m_LastWantedSize = Vector2.zero;
    private PopupWindowContent m_WindowContent;
    private Rect m_ActivatorRect;
    private static double s_LastClosedTime;
    private static Rect s_LastActivatorRect;

    internal PopupWindow()
    {
    }

    /// <summary>
    ///   <para>Show a popup with the given PopupWindowContent.</para>
    /// </summary>
    /// <param name="activatorRect">The rect of the button that opens the popup.</param>
    /// <param name="windowContent">The content to show in the popup window.</param>
    public static void Show(Rect activatorRect, PopupWindowContent windowContent)
    {
      PopupWindow.Show(activatorRect, windowContent, (PopupLocationHelper.PopupLocation[]) null);
    }

    internal static void Show(Rect activatorRect, PopupWindowContent windowContent, PopupLocationHelper.PopupLocation[] locationPriorityOrder)
    {
      PopupWindow.Show(activatorRect, windowContent, locationPriorityOrder, ShowMode.PopupMenu);
    }

    internal static void Show(Rect activatorRect, PopupWindowContent windowContent, PopupLocationHelper.PopupLocation[] locationPriorityOrder, ShowMode showMode)
    {
      if (!PopupWindow.ShouldShowWindow(activatorRect))
        return;
      PopupWindow instance = ScriptableObject.CreateInstance<PopupWindow>();
      if ((Object) instance != (Object) null)
        instance.Init(activatorRect, windowContent, locationPriorityOrder, showMode);
      GUIUtility.ExitGUI();
    }

    private static bool ShouldShowWindow(Rect activatorRect)
    {
      if (EditorApplication.timeSinceStartup - PopupWindow.s_LastClosedTime < 0.2 && !(activatorRect != PopupWindow.s_LastActivatorRect))
        return false;
      PopupWindow.s_LastActivatorRect = activatorRect;
      return true;
    }

    private void Init(Rect activatorRect, PopupWindowContent windowContent, PopupLocationHelper.PopupLocation[] locationPriorityOrder)
    {
      this.Init(activatorRect, windowContent, locationPriorityOrder, ShowMode.PopupMenu);
    }

    private void Init(Rect activatorRect, PopupWindowContent windowContent, PopupLocationHelper.PopupLocation[] locationPriorityOrder, ShowMode showMode)
    {
      this.hideFlags = HideFlags.DontSave;
      this.wantsMouseMove = true;
      this.m_WindowContent = windowContent;
      this.m_WindowContent.editorWindow = (EditorWindow) this;
      this.m_WindowContent.OnOpen();
      this.m_ActivatorRect = GUIUtility.GUIToScreenRect(activatorRect);
      this.ShowAsDropDown(this.m_ActivatorRect, this.m_WindowContent.GetWindowSize(), locationPriorityOrder, showMode);
    }

    internal void OnGUI()
    {
      this.FitWindowToContent();
      Rect rect = new Rect(0.0f, 0.0f, this.position.width, this.position.height);
      this.m_WindowContent.OnGUI(rect);
      GUI.Label(rect, GUIContent.none, (GUIStyle) "grey_border");
    }

    private void FitWindowToContent()
    {
      Vector2 windowSize = this.m_WindowContent.GetWindowSize();
      if (!(this.m_LastWantedSize != windowSize))
        return;
      this.m_LastWantedSize = windowSize;
      Rect dropDownRect = this.m_Parent.window.GetDropDownRect(this.m_ActivatorRect, windowSize, windowSize);
      Vector2 vector2 = new Vector2(dropDownRect.width, dropDownRect.height);
      this.maxSize = vector2;
      this.minSize = vector2;
      this.position = dropDownRect;
    }

    private void CloseWindow()
    {
      this.Close();
    }

    private void OnEnable()
    {
      AssemblyReloadEvents.beforeAssemblyReload += new AssemblyReloadEvents.AssemblyReloadCallback(this.CloseWindow);
    }

    private void OnDisable()
    {
      AssemblyReloadEvents.beforeAssemblyReload -= new AssemblyReloadEvents.AssemblyReloadCallback(this.CloseWindow);
      PopupWindow.s_LastClosedTime = EditorApplication.timeSinceStartup;
      if (this.m_WindowContent == null)
        return;
      this.m_WindowContent.OnClose();
    }
  }
}
