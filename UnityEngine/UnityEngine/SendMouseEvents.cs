﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.SendMouseEvents
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using UnityEngine.Scripting;

namespace UnityEngine
{
  internal class SendMouseEvents
  {
    private static bool s_MouseUsed = false;
    private static readonly SendMouseEvents.HitInfo[] m_LastHit = new SendMouseEvents.HitInfo[3]{ new SendMouseEvents.HitInfo(), new SendMouseEvents.HitInfo(), new SendMouseEvents.HitInfo() };
    private static readonly SendMouseEvents.HitInfo[] m_MouseDownHit = new SendMouseEvents.HitInfo[3]{ new SendMouseEvents.HitInfo(), new SendMouseEvents.HitInfo(), new SendMouseEvents.HitInfo() };
    private static readonly SendMouseEvents.HitInfo[] m_CurrentHit = new SendMouseEvents.HitInfo[3]{ new SendMouseEvents.HitInfo(), new SendMouseEvents.HitInfo(), new SendMouseEvents.HitInfo() };
    private const int m_HitIndexGUI = 0;
    private const int m_HitIndexPhysics3D = 1;
    private const int m_HitIndexPhysics2D = 2;
    private static Camera[] m_Cameras;

    [RequiredByNativeCode]
    private static void SetMouseMoved()
    {
      SendMouseEvents.s_MouseUsed = true;
    }

    private static void HitTestLegacyGUI(Camera camera, Vector3 mousePosition, ref SendMouseEvents.HitInfo hitInfo)
    {
      GUILayer component = camera.GetComponent<GUILayer>();
      if (!(bool) ((Object) component))
        return;
      GUIElement guiElement = component.HitTest(mousePosition);
      if ((bool) ((Object) guiElement))
      {
        hitInfo.target = guiElement.gameObject;
        hitInfo.camera = camera;
      }
      else
      {
        hitInfo.target = (GameObject) null;
        hitInfo.camera = (Camera) null;
      }
    }

    [RequiredByNativeCode]
    private static void DoSendMouseEvents(int skipRTCameras)
    {
      Vector3 mousePosition = Input.mousePosition;
      int allCamerasCount = Camera.allCamerasCount;
      if (SendMouseEvents.m_Cameras == null || SendMouseEvents.m_Cameras.Length != allCamerasCount)
        SendMouseEvents.m_Cameras = new Camera[allCamerasCount];
      Camera.GetAllCameras(SendMouseEvents.m_Cameras);
      for (int index = 0; index < SendMouseEvents.m_CurrentHit.Length; ++index)
        SendMouseEvents.m_CurrentHit[index] = new SendMouseEvents.HitInfo();
      if (!SendMouseEvents.s_MouseUsed)
      {
        foreach (Camera camera in SendMouseEvents.m_Cameras)
        {
          if (!((Object) camera == (Object) null) && (skipRTCameras == 0 || !((Object) camera.targetTexture != (Object) null)) && camera.pixelRect.Contains(mousePosition))
          {
            SendMouseEvents.HitTestLegacyGUI(camera, mousePosition, ref SendMouseEvents.m_CurrentHit[0]);
            if (camera.eventMask != 0)
            {
              Ray ray = camera.ScreenPointToRay(mousePosition);
              float z = ray.direction.z;
              float distance = !Mathf.Approximately(0.0f, z) ? Mathf.Abs((camera.farClipPlane - camera.nearClipPlane) / z) : float.PositiveInfinity;
              GameObject gameObject1 = camera.RaycastTry(ray, distance, camera.cullingMask & camera.eventMask);
              if ((Object) gameObject1 != (Object) null)
              {
                SendMouseEvents.m_CurrentHit[1].target = gameObject1;
                SendMouseEvents.m_CurrentHit[1].camera = camera;
              }
              else if (camera.clearFlags == CameraClearFlags.Skybox || camera.clearFlags == CameraClearFlags.Color)
              {
                SendMouseEvents.m_CurrentHit[1].target = (GameObject) null;
                SendMouseEvents.m_CurrentHit[1].camera = (Camera) null;
              }
              GameObject gameObject2 = camera.RaycastTry2D(ray, distance, camera.cullingMask & camera.eventMask);
              if ((Object) gameObject2 != (Object) null)
              {
                SendMouseEvents.m_CurrentHit[2].target = gameObject2;
                SendMouseEvents.m_CurrentHit[2].camera = camera;
              }
              else if (camera.clearFlags == CameraClearFlags.Skybox || camera.clearFlags == CameraClearFlags.Color)
              {
                SendMouseEvents.m_CurrentHit[2].target = (GameObject) null;
                SendMouseEvents.m_CurrentHit[2].camera = (Camera) null;
              }
            }
          }
        }
      }
      for (int i = 0; i < SendMouseEvents.m_CurrentHit.Length; ++i)
        SendMouseEvents.SendEvents(i, SendMouseEvents.m_CurrentHit[i]);
      SendMouseEvents.s_MouseUsed = false;
    }

    private static void SendEvents(int i, SendMouseEvents.HitInfo hit)
    {
      bool mouseButtonDown = Input.GetMouseButtonDown(0);
      bool mouseButton = Input.GetMouseButton(0);
      if (mouseButtonDown)
      {
        if ((bool) hit)
        {
          SendMouseEvents.m_MouseDownHit[i] = hit;
          SendMouseEvents.m_MouseDownHit[i].SendMessage("OnMouseDown");
        }
      }
      else if (!mouseButton)
      {
        if ((bool) SendMouseEvents.m_MouseDownHit[i])
        {
          if (SendMouseEvents.HitInfo.Compare(hit, SendMouseEvents.m_MouseDownHit[i]))
            SendMouseEvents.m_MouseDownHit[i].SendMessage("OnMouseUpAsButton");
          SendMouseEvents.m_MouseDownHit[i].SendMessage("OnMouseUp");
          SendMouseEvents.m_MouseDownHit[i] = new SendMouseEvents.HitInfo();
        }
      }
      else if ((bool) SendMouseEvents.m_MouseDownHit[i])
        SendMouseEvents.m_MouseDownHit[i].SendMessage("OnMouseDrag");
      if (SendMouseEvents.HitInfo.Compare(hit, SendMouseEvents.m_LastHit[i]))
      {
        if ((bool) hit)
          hit.SendMessage("OnMouseOver");
      }
      else
      {
        if ((bool) SendMouseEvents.m_LastHit[i])
          SendMouseEvents.m_LastHit[i].SendMessage("OnMouseExit");
        if ((bool) hit)
        {
          hit.SendMessage("OnMouseEnter");
          hit.SendMessage("OnMouseOver");
        }
      }
      SendMouseEvents.m_LastHit[i] = hit;
    }

    private struct HitInfo
    {
      public GameObject target;
      public Camera camera;

      public void SendMessage(string name)
      {
        this.target.SendMessage(name, (object) null, SendMessageOptions.DontRequireReceiver);
      }

      public static implicit operator bool(SendMouseEvents.HitInfo exists)
      {
        return (Object) exists.target != (Object) null && (Object) exists.camera != (Object) null;
      }

      public static bool Compare(SendMouseEvents.HitInfo lhs, SendMouseEvents.HitInfo rhs)
      {
        return (Object) lhs.target == (Object) rhs.target && (Object) lhs.camera == (Object) rhs.camera;
      }
    }
  }
}
