﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.AudioMixerControllerInspector
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using UnityEditor.Audio;
using UnityEngine;

namespace UnityEditor
{
  [CustomEditor(typeof (AudioMixerController))]
  [CanEditMultipleObjects]
  internal class AudioMixerControllerInspector : Editor
  {
    private SerializedProperty m_EnableSuspend;
    private SerializedProperty m_SuspendThreshold;
    private SerializedProperty m_UpdateMode;

    public void OnEnable()
    {
      this.m_SuspendThreshold = this.serializedObject.FindProperty("m_SuspendThreshold");
      this.m_EnableSuspend = this.serializedObject.FindProperty("m_EnableSuspend");
      this.m_UpdateMode = this.serializedObject.FindProperty("m_UpdateMode");
    }

    public override void OnInspectorGUI()
    {
      this.serializedObject.Update();
      EditorGUILayout.PropertyField(this.m_EnableSuspend, AudioMixerControllerInspector.Texts.m_EnableSuspendLabel, new GUILayoutOption[0]);
      using (new EditorGUI.DisabledScope(!this.m_EnableSuspend.boolValue || this.m_EnableSuspend.hasMultipleDifferentValues))
      {
        EditorGUI.BeginChangeCheck();
        EditorGUI.s_UnitString = AudioMixerControllerInspector.Texts.dB;
        float floatValue = this.m_SuspendThreshold.floatValue;
        float num = EditorGUILayout.PowerSlider(AudioMixerControllerInspector.Texts.m_SuspendThresholdLabel, floatValue, AudioMixerController.kMinVolume, AudioMixerController.GetMaxVolume(), 1f);
        EditorGUI.s_UnitString = (string) null;
        if (EditorGUI.EndChangeCheck())
          this.m_SuspendThreshold.floatValue = num;
      }
      EditorGUILayout.PropertyField(this.m_UpdateMode, AudioMixerControllerInspector.Texts.m_UpdateModeLabel, new GUILayoutOption[0]);
      this.serializedObject.ApplyModifiedProperties();
    }

    private static class Texts
    {
      public static GUIContent m_EnableSuspendLabel = new GUIContent("Auto Mixer Suspend", "Enables/disables suspending of processing in order to save CPU when the RMS signal level falls under the defined threshold (in dB). Mixers resume processing when an AudioSource referencing them starts playing again.");
      public static GUIContent m_SuspendThresholdLabel = new GUIContent("    Threshold Volume", "The level of the Master Group at which the mixer suspends processing in order to save CPU. Mixers resume processing when an AudioSource referencing them starts playing again.");
      public static GUIContent m_UpdateModeLabel = new GUIContent("Update Mode", "Update AudioMixer transitions with game time or unscaled realtime.");
      public static string dB = nameof (dB);
    }
  }
}
