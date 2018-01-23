﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.SceneViewRotation
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Profiling;

namespace UnityEditor
{
  [Serializable]
  internal class SceneViewRotation
  {
    private static Quaternion[] kDirectionRotations = new Quaternion[6]{ Quaternion.LookRotation(new Vector3(-1f, 0.0f, 0.0f)), Quaternion.LookRotation(new Vector3(0.0f, -1f, 0.0f)), Quaternion.LookRotation(new Vector3(0.0f, 0.0f, -1f)), Quaternion.LookRotation(new Vector3(1f, 0.0f, 0.0f)), Quaternion.LookRotation(new Vector3(0.0f, 1f, 0.0f)), Quaternion.LookRotation(new Vector3(0.0f, 0.0f, 1f)) };
    private static string[] kDirNames = new string[9]{ "Right", "Top", "Front", "Left", "Bottom", "Back", "Iso", "Persp", "2D" };
    private static string[] kMenuDirNames = new string[9]{ "Free", "Right", "Top", "Front", "Left", "Bottom", "Back", "", "Perspective" };
    private static readonly GUIContent[] s_HandleAxisLabels = new GUIContent[3]{ new GUIContent("x"), new GUIContent("y"), new GUIContent("z") };
    private int currentDir = 7;
    private AnimBool[] dirVisible = new AnimBool[3]{ new AnimBool(true), new AnimBool(true), new AnimBool(true) };
    private AnimBool[] dirNameVisible = new AnimBool[9]{ new AnimBool(), new AnimBool(), new AnimBool(), new AnimBool(), new AnimBool(), new AnimBool(), new AnimBool(), new AnimBool(), new AnimBool() };
    private AnimBool m_RotationLocked = new AnimBool();
    private AnimBool m_Visible = new AnimBool();
    private const int kRotationSize = 100;
    private const int kRotationMenuInset = 22;
    private const float kRotationLockedAlpha = 0.4f;
    private int[] m_ViewDirectionControlIDs;
    private int m_CenterButtonControlID;
    private static SceneViewRotation.Styles s_Styles;

    private float faded2Dgray
    {
      get
      {
        return this.dirNameVisible[8].faded;
      }
    }

    private float fadedRotationLock
    {
      get
      {
        return Mathf.Lerp(0.4f, 1f, this.m_RotationLocked.faded);
      }
    }

    private float fadedVisibility
    {
      get
      {
        return this.m_Visible.faded * this.fadedRotationLock;
      }
    }

    private static SceneViewRotation.Styles styles
    {
      get
      {
        if (SceneViewRotation.s_Styles == null)
          SceneViewRotation.s_Styles = new SceneViewRotation.Styles();
        return SceneViewRotation.s_Styles;
      }
    }

    public void Register(SceneView view)
    {
      for (int index = 0; index < this.dirVisible.Length; ++index)
        this.dirVisible[index].valueChanged.AddListener(new UnityAction(((EditorWindow) view).Repaint));
      for (int index = 0; index < this.dirNameVisible.Length; ++index)
        this.dirNameVisible[index].valueChanged.AddListener(new UnityAction(((EditorWindow) view).Repaint));
      this.m_RotationLocked.valueChanged.AddListener(new UnityAction(((EditorWindow) view).Repaint));
      this.m_Visible.valueChanged.AddListener(new UnityAction(((EditorWindow) view).Repaint));
      int labelIndexForView = this.GetLabelIndexForView(view, view.rotation * Vector3.forward, view.orthographic);
      for (int index = 0; index < this.dirNameVisible.Length; ++index)
        this.dirNameVisible[index].value = index == labelIndexForView;
      this.m_RotationLocked.value = !view.isRotationLocked;
      this.m_Visible.value = labelIndexForView != 8;
      this.SwitchDirNameVisible(labelIndexForView);
      if (this.m_ViewDirectionControlIDs != null)
        return;
      this.m_ViewDirectionControlIDs = new int[SceneViewRotation.kDirectionRotations.Length];
      for (int index = 0; index < this.m_ViewDirectionControlIDs.Length; ++index)
        this.m_ViewDirectionControlIDs[index] = GUIUtility.GetPermanentControlID();
      this.m_CenterButtonControlID = GUIUtility.GetPermanentControlID();
    }

    private void AxisSelectors(SceneView view, Camera cam, float size, float sgn, GUIStyle viewAxisLabelStyle)
    {
      for (int dir = SceneViewRotation.kDirectionRotations.Length - 1; dir >= 0; --dir)
      {
        Quaternion directionRotation = SceneViewRotation.kDirectionRotations[dir];
        float faded = this.dirVisible[dir % 3].faded;
        Vector3 rhs = SceneViewRotation.kDirectionRotations[dir] * Vector3.forward;
        float num1 = Vector3.Dot(view.camera.transform.forward, rhs);
        if (((double) num1 > 0.0 || (double) sgn <= 0.0) && ((double) num1 <= 0.0 || (double) sgn >= 0.0))
        {
          Color a;
          switch (dir)
          {
            case 0:
              a = Handles.xAxisColor;
              break;
            case 1:
              a = Handles.yAxisColor;
              break;
            case 2:
              a = Handles.zAxisColor;
              break;
            default:
              a = Handles.centerColor;
              break;
          }
          if (view.in2DMode)
            a = Color.Lerp(a, Color.gray, this.faded2Dgray);
          a.a *= faded * this.fadedVisibility;
          Handles.color = a;
          if ((double) a.a <= 0.100000001490116 || view.isRotationLocked)
            GUI.enabled = false;
          if ((double) sgn > 0.0)
          {
            int directionControlId = this.m_ViewDirectionControlIDs[dir];
            Vector3 position = directionRotation * Vector3.forward * size * -1.2f;
            Quaternion direction = directionRotation;
            double num2 = (double) size;
            double num3 = (double) size * 0.699999988079071;
            // ISSUE: reference to a compiler-generated field
            if (SceneViewRotation.\u003C\u003Ef__mg\u0024cache0 == null)
            {
              // ISSUE: reference to a compiler-generated field
              SceneViewRotation.\u003C\u003Ef__mg\u0024cache0 = new Handles.CapFunction(Handles.ConeHandleCap);
            }
            // ISSUE: reference to a compiler-generated field
            Handles.CapFunction fMgCache0 = SceneViewRotation.\u003C\u003Ef__mg\u0024cache0;
            if (Handles.Button(directionControlId, position, direction, (float) num2, (float) num3, fMgCache0) && !view.in2DMode && !view.isRotationLocked)
              this.ViewAxisDirection(view, dir);
          }
          if (dir < 3)
          {
            GUI.color = new Color(1f, 1f, 1f, this.dirVisible[dir].faded * this.fadedVisibility);
            Vector3 vector3 = rhs + num1 * view.camera.transform.forward * -0.5f;
            Handles.Label(-((vector3 * 0.7f + vector3.normalized * 1.5f) * size), SceneViewRotation.s_HandleAxisLabels[dir], SceneViewRotation.styles.viewAxisLabelStyle);
          }
          if ((double) sgn < 0.0)
          {
            int directionControlId = this.m_ViewDirectionControlIDs[dir];
            Vector3 position = directionRotation * Vector3.forward * size * -1.2f;
            Quaternion direction = directionRotation;
            double num2 = (double) size;
            double num3 = (double) size * 0.699999988079071;
            // ISSUE: reference to a compiler-generated field
            if (SceneViewRotation.\u003C\u003Ef__mg\u0024cache1 == null)
            {
              // ISSUE: reference to a compiler-generated field
              SceneViewRotation.\u003C\u003Ef__mg\u0024cache1 = new Handles.CapFunction(Handles.ConeHandleCap);
            }
            // ISSUE: reference to a compiler-generated field
            Handles.CapFunction fMgCache1 = SceneViewRotation.\u003C\u003Ef__mg\u0024cache1;
            if (Handles.Button(directionControlId, position, direction, (float) num2, (float) num3, fMgCache1) && !view.in2DMode && !view.isRotationLocked)
              this.ViewAxisDirection(view, dir);
          }
          Handles.color = Color.white;
          GUI.color = Color.white;
          GUI.enabled = true;
        }
      }
    }

    internal void HandleContextClick(SceneView view)
    {
      if (view.in2DMode || view.isRotationLocked)
        return;
      Event current = Event.current;
      if (current.type == EventType.MouseDown && current.button == 1 && (double) Mathf.Min(view.position.width, view.position.height) >= 100.0 && new Rect((float) ((double) view.position.width - 100.0 + 22.0), 22f, 56f, 56f).Contains(current.mousePosition))
      {
        this.DisplayContextMenu(new Rect(current.mousePosition.x, current.mousePosition.y, 0.0f, 0.0f), view);
        current.Use();
      }
    }

    private void DisplayContextMenu(Rect buttonOrCursorRect, SceneView view)
    {
      int[] selected = new int[!view.orthographic ? 2 : 1];
      selected[0] = this.currentDir < 6 ? this.currentDir + 1 : 0;
      if (!view.orthographic)
        selected[1] = 8;
      EditorUtility.DisplayCustomMenu(buttonOrCursorRect, SceneViewRotation.kMenuDirNames, selected, new EditorUtility.SelectMenuItemFunction(this.ContextMenuDelegate), (object) view);
      GUIUtility.ExitGUI();
    }

    private void ContextMenuDelegate(object userData, string[] options, int selected)
    {
      SceneView view = userData as SceneView;
      if ((UnityEngine.Object) view == (UnityEngine.Object) null)
        return;
      if (selected == 0)
        this.ViewFromNiceAngle(view, false);
      else if (selected >= 1 && selected <= 6)
      {
        int dir = selected - 1;
        this.ViewAxisDirection(view, dir);
      }
      else
      {
        switch (selected)
        {
          case 8:
            this.ViewSetOrtho(view, !view.orthographic);
            break;
          case 10:
            view.LookAt(view.pivot, Quaternion.LookRotation(new Vector3(-1f, -0.7f, -1f)), view.size, view.orthographic);
            break;
          case 11:
            view.LookAt(view.pivot, Quaternion.LookRotation(new Vector3(1f, -0.7f, -1f)), view.size, view.orthographic);
            break;
          case 12:
            view.LookAt(view.pivot, Quaternion.LookRotation(new Vector3(1f, -0.7f, 1f)), view.size, view.orthographic);
            break;
        }
      }
    }

    private void DrawIsoStatusSymbol(Vector3 center, SceneView view, float alpha)
    {
      float num = 1f - Mathf.Clamp01((float) ((double) view.m_Ortho.faded * 1.20000004768372 - 0.100000001490116));
      Vector3 vector3_1 = Vector3.up * 3f;
      Vector3 vector3_2 = Vector3.right * 10f;
      Vector3 vector3_3 = center - vector3_2 * 0.5f;
      Handles.color = new Color(1f, 1f, 1f, 0.6f * alpha);
      Handles.DrawAAPolyLine(new Vector3[2]
      {
        vector3_3 + vector3_1 * (1f - num),
        vector3_3 + vector3_2 + vector3_1 * (float) (1.0 + (double) num * 0.5)
      });
      Handles.DrawAAPolyLine(new Vector3[2]
      {
        vector3_3,
        vector3_3 + vector3_2
      });
      Handles.DrawAAPolyLine(new Vector3[2]
      {
        vector3_3 - vector3_1 * (1f - num),
        vector3_3 + vector3_2 - vector3_1 * (float) (1.0 + (double) num * 0.5)
      });
    }

    private void DrawRotationLock(SceneView view)
    {
      Rect position = new Rect(view.position.width - 16f - 12f, 17f - 12f, 24f, 24f);
      Color centerColor = Handles.centerColor;
      centerColor.a *= this.m_Visible.faded;
      if ((double) centerColor.a <= 0.0)
        return;
      Color color = GUI.color;
      GUI.color = centerColor;
      GUIContent content = !view.isRotationLocked ? SceneViewRotation.styles.unlockedRotationIcon : SceneViewRotation.styles.lockedRotationIcon;
      if (GUI.Button(position, content, SceneViewRotation.styles.lockStyle) && !view.in2DMode)
      {
        view.isRotationLocked = !view.isRotationLocked;
        this.m_RotationLocked.target = !view.isRotationLocked;
      }
      GUI.color = color;
    }

    private void DrawLabels(SceneView view)
    {
      Rect rect = new Rect((float) ((double) view.position.width - 100.0 + 17.0), 92f, 66f, 16f);
      if (!view.in2DMode && !view.isRotationLocked && GUI.Button(rect, string.Empty, SceneViewRotation.styles.viewLabelStyleLeftAligned))
      {
        if (Event.current.button == 1)
          this.DisplayContextMenu(rect, view);
        else
          this.ViewSetOrtho(view, !view.orthographic);
      }
      if (Event.current.type != EventType.Repaint)
        return;
      int index1 = 8;
      Rect position = rect;
      float num1 = 0.0f;
      float num2 = 0.0f;
      for (int index2 = 0; index2 < SceneViewRotation.kDirNames.Length; ++index2)
      {
        if (index2 != index1)
        {
          num2 += this.dirNameVisible[index2].faded;
          if ((double) this.dirNameVisible[index2].faded > 0.0)
            num1 += SceneViewRotation.styles.viewLabelStyleLeftAligned.CalcSize(EditorGUIUtility.TempContent(SceneViewRotation.kDirNames[index2])).x * this.dirNameVisible[index2].faded;
        }
      }
      if ((double) num2 > 0.0)
        num1 /= num2;
      position.x += (float) (37.0 - (double) num1 * 0.5);
      position.x = (float) Mathf.RoundToInt(position.x);
      for (int index2 = 0; index2 < this.dirNameVisible.Length && index2 < SceneViewRotation.kDirNames.Length; ++index2)
      {
        if (index2 != index1)
        {
          Color centerColor = Handles.centerColor;
          centerColor.a *= this.dirNameVisible[index2].faded * this.fadedRotationLock;
          if ((double) centerColor.a > 0.0)
          {
            GUI.color = centerColor;
            GUI.Label(position, SceneViewRotation.kDirNames[index2], SceneViewRotation.styles.viewLabelStyleLeftAligned);
          }
        }
      }
      Color centerColor1 = Handles.centerColor;
      centerColor1.a *= this.faded2Dgray * this.fadedVisibility;
      if ((double) centerColor1.a > 0.0)
      {
        GUI.color = centerColor1;
        GUI.Label(rect, SceneViewRotation.kDirNames[index1], SceneViewRotation.styles.viewLabelStyleCentered);
      }
      if ((double) this.faded2Dgray < 1.0)
        this.DrawIsoStatusSymbol(new Vector3(position.x - 8f, position.y + 8.5f, 0.0f), view, (1f - this.faded2Dgray) * this.fadedRotationLock);
    }

    internal void OnGUI(SceneView view)
    {
      if ((double) Mathf.Min(view.position.width, view.position.height) < 100.0)
        return;
      if (Event.current.type == EventType.Repaint)
        Profiler.BeginSample("SceneView.AxisSelector");
      this.HandleContextClick(view);
      Camera camera = view.camera;
      HandleUtility.PushCamera(camera);
      if (camera.orthographic)
        camera.orthographicSize = 0.5f;
      camera.cullingMask = 0;
      camera.transform.position = camera.transform.rotation * new Vector3(0.0f, 0.0f, -5f);
      camera.clearFlags = CameraClearFlags.Nothing;
      camera.nearClipPlane = 0.1f;
      camera.farClipPlane = 10f;
      camera.fieldOfView = view.m_Ortho.Fade(70f, 0.0f);
      SceneView.AddCursorRect(new Rect((float) ((double) view.position.width - 100.0 + 22.0), 22f, 56f, 102f), MouseCursor.Arrow);
      Handles.SetCamera(new Rect(view.position.width - 100f, 0.0f, 100f, 100f), camera);
      Handles.BeginGUI();
      this.DrawRotationLock(view);
      this.DrawLabels(view);
      Handles.EndGUI();
      for (int index = 0; index < 3; ++index)
      {
        Vector3 rhs = SceneViewRotation.kDirectionRotations[index] * Vector3.forward;
        this.dirVisible[index].target = (double) Mathf.Abs(Vector3.Dot(camera.transform.forward, rhs)) < 0.899999976158142;
      }
      float size = HandleUtility.GetHandleSize(Vector3.zero) * 0.2f;
      this.AxisSelectors(view, camera, size, -1f, SceneViewRotation.styles.viewAxisLabelStyle);
      Color color = Color.Lerp(Handles.centerColor, Color.gray, this.faded2Dgray);
      color.a *= this.fadedVisibility;
      if ((double) color.a <= 0.100000001490116 || view.isRotationLocked)
        GUI.enabled = false;
      Handles.color = color;
      int centerButtonControlId = this.m_CenterButtonControlID;
      Vector3 zero = Vector3.zero;
      Quaternion identity = Quaternion.identity;
      double num1 = (double) size * 0.800000011920929;
      double num2 = (double) size;
      // ISSUE: reference to a compiler-generated field
      if (SceneViewRotation.\u003C\u003Ef__mg\u0024cache2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        SceneViewRotation.\u003C\u003Ef__mg\u0024cache2 = new Handles.CapFunction(Handles.CubeHandleCap);
      }
      // ISSUE: reference to a compiler-generated field
      Handles.CapFunction fMgCache2 = SceneViewRotation.\u003C\u003Ef__mg\u0024cache2;
      if (Handles.Button(centerButtonControlId, zero, identity, (float) num1, (float) num2, fMgCache2) && !view.in2DMode && !view.isRotationLocked)
      {
        if (Event.current.clickCount == 2)
          view.FrameSelected();
        else if (Event.current.shift || Event.current.button == 2)
          this.ViewFromNiceAngle(view, true);
        else
          this.ViewSetOrtho(view, !view.orthographic);
      }
      this.AxisSelectors(view, camera, size, 1f, SceneViewRotation.styles.viewAxisLabelStyle);
      GUI.enabled = true;
      if (!view.in2DMode && !view.isRotationLocked && Event.current.type == EditorGUIUtility.swipeGestureEventType)
      {
        Event current = Event.current;
        Vector3 direction = -((double) current.delta.y <= 0.0 ? ((double) current.delta.y >= 0.0 ? ((double) current.delta.x >= 0.0 ? -Vector3.right : Vector3.right) : -Vector3.up) : Vector3.up) - Vector3.forward * 0.9f;
        Vector3 rhs = view.camera.transform.TransformDirection(direction);
        float num3 = 0.0f;
        int dir = 0;
        for (int index = 0; index < 6; ++index)
        {
          float num4 = Vector3.Dot(SceneViewRotation.kDirectionRotations[index] * -Vector3.forward, rhs);
          if ((double) num4 > (double) num3)
          {
            num3 = num4;
            dir = index;
          }
        }
        this.ViewAxisDirection(view, dir);
        Event.current.Use();
      }
      HandleUtility.PopCamera(camera);
      Handles.SetCamera(camera);
      if (Event.current.type != EventType.Repaint)
        return;
      Profiler.EndSample();
    }

    private void ViewAxisDirection(SceneView view, int dir)
    {
      bool ortho = view.orthographic;
      if (Event.current != null && (Event.current.shift || Event.current.button == 2))
        ortho = true;
      view.LookAt(view.pivot, SceneViewRotation.kDirectionRotations[dir], view.size, ortho);
      this.SwitchDirNameVisible(dir);
    }

    private void ViewSetOrtho(SceneView view, bool ortho)
    {
      view.LookAt(view.pivot, view.rotation, view.size, ortho);
    }

    internal void UpdateGizmoLabel(SceneView view, Vector3 direction, bool ortho)
    {
      this.SwitchDirNameVisible(this.GetLabelIndexForView(view, direction, ortho));
    }

    internal int GetLabelIndexForView(SceneView view, Vector3 direction, bool ortho)
    {
      if (view.in2DMode)
        return 8;
      if (this.IsAxisAligned(direction))
      {
        for (int index = 0; index < 6; ++index)
        {
          if ((double) Vector3.Dot(SceneViewRotation.kDirectionRotations[index] * Vector3.forward, direction) > 0.899999976158142)
            return index;
        }
      }
      return !ortho ? 7 : 6;
    }

    private void ViewFromNiceAngle(SceneView view, bool forcePerspective)
    {
      Vector3 forward = view.rotation * Vector3.forward;
      forward.y = 0.0f;
      forward = !(forward == Vector3.zero) ? forward.normalized : Vector3.forward;
      forward.y = -0.5f;
      bool ortho = !forcePerspective && view.orthographic;
      view.LookAt(view.pivot, Quaternion.LookRotation(forward), view.size, ortho);
      this.SwitchDirNameVisible(!ortho ? 7 : 6);
    }

    private bool IsAxisAligned(Vector3 v)
    {
      return (double) Mathf.Abs(v.x * v.y) < 9.99999974737875E-05 && (double) Mathf.Abs(v.y * v.z) < 9.99999974737875E-05 && (double) Mathf.Abs(v.z * v.x) < 9.99999974737875E-05;
    }

    private void SwitchDirNameVisible(int newVisible)
    {
      if (newVisible == this.currentDir)
        return;
      this.dirNameVisible[this.currentDir].target = false;
      this.currentDir = newVisible;
      this.dirNameVisible[this.currentDir].target = true;
      if (newVisible == 8)
        this.m_Visible.speed = 0.3f;
      else
        this.m_Visible.speed = 2f;
      this.m_Visible.target = newVisible != 8;
    }

    private class Styles
    {
      public GUIStyle viewLabelStyleLeftAligned;
      public GUIStyle viewLabelStyleCentered;
      public GUIStyle viewAxisLabelStyle;
      public GUIStyle lockStyle;
      public GUIContent unlockedRotationIcon;
      public GUIContent lockedRotationIcon;

      public Styles()
      {
        this.viewLabelStyleLeftAligned = new GUIStyle((GUIStyle) "SC ViewLabel");
        this.viewLabelStyleCentered = new GUIStyle((GUIStyle) "SC ViewLabel");
        this.unlockedRotationIcon = EditorGUIUtility.IconContent("LockIcon", "Lock Rotation|Click to lock the rotation in the current direction.");
        this.lockedRotationIcon = EditorGUIUtility.IconContent("LockIcon-On", "Lock Rotation|Click to unlock the rotation.");
        this.lockStyle = new GUIStyle((GUIStyle) "label");
        this.lockStyle.alignment = TextAnchor.MiddleCenter;
        this.viewLabelStyleLeftAligned.alignment = TextAnchor.MiddleLeft;
        this.viewLabelStyleCentered.alignment = TextAnchor.MiddleCenter;
        this.viewAxisLabelStyle = (GUIStyle) "SC ViewAxisLabel";
      }
    }
  }
}
