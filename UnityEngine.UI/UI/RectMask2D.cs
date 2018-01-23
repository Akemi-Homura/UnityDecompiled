﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.RectMask2D
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 95F4B50A-137D-4022-9C58-045B696814A0
// Assembly location: C:\Program Files\Unity 5\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
  /// <summary>
  ///   <para>A 2D rectangular mask that allows for clipping / masking of areas outside the mask.</para>
  /// </summary>
  [AddComponentMenu("UI/Rect Mask 2D", 13)]
  [ExecuteInEditMode]
  [DisallowMultipleComponent]
  [RequireComponent(typeof (RectTransform))]
  public class RectMask2D : UIBehaviour, IClipper, ICanvasRaycastFilter
  {
    [NonSerialized]
    private readonly RectangularVertexClipper m_VertexClipper = new RectangularVertexClipper();
    [NonSerialized]
    private HashSet<IClippable> m_ClipTargets = new HashSet<IClippable>();
    [NonSerialized]
    private List<RectMask2D> m_Clippers = new List<RectMask2D>();
    [NonSerialized]
    private RectTransform m_RectTransform;
    [NonSerialized]
    private bool m_ShouldRecalculateClipRects;
    [NonSerialized]
    private Rect m_LastClipRectCanvasSpace;
    [NonSerialized]
    private bool m_LastValidClipRect;
    [NonSerialized]
    private bool m_ForceClip;

    protected RectMask2D()
    {
    }

    /// <summary>
    ///   <para>Get the Rect for the mask in canvas space.</para>
    /// </summary>
    public Rect canvasRect
    {
      get
      {
        Canvas c = (Canvas) null;
        List<Canvas> canvasList = ListPool<Canvas>.Get();
        this.gameObject.GetComponentsInParent<Canvas>(false, canvasList);
        if (canvasList.Count > 0)
          c = canvasList[canvasList.Count - 1];
        ListPool<Canvas>.Release(canvasList);
        return this.m_VertexClipper.GetCanvasRect(this.rectTransform, c);
      }
    }

    /// <summary>
    ///   <para>Get the RectTransform for the mask.</para>
    /// </summary>
    public RectTransform rectTransform
    {
      get
      {
        return this.m_RectTransform ?? (this.m_RectTransform = this.GetComponent<RectTransform>());
      }
    }

    protected override void OnEnable()
    {
      base.OnEnable();
      this.m_ShouldRecalculateClipRects = true;
      ClipperRegistry.Register((IClipper) this);
      MaskUtilities.Notify2DMaskStateChanged((Component) this);
    }

    protected override void OnDisable()
    {
      base.OnDisable();
      this.m_ClipTargets.Clear();
      this.m_Clippers.Clear();
      ClipperRegistry.Unregister((IClipper) this);
      MaskUtilities.Notify2DMaskStateChanged((Component) this);
    }

    protected override void OnValidate()
    {
      base.OnValidate();
      this.m_ShouldRecalculateClipRects = true;
      if (!this.IsActive())
        return;
      MaskUtilities.Notify2DMaskStateChanged((Component) this);
    }

    /// <summary>
    ///   <para>See:ICanvasRaycastFilter.</para>
    /// </summary>
    /// <param name="sp"></param>
    /// <param name="eventCamera"></param>
    public virtual bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
      if (!this.isActiveAndEnabled)
        return true;
      return RectTransformUtility.RectangleContainsScreenPoint(this.rectTransform, sp, eventCamera);
    }

    /// <summary>
    ///   <para>See: IClipper.PerformClipping.</para>
    /// </summary>
    public virtual void PerformClipping()
    {
      if (this.m_ShouldRecalculateClipRects)
      {
        MaskUtilities.GetRectMasksForClip(this, this.m_Clippers);
        this.m_ShouldRecalculateClipRects = false;
      }
      bool validRect = true;
      Rect andClipWorldRect = Clipping.FindCullAndClipWorldRect(this.m_Clippers, out validRect);
      bool flag = andClipWorldRect != this.m_LastClipRectCanvasSpace;
      if (flag || this.m_ForceClip)
      {
        foreach (IClippable clipTarget in this.m_ClipTargets)
          clipTarget.SetClipRect(andClipWorldRect, validRect);
        this.m_LastClipRectCanvasSpace = andClipWorldRect;
        this.m_LastValidClipRect = validRect;
      }
      foreach (IClippable clipTarget in this.m_ClipTargets)
      {
        MaskableGraphic maskableGraphic = clipTarget as MaskableGraphic;
        if (!((UnityEngine.Object) maskableGraphic != (UnityEngine.Object) null) || maskableGraphic.canvasRenderer.hasMoved || flag)
          clipTarget.Cull(this.m_LastClipRectCanvasSpace, this.m_LastValidClipRect);
      }
    }

    /// <summary>
    ///   <para>Add a [IClippable]] to be tracked by the mask.</para>
    /// </summary>
    /// <param name="clippable"></param>
    public void AddClippable(IClippable clippable)
    {
      if (clippable == null)
        return;
      this.m_ShouldRecalculateClipRects = true;
      if (!this.m_ClipTargets.Contains(clippable))
        this.m_ClipTargets.Add(clippable);
      this.m_ForceClip = true;
    }

    /// <summary>
    ///   <para>Remove an IClippable from being tracked by the mask.</para>
    /// </summary>
    /// <param name="clippable"></param>
    public void RemoveClippable(IClippable clippable)
    {
      if (clippable == null)
        return;
      this.m_ShouldRecalculateClipRects = true;
      clippable.SetClipRect(new Rect(), false);
      this.m_ClipTargets.Remove(clippable);
      this.m_ForceClip = true;
    }

    protected override void OnTransformParentChanged()
    {
      base.OnTransformParentChanged();
      this.m_ShouldRecalculateClipRects = true;
    }

    protected override void OnCanvasHierarchyChanged()
    {
      base.OnCanvasHierarchyChanged();
      this.m_ShouldRecalculateClipRects = true;
    }
  }
}
