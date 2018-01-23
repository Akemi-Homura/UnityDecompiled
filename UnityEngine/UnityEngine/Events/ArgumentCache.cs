﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.Events.ArgumentCache
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System;
using UnityEngine.Serialization;

namespace UnityEngine.Events
{
  [Serializable]
  internal class ArgumentCache : ISerializationCallbackReceiver
  {
    [FormerlySerializedAs("objectArgument")]
    [SerializeField]
    private UnityEngine.Object m_ObjectArgument;
    [FormerlySerializedAs("objectArgumentAssemblyTypeName")]
    [SerializeField]
    private string m_ObjectArgumentAssemblyTypeName;
    [FormerlySerializedAs("intArgument")]
    [SerializeField]
    private int m_IntArgument;
    [FormerlySerializedAs("floatArgument")]
    [SerializeField]
    private float m_FloatArgument;
    [FormerlySerializedAs("stringArgument")]
    [SerializeField]
    private string m_StringArgument;
    [SerializeField]
    private bool m_BoolArgument;

    public UnityEngine.Object unityObjectArgument
    {
      get
      {
        return this.m_ObjectArgument;
      }
      set
      {
        this.m_ObjectArgument = value;
        this.m_ObjectArgumentAssemblyTypeName = !(value != (UnityEngine.Object) null) ? string.Empty : value.GetType().AssemblyQualifiedName;
      }
    }

    public string unityObjectArgumentAssemblyTypeName
    {
      get
      {
        return this.m_ObjectArgumentAssemblyTypeName;
      }
    }

    public int intArgument
    {
      get
      {
        return this.m_IntArgument;
      }
      set
      {
        this.m_IntArgument = value;
      }
    }

    public float floatArgument
    {
      get
      {
        return this.m_FloatArgument;
      }
      set
      {
        this.m_FloatArgument = value;
      }
    }

    public string stringArgument
    {
      get
      {
        return this.m_StringArgument;
      }
      set
      {
        this.m_StringArgument = value;
      }
    }

    public bool boolArgument
    {
      get
      {
        return this.m_BoolArgument;
      }
      set
      {
        this.m_BoolArgument = value;
      }
    }

    private void TidyAssemblyTypeName()
    {
      if (string.IsNullOrEmpty(this.m_ObjectArgumentAssemblyTypeName))
        return;
      int num = int.MaxValue;
      int val1_1 = this.m_ObjectArgumentAssemblyTypeName.IndexOf(", Version=");
      if (val1_1 != -1)
        num = Math.Min(val1_1, num);
      int val1_2 = this.m_ObjectArgumentAssemblyTypeName.IndexOf(", Culture=");
      if (val1_2 != -1)
        num = Math.Min(val1_2, num);
      int val1_3 = this.m_ObjectArgumentAssemblyTypeName.IndexOf(", PublicKeyToken=");
      if (val1_3 != -1)
        num = Math.Min(val1_3, num);
      if (num != int.MaxValue)
        this.m_ObjectArgumentAssemblyTypeName = this.m_ObjectArgumentAssemblyTypeName.Substring(0, num);
      int length = this.m_ObjectArgumentAssemblyTypeName.IndexOf(", UnityEngine.");
      if (length == -1 || !this.m_ObjectArgumentAssemblyTypeName.EndsWith("Module"))
        return;
      this.m_ObjectArgumentAssemblyTypeName = this.m_ObjectArgumentAssemblyTypeName.Substring(0, length) + ", UnityEngine";
    }

    public void OnBeforeSerialize()
    {
      this.TidyAssemblyTypeName();
    }

    public void OnAfterDeserialize()
    {
      this.TidyAssemblyTypeName();
    }
  }
}
