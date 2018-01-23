﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.EventSystems.BaseRaycaster
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 95F4B50A-137D-4022-9C58-045B696814A0
// Assembly location: C:\Program Files\Unity 5\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

using System;
using System.Collections.Generic;

namespace UnityEngine.EventSystems
{
  /// <summary>
  ///   <para>Base class for any RayCaster.</para>
  /// </summary>
  public abstract class BaseRaycaster : UIBehaviour
  {
    public abstract void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList);

    /// <summary>
    ///   <para>The camera that will generate rays for this raycaster.</para>
    /// </summary>
    public abstract Camera eventCamera { get; }

    /// <summary>
    ///   <para>Priority of the caster relative to other casters.</para>
    /// </summary>
    [Obsolete("Please use sortOrderPriority and renderOrderPriority", false)]
    public virtual int priority
    {
      get
      {
        return 0;
      }
    }

    /// <summary>
    ///   <para>Priority of the raycaster based upon sort order.</para>
    /// </summary>
    public virtual int sortOrderPriority
    {
      get
      {
        return int.MinValue;
      }
    }

    /// <summary>
    ///   <para>Priority of the raycaster based upon render order.</para>
    /// </summary>
    public virtual int renderOrderPriority
    {
      get
      {
        return int.MinValue;
      }
    }

    public override string ToString()
    {
      return "Name: " + (object) this.gameObject + "\neventCamera: " + (object) this.eventCamera + "\nsortOrderPriority: " + (object) this.sortOrderPriority + "\nrenderOrderPriority: " + (object) this.renderOrderPriority;
    }

    protected override void OnEnable()
    {
      base.OnEnable();
      RaycasterManager.AddRaycaster(this);
    }

    /// <summary>
    ///   <para>See MonoBehaviour.OnDisable.</para>
    /// </summary>
    protected override void OnDisable()
    {
      RaycasterManager.RemoveRaycasters(this);
      base.OnDisable();
    }
  }
}
