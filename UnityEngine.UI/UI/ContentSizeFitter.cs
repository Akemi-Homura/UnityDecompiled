﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.ContentSizeFitter
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 95F4B50A-137D-4022-9C58-045B696814A0
// Assembly location: C:\Program Files\Unity 5\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

using System;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
  /// <summary>
  ///   <para>Resizes a RectTransform to fit the size of its content.</para>
  /// </summary>
  [AddComponentMenu("Layout/Content Size Fitter", 141)]
  [ExecuteInEditMode]
  [RequireComponent(typeof (RectTransform))]
  public class ContentSizeFitter : UIBehaviour, ILayoutSelfController, ILayoutController
  {
    [SerializeField]
    protected ContentSizeFitter.FitMode m_HorizontalFit = ContentSizeFitter.FitMode.Unconstrained;
    [SerializeField]
    protected ContentSizeFitter.FitMode m_VerticalFit = ContentSizeFitter.FitMode.Unconstrained;
    [NonSerialized]
    private RectTransform m_Rect;
    private DrivenRectTransformTracker m_Tracker;

    protected ContentSizeFitter()
    {
    }

    /// <summary>
    ///   <para>The fit mode to use to determine the width.</para>
    /// </summary>
    public ContentSizeFitter.FitMode horizontalFit
    {
      get
      {
        return this.m_HorizontalFit;
      }
      set
      {
        if (!SetPropertyUtility.SetStruct<ContentSizeFitter.FitMode>(ref this.m_HorizontalFit, value))
          return;
        this.SetDirty();
      }
    }

    /// <summary>
    ///   <para>The fit mode to use to determine the height.</para>
    /// </summary>
    public ContentSizeFitter.FitMode verticalFit
    {
      get
      {
        return this.m_VerticalFit;
      }
      set
      {
        if (!SetPropertyUtility.SetStruct<ContentSizeFitter.FitMode>(ref this.m_VerticalFit, value))
          return;
        this.SetDirty();
      }
    }

    private RectTransform rectTransform
    {
      get
      {
        if ((UnityEngine.Object) this.m_Rect == (UnityEngine.Object) null)
          this.m_Rect = this.GetComponent<RectTransform>();
        return this.m_Rect;
      }
    }

    protected override void OnEnable()
    {
      base.OnEnable();
      this.SetDirty();
    }

    /// <summary>
    ///   <para>See MonoBehaviour.OnDisable.</para>
    /// </summary>
    protected override void OnDisable()
    {
      this.m_Tracker.Clear();
      LayoutRebuilder.MarkLayoutForRebuild(this.rectTransform);
      base.OnDisable();
    }

    protected override void OnRectTransformDimensionsChange()
    {
      this.SetDirty();
    }

    private void HandleSelfFittingAlongAxis(int axis)
    {
      ContentSizeFitter.FitMode fitMode = axis != 0 ? this.verticalFit : this.horizontalFit;
      if (fitMode == ContentSizeFitter.FitMode.Unconstrained)
      {
        this.m_Tracker.Add((UnityEngine.Object) this, this.rectTransform, DrivenTransformProperties.None);
      }
      else
      {
        this.m_Tracker.Add((UnityEngine.Object) this, this.rectTransform, axis != 0 ? DrivenTransformProperties.SizeDeltaY : DrivenTransformProperties.SizeDeltaX);
        if (fitMode == ContentSizeFitter.FitMode.MinSize)
          this.rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) axis, LayoutUtility.GetMinSize(this.m_Rect, axis));
        else
          this.rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) axis, LayoutUtility.GetPreferredSize(this.m_Rect, axis));
      }
    }

    /// <summary>
    ///   <para>Method called by the layout system.</para>
    /// </summary>
    public virtual void SetLayoutHorizontal()
    {
      this.m_Tracker.Clear();
      this.HandleSelfFittingAlongAxis(0);
    }

    /// <summary>
    ///   <para>Method called by the layout system.</para>
    /// </summary>
    public virtual void SetLayoutVertical()
    {
      this.HandleSelfFittingAlongAxis(1);
    }

    /// <summary>
    ///   <para>Mark the ContentSizeFitter as dirty.</para>
    /// </summary>
    protected void SetDirty()
    {
      if (!this.IsActive())
        return;
      LayoutRebuilder.MarkLayoutForRebuild(this.rectTransform);
    }

    protected override void OnValidate()
    {
      this.SetDirty();
    }

    /// <summary>
    ///   <para>The size fit mode to use.</para>
    /// </summary>
    public enum FitMode
    {
      Unconstrained,
      MinSize,
      PreferredSize,
    }
  }
}
