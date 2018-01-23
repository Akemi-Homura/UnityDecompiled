﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.BaseMeshEffect
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 95F4B50A-137D-4022-9C58-045B696814A0
// Assembly location: C:\Program Files\Unity 5\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

using System;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
  /// <summary>
  ///   <para>Base class for effects that modify the generated Mesh.</para>
  /// </summary>
  [ExecuteInEditMode]
  public abstract class BaseMeshEffect : UIBehaviour, IMeshModifier
  {
    [NonSerialized]
    private Graphic m_Graphic;

    protected Graphic graphic
    {
      get
      {
        if ((UnityEngine.Object) this.m_Graphic == (UnityEngine.Object) null)
          this.m_Graphic = this.GetComponent<Graphic>();
        return this.m_Graphic;
      }
    }

    protected override void OnEnable()
    {
      base.OnEnable();
      if (!((UnityEngine.Object) this.graphic != (UnityEngine.Object) null))
        return;
      this.graphic.SetVerticesDirty();
    }

    /// <summary>
    ///   <para>See MonoBehaviour.OnDisable.</para>
    /// </summary>
    protected override void OnDisable()
    {
      if ((UnityEngine.Object) this.graphic != (UnityEngine.Object) null)
        this.graphic.SetVerticesDirty();
      base.OnDisable();
    }

    protected override void OnDidApplyAnimationProperties()
    {
      if ((UnityEngine.Object) this.graphic != (UnityEngine.Object) null)
        this.graphic.SetVerticesDirty();
      base.OnDidApplyAnimationProperties();
    }

    protected override void OnValidate()
    {
      base.OnValidate();
      if (!((UnityEngine.Object) this.graphic != (UnityEngine.Object) null))
        return;
      this.graphic.SetVerticesDirty();
    }

    /// <summary>
    ///   <para>See:IMeshModifier.</para>
    /// </summary>
    /// <param name="mesh"></param>
    public virtual void ModifyMesh(Mesh mesh)
    {
      using (VertexHelper vh = new VertexHelper(mesh))
      {
        this.ModifyMesh(vh);
        vh.FillMesh(mesh);
      }
    }

    public abstract void ModifyMesh(VertexHelper vh);
  }
}
