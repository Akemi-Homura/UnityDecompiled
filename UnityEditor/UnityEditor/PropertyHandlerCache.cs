﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.PropertyHandlerCache
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System.Collections.Generic;
using UnityEngine;

namespace UnityEditor
{
  internal class PropertyHandlerCache
  {
    protected Dictionary<int, PropertyHandler> m_PropertyHandlers = new Dictionary<int, PropertyHandler>();

    internal PropertyHandler GetHandler(SerializedProperty property)
    {
      PropertyHandler propertyHandler;
      if (this.m_PropertyHandlers.TryGetValue(PropertyHandlerCache.GetPropertyHash(property), out propertyHandler))
        return propertyHandler;
      return (PropertyHandler) null;
    }

    internal void SetHandler(SerializedProperty property, PropertyHandler handler)
    {
      this.m_PropertyHandlers[PropertyHandlerCache.GetPropertyHash(property)] = handler;
    }

    private static int GetPropertyHash(SerializedProperty property)
    {
      if (property.serializedObject.targetObject == (Object) null)
        return 0;
      int num = property.serializedObject.targetObject.GetInstanceID() ^ property.hashCodeForPropertyPathWithoutArrayIndex;
      if (property.propertyType == SerializedPropertyType.ObjectReference)
        num ^= property.objectReferenceInstanceIDValue;
      return num;
    }

    public void Clear()
    {
      this.m_PropertyHandlers.Clear();
    }
  }
}
