﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.RectangularVertexClipper
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 95F4B50A-137D-4022-9C58-045B696814A0
// Assembly location: C:\Program Files\Unity 5\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

namespace UnityEngine.UI
{
  internal class RectangularVertexClipper
  {
    private readonly Vector3[] m_WorldCorners = new Vector3[4];
    private readonly Vector3[] m_CanvasCorners = new Vector3[4];

    public Rect GetCanvasRect(RectTransform t, Canvas c)
    {
      if ((Object) c == (Object) null)
        return new Rect();
      t.GetWorldCorners(this.m_WorldCorners);
      Transform component = c.GetComponent<Transform>();
      for (int index = 0; index < 4; ++index)
        this.m_CanvasCorners[index] = component.InverseTransformPoint(this.m_WorldCorners[index]);
      return new Rect(this.m_CanvasCorners[0].x, this.m_CanvasCorners[0].y, this.m_CanvasCorners[2].x - this.m_CanvasCorners[0].x, this.m_CanvasCorners[2].y - this.m_CanvasCorners[0].y);
    }
  }
}
