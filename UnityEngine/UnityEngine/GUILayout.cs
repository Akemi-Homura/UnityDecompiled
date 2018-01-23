﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.GUILayout
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

namespace UnityEngine
{
  /// <summary>
  ///   <para>The GUILayout class is the interface for Unity gui with automatic layout.</para>
  /// </summary>
  public class GUILayout
  {
    /// <summary>
    ///   <para>Make an auto-layout label.</para>
    /// </summary>
    /// <param name="text">Text to display on the label.</param>
    /// <param name="image">Texture to display on the label.</param>
    /// <param name="content">Text, image and tooltip for this label.</param>
    /// <param name="style">The style to use. If left out, the label style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void Label(Texture image, params GUILayoutOption[] options)
    {
      GUILayout.DoLabel(GUIContent.Temp(image), GUI.skin.label, options);
    }

    /// <summary>
    ///   <para>Make an auto-layout label.</para>
    /// </summary>
    /// <param name="text">Text to display on the label.</param>
    /// <param name="image">Texture to display on the label.</param>
    /// <param name="content">Text, image and tooltip for this label.</param>
    /// <param name="style">The style to use. If left out, the label style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void Label(string text, params GUILayoutOption[] options)
    {
      GUILayout.DoLabel(GUIContent.Temp(text), GUI.skin.label, options);
    }

    /// <summary>
    ///   <para>Make an auto-layout label.</para>
    /// </summary>
    /// <param name="text">Text to display on the label.</param>
    /// <param name="image">Texture to display on the label.</param>
    /// <param name="content">Text, image and tooltip for this label.</param>
    /// <param name="style">The style to use. If left out, the label style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void Label(GUIContent content, params GUILayoutOption[] options)
    {
      GUILayout.DoLabel(content, GUI.skin.label, options);
    }

    /// <summary>
    ///   <para>Make an auto-layout label.</para>
    /// </summary>
    /// <param name="text">Text to display on the label.</param>
    /// <param name="image">Texture to display on the label.</param>
    /// <param name="content">Text, image and tooltip for this label.</param>
    /// <param name="style">The style to use. If left out, the label style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void Label(Texture image, GUIStyle style, params GUILayoutOption[] options)
    {
      GUILayout.DoLabel(GUIContent.Temp(image), style, options);
    }

    /// <summary>
    ///   <para>Make an auto-layout label.</para>
    /// </summary>
    /// <param name="text">Text to display on the label.</param>
    /// <param name="image">Texture to display on the label.</param>
    /// <param name="content">Text, image and tooltip for this label.</param>
    /// <param name="style">The style to use. If left out, the label style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void Label(string text, GUIStyle style, params GUILayoutOption[] options)
    {
      GUILayout.DoLabel(GUIContent.Temp(text), style, options);
    }

    /// <summary>
    ///   <para>Make an auto-layout label.</para>
    /// </summary>
    /// <param name="text">Text to display on the label.</param>
    /// <param name="image">Texture to display on the label.</param>
    /// <param name="content">Text, image and tooltip for this label.</param>
    /// <param name="style">The style to use. If left out, the label style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void Label(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
    {
      GUILayout.DoLabel(content, style, options);
    }

    private static void DoLabel(GUIContent content, GUIStyle style, GUILayoutOption[] options)
    {
      GUI.Label(GUILayoutUtility.GetRect(content, style, options), content, style);
    }

    /// <summary>
    ///   <para>Make an auto-layout box.</para>
    /// </summary>
    /// <param name="text">Text to display on the box.</param>
    /// <param name="image">Texture to display on the box.</param>
    /// <param name="content">Text, image and tooltip for this box.</param>
    /// <param name="style">The style to use. If left out, the box style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void Box(Texture image, params GUILayoutOption[] options)
    {
      GUILayout.DoBox(GUIContent.Temp(image), GUI.skin.box, options);
    }

    /// <summary>
    ///   <para>Make an auto-layout box.</para>
    /// </summary>
    /// <param name="text">Text to display on the box.</param>
    /// <param name="image">Texture to display on the box.</param>
    /// <param name="content">Text, image and tooltip for this box.</param>
    /// <param name="style">The style to use. If left out, the box style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void Box(string text, params GUILayoutOption[] options)
    {
      GUILayout.DoBox(GUIContent.Temp(text), GUI.skin.box, options);
    }

    /// <summary>
    ///   <para>Make an auto-layout box.</para>
    /// </summary>
    /// <param name="text">Text to display on the box.</param>
    /// <param name="image">Texture to display on the box.</param>
    /// <param name="content">Text, image and tooltip for this box.</param>
    /// <param name="style">The style to use. If left out, the box style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void Box(GUIContent content, params GUILayoutOption[] options)
    {
      GUILayout.DoBox(content, GUI.skin.box, options);
    }

    /// <summary>
    ///   <para>Make an auto-layout box.</para>
    /// </summary>
    /// <param name="text">Text to display on the box.</param>
    /// <param name="image">Texture to display on the box.</param>
    /// <param name="content">Text, image and tooltip for this box.</param>
    /// <param name="style">The style to use. If left out, the box style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void Box(Texture image, GUIStyle style, params GUILayoutOption[] options)
    {
      GUILayout.DoBox(GUIContent.Temp(image), style, options);
    }

    /// <summary>
    ///   <para>Make an auto-layout box.</para>
    /// </summary>
    /// <param name="text">Text to display on the box.</param>
    /// <param name="image">Texture to display on the box.</param>
    /// <param name="content">Text, image and tooltip for this box.</param>
    /// <param name="style">The style to use. If left out, the box style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void Box(string text, GUIStyle style, params GUILayoutOption[] options)
    {
      GUILayout.DoBox(GUIContent.Temp(text), style, options);
    }

    /// <summary>
    ///   <para>Make an auto-layout box.</para>
    /// </summary>
    /// <param name="text">Text to display on the box.</param>
    /// <param name="image">Texture to display on the box.</param>
    /// <param name="content">Text, image and tooltip for this box.</param>
    /// <param name="style">The style to use. If left out, the box style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void Box(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
    {
      GUILayout.DoBox(content, style, options);
    }

    private static void DoBox(GUIContent content, GUIStyle style, GUILayoutOption[] options)
    {
      GUI.Box(GUILayoutUtility.GetRect(content, style, options), content, style);
    }

    /// <summary>
    ///   <para>Make a single press button.</para>
    /// </summary>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>true when the users clicks the button.</para>
    /// </returns>
    public static bool Button(Texture image, params GUILayoutOption[] options)
    {
      return GUILayout.DoButton(GUIContent.Temp(image), GUI.skin.button, options);
    }

    /// <summary>
    ///   <para>Make a single press button.</para>
    /// </summary>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>true when the users clicks the button.</para>
    /// </returns>
    public static bool Button(string text, params GUILayoutOption[] options)
    {
      return GUILayout.DoButton(GUIContent.Temp(text), GUI.skin.button, options);
    }

    /// <summary>
    ///   <para>Make a single press button.</para>
    /// </summary>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>true when the users clicks the button.</para>
    /// </returns>
    public static bool Button(GUIContent content, params GUILayoutOption[] options)
    {
      return GUILayout.DoButton(content, GUI.skin.button, options);
    }

    /// <summary>
    ///   <para>Make a single press button.</para>
    /// </summary>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>true when the users clicks the button.</para>
    /// </returns>
    public static bool Button(Texture image, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.DoButton(GUIContent.Temp(image), style, options);
    }

    /// <summary>
    ///   <para>Make a single press button.</para>
    /// </summary>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>true when the users clicks the button.</para>
    /// </returns>
    public static bool Button(string text, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.DoButton(GUIContent.Temp(text), style, options);
    }

    /// <summary>
    ///   <para>Make a single press button.</para>
    /// </summary>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>true when the users clicks the button.</para>
    /// </returns>
    public static bool Button(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.DoButton(content, style, options);
    }

    private static bool DoButton(GUIContent content, GUIStyle style, GUILayoutOption[] options)
    {
      return GUI.Button(GUILayoutUtility.GetRect(content, style, options), content, style);
    }

    /// <summary>
    ///   <para>Make a repeating button. The button returns true as long as the user holds down the mouse.</para>
    /// </summary>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>true when the holds down the mouse.</para>
    /// </returns>
    public static bool RepeatButton(Texture image, params GUILayoutOption[] options)
    {
      return GUILayout.DoRepeatButton(GUIContent.Temp(image), GUI.skin.button, options);
    }

    /// <summary>
    ///   <para>Make a repeating button. The button returns true as long as the user holds down the mouse.</para>
    /// </summary>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>true when the holds down the mouse.</para>
    /// </returns>
    public static bool RepeatButton(string text, params GUILayoutOption[] options)
    {
      return GUILayout.DoRepeatButton(GUIContent.Temp(text), GUI.skin.button, options);
    }

    /// <summary>
    ///   <para>Make a repeating button. The button returns true as long as the user holds down the mouse.</para>
    /// </summary>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>true when the holds down the mouse.</para>
    /// </returns>
    public static bool RepeatButton(GUIContent content, params GUILayoutOption[] options)
    {
      return GUILayout.DoRepeatButton(content, GUI.skin.button, options);
    }

    /// <summary>
    ///   <para>Make a repeating button. The button returns true as long as the user holds down the mouse.</para>
    /// </summary>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>true when the holds down the mouse.</para>
    /// </returns>
    public static bool RepeatButton(Texture image, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.DoRepeatButton(GUIContent.Temp(image), style, options);
    }

    /// <summary>
    ///   <para>Make a repeating button. The button returns true as long as the user holds down the mouse.</para>
    /// </summary>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>true when the holds down the mouse.</para>
    /// </returns>
    public static bool RepeatButton(string text, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.DoRepeatButton(GUIContent.Temp(text), style, options);
    }

    /// <summary>
    ///   <para>Make a repeating button. The button returns true as long as the user holds down the mouse.</para>
    /// </summary>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>true when the holds down the mouse.</para>
    /// </returns>
    public static bool RepeatButton(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.DoRepeatButton(content, style, options);
    }

    private static bool DoRepeatButton(GUIContent content, GUIStyle style, GUILayoutOption[] options)
    {
      return GUI.RepeatButton(GUILayoutUtility.GetRect(content, style, options), content, style);
    }

    /// <summary>
    ///   <para>Make a single-line text field where the user can edit a string.</para>
    /// </summary>
    /// <param name="text">Text to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textArea style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>The edited string.</para>
    /// </returns>
    public static string TextField(string text, params GUILayoutOption[] options)
    {
      return GUILayout.DoTextField(text, -1, false, GUI.skin.textField, options);
    }

    /// <summary>
    ///   <para>Make a single-line text field where the user can edit a string.</para>
    /// </summary>
    /// <param name="text">Text to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textArea style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>The edited string.</para>
    /// </returns>
    public static string TextField(string text, int maxLength, params GUILayoutOption[] options)
    {
      return GUILayout.DoTextField(text, maxLength, false, GUI.skin.textField, options);
    }

    /// <summary>
    ///   <para>Make a single-line text field where the user can edit a string.</para>
    /// </summary>
    /// <param name="text">Text to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textArea style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>The edited string.</para>
    /// </returns>
    public static string TextField(string text, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.DoTextField(text, -1, false, style, options);
    }

    /// <summary>
    ///   <para>Make a single-line text field where the user can edit a string.</para>
    /// </summary>
    /// <param name="text">Text to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textArea style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>The edited string.</para>
    /// </returns>
    public static string TextField(string text, int maxLength, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.DoTextField(text, maxLength, true, style, options);
    }

    /// <summary>
    ///   <para>Make a text field where the user can enter a password.</para>
    /// </summary>
    /// <param name="password">Password to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maskChar">Character to mask the password with.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textField style from the current GUISkin is used.</param>
    /// <param name="options"></param>
    /// <returns>
    ///   <para>The edited password.</para>
    /// </returns>
    public static string PasswordField(string password, char maskChar, params GUILayoutOption[] options)
    {
      return GUILayout.PasswordField(password, maskChar, -1, GUI.skin.textField, options);
    }

    /// <summary>
    ///   <para>Make a text field where the user can enter a password.</para>
    /// </summary>
    /// <param name="password">Password to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maskChar">Character to mask the password with.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textField style from the current GUISkin is used.</param>
    /// <param name="options"></param>
    /// <returns>
    ///   <para>The edited password.</para>
    /// </returns>
    public static string PasswordField(string password, char maskChar, int maxLength, params GUILayoutOption[] options)
    {
      return GUILayout.PasswordField(password, maskChar, maxLength, GUI.skin.textField, options);
    }

    /// <summary>
    ///   <para>Make a text field where the user can enter a password.</para>
    /// </summary>
    /// <param name="password">Password to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maskChar">Character to mask the password with.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textField style from the current GUISkin is used.</param>
    /// <param name="options"></param>
    /// <returns>
    ///   <para>The edited password.</para>
    /// </returns>
    public static string PasswordField(string password, char maskChar, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.PasswordField(password, maskChar, -1, style, options);
    }

    /// <summary>
    ///   <para>Make a text field where the user can enter a password.</para>
    /// </summary>
    /// <param name="password">Password to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maskChar">Character to mask the password with.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textField style from the current GUISkin is used.</param>
    /// <param name="options"></param>
    /// <returns>
    ///   <para>The edited password.</para>
    /// </returns>
    public static string PasswordField(string password, char maskChar, int maxLength, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUI.PasswordField(GUILayoutUtility.GetRect(GUIContent.Temp(GUI.PasswordFieldGetStrToShow(password, maskChar)), GUI.skin.textField, options), password, maskChar, maxLength, style);
    }

    /// <summary>
    ///   <para>Make a multi-line text field where the user can edit a string.</para>
    /// </summary>
    /// <param name="text">Text to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textField style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&amp;amp;lt;br&amp;amp;gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>The edited string.</para>
    /// </returns>
    public static string TextArea(string text, params GUILayoutOption[] options)
    {
      return GUILayout.DoTextField(text, -1, true, GUI.skin.textArea, options);
    }

    /// <summary>
    ///   <para>Make a multi-line text field where the user can edit a string.</para>
    /// </summary>
    /// <param name="text">Text to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textField style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&amp;amp;lt;br&amp;amp;gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>The edited string.</para>
    /// </returns>
    public static string TextArea(string text, int maxLength, params GUILayoutOption[] options)
    {
      return GUILayout.DoTextField(text, maxLength, true, GUI.skin.textArea, options);
    }

    /// <summary>
    ///   <para>Make a multi-line text field where the user can edit a string.</para>
    /// </summary>
    /// <param name="text">Text to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textField style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&amp;amp;lt;br&amp;amp;gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>The edited string.</para>
    /// </returns>
    public static string TextArea(string text, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.DoTextField(text, -1, true, style, options);
    }

    /// <summary>
    ///   <para>Make a multi-line text field where the user can edit a string.</para>
    /// </summary>
    /// <param name="text">Text to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textField style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&amp;amp;lt;br&amp;amp;gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>The edited string.</para>
    /// </returns>
    public static string TextArea(string text, int maxLength, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.DoTextField(text, maxLength, true, style, options);
    }

    private static string DoTextField(string text, int maxLength, bool multiline, GUIStyle style, GUILayoutOption[] options)
    {
      int controlId = GUIUtility.GetControlID(FocusType.Keyboard);
      GUIContent.Temp(text);
      GUIContent content = GUIUtility.keyboardControl == controlId ? GUIContent.Temp(text + Input.compositionString) : GUIContent.Temp(text);
      Rect rect = GUILayoutUtility.GetRect(content, style, options);
      if (GUIUtility.keyboardControl == controlId)
        content = GUIContent.Temp(text);
      GUI.DoTextField(rect, controlId, content, multiline, maxLength, style);
      return content.text;
    }

    /// <summary>
    ///   <para>Make an on/off toggle button.</para>
    /// </summary>
    /// <param name="value">Is the button on or off?</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>The new value of the button.</para>
    /// </returns>
    public static bool Toggle(bool value, Texture image, params GUILayoutOption[] options)
    {
      return GUILayout.DoToggle(value, GUIContent.Temp(image), GUI.skin.toggle, options);
    }

    /// <summary>
    ///   <para>Make an on/off toggle button.</para>
    /// </summary>
    /// <param name="value">Is the button on or off?</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>The new value of the button.</para>
    /// </returns>
    public static bool Toggle(bool value, string text, params GUILayoutOption[] options)
    {
      return GUILayout.DoToggle(value, GUIContent.Temp(text), GUI.skin.toggle, options);
    }

    /// <summary>
    ///   <para>Make an on/off toggle button.</para>
    /// </summary>
    /// <param name="value">Is the button on or off?</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>The new value of the button.</para>
    /// </returns>
    public static bool Toggle(bool value, GUIContent content, params GUILayoutOption[] options)
    {
      return GUILayout.DoToggle(value, content, GUI.skin.toggle, options);
    }

    /// <summary>
    ///   <para>Make an on/off toggle button.</para>
    /// </summary>
    /// <param name="value">Is the button on or off?</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>The new value of the button.</para>
    /// </returns>
    public static bool Toggle(bool value, Texture image, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.DoToggle(value, GUIContent.Temp(image), style, options);
    }

    /// <summary>
    ///   <para>Make an on/off toggle button.</para>
    /// </summary>
    /// <param name="value">Is the button on or off?</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>The new value of the button.</para>
    /// </returns>
    public static bool Toggle(bool value, string text, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.DoToggle(value, GUIContent.Temp(text), style, options);
    }

    /// <summary>
    ///   <para>Make an on/off toggle button.</para>
    /// </summary>
    /// <param name="value">Is the button on or off?</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <returns>
    ///   <para>The new value of the button.</para>
    /// </returns>
    public static bool Toggle(bool value, GUIContent content, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.DoToggle(value, content, style, options);
    }

    private static bool DoToggle(bool value, GUIContent content, GUIStyle style, GUILayoutOption[] options)
    {
      return GUI.Toggle(GUILayoutUtility.GetRect(content, style, options), value, content, style);
    }

    /// <summary>
    ///   <para>Make a toolbar.</para>
    /// </summary>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the buttons.</param>
    /// <param name="images">An array of textures on the buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <param name="buttonSize">Determines how toolbar button size is calculated.</param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int Toolbar(int selected, string[] texts, params GUILayoutOption[] options)
    {
      return GUILayout.Toolbar(selected, GUIContent.Temp(texts), GUI.skin.button, options);
    }

    /// <summary>
    ///   <para>Make a toolbar.</para>
    /// </summary>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the buttons.</param>
    /// <param name="images">An array of textures on the buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <param name="buttonSize">Determines how toolbar button size is calculated.</param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int Toolbar(int selected, Texture[] images, params GUILayoutOption[] options)
    {
      return GUILayout.Toolbar(selected, GUIContent.Temp(images), GUI.skin.button, options);
    }

    /// <summary>
    ///   <para>Make a toolbar.</para>
    /// </summary>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the buttons.</param>
    /// <param name="images">An array of textures on the buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <param name="buttonSize">Determines how toolbar button size is calculated.</param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int Toolbar(int selected, GUIContent[] contents, params GUILayoutOption[] options)
    {
      return GUILayout.Toolbar(selected, contents, GUI.skin.button, options);
    }

    /// <summary>
    ///   <para>Make a toolbar.</para>
    /// </summary>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the buttons.</param>
    /// <param name="images">An array of textures on the buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <param name="buttonSize">Determines how toolbar button size is calculated.</param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int Toolbar(int selected, string[] texts, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.Toolbar(selected, GUIContent.Temp(texts), style, options);
    }

    /// <summary>
    ///   <para>Make a toolbar.</para>
    /// </summary>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the buttons.</param>
    /// <param name="images">An array of textures on the buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <param name="buttonSize">Determines how toolbar button size is calculated.</param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int Toolbar(int selected, Texture[] images, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.Toolbar(selected, GUIContent.Temp(images), style, options);
    }

    public static int Toolbar(int selected, string[] texts, GUIStyle style, GUI.ToolbarButtonSize buttonSize, params GUILayoutOption[] options)
    {
      return GUILayout.Toolbar(selected, GUIContent.Temp(texts), style, buttonSize, options);
    }

    public static int Toolbar(int selected, Texture[] images, GUIStyle style, GUI.ToolbarButtonSize buttonSize, params GUILayoutOption[] options)
    {
      return GUILayout.Toolbar(selected, GUIContent.Temp(images), style, buttonSize, options);
    }

    /// <summary>
    ///   <para>Make a toolbar.</para>
    /// </summary>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the buttons.</param>
    /// <param name="images">An array of textures on the buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <param name="buttonSize">Determines how toolbar button size is calculated.</param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int Toolbar(int selected, GUIContent[] contents, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.Toolbar(selected, contents, style, GUI.ToolbarButtonSize.Fixed, options);
    }

    public static int Toolbar(int selected, GUIContent[] contents, GUIStyle style, GUI.ToolbarButtonSize buttonSize, params GUILayoutOption[] options)
    {
      GUIStyle firstStyle;
      GUIStyle midStyle;
      GUIStyle lastStyle;
      GUI.FindStyles(ref style, out firstStyle, out midStyle, out lastStyle, "left", "mid", "right");
      Vector2 vector2_1 = new Vector2();
      int length = contents.Length;
      GUIStyle guiStyle1 = length <= 1 ? style : firstStyle;
      GUIStyle guiStyle2 = length <= 1 ? style : midStyle;
      GUIStyle guiStyle3 = length <= 1 ? style : lastStyle;
      float num = 0.0f;
      for (int index = 0; index < contents.Length; ++index)
      {
        if (index == length - 2)
          guiStyle2 = guiStyle3;
        Vector2 vector2_2 = guiStyle1.CalcSize(contents[index]);
        switch (buttonSize)
        {
          case GUI.ToolbarButtonSize.Fixed:
            if ((double) vector2_2.x > (double) vector2_1.x)
            {
              vector2_1.x = vector2_2.x;
              break;
            }
            break;
          case GUI.ToolbarButtonSize.FitToContents:
            vector2_1.x += vector2_2.x;
            break;
        }
        if ((double) vector2_2.y > (double) vector2_1.y)
          vector2_1.y = vector2_2.y;
        if (index == length - 1)
          num += (float) guiStyle1.margin.right;
        else
          num += (float) Mathf.Max(guiStyle1.margin.right, guiStyle2.margin.left);
        guiStyle1 = guiStyle2;
      }
      switch (buttonSize)
      {
        case GUI.ToolbarButtonSize.Fixed:
          vector2_1.x = vector2_1.x * (float) contents.Length + num;
          break;
        case GUI.ToolbarButtonSize.FitToContents:
          vector2_1.x += num;
          break;
      }
      return GUI.Toolbar(GUILayoutUtility.GetRect(vector2_1.x, vector2_1.y, style, options), selected, contents, style, buttonSize);
    }

    /// <summary>
    ///   <para>Make a Selection Grid.</para>
    /// </summary>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the buttons.</param>
    /// <param name="images">An array of textures on the buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the button.</param>
    /// <param name="xCount">How many elements to fit in the horizontal direction. The elements will be scaled to fit unless the style defines a fixedWidth to use. The height of the control will be determined from the number of elements.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <param name="content"></param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int SelectionGrid(int selected, string[] texts, int xCount, params GUILayoutOption[] options)
    {
      return GUILayout.SelectionGrid(selected, GUIContent.Temp(texts), xCount, GUI.skin.button, options);
    }

    /// <summary>
    ///   <para>Make a Selection Grid.</para>
    /// </summary>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the buttons.</param>
    /// <param name="images">An array of textures on the buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the button.</param>
    /// <param name="xCount">How many elements to fit in the horizontal direction. The elements will be scaled to fit unless the style defines a fixedWidth to use. The height of the control will be determined from the number of elements.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <param name="content"></param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int SelectionGrid(int selected, Texture[] images, int xCount, params GUILayoutOption[] options)
    {
      return GUILayout.SelectionGrid(selected, GUIContent.Temp(images), xCount, GUI.skin.button, options);
    }

    /// <summary>
    ///   <para>Make a Selection Grid.</para>
    /// </summary>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the buttons.</param>
    /// <param name="images">An array of textures on the buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the button.</param>
    /// <param name="xCount">How many elements to fit in the horizontal direction. The elements will be scaled to fit unless the style defines a fixedWidth to use. The height of the control will be determined from the number of elements.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <param name="content"></param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int SelectionGrid(int selected, GUIContent[] content, int xCount, params GUILayoutOption[] options)
    {
      return GUILayout.SelectionGrid(selected, content, xCount, GUI.skin.button, options);
    }

    /// <summary>
    ///   <para>Make a Selection Grid.</para>
    /// </summary>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the buttons.</param>
    /// <param name="images">An array of textures on the buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the button.</param>
    /// <param name="xCount">How many elements to fit in the horizontal direction. The elements will be scaled to fit unless the style defines a fixedWidth to use. The height of the control will be determined from the number of elements.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <param name="content"></param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int SelectionGrid(int selected, string[] texts, int xCount, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.SelectionGrid(selected, GUIContent.Temp(texts), xCount, style, options);
    }

    /// <summary>
    ///   <para>Make a Selection Grid.</para>
    /// </summary>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the buttons.</param>
    /// <param name="images">An array of textures on the buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the button.</param>
    /// <param name="xCount">How many elements to fit in the horizontal direction. The elements will be scaled to fit unless the style defines a fixedWidth to use. The height of the control will be determined from the number of elements.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <param name="content"></param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int SelectionGrid(int selected, Texture[] images, int xCount, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.SelectionGrid(selected, GUIContent.Temp(images), xCount, style, options);
    }

    /// <summary>
    ///   <para>Make a Selection Grid.</para>
    /// </summary>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the buttons.</param>
    /// <param name="images">An array of textures on the buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the button.</param>
    /// <param name="xCount">How many elements to fit in the horizontal direction. The elements will be scaled to fit unless the style defines a fixedWidth to use. The height of the control will be determined from the number of elements.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    /// <param name="content"></param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int SelectionGrid(int selected, GUIContent[] contents, int xCount, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUI.SelectionGrid(GUIGridSizer.GetRect(contents, xCount, style, options), selected, contents, xCount, style);
    }

    /// <summary>
    ///   <para>A horizontal slider the user can drag to change a value between a min and a max.</para>
    /// </summary>
    /// <param name="value">The value the slider shows. This determines the position of the draggable thumb.</param>
    /// <param name="leftValue">The value at the left end of the slider.</param>
    /// <param name="rightValue">The value at the right end of the slider.</param>
    /// <param name="slider">The GUIStyle to use for displaying the dragging area. If left out, the horizontalSlider style from the current GUISkin is used.</param>
    /// <param name="thumb">The GUIStyle to use for displaying draggable thumb. If left out, the horizontalSliderThumb style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.</param>
    /// <returns>
    ///   <para>The value that has been set by the user.</para>
    /// </returns>
    public static float HorizontalSlider(float value, float leftValue, float rightValue, params GUILayoutOption[] options)
    {
      return GUILayout.DoHorizontalSlider(value, leftValue, rightValue, GUI.skin.horizontalSlider, GUI.skin.horizontalSliderThumb, options);
    }

    /// <summary>
    ///   <para>A horizontal slider the user can drag to change a value between a min and a max.</para>
    /// </summary>
    /// <param name="value">The value the slider shows. This determines the position of the draggable thumb.</param>
    /// <param name="leftValue">The value at the left end of the slider.</param>
    /// <param name="rightValue">The value at the right end of the slider.</param>
    /// <param name="slider">The GUIStyle to use for displaying the dragging area. If left out, the horizontalSlider style from the current GUISkin is used.</param>
    /// <param name="thumb">The GUIStyle to use for displaying draggable thumb. If left out, the horizontalSliderThumb style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.</param>
    /// <returns>
    ///   <para>The value that has been set by the user.</para>
    /// </returns>
    public static float HorizontalSlider(float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, params GUILayoutOption[] options)
    {
      return GUILayout.DoHorizontalSlider(value, leftValue, rightValue, slider, thumb, options);
    }

    private static float DoHorizontalSlider(float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, GUILayoutOption[] options)
    {
      return GUI.HorizontalSlider(GUILayoutUtility.GetRect(GUIContent.Temp("mmmm"), slider, options), value, leftValue, rightValue, slider, thumb);
    }

    /// <summary>
    ///   <para>A vertical slider the user can drag to change a value between a min and a max.</para>
    /// </summary>
    /// <param name="value">The value the slider shows. This determines the position of the draggable thumb.</param>
    /// <param name="topValue">The value at the top end of the slider.</param>
    /// <param name="bottomValue">The value at the bottom end of the slider.</param>
    /// <param name="slider">The GUIStyle to use for displaying the dragging area. If left out, the horizontalSlider style from the current GUISkin is used.</param>
    /// <param name="thumb">The GUIStyle to use for displaying draggable thumb. If left out, the horizontalSliderThumb style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.</param>
    /// <param name="leftValue"></param>
    /// <param name="rightValue"></param>
    /// <returns>
    ///   <para>The value that has been set by the user.</para>
    /// </returns>
    public static float VerticalSlider(float value, float leftValue, float rightValue, params GUILayoutOption[] options)
    {
      return GUILayout.DoVerticalSlider(value, leftValue, rightValue, GUI.skin.verticalSlider, GUI.skin.verticalSliderThumb, options);
    }

    /// <summary>
    ///   <para>A vertical slider the user can drag to change a value between a min and a max.</para>
    /// </summary>
    /// <param name="value">The value the slider shows. This determines the position of the draggable thumb.</param>
    /// <param name="topValue">The value at the top end of the slider.</param>
    /// <param name="bottomValue">The value at the bottom end of the slider.</param>
    /// <param name="slider">The GUIStyle to use for displaying the dragging area. If left out, the horizontalSlider style from the current GUISkin is used.</param>
    /// <param name="thumb">The GUIStyle to use for displaying draggable thumb. If left out, the horizontalSliderThumb style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.</param>
    /// <param name="leftValue"></param>
    /// <param name="rightValue"></param>
    /// <returns>
    ///   <para>The value that has been set by the user.</para>
    /// </returns>
    public static float VerticalSlider(float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, params GUILayoutOption[] options)
    {
      return GUILayout.DoVerticalSlider(value, leftValue, rightValue, slider, thumb, options);
    }

    private static float DoVerticalSlider(float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, params GUILayoutOption[] options)
    {
      return GUI.VerticalSlider(GUILayoutUtility.GetRect(GUIContent.Temp("\n\n\n\n\n"), slider, options), value, leftValue, rightValue, slider, thumb);
    }

    /// <summary>
    ///   <para>Make a horizontal scrollbar.</para>
    /// </summary>
    /// <param name="value">The position between min and max.</param>
    /// <param name="size">How much can we see?</param>
    /// <param name="leftValue">The value at the left end of the scrollbar.</param>
    /// <param name="rightValue">The value at the right end of the scrollbar.</param>
    /// <param name="style">The style to use for the scrollbar background. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.</param>
    /// <returns>
    ///   <para>The modified value. This can be changed by the user by dragging the scrollbar, or clicking the arrows at the end.</para>
    /// </returns>
    public static float HorizontalScrollbar(float value, float size, float leftValue, float rightValue, params GUILayoutOption[] options)
    {
      return GUILayout.HorizontalScrollbar(value, size, leftValue, rightValue, GUI.skin.horizontalScrollbar, options);
    }

    /// <summary>
    ///   <para>Make a horizontal scrollbar.</para>
    /// </summary>
    /// <param name="value">The position between min and max.</param>
    /// <param name="size">How much can we see?</param>
    /// <param name="leftValue">The value at the left end of the scrollbar.</param>
    /// <param name="rightValue">The value at the right end of the scrollbar.</param>
    /// <param name="style">The style to use for the scrollbar background. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.</param>
    /// <returns>
    ///   <para>The modified value. This can be changed by the user by dragging the scrollbar, or clicking the arrows at the end.</para>
    /// </returns>
    public static float HorizontalScrollbar(float value, float size, float leftValue, float rightValue, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUI.HorizontalScrollbar(GUILayoutUtility.GetRect(GUIContent.Temp("mmmm"), style, options), value, size, leftValue, rightValue, style);
    }

    /// <summary>
    ///   <para>Make a vertical scrollbar.</para>
    /// </summary>
    /// <param name="value">The position between min and max.</param>
    /// <param name="size">How much can we see?</param>
    /// <param name="topValue">The value at the top end of the scrollbar.</param>
    /// <param name="bottomValue">The value at the bottom end of the scrollbar.</param>
    /// <param name="style">The style to use for the scrollbar background. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.</param>
    /// <returns>
    ///   <para>The modified value. This can be changed by the user by dragging the scrollbar, or clicking the arrows at the end.</para>
    /// </returns>
    public static float VerticalScrollbar(float value, float size, float topValue, float bottomValue, params GUILayoutOption[] options)
    {
      return GUILayout.VerticalScrollbar(value, size, topValue, bottomValue, GUI.skin.verticalScrollbar, options);
    }

    /// <summary>
    ///   <para>Make a vertical scrollbar.</para>
    /// </summary>
    /// <param name="value">The position between min and max.</param>
    /// <param name="size">How much can we see?</param>
    /// <param name="topValue">The value at the top end of the scrollbar.</param>
    /// <param name="bottomValue">The value at the bottom end of the scrollbar.</param>
    /// <param name="style">The style to use for the scrollbar background. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.</param>
    /// <returns>
    ///   <para>The modified value. This can be changed by the user by dragging the scrollbar, or clicking the arrows at the end.</para>
    /// </returns>
    public static float VerticalScrollbar(float value, float size, float topValue, float bottomValue, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUI.VerticalScrollbar(GUILayoutUtility.GetRect(GUIContent.Temp("\n\n\n\n"), style, options), value, size, topValue, bottomValue, style);
    }

    /// <summary>
    ///   <para>Insert a space in the current layout group.</para>
    /// </summary>
    /// <param name="pixels"></param>
    public static void Space(float pixels)
    {
      GUIUtility.CheckOnGUI();
      if (GUILayoutUtility.current.topLevel.isVertical)
        GUILayoutUtility.GetRect(0.0f, pixels, GUILayoutUtility.spaceStyle, new GUILayoutOption[1]
        {
          GUILayout.Height(pixels)
        });
      else
        GUILayoutUtility.GetRect(pixels, 0.0f, GUILayoutUtility.spaceStyle, new GUILayoutOption[1]
        {
          GUILayout.Width(pixels)
        });
    }

    /// <summary>
    ///   <para>Insert a flexible space element.</para>
    /// </summary>
    public static void FlexibleSpace()
    {
      GUIUtility.CheckOnGUI();
      GUILayoutOption guiLayoutOption = !GUILayoutUtility.current.topLevel.isVertical ? GUILayout.ExpandWidth(true) : GUILayout.ExpandHeight(true);
      guiLayoutOption.value = (object) 10000;
      GUILayoutUtility.GetRect(0.0f, 0.0f, GUILayoutUtility.spaceStyle, new GUILayoutOption[1]
      {
        guiLayoutOption
      });
    }

    /// <summary>
    ///   <para>Begin a Horizontal control group.</para>
    /// </summary>
    /// <param name="text">Text to display on group.</param>
    /// <param name="image">Texture to display on group.</param>
    /// <param name="content">Text, image, and tooltip for this group.</param>
    /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void BeginHorizontal(params GUILayoutOption[] options)
    {
      GUILayout.BeginHorizontal(GUIContent.none, GUIStyle.none, options);
    }

    /// <summary>
    ///   <para>Begin a Horizontal control group.</para>
    /// </summary>
    /// <param name="text">Text to display on group.</param>
    /// <param name="image">Texture to display on group.</param>
    /// <param name="content">Text, image, and tooltip for this group.</param>
    /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void BeginHorizontal(GUIStyle style, params GUILayoutOption[] options)
    {
      GUILayout.BeginHorizontal(GUIContent.none, style, options);
    }

    /// <summary>
    ///   <para>Begin a Horizontal control group.</para>
    /// </summary>
    /// <param name="text">Text to display on group.</param>
    /// <param name="image">Texture to display on group.</param>
    /// <param name="content">Text, image, and tooltip for this group.</param>
    /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void BeginHorizontal(string text, GUIStyle style, params GUILayoutOption[] options)
    {
      GUILayout.BeginHorizontal(GUIContent.Temp(text), style, options);
    }

    /// <summary>
    ///   <para>Begin a Horizontal control group.</para>
    /// </summary>
    /// <param name="text">Text to display on group.</param>
    /// <param name="image">Texture to display on group.</param>
    /// <param name="content">Text, image, and tooltip for this group.</param>
    /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void BeginHorizontal(Texture image, GUIStyle style, params GUILayoutOption[] options)
    {
      GUILayout.BeginHorizontal(GUIContent.Temp(image), style, options);
    }

    /// <summary>
    ///   <para>Begin a Horizontal control group.</para>
    /// </summary>
    /// <param name="text">Text to display on group.</param>
    /// <param name="image">Texture to display on group.</param>
    /// <param name="content">Text, image, and tooltip for this group.</param>
    /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void BeginHorizontal(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
    {
      GUILayoutGroup guiLayoutGroup = GUILayoutUtility.BeginLayoutGroup(style, options, typeof (GUILayoutGroup));
      guiLayoutGroup.isVertical = false;
      if (style == GUIStyle.none && content == GUIContent.none)
        return;
      GUI.Box(guiLayoutGroup.rect, content, style);
    }

    /// <summary>
    ///   <para>Close a group started with BeginHorizontal.</para>
    /// </summary>
    public static void EndHorizontal()
    {
      GUILayoutUtility.EndLayoutGroup();
    }

    /// <summary>
    ///   <para>Begin a vertical control group.</para>
    /// </summary>
    /// <param name="text">Text to display on group.</param>
    /// <param name="image">Texture to display on group.</param>
    /// <param name="content">Text, image, and tooltip for this group.</param>
    /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void BeginVertical(params GUILayoutOption[] options)
    {
      GUILayout.BeginVertical(GUIContent.none, GUIStyle.none, options);
    }

    /// <summary>
    ///   <para>Begin a vertical control group.</para>
    /// </summary>
    /// <param name="text">Text to display on group.</param>
    /// <param name="image">Texture to display on group.</param>
    /// <param name="content">Text, image, and tooltip for this group.</param>
    /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void BeginVertical(GUIStyle style, params GUILayoutOption[] options)
    {
      GUILayout.BeginVertical(GUIContent.none, style, options);
    }

    /// <summary>
    ///   <para>Begin a vertical control group.</para>
    /// </summary>
    /// <param name="text">Text to display on group.</param>
    /// <param name="image">Texture to display on group.</param>
    /// <param name="content">Text, image, and tooltip for this group.</param>
    /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void BeginVertical(string text, GUIStyle style, params GUILayoutOption[] options)
    {
      GUILayout.BeginVertical(GUIContent.Temp(text), style, options);
    }

    /// <summary>
    ///   <para>Begin a vertical control group.</para>
    /// </summary>
    /// <param name="text">Text to display on group.</param>
    /// <param name="image">Texture to display on group.</param>
    /// <param name="content">Text, image, and tooltip for this group.</param>
    /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void BeginVertical(Texture image, GUIStyle style, params GUILayoutOption[] options)
    {
      GUILayout.BeginVertical(GUIContent.Temp(image), style, options);
    }

    /// <summary>
    ///   <para>Begin a vertical control group.</para>
    /// </summary>
    /// <param name="text">Text to display on group.</param>
    /// <param name="image">Texture to display on group.</param>
    /// <param name="content">Text, image, and tooltip for this group.</param>
    /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
    /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
    /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
    /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
    public static void BeginVertical(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
    {
      GUILayoutGroup guiLayoutGroup = GUILayoutUtility.BeginLayoutGroup(style, options, typeof (GUILayoutGroup));
      guiLayoutGroup.isVertical = true;
      if (style == GUIStyle.none && content == GUIContent.none)
        return;
      GUI.Box(guiLayoutGroup.rect, content, style);
    }

    /// <summary>
    ///   <para>Close a group started with BeginVertical.</para>
    /// </summary>
    public static void EndVertical()
    {
      GUILayoutUtility.EndLayoutGroup();
    }

    /// <summary>
    ///   <para>Begin a GUILayout block of GUI controls in a fixed screen area.</para>
    /// </summary>
    /// <param name="text">Optional text to display in the area.</param>
    /// <param name="image">Optional texture to display in the area.</param>
    /// <param name="content">Optional text, image and tooltip top display for this area.</param>
    /// <param name="style">The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving a transparent background.</param>
    /// <param name="screenRect"></param>
    public static void BeginArea(Rect screenRect)
    {
      GUILayout.BeginArea(screenRect, GUIContent.none, GUIStyle.none);
    }

    /// <summary>
    ///   <para>Begin a GUILayout block of GUI controls in a fixed screen area.</para>
    /// </summary>
    /// <param name="text">Optional text to display in the area.</param>
    /// <param name="image">Optional texture to display in the area.</param>
    /// <param name="content">Optional text, image and tooltip top display for this area.</param>
    /// <param name="style">The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving a transparent background.</param>
    /// <param name="screenRect"></param>
    public static void BeginArea(Rect screenRect, string text)
    {
      GUILayout.BeginArea(screenRect, GUIContent.Temp(text), GUIStyle.none);
    }

    /// <summary>
    ///   <para>Begin a GUILayout block of GUI controls in a fixed screen area.</para>
    /// </summary>
    /// <param name="text">Optional text to display in the area.</param>
    /// <param name="image">Optional texture to display in the area.</param>
    /// <param name="content">Optional text, image and tooltip top display for this area.</param>
    /// <param name="style">The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving a transparent background.</param>
    /// <param name="screenRect"></param>
    public static void BeginArea(Rect screenRect, Texture image)
    {
      GUILayout.BeginArea(screenRect, GUIContent.Temp(image), GUIStyle.none);
    }

    /// <summary>
    ///   <para>Begin a GUILayout block of GUI controls in a fixed screen area.</para>
    /// </summary>
    /// <param name="text">Optional text to display in the area.</param>
    /// <param name="image">Optional texture to display in the area.</param>
    /// <param name="content">Optional text, image and tooltip top display for this area.</param>
    /// <param name="style">The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving a transparent background.</param>
    /// <param name="screenRect"></param>
    public static void BeginArea(Rect screenRect, GUIContent content)
    {
      GUILayout.BeginArea(screenRect, content, GUIStyle.none);
    }

    /// <summary>
    ///   <para>Begin a GUILayout block of GUI controls in a fixed screen area.</para>
    /// </summary>
    /// <param name="text">Optional text to display in the area.</param>
    /// <param name="image">Optional texture to display in the area.</param>
    /// <param name="content">Optional text, image and tooltip top display for this area.</param>
    /// <param name="style">The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving a transparent background.</param>
    /// <param name="screenRect"></param>
    public static void BeginArea(Rect screenRect, GUIStyle style)
    {
      GUILayout.BeginArea(screenRect, GUIContent.none, style);
    }

    /// <summary>
    ///   <para>Begin a GUILayout block of GUI controls in a fixed screen area.</para>
    /// </summary>
    /// <param name="text">Optional text to display in the area.</param>
    /// <param name="image">Optional texture to display in the area.</param>
    /// <param name="content">Optional text, image and tooltip top display for this area.</param>
    /// <param name="style">The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving a transparent background.</param>
    /// <param name="screenRect"></param>
    public static void BeginArea(Rect screenRect, string text, GUIStyle style)
    {
      GUILayout.BeginArea(screenRect, GUIContent.Temp(text), style);
    }

    /// <summary>
    ///   <para>Begin a GUILayout block of GUI controls in a fixed screen area.</para>
    /// </summary>
    /// <param name="text">Optional text to display in the area.</param>
    /// <param name="image">Optional texture to display in the area.</param>
    /// <param name="content">Optional text, image and tooltip top display for this area.</param>
    /// <param name="style">The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving a transparent background.</param>
    /// <param name="screenRect"></param>
    public static void BeginArea(Rect screenRect, Texture image, GUIStyle style)
    {
      GUILayout.BeginArea(screenRect, GUIContent.Temp(image), style);
    }

    /// <summary>
    ///   <para>Begin a GUILayout block of GUI controls in a fixed screen area.</para>
    /// </summary>
    /// <param name="text">Optional text to display in the area.</param>
    /// <param name="image">Optional texture to display in the area.</param>
    /// <param name="content">Optional text, image and tooltip top display for this area.</param>
    /// <param name="style">The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving a transparent background.</param>
    /// <param name="screenRect"></param>
    public static void BeginArea(Rect screenRect, GUIContent content, GUIStyle style)
    {
      GUIUtility.CheckOnGUI();
      GUILayoutGroup guiLayoutGroup = GUILayoutUtility.BeginLayoutArea(style, typeof (GUILayoutGroup));
      if (Event.current.type == EventType.Layout)
      {
        guiLayoutGroup.resetCoords = true;
        guiLayoutGroup.minWidth = guiLayoutGroup.maxWidth = screenRect.width;
        guiLayoutGroup.minHeight = guiLayoutGroup.maxHeight = screenRect.height;
        guiLayoutGroup.rect = Rect.MinMaxRect(screenRect.xMin, screenRect.yMin, guiLayoutGroup.rect.xMax, guiLayoutGroup.rect.yMax);
      }
      GUI.BeginGroup(guiLayoutGroup.rect, content, style);
    }

    /// <summary>
    ///   <para>Close a GUILayout block started with BeginArea.</para>
    /// </summary>
    public static void EndArea()
    {
      GUIUtility.CheckOnGUI();
      if (Event.current.type == EventType.Used)
        return;
      GUILayoutUtility.current.layoutGroups.Pop();
      GUILayoutUtility.current.topLevel = (GUILayoutGroup) GUILayoutUtility.current.layoutGroups.Peek();
      GUI.EndGroup();
    }

    /// <summary>
    ///   <para>Begin an automatically laid out scrollview.</para>
    /// </summary>
    /// <param name="scrollPosition">The position to use display.</param>
    /// <param name="alwayShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when the content inside the ScrollView is wider than the scrollview itself.</param>
    /// <param name="alwayShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when content inside the ScrollView is taller than the scrollview itself.</param>
    /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
    /// <param name="options"></param>
    /// <param name="alwaysShowHorizontal"></param>
    /// <param name="alwaysShowVertical"></param>
    /// <param name="style"></param>
    /// <param name="background"></param>
    /// <returns>
    ///   <para>The modified scrollPosition. Feed this back into the variable you pass in, as shown in the example.</para>
    /// </returns>
    public static Vector2 BeginScrollView(Vector2 scrollPosition, params GUILayoutOption[] options)
    {
      return GUILayout.BeginScrollView(scrollPosition, false, false, GUI.skin.horizontalScrollbar, GUI.skin.verticalScrollbar, GUI.skin.scrollView, options);
    }

    /// <summary>
    ///   <para>Begin an automatically laid out scrollview.</para>
    /// </summary>
    /// <param name="scrollPosition">The position to use display.</param>
    /// <param name="alwayShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when the content inside the ScrollView is wider than the scrollview itself.</param>
    /// <param name="alwayShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when content inside the ScrollView is taller than the scrollview itself.</param>
    /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
    /// <param name="options"></param>
    /// <param name="alwaysShowHorizontal"></param>
    /// <param name="alwaysShowVertical"></param>
    /// <param name="style"></param>
    /// <param name="background"></param>
    /// <returns>
    ///   <para>The modified scrollPosition. Feed this back into the variable you pass in, as shown in the example.</para>
    /// </returns>
    public static Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, params GUILayoutOption[] options)
    {
      return GUILayout.BeginScrollView(scrollPosition, alwaysShowHorizontal, alwaysShowVertical, GUI.skin.horizontalScrollbar, GUI.skin.verticalScrollbar, GUI.skin.scrollView, options);
    }

    /// <summary>
    ///   <para>Begin an automatically laid out scrollview.</para>
    /// </summary>
    /// <param name="scrollPosition">The position to use display.</param>
    /// <param name="alwayShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when the content inside the ScrollView is wider than the scrollview itself.</param>
    /// <param name="alwayShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when content inside the ScrollView is taller than the scrollview itself.</param>
    /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
    /// <param name="options"></param>
    /// <param name="alwaysShowHorizontal"></param>
    /// <param name="alwaysShowVertical"></param>
    /// <param name="style"></param>
    /// <param name="background"></param>
    /// <returns>
    ///   <para>The modified scrollPosition. Feed this back into the variable you pass in, as shown in the example.</para>
    /// </returns>
    public static Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options)
    {
      return GUILayout.BeginScrollView(scrollPosition, false, false, horizontalScrollbar, verticalScrollbar, GUI.skin.scrollView, options);
    }

    /// <summary>
    ///   <para>Begin an automatically laid out scrollview.</para>
    /// </summary>
    /// <param name="scrollPosition">The position to use display.</param>
    /// <param name="alwayShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when the content inside the ScrollView is wider than the scrollview itself.</param>
    /// <param name="alwayShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when content inside the ScrollView is taller than the scrollview itself.</param>
    /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
    /// <param name="options"></param>
    /// <param name="alwaysShowHorizontal"></param>
    /// <param name="alwaysShowVertical"></param>
    /// <param name="style"></param>
    /// <param name="background"></param>
    /// <returns>
    ///   <para>The modified scrollPosition. Feed this back into the variable you pass in, as shown in the example.</para>
    /// </returns>
    public static Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle style)
    {
      GUILayoutOption[] guiLayoutOptionArray = (GUILayoutOption[]) null;
      return GUILayout.BeginScrollView(scrollPosition, style, guiLayoutOptionArray);
    }

    /// <summary>
    ///   <para>Begin an automatically laid out scrollview.</para>
    /// </summary>
    /// <param name="scrollPosition">The position to use display.</param>
    /// <param name="alwayShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when the content inside the ScrollView is wider than the scrollview itself.</param>
    /// <param name="alwayShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when content inside the ScrollView is taller than the scrollview itself.</param>
    /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
    /// <param name="options"></param>
    /// <param name="alwaysShowHorizontal"></param>
    /// <param name="alwaysShowVertical"></param>
    /// <param name="style"></param>
    /// <param name="background"></param>
    /// <returns>
    ///   <para>The modified scrollPosition. Feed this back into the variable you pass in, as shown in the example.</para>
    /// </returns>
    public static Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle style, params GUILayoutOption[] options)
    {
      string name = style.name;
      GUIStyle verticalScrollbar = GUI.skin.FindStyle(name + "VerticalScrollbar") ?? GUI.skin.verticalScrollbar;
      GUIStyle horizontalScrollbar = GUI.skin.FindStyle(name + "HorizontalScrollbar") ?? GUI.skin.horizontalScrollbar;
      return GUILayout.BeginScrollView(scrollPosition, false, false, horizontalScrollbar, verticalScrollbar, style, options);
    }

    /// <summary>
    ///   <para>Begin an automatically laid out scrollview.</para>
    /// </summary>
    /// <param name="scrollPosition">The position to use display.</param>
    /// <param name="alwayShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when the content inside the ScrollView is wider than the scrollview itself.</param>
    /// <param name="alwayShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when content inside the ScrollView is taller than the scrollview itself.</param>
    /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
    /// <param name="options"></param>
    /// <param name="alwaysShowHorizontal"></param>
    /// <param name="alwaysShowVertical"></param>
    /// <param name="style"></param>
    /// <param name="background"></param>
    /// <returns>
    ///   <para>The modified scrollPosition. Feed this back into the variable you pass in, as shown in the example.</para>
    /// </returns>
    public static Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options)
    {
      return GUILayout.BeginScrollView(scrollPosition, alwaysShowHorizontal, alwaysShowVertical, horizontalScrollbar, verticalScrollbar, GUI.skin.scrollView, options);
    }

    /// <summary>
    ///   <para>Begin an automatically laid out scrollview.</para>
    /// </summary>
    /// <param name="scrollPosition">The position to use display.</param>
    /// <param name="alwayShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when the content inside the ScrollView is wider than the scrollview itself.</param>
    /// <param name="alwayShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when content inside the ScrollView is taller than the scrollview itself.</param>
    /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
    /// <param name="options"></param>
    /// <param name="alwaysShowHorizontal"></param>
    /// <param name="alwaysShowVertical"></param>
    /// <param name="style"></param>
    /// <param name="background"></param>
    /// <returns>
    ///   <para>The modified scrollPosition. Feed this back into the variable you pass in, as shown in the example.</para>
    /// </returns>
    public static Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background, params GUILayoutOption[] options)
    {
      GUIUtility.CheckOnGUI();
      GUIScrollGroup guiScrollGroup = (GUIScrollGroup) GUILayoutUtility.BeginLayoutGroup(background, (GUILayoutOption[]) null, typeof (GUIScrollGroup));
      if (Event.current.type == EventType.Layout)
      {
        guiScrollGroup.resetCoords = true;
        guiScrollGroup.isVertical = true;
        guiScrollGroup.stretchWidth = 1;
        guiScrollGroup.stretchHeight = 1;
        guiScrollGroup.verticalScrollbar = verticalScrollbar;
        guiScrollGroup.horizontalScrollbar = horizontalScrollbar;
        guiScrollGroup.needsVerticalScrollbar = alwaysShowVertical;
        guiScrollGroup.needsHorizontalScrollbar = alwaysShowHorizontal;
        guiScrollGroup.ApplyOptions(options);
      }
      return GUI.BeginScrollView(guiScrollGroup.rect, scrollPosition, new Rect(0.0f, 0.0f, guiScrollGroup.clientWidth, guiScrollGroup.clientHeight), alwaysShowHorizontal, alwaysShowVertical, horizontalScrollbar, verticalScrollbar, background);
    }

    /// <summary>
    ///   <para>End a scroll view begun with a call to BeginScrollView.</para>
    /// </summary>
    public static void EndScrollView()
    {
      GUILayout.EndScrollView(true);
    }

    internal static void EndScrollView(bool handleScrollWheel)
    {
      GUILayoutUtility.EndLayoutGroup();
      GUI.EndScrollView(handleScrollWheel);
    }

    public static Rect Window(int id, Rect screenRect, GUI.WindowFunction func, string text, params GUILayoutOption[] options)
    {
      return GUILayout.DoWindow(id, screenRect, func, GUIContent.Temp(text), GUI.skin.window, options);
    }

    public static Rect Window(int id, Rect screenRect, GUI.WindowFunction func, Texture image, params GUILayoutOption[] options)
    {
      return GUILayout.DoWindow(id, screenRect, func, GUIContent.Temp(image), GUI.skin.window, options);
    }

    public static Rect Window(int id, Rect screenRect, GUI.WindowFunction func, GUIContent content, params GUILayoutOption[] options)
    {
      return GUILayout.DoWindow(id, screenRect, func, content, GUI.skin.window, options);
    }

    public static Rect Window(int id, Rect screenRect, GUI.WindowFunction func, string text, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.DoWindow(id, screenRect, func, GUIContent.Temp(text), style, options);
    }

    public static Rect Window(int id, Rect screenRect, GUI.WindowFunction func, Texture image, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.DoWindow(id, screenRect, func, GUIContent.Temp(image), style, options);
    }

    public static Rect Window(int id, Rect screenRect, GUI.WindowFunction func, GUIContent content, GUIStyle style, params GUILayoutOption[] options)
    {
      return GUILayout.DoWindow(id, screenRect, func, content, style, options);
    }

    private static Rect DoWindow(int id, Rect screenRect, GUI.WindowFunction func, GUIContent content, GUIStyle style, GUILayoutOption[] options)
    {
      GUIUtility.CheckOnGUI();
      GUILayout.LayoutedWindow layoutedWindow = new GUILayout.LayoutedWindow(func, screenRect, content, options, style);
      return GUI.Window(id, screenRect, new GUI.WindowFunction(layoutedWindow.DoWindow), content, style);
    }

    /// <summary>
    ///   <para>Option passed to a control to give it an absolute width.</para>
    /// </summary>
    /// <param name="width"></param>
    public static GUILayoutOption Width(float width)
    {
      return new GUILayoutOption(GUILayoutOption.Type.fixedWidth, (object) width);
    }

    /// <summary>
    ///         <para>Option passed to a control to specify a minimum width.
    /// </para>
    ///       </summary>
    /// <param name="minWidth"></param>
    public static GUILayoutOption MinWidth(float minWidth)
    {
      return new GUILayoutOption(GUILayoutOption.Type.minWidth, (object) minWidth);
    }

    /// <summary>
    ///   <para>Option passed to a control to specify a maximum width.</para>
    /// </summary>
    /// <param name="maxWidth"></param>
    public static GUILayoutOption MaxWidth(float maxWidth)
    {
      return new GUILayoutOption(GUILayoutOption.Type.maxWidth, (object) maxWidth);
    }

    /// <summary>
    ///   <para>Option passed to a control to give it an absolute height.</para>
    /// </summary>
    /// <param name="height"></param>
    public static GUILayoutOption Height(float height)
    {
      return new GUILayoutOption(GUILayoutOption.Type.fixedHeight, (object) height);
    }

    /// <summary>
    ///   <para>Option passed to a control to specify a minimum height.</para>
    /// </summary>
    /// <param name="minHeight"></param>
    public static GUILayoutOption MinHeight(float minHeight)
    {
      return new GUILayoutOption(GUILayoutOption.Type.minHeight, (object) minHeight);
    }

    /// <summary>
    ///   <para>Option passed to a control to specify a maximum height.</para>
    /// </summary>
    /// <param name="maxHeight"></param>
    public static GUILayoutOption MaxHeight(float maxHeight)
    {
      return new GUILayoutOption(GUILayoutOption.Type.maxHeight, (object) maxHeight);
    }

    /// <summary>
    ///   <para>Option passed to a control to allow or disallow horizontal expansion.</para>
    /// </summary>
    /// <param name="expand"></param>
    public static GUILayoutOption ExpandWidth(bool expand)
    {
      return new GUILayoutOption(GUILayoutOption.Type.stretchWidth, (object) (!expand ? 0 : 1));
    }

    /// <summary>
    ///   <para>Option passed to a control to allow or disallow vertical expansion.</para>
    /// </summary>
    /// <param name="expand"></param>
    public static GUILayoutOption ExpandHeight(bool expand)
    {
      return new GUILayoutOption(GUILayoutOption.Type.stretchHeight, (object) (!expand ? 0 : 1));
    }

    private sealed class LayoutedWindow
    {
      private readonly GUI.WindowFunction m_Func;
      private readonly Rect m_ScreenRect;
      private readonly GUILayoutOption[] m_Options;
      private readonly GUIStyle m_Style;

      internal LayoutedWindow(GUI.WindowFunction f, Rect screenRect, GUIContent content, GUILayoutOption[] options, GUIStyle style)
      {
        this.m_Func = f;
        this.m_ScreenRect = screenRect;
        this.m_Options = options;
        this.m_Style = style;
      }

      public void DoWindow(int windowID)
      {
        GUILayoutGroup topLevel = GUILayoutUtility.current.topLevel;
        if (Event.current.type == EventType.Layout)
        {
          topLevel.resetCoords = true;
          topLevel.rect = this.m_ScreenRect;
          if (this.m_Options != null)
            topLevel.ApplyOptions(this.m_Options);
          topLevel.isWindow = true;
          topLevel.windowID = windowID;
          topLevel.style = this.m_Style;
        }
        else
          topLevel.ResetCursor();
        this.m_Func(windowID);
      }
    }

    /// <summary>
    ///   <para>Disposable helper class for managing BeginHorizontal / EndHorizontal.</para>
    /// </summary>
    public class HorizontalScope : GUI.Scope
    {
      /// <summary>
      ///   <para>Create a new HorizontalScope and begin the corresponding horizontal group.</para>
      /// </summary>
      /// <param name="text">Text to display on group.</param>
      /// <param name="image">Texture to display on group.</param>
      /// <param name="content">Text, image, and tooltip for this group.</param>
      /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
      /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
      /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
      /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
      public HorizontalScope(params GUILayoutOption[] options)
      {
        GUILayout.BeginHorizontal(options);
      }

      /// <summary>
      ///   <para>Create a new HorizontalScope and begin the corresponding horizontal group.</para>
      /// </summary>
      /// <param name="text">Text to display on group.</param>
      /// <param name="image">Texture to display on group.</param>
      /// <param name="content">Text, image, and tooltip for this group.</param>
      /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
      /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
      /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
      /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
      public HorizontalScope(GUIStyle style, params GUILayoutOption[] options)
      {
        GUILayout.BeginHorizontal(style, options);
      }

      /// <summary>
      ///   <para>Create a new HorizontalScope and begin the corresponding horizontal group.</para>
      /// </summary>
      /// <param name="text">Text to display on group.</param>
      /// <param name="image">Texture to display on group.</param>
      /// <param name="content">Text, image, and tooltip for this group.</param>
      /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
      /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
      /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
      /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
      public HorizontalScope(string text, GUIStyle style, params GUILayoutOption[] options)
      {
        GUILayout.BeginHorizontal(text, style, options);
      }

      /// <summary>
      ///   <para>Create a new HorizontalScope and begin the corresponding horizontal group.</para>
      /// </summary>
      /// <param name="text">Text to display on group.</param>
      /// <param name="image">Texture to display on group.</param>
      /// <param name="content">Text, image, and tooltip for this group.</param>
      /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
      /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
      /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
      /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
      public HorizontalScope(Texture image, GUIStyle style, params GUILayoutOption[] options)
      {
        GUILayout.BeginHorizontal(image, style, options);
      }

      /// <summary>
      ///   <para>Create a new HorizontalScope and begin the corresponding horizontal group.</para>
      /// </summary>
      /// <param name="text">Text to display on group.</param>
      /// <param name="image">Texture to display on group.</param>
      /// <param name="content">Text, image, and tooltip for this group.</param>
      /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
      /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
      /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
      /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
      public HorizontalScope(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
      {
        GUILayout.BeginHorizontal(content, style, options);
      }

      protected override void CloseScope()
      {
        GUILayout.EndHorizontal();
      }
    }

    /// <summary>
    ///   <para>Disposable helper class for managing BeginVertical / EndVertical.</para>
    /// </summary>
    public class VerticalScope : GUI.Scope
    {
      /// <summary>
      ///   <para>Create a new VerticalScope and begin the corresponding vertical group.</para>
      /// </summary>
      /// <param name="text">Text to display on group.</param>
      /// <param name="image">Texture to display on group.</param>
      /// <param name="content">Text, image, and tooltip for this group.</param>
      /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
      /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
      /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
      /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
      public VerticalScope(params GUILayoutOption[] options)
      {
        GUILayout.BeginVertical(options);
      }

      /// <summary>
      ///   <para>Create a new VerticalScope and begin the corresponding vertical group.</para>
      /// </summary>
      /// <param name="text">Text to display on group.</param>
      /// <param name="image">Texture to display on group.</param>
      /// <param name="content">Text, image, and tooltip for this group.</param>
      /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
      /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
      /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
      /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
      public VerticalScope(GUIStyle style, params GUILayoutOption[] options)
      {
        GUILayout.BeginVertical(style, options);
      }

      /// <summary>
      ///   <para>Create a new VerticalScope and begin the corresponding vertical group.</para>
      /// </summary>
      /// <param name="text">Text to display on group.</param>
      /// <param name="image">Texture to display on group.</param>
      /// <param name="content">Text, image, and tooltip for this group.</param>
      /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
      /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
      /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
      /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
      public VerticalScope(string text, GUIStyle style, params GUILayoutOption[] options)
      {
        GUILayout.BeginVertical(text, style, options);
      }

      /// <summary>
      ///   <para>Create a new VerticalScope and begin the corresponding vertical group.</para>
      /// </summary>
      /// <param name="text">Text to display on group.</param>
      /// <param name="image">Texture to display on group.</param>
      /// <param name="content">Text, image, and tooltip for this group.</param>
      /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
      /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
      /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
      /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
      public VerticalScope(Texture image, GUIStyle style, params GUILayoutOption[] options)
      {
        GUILayout.BeginVertical(image, style, options);
      }

      /// <summary>
      ///   <para>Create a new VerticalScope and begin the corresponding vertical group.</para>
      /// </summary>
      /// <param name="text">Text to display on group.</param>
      /// <param name="image">Texture to display on group.</param>
      /// <param name="content">Text, image, and tooltip for this group.</param>
      /// <param name="style">The style to use for background image and padding values. If left out, the background is transparent.</param>
      /// <param name="options">An optional list of layout options that specify extra layouting properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
      /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
      /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
      public VerticalScope(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
      {
        GUILayout.BeginVertical(content, style, options);
      }

      protected override void CloseScope()
      {
        GUILayout.EndVertical();
      }
    }

    /// <summary>
    ///   <para>Disposable helper class for managing BeginArea / EndArea.</para>
    /// </summary>
    public class AreaScope : GUI.Scope
    {
      /// <summary>
      ///   <para>Create a new AreaScope and begin the corresponding Area.</para>
      /// </summary>
      /// <param name="text">Optional text to display in the area.</param>
      /// <param name="image">Optional texture to display in the area.</param>
      /// <param name="content">Optional text, image and tooltip top display for this area.</param>
      /// <param name="style">The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving a transparent background.</param>
      /// <param name="screenRect"></param>
      public AreaScope(Rect screenRect)
      {
        GUILayout.BeginArea(screenRect);
      }

      /// <summary>
      ///   <para>Create a new AreaScope and begin the corresponding Area.</para>
      /// </summary>
      /// <param name="text">Optional text to display in the area.</param>
      /// <param name="image">Optional texture to display in the area.</param>
      /// <param name="content">Optional text, image and tooltip top display for this area.</param>
      /// <param name="style">The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving a transparent background.</param>
      /// <param name="screenRect"></param>
      public AreaScope(Rect screenRect, string text)
      {
        GUILayout.BeginArea(screenRect, text);
      }

      /// <summary>
      ///   <para>Create a new AreaScope and begin the corresponding Area.</para>
      /// </summary>
      /// <param name="text">Optional text to display in the area.</param>
      /// <param name="image">Optional texture to display in the area.</param>
      /// <param name="content">Optional text, image and tooltip top display for this area.</param>
      /// <param name="style">The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving a transparent background.</param>
      /// <param name="screenRect"></param>
      public AreaScope(Rect screenRect, Texture image)
      {
        GUILayout.BeginArea(screenRect, image);
      }

      /// <summary>
      ///   <para>Create a new AreaScope and begin the corresponding Area.</para>
      /// </summary>
      /// <param name="text">Optional text to display in the area.</param>
      /// <param name="image">Optional texture to display in the area.</param>
      /// <param name="content">Optional text, image and tooltip top display for this area.</param>
      /// <param name="style">The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving a transparent background.</param>
      /// <param name="screenRect"></param>
      public AreaScope(Rect screenRect, GUIContent content)
      {
        GUILayout.BeginArea(screenRect, content);
      }

      /// <summary>
      ///   <para>Create a new AreaScope and begin the corresponding Area.</para>
      /// </summary>
      /// <param name="text">Optional text to display in the area.</param>
      /// <param name="image">Optional texture to display in the area.</param>
      /// <param name="content">Optional text, image and tooltip top display for this area.</param>
      /// <param name="style">The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving a transparent background.</param>
      /// <param name="screenRect"></param>
      public AreaScope(Rect screenRect, string text, GUIStyle style)
      {
        GUILayout.BeginArea(screenRect, text, style);
      }

      /// <summary>
      ///   <para>Create a new AreaScope and begin the corresponding Area.</para>
      /// </summary>
      /// <param name="text">Optional text to display in the area.</param>
      /// <param name="image">Optional texture to display in the area.</param>
      /// <param name="content">Optional text, image and tooltip top display for this area.</param>
      /// <param name="style">The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving a transparent background.</param>
      /// <param name="screenRect"></param>
      public AreaScope(Rect screenRect, Texture image, GUIStyle style)
      {
        GUILayout.BeginArea(screenRect, image, style);
      }

      /// <summary>
      ///   <para>Create a new AreaScope and begin the corresponding Area.</para>
      /// </summary>
      /// <param name="text">Optional text to display in the area.</param>
      /// <param name="image">Optional texture to display in the area.</param>
      /// <param name="content">Optional text, image and tooltip top display for this area.</param>
      /// <param name="style">The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving a transparent background.</param>
      /// <param name="screenRect"></param>
      public AreaScope(Rect screenRect, GUIContent content, GUIStyle style)
      {
        GUILayout.BeginArea(screenRect, content, style);
      }

      protected override void CloseScope()
      {
        GUILayout.EndArea();
      }
    }

    /// <summary>
    ///   <para>Disposable helper class for managing BeginScrollView / EndScrollView.</para>
    /// </summary>
    public class ScrollViewScope : GUI.Scope
    {
      /// <summary>
      ///   <para>Create a new ScrollViewScope and begin the corresponding ScrollView.</para>
      /// </summary>
      /// <param name="scrollPosition">The position to use display.</param>
      /// <param name="alwaysShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when the content inside the ScrollView is wider than the scrollview itself.</param>
      /// <param name="alwaysShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when content inside the ScrollView is taller than the scrollview itself.</param>
      /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
      /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
      /// <param name="options"></param>
      /// <param name="style"></param>
      /// <param name="background"></param>
      public ScrollViewScope(Vector2 scrollPosition, params GUILayoutOption[] options)
      {
        this.handleScrollWheel = true;
        this.scrollPosition = GUILayout.BeginScrollView(scrollPosition, options);
      }

      /// <summary>
      ///   <para>Create a new ScrollViewScope and begin the corresponding ScrollView.</para>
      /// </summary>
      /// <param name="scrollPosition">The position to use display.</param>
      /// <param name="alwaysShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when the content inside the ScrollView is wider than the scrollview itself.</param>
      /// <param name="alwaysShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when content inside the ScrollView is taller than the scrollview itself.</param>
      /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
      /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
      /// <param name="options"></param>
      /// <param name="style"></param>
      /// <param name="background"></param>
      public ScrollViewScope(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, params GUILayoutOption[] options)
      {
        this.handleScrollWheel = true;
        this.scrollPosition = GUILayout.BeginScrollView(scrollPosition, alwaysShowHorizontal, alwaysShowVertical, options);
      }

      /// <summary>
      ///   <para>Create a new ScrollViewScope and begin the corresponding ScrollView.</para>
      /// </summary>
      /// <param name="scrollPosition">The position to use display.</param>
      /// <param name="alwaysShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when the content inside the ScrollView is wider than the scrollview itself.</param>
      /// <param name="alwaysShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when content inside the ScrollView is taller than the scrollview itself.</param>
      /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
      /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
      /// <param name="options"></param>
      /// <param name="style"></param>
      /// <param name="background"></param>
      public ScrollViewScope(Vector2 scrollPosition, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options)
      {
        this.handleScrollWheel = true;
        this.scrollPosition = GUILayout.BeginScrollView(scrollPosition, horizontalScrollbar, verticalScrollbar, options);
      }

      /// <summary>
      ///   <para>Create a new ScrollViewScope and begin the corresponding ScrollView.</para>
      /// </summary>
      /// <param name="scrollPosition">The position to use display.</param>
      /// <param name="alwaysShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when the content inside the ScrollView is wider than the scrollview itself.</param>
      /// <param name="alwaysShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when content inside the ScrollView is taller than the scrollview itself.</param>
      /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
      /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
      /// <param name="options"></param>
      /// <param name="style"></param>
      /// <param name="background"></param>
      public ScrollViewScope(Vector2 scrollPosition, GUIStyle style, params GUILayoutOption[] options)
      {
        this.handleScrollWheel = true;
        this.scrollPosition = GUILayout.BeginScrollView(scrollPosition, style, options);
      }

      /// <summary>
      ///   <para>Create a new ScrollViewScope and begin the corresponding ScrollView.</para>
      /// </summary>
      /// <param name="scrollPosition">The position to use display.</param>
      /// <param name="alwaysShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when the content inside the ScrollView is wider than the scrollview itself.</param>
      /// <param name="alwaysShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when content inside the ScrollView is taller than the scrollview itself.</param>
      /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
      /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
      /// <param name="options"></param>
      /// <param name="style"></param>
      /// <param name="background"></param>
      public ScrollViewScope(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options)
      {
        this.handleScrollWheel = true;
        this.scrollPosition = GUILayout.BeginScrollView(scrollPosition, alwaysShowHorizontal, alwaysShowVertical, horizontalScrollbar, verticalScrollbar, options);
      }

      /// <summary>
      ///   <para>Create a new ScrollViewScope and begin the corresponding ScrollView.</para>
      /// </summary>
      /// <param name="scrollPosition">The position to use display.</param>
      /// <param name="alwaysShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when the content inside the ScrollView is wider than the scrollview itself.</param>
      /// <param name="alwaysShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when content inside the ScrollView is taller than the scrollview itself.</param>
      /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
      /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
      /// <param name="options"></param>
      /// <param name="style"></param>
      /// <param name="background"></param>
      public ScrollViewScope(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background, params GUILayoutOption[] options)
      {
        this.handleScrollWheel = true;
        this.scrollPosition = GUILayout.BeginScrollView(scrollPosition, alwaysShowHorizontal, alwaysShowVertical, horizontalScrollbar, verticalScrollbar, background, options);
      }

      /// <summary>
      ///   <para>The modified scrollPosition. Feed this back into the variable you pass in, as shown in the example.</para>
      /// </summary>
      public Vector2 scrollPosition { get; private set; }

      /// <summary>
      ///   <para>Whether this ScrollView should handle scroll wheel events. (default: true).</para>
      /// </summary>
      public bool handleScrollWheel { get; set; }

      protected override void CloseScope()
      {
        GUILayout.EndScrollView(this.handleScrollWheel);
      }
    }
  }
}
