﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.AudioMixerEffectView
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor.Audio;
using UnityEngine;

namespace UnityEditor
{
  internal class AudioMixerEffectView
  {
    private const float kMinPitch = 0.01f;
    private const float kMaxPitch = 10f;
    private const int kLabelWidth = 170;
    private const int kTextboxWidth = 70;
    private AudioMixerGroupController m_PrevGroup;
    private readonly AudioMixerEffectView.EffectDragging m_EffectDragging;
    private int m_LastNumChannels;
    private AudioMixerEffectPlugin m_SharedPlugin;
    private Dictionary<string, IAudioEffectPluginGUI> m_CustomEffectGUIs;

    public AudioMixerEffectView()
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      AudioMixerEffectView.\u003CAudioMixerEffectView\u003Ec__AnonStorey0 viewCAnonStorey0 = new AudioMixerEffectView.\u003CAudioMixerEffectView\u003Ec__AnonStorey0();
      this.m_PrevGroup = (AudioMixerGroupController) null;
      this.m_LastNumChannels = 0;
      this.m_SharedPlugin = new AudioMixerEffectPlugin();
      this.m_CustomEffectGUIs = new Dictionary<string, IAudioEffectPluginGUI>();
      // ISSUE: explicit constructor call
      base.\u002Ector();
      this.m_EffectDragging = new AudioMixerEffectView.EffectDragging();
      // ISSUE: reference to a compiler-generated field
      viewCAnonStorey0.pluginType = typeof (IAudioEffectPluginGUI);
      foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
      {
        try
        {
          // ISSUE: reference to a compiler-generated method
          foreach (System.Type type in ((IEnumerable<System.Type>) assembly.GetTypes()).Where<System.Type>(new Func<System.Type, bool>(viewCAnonStorey0.\u003C\u003Em__0)))
            this.RegisterCustomGUI(Activator.CreateInstance(type) as IAudioEffectPluginGUI);
        }
        catch (Exception ex)
        {
        }
      }
    }

    public bool RegisterCustomGUI(IAudioEffectPluginGUI gui)
    {
      string name = gui.Name;
      if (this.m_CustomEffectGUIs.ContainsKey(name))
      {
        IAudioEffectPluginGUI customEffectGuI = this.m_CustomEffectGUIs[name];
        Debug.LogError((object) ("Attempt to register custom GUI for plugin " + name + " failed as another plugin is already registered under this name."));
        Debug.LogError((object) ("Plugin trying to register itself: " + gui.Description + " (Vendor: " + gui.Vendor + ")"));
        Debug.LogError((object) ("Plugin already registered: " + customEffectGuI.Description + " (Vendor: " + customEffectGuI.Vendor + ")"));
        return false;
      }
      this.m_CustomEffectGUIs[name] = gui;
      return true;
    }

    public void OnGUI(AudioMixerGroupController group)
    {
      if ((UnityEngine.Object) group == (UnityEngine.Object) null)
        return;
      AudioMixerController controller = group.controller;
      List<AudioMixerGroupController> allAudioGroupsSlow = controller.GetAllAudioGroupsSlow();
      Dictionary<AudioMixerEffectController, AudioMixerGroupController> effectMap = new Dictionary<AudioMixerEffectController, AudioMixerGroupController>();
      foreach (AudioMixerGroupController mixerGroupController in allAudioGroupsSlow)
      {
        foreach (AudioMixerEffectController effect in mixerGroupController.effects)
          effectMap[effect] = mixerGroupController;
      }
      Rect totalRect = EditorGUILayout.BeginVertical();
      if (EditorApplication.isPlaying)
      {
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        EditorGUI.BeginChangeCheck();
        GUILayout.Toggle((AudioSettings.editingInPlaymode ? 1 : 0) != 0, AudioMixerEffectView.Texts.editInPlaymode, EditorStyles.miniButton, new GUILayoutOption[1]
        {
          GUILayout.Width(120f)
        });
        if (EditorGUI.EndChangeCheck())
          AudioSettings.editingInPlaymode = !AudioSettings.editingInPlaymode;
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
      }
      using (new EditorGUI.DisabledScope(!AudioMixerController.EditingTargetSnapshot()))
      {
        if ((UnityEngine.Object) group != (UnityEngine.Object) this.m_PrevGroup)
        {
          this.m_PrevGroup = group;
          controller.m_HighlightEffectIndex = -1;
          AudioMixerUtility.RepaintAudioMixerAndInspectors();
        }
        double num = (double) AudioMixerEffectView.DoInitialModule(group, controller, allAudioGroupsSlow);
        for (int effectIndex = 0; effectIndex < group.effects.Length; ++effectIndex)
          this.DoEffectGUI(effectIndex, group, allAudioGroupsSlow, effectMap, ref controller.m_HighlightEffectIndex);
        this.m_EffectDragging.HandleDragging(totalRect, group, controller);
        GUILayout.Space(10f);
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (EditorGUILayout.DropdownButton(AudioMixerEffectView.Texts.addEffect, FocusType.Passive, GUISkin.current.button, new GUILayoutOption[0]))
        {
          GenericMenu pm = new GenericMenu();
          Rect last = GUILayoutUtility.topLevel.GetLast();
          AudioMixerGroupController[] groups = new AudioMixerGroupController[1]{ group };
          AudioMixerChannelStripView.AddEffectItemsToMenu(controller, groups, group.effects.Length, string.Empty, pm);
          pm.DropDown(last);
        }
        EditorGUILayout.EndHorizontal();
      }
      EditorGUILayout.EndVertical();
    }

    public static float DoInitialModule(AudioMixerGroupController group, AudioMixerController controller, List<AudioMixerGroupController> allGroups)
    {
      Rect rect = EditorGUILayout.BeginVertical(EditorStyles.inspectorDefaultMargins, new GUILayoutOption[0]);
      float valueForPitch = group.GetValueForPitch(controller, controller.TargetSnapshot);
      if (AudioMixerEffectGUI.Slider(AudioMixerEffectView.Texts.pitch, ref valueForPitch, 100f, 1f, AudioMixerEffectView.Texts.percentage, 0.01f, 10f, controller, (AudioParameterPath) new AudioGroupParameterPath(group, group.GetGUIDForPitch())))
      {
        Undo.RecordObject((UnityEngine.Object) controller.TargetSnapshot, "Change Pitch");
        group.SetValueForPitch(controller, controller.TargetSnapshot, valueForPitch);
      }
      GUILayout.Space(5f);
      EditorGUILayout.EndVertical();
      AudioMixerDrawUtils.DrawSplitter();
      return rect.height;
    }

    public void DoEffectGUI(int effectIndex, AudioMixerGroupController group, List<AudioMixerGroupController> allGroups, Dictionary<AudioMixerEffectController, AudioMixerGroupController> effectMap, ref int highlightEffectIndex)
    {
      Event current = Event.current;
      AudioMixerController controller = group.controller;
      AudioMixerEffectController effect1 = group.effects[effectIndex];
      MixerParameterDefinition[] effectParameters = MixerEffectDefinitions.GetEffectParameters(effect1.effectName);
      Rect effectRect = EditorGUILayout.BeginVertical();
      bool flag1 = effectRect.Contains(current.mousePosition);
      EventType typeForControl = current.GetTypeForControl(this.m_EffectDragging.dragControlID);
      if (typeForControl == EventType.MouseMove && flag1 && highlightEffectIndex != effectIndex)
      {
        highlightEffectIndex = effectIndex;
        AudioMixerUtility.RepaintAudioMixerAndInspectors();
      }
      Vector2 vector2 = EditorStyles.iconButton.CalcSize(EditorGUI.GUIContents.titleSettingsIcon);
      Rect rect1 = GUILayoutUtility.GetRect(1f, 17f);
      Rect rect2 = new Rect(rect1.x + 6f, rect1.y + 5f, 6f, 6f);
      Rect position = new Rect((float) ((double) rect1.x + 8.0 + 6.0), rect1.y, (float) ((double) rect1.width - 8.0 - 6.0 - (double) vector2.x - 5.0), rect1.height);
      Rect rect3 = new Rect(position.xMax, rect1.y, vector2.x, vector2.y);
      Rect rect4 = new Rect(rect1.x, rect1.y, (float) ((double) rect1.width - (double) vector2.x - 5.0), rect1.height);
      bool flag2 = EditorPrefs.GetBool(AudioMixerGroupEditor.kPrefKeyForShowCpuUsage, false) && EditorUtility.audioProfilingEnabled;
      float num1 = !EditorGUIUtility.isProSkin ? 1f : 0.1f;
      Color color1 = new Color(num1, num1, num1, 0.2f);
      Color color2 = GUI.color;
      GUI.color = color1;
      GUI.DrawTexture(rect1, (Texture) EditorGUIUtility.whiteTexture);
      GUI.color = color2;
      Color effectColor = AudioMixerDrawUtils.GetEffectColor(effect1);
      EditorGUI.DrawRect(rect2, effectColor);
      GUI.Label(position, !flag2 ? effect1.effectName : effect1.effectName + string.Format(AudioMixerEffectView.Texts.cpuFormatString, (object) effect1.GetCPUUsage(controller)), EditorStyles.boldLabel);
      if (EditorGUI.DropdownButton(rect3, EditorGUI.GUIContents.titleSettingsIcon, FocusType.Passive, EditorStyles.iconButton))
        AudioMixerEffectView.ShowEffectContextMenu(group, effect1, effectIndex, controller, rect3);
      if (current.type == EventType.ContextClick && rect1.Contains(current.mousePosition))
      {
        AudioMixerEffectView.ShowEffectContextMenu(group, effect1, effectIndex, controller, new Rect(current.mousePosition.x, rect1.y, 1f, rect1.height));
        current.Use();
      }
      if (typeForControl == EventType.Repaint)
        EditorGUIUtility.AddCursorRect(rect4, MouseCursor.ResizeVertical, this.m_EffectDragging.dragControlID);
      using (new EditorGUI.DisabledScope(effect1.bypass || group.bypassEffects))
      {
        EditorGUILayout.BeginVertical(EditorStyles.inspectorDefaultMargins, new GUILayoutOption[0]);
        if (effect1.IsAttenuation())
        {
          EditorGUILayout.BeginVertical();
          float valueForVolume = group.GetValueForVolume(controller, controller.TargetSnapshot);
          if (AudioMixerEffectGUI.Slider(AudioMixerEffectView.Texts.volume, ref valueForVolume, 1f, 1f, AudioMixerEffectView.Texts.dB, AudioMixerController.kMinVolume, AudioMixerController.GetMaxVolume(), controller, (AudioParameterPath) new AudioGroupParameterPath(group, group.GetGUIDForVolume())))
          {
            Undo.RecordObject((UnityEngine.Object) controller.TargetSnapshot, "Change Volume Fader");
            group.SetValueForVolume(controller, controller.TargetSnapshot, valueForVolume);
            AudioMixerUtility.RepaintAudioMixerAndInspectors();
          }
          float[] vuLevel = new float[9];
          float[] vuPeak = new float[9];
          int num2 = group.controller.GetGroupVUInfo(group.groupID, true, ref vuLevel, ref vuPeak);
          if (current.type == EventType.Layout)
          {
            this.m_LastNumChannels = num2;
          }
          else
          {
            if (num2 != this.m_LastNumChannels)
              HandleUtility.Repaint();
            num2 = this.m_LastNumChannels;
          }
          GUILayout.Space(4f);
          for (int index = 0; index < num2; ++index)
          {
            float num3 = 1f - AudioMixerController.VolumeToScreenMapping(Mathf.Clamp(vuLevel[index], AudioMixerController.kMinVolume, AudioMixerController.GetMaxVolume()), 1f, true);
            float peak = 1f - AudioMixerController.VolumeToScreenMapping(Mathf.Clamp(vuPeak[index], AudioMixerController.kMinVolume, AudioMixerController.GetMaxVolume()), 1f, true);
            EditorGUILayout.VUMeterHorizontal(num3, peak, new GUILayoutOption[1]
            {
              GUILayout.Height(10f)
            });
            if (!EditorApplication.isPlaying && (double) peak > 0.0)
              AudioMixerUtility.RepaintAudioMixerAndInspectors();
          }
          GUILayout.Space(4f);
          EditorGUILayout.EndVertical();
        }
        if (effect1.IsSend())
        {
          GUIContent buttonContent = !((UnityEngine.Object) effect1.sendTarget == (UnityEngine.Object) null) ? GUIContent.Temp(effect1.GetSendTargetDisplayString(effectMap)) : AudioMixerEffectView.Texts.none;
          Rect buttonRect;
          if (AudioMixerEffectGUI.PopupButton(AudioMixerEffectView.Texts.bus, buttonContent, EditorStyles.popup, out buttonRect))
            AudioMixerEffectView.ShowBusPopupMenu(effectIndex, group, allGroups, effectMap, effect1, buttonRect);
          if ((UnityEngine.Object) effect1.sendTarget != (UnityEngine.Object) null)
          {
            float valueForMixLevel = effect1.GetValueForMixLevel(controller, controller.TargetSnapshot);
            if (AudioMixerEffectGUI.Slider(AudioMixerEffectView.Texts.sendLevel, ref valueForMixLevel, 1f, 1f, AudioMixerEffectView.Texts.dB, AudioMixerController.kMinVolume, AudioMixerController.kMaxEffect, controller, (AudioParameterPath) new AudioEffectParameterPath(group, effect1, effect1.GetGUIDForMixLevel())))
            {
              Undo.RecordObject((UnityEngine.Object) controller.TargetSnapshot, "Change Send Level");
              effect1.SetValueForMixLevel(controller, controller.TargetSnapshot, valueForMixLevel);
              AudioMixerUtility.RepaintAudioMixerAndInspectors();
            }
          }
        }
        if (MixerEffectDefinitions.EffectCanBeSidechainTarget(effect1))
        {
          bool flag3 = false;
          foreach (AudioMixerGroupController allGroup in allGroups)
          {
            foreach (AudioMixerEffectController effect2 in allGroup.effects)
            {
              if (effect2.IsSend() && (UnityEngine.Object) effect2.sendTarget == (UnityEngine.Object) effect1)
              {
                flag3 = true;
                break;
              }
            }
            if (flag3)
              break;
          }
          if (!flag3)
            GUILayout.Label(new GUIContent("No Send sources connected.", (Texture) EditorGUIUtility.warningIcon));
        }
        if (effect1.enableWetMix && !effect1.IsReceive() && (!effect1.IsDuckVolume() && !effect1.IsAttenuation()) && !effect1.IsSend())
        {
          float valueForMixLevel = effect1.GetValueForMixLevel(controller, controller.TargetSnapshot);
          if (AudioMixerEffectGUI.Slider(AudioMixerEffectView.Texts.wet, ref valueForMixLevel, 1f, 1f, AudioMixerEffectView.Texts.dB, AudioMixerController.kMinVolume, AudioMixerController.kMaxEffect, controller, (AudioParameterPath) new AudioEffectParameterPath(group, effect1, effect1.GetGUIDForMixLevel())))
          {
            Undo.RecordObject((UnityEngine.Object) controller.TargetSnapshot, "Change Mix Level");
            effect1.SetValueForMixLevel(controller, controller.TargetSnapshot, valueForMixLevel);
            AudioMixerUtility.RepaintAudioMixerAndInspectors();
          }
        }
        bool flag4 = true;
        if (this.m_CustomEffectGUIs.ContainsKey(effect1.effectName))
        {
          IAudioEffectPluginGUI customEffectGuI = this.m_CustomEffectGUIs[effect1.effectName];
          this.m_SharedPlugin.m_Controller = controller;
          this.m_SharedPlugin.m_Effect = effect1;
          this.m_SharedPlugin.m_ParamDefs = effectParameters;
          flag4 = customEffectGuI.OnGUI((IAudioEffectPlugin) this.m_SharedPlugin);
        }
        if (flag4)
        {
          foreach (MixerParameterDefinition parameterDefinition in effectParameters)
          {
            float valueForParameter = effect1.GetValueForParameter(controller, controller.TargetSnapshot, parameterDefinition.name);
            if (AudioMixerEffectGUI.Slider(GUIContent.Temp(parameterDefinition.name, parameterDefinition.description), ref valueForParameter, parameterDefinition.displayScale, parameterDefinition.displayExponent, parameterDefinition.units, parameterDefinition.minRange, parameterDefinition.maxRange, controller, (AudioParameterPath) new AudioEffectParameterPath(group, effect1, effect1.GetGUIDForParameter(parameterDefinition.name))))
            {
              Undo.RecordObject((UnityEngine.Object) controller.TargetSnapshot, "Change " + parameterDefinition.name);
              effect1.SetValueForParameter(controller, controller.TargetSnapshot, parameterDefinition.name, valueForParameter);
            }
          }
          if (effectParameters.Length > 0)
            GUILayout.Space(6f);
        }
      }
      this.m_EffectDragging.HandleDragElement(effectIndex, effectRect, rect4, group, allGroups);
      EditorGUILayout.EndVertical();
      EditorGUILayout.EndVertical();
      AudioMixerDrawUtils.DrawSplitter();
    }

    private static void ShowEffectContextMenu(AudioMixerGroupController group, AudioMixerEffectController effect, int effectIndex, AudioMixerController controller, Rect buttonRect)
    {
      GenericMenu pm = new GenericMenu();
      if (!effect.IsReceive())
      {
        if (!effect.IsAttenuation() && !effect.IsSend() && !effect.IsDuckVolume())
        {
          pm.AddItem(new GUIContent("Allow Wet Mixing (causes higher memory usage)"), effect.enableWetMix, (GenericMenu.MenuFunction) (() =>
          {
            Undo.RecordObject((UnityEngine.Object) effect, "Enable Wet Mixing");
            effect.enableWetMix = !effect.enableWetMix;
          }));
          pm.AddItem(new GUIContent("Bypass"), effect.bypass, (GenericMenu.MenuFunction) (() =>
          {
            Undo.RecordObject((UnityEngine.Object) effect, "Bypass Effect");
            effect.bypass = !effect.bypass;
            controller.UpdateBypass();
            AudioMixerUtility.RepaintAudioMixerAndInspectors();
          }));
          pm.AddSeparator("");
        }
        pm.AddItem(new GUIContent("Copy effect settings to all snapshots"), false, (GenericMenu.MenuFunction) (() =>
        {
          Undo.RecordObject((UnityEngine.Object) controller, "Copy effect settings to all snapshots");
          if (effect.IsAttenuation())
            controller.CopyAttenuationToAllSnapshots(group, controller.TargetSnapshot);
          else
            controller.CopyEffectSettingsToAllSnapshots(group, effectIndex, controller.TargetSnapshot, effect.IsSend());
          AudioMixerUtility.RepaintAudioMixerAndInspectors();
        }));
        if (!effect.IsAttenuation() && !effect.IsSend() && (!effect.IsDuckVolume() && effect.enableWetMix))
          pm.AddItem(new GUIContent("Copy effect settings to all snapshots, including wet level"), false, (GenericMenu.MenuFunction) (() =>
          {
            Undo.RecordObject((UnityEngine.Object) controller, "Copy effect settings to all snapshots, including wet level");
            controller.CopyEffectSettingsToAllSnapshots(group, effectIndex, controller.TargetSnapshot, true);
            AudioMixerUtility.RepaintAudioMixerAndInspectors();
          }));
        pm.AddSeparator("");
      }
      AudioMixerGroupController[] groups = new AudioMixerGroupController[1]{ group };
      AudioMixerChannelStripView.AddEffectItemsToMenu(controller, groups, effectIndex, "Add effect before/", pm);
      AudioMixerChannelStripView.AddEffectItemsToMenu(controller, groups, effectIndex + 1, "Add effect after/", pm);
      if (!effect.IsAttenuation())
      {
        pm.AddSeparator("");
        pm.AddItem(new GUIContent("Remove this effect"), false, (GenericMenu.MenuFunction) (() =>
        {
          controller.ClearSendConnectionsTo(effect);
          controller.RemoveEffect(effect, group);
          AudioMixerUtility.RepaintAudioMixerAndInspectors();
        }));
      }
      pm.DropDown(buttonRect);
    }

    private static void ShowBusPopupMenu(int effectIndex, AudioMixerGroupController group, List<AudioMixerGroupController> allGroups, Dictionary<AudioMixerEffectController, AudioMixerGroupController> effectMap, AudioMixerEffectController effect, Rect buttonRect)
    {
      GenericMenu pm = new GenericMenu();
      GenericMenu genericMenu = pm;
      GUIContent content = new GUIContent("None");
      int num = 0;
      // ISSUE: reference to a compiler-generated field
      if (AudioMixerEffectView.\u003C\u003Ef__mg\u0024cache0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AudioMixerEffectView.\u003C\u003Ef__mg\u0024cache0 = new GenericMenu.MenuFunction2(AudioMixerChannelStripView.ConnectSendPopupCallback);
      }
      // ISSUE: reference to a compiler-generated field
      GenericMenu.MenuFunction2 fMgCache0 = AudioMixerEffectView.\u003C\u003Ef__mg\u0024cache0;
      AudioMixerChannelStripView.ConnectSendContext connectSendContext = new AudioMixerChannelStripView.ConnectSendContext(effect, (AudioMixerEffectController) null);
      genericMenu.AddItem(content, num != 0, fMgCache0, (object) connectSendContext);
      pm.AddSeparator("");
      AudioMixerChannelStripView.AddMenuItemsForReturns(pm, string.Empty, effectIndex, group, allGroups, effectMap, effect, true);
      if (pm.GetItemCount() == 2)
        pm.AddDisabledItem(new GUIContent("No valid Receive targets found"));
      pm.DropDown(buttonRect);
    }

    private static class Texts
    {
      public static GUIContent editInPlaymode = new GUIContent("Edit in Playmode");
      public static GUIContent pitch = new GUIContent("Pitch");
      public static GUIContent addEffect = new GUIContent("Add Effect");
      public static GUIContent volume = new GUIContent("Volume");
      public static GUIContent sendLevel = new GUIContent("Send level");
      public static GUIContent bus = new GUIContent("Receive");
      public static GUIContent none = new GUIContent("None");
      public static GUIContent wet = new GUIContent("Wet", "Enables/disables wet/dry ratio on this effect. Note that this makes the DSP graph more complex and requires additional CPU and memory, so use it only when necessary.");
      public static string dB = nameof (dB);
      public static string percentage = "%";
      public static string cpuFormatString = " - CPU: {0:#0.00}%";
    }

    private class EffectDragging
    {
      private readonly Color kMoveColorBorderAllowed = new Color(1f, 1f, 1f, 1f);
      private readonly Color kMoveColorHiAllowed = new Color(1f, 1f, 1f, 0.3f);
      private readonly Color kMoveColorLoAllowed = new Color(1f, 1f, 1f, 0.0f);
      private readonly Color kMoveColorBorderDisallowed = new Color(0.8f, 0.0f, 0.0f, 1f);
      private readonly Color kMoveColorHiDisallowed = new Color(1f, 0.0f, 0.0f, 0.3f);
      private readonly Color kMoveColorLoDisallowed = new Color(1f, 0.0f, 0.0f, 0.0f);
      private readonly int m_DragControlID = 0;
      private int m_MovingSrcIndex = -1;
      private int m_MovingDstIndex = -1;
      private bool m_MovingEffectAllowed = false;
      private float m_MovingPos = 0.0f;
      private Rect m_MovingRect = new Rect(0.0f, 0.0f, 0.0f, 0.0f);
      private float m_DragHighlightPos = -1f;
      private float m_DragHighlightHeight = 2f;

      public EffectDragging()
      {
        this.m_DragControlID = GUIUtility.GetPermanentControlID();
      }

      public bool IsDraggingIndex(int effectIndex)
      {
        return this.m_MovingSrcIndex == effectIndex && GUIUtility.hotControl == this.m_DragControlID;
      }

      public int dragControlID
      {
        get
        {
          return this.m_DragControlID;
        }
      }

      private bool isDragging
      {
        get
        {
          return this.m_MovingSrcIndex != -1 && GUIUtility.hotControl == this.m_DragControlID;
        }
      }

      public void HandleDragElement(int effectIndex, Rect effectRect, Rect dragRect, AudioMixerGroupController group, List<AudioMixerGroupController> allGroups)
      {
        Event current = Event.current;
        switch (current.GetTypeForControl(this.m_DragControlID))
        {
          case EventType.MouseDown:
            if (current.button == 0 && dragRect.Contains(current.mousePosition) && GUIUtility.hotControl == 0)
            {
              this.m_MovingSrcIndex = effectIndex;
              this.m_MovingPos = current.mousePosition.y;
              this.m_MovingRect = new Rect(effectRect.x, effectRect.y - this.m_MovingPos, effectRect.width, effectRect.height);
              GUIUtility.hotControl = this.m_DragControlID;
              EditorGUIUtility.SetWantsMouseJumping(1);
              current.Use();
              break;
            }
            break;
          case EventType.Repaint:
            if (effectIndex == this.m_MovingSrcIndex)
            {
              using (new EditorGUI.DisabledScope(true))
              {
                AudioMixerDrawUtils.styles.channelStripAreaBackground.Draw(effectRect, false, false, false, false);
                break;
              }
            }
            else
              break;
        }
        if (!this.isDragging)
          return;
        float num = effectRect.height * 0.5f;
        float f = current.mousePosition.y - effectRect.y - num;
        if ((double) Mathf.Abs(f) <= (double) num)
        {
          int targetIndex = (double) f >= 0.0 ? effectIndex + 1 : effectIndex;
          if (targetIndex != this.m_MovingDstIndex)
          {
            this.m_DragHighlightPos = (double) f >= 0.0 ? effectRect.y + effectRect.height : effectRect.y;
            this.m_MovingDstIndex = targetIndex;
            this.m_MovingEffectAllowed = !AudioMixerController.WillMovingEffectCauseFeedback(allGroups, group, this.m_MovingSrcIndex, group, targetIndex, (List<AudioMixerController.ConnectionNode>) null);
          }
        }
        if (this.m_MovingDstIndex == this.m_MovingSrcIndex || this.m_MovingDstIndex == this.m_MovingSrcIndex + 1)
          this.m_DragHighlightPos = 0.0f;
      }

      public void HandleDragging(Rect totalRect, AudioMixerGroupController group, AudioMixerController controller)
      {
        if (!this.isDragging)
          return;
        Event current = Event.current;
        switch (current.GetTypeForControl(this.m_DragControlID))
        {
          case EventType.MouseUp:
            current.Use();
            if (this.m_MovingSrcIndex == -1)
              break;
            if (this.m_MovingDstIndex != -1 && this.m_MovingEffectAllowed)
            {
              List<AudioMixerEffectController> list = ((IEnumerable<AudioMixerEffectController>) group.effects).ToList<AudioMixerEffectController>();
              if (AudioMixerController.MoveEffect(ref list, this.m_MovingSrcIndex, ref list, this.m_MovingDstIndex))
                group.effects = list.ToArray();
            }
            this.m_MovingSrcIndex = -1;
            this.m_MovingDstIndex = -1;
            controller.m_HighlightEffectIndex = -1;
            if (GUIUtility.hotControl == this.m_DragControlID)
              GUIUtility.hotControl = 0;
            EditorGUIUtility.SetWantsMouseJumping(0);
            AudioMixerUtility.RepaintAudioMixerAndInspectors();
            GUIUtility.ExitGUI();
            break;
          case EventType.MouseDrag:
            this.m_MovingPos = current.mousePosition.y;
            current.Use();
            break;
          case EventType.Repaint:
            if ((double) this.m_DragHighlightPos <= 0.0)
              break;
            float width = totalRect.width;
            Color color1 = !this.m_MovingEffectAllowed ? this.kMoveColorLoDisallowed : this.kMoveColorLoAllowed;
            Color color2 = !this.m_MovingEffectAllowed ? this.kMoveColorHiDisallowed : this.kMoveColorHiAllowed;
            Color color3 = !this.m_MovingEffectAllowed ? this.kMoveColorBorderDisallowed : this.kMoveColorBorderAllowed;
            AudioMixerDrawUtils.DrawGradientRect(new Rect(this.m_MovingRect.x, this.m_DragHighlightPos - 15f, width, 15f), color1, color2);
            AudioMixerDrawUtils.DrawGradientRect(new Rect(this.m_MovingRect.x, this.m_DragHighlightPos, width, 15f), color2, color1);
            AudioMixerDrawUtils.DrawGradientRect(new Rect(this.m_MovingRect.x, this.m_DragHighlightPos - this.m_DragHighlightHeight / 2f, width, this.m_DragHighlightHeight), color3, color3);
            break;
        }
      }
    }
  }
}
