﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.NetworkViewID
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>The NetworkViewID is a unique identifier for a network view instance in a multiplayer game.</para>
  /// </summary>
  [RequiredByNativeCode(Optional = true)]
  public struct NetworkViewID
  {
    private int a;
    private int b;
    private int c;

    /// <summary>
    ///   <para>Represents an invalid network view ID.</para>
    /// </summary>
    public static NetworkViewID unassigned
    {
      get
      {
        NetworkViewID networkViewId;
        NetworkViewID.INTERNAL_get_unassigned(out networkViewId);
        return networkViewId;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_get_unassigned(out NetworkViewID value);

    internal static bool Internal_IsMine(NetworkViewID value)
    {
      return NetworkViewID.INTERNAL_CALL_Internal_IsMine(ref value);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool INTERNAL_CALL_Internal_IsMine(ref NetworkViewID value);

    internal static void Internal_GetOwner(NetworkViewID value, out NetworkPlayer player)
    {
      NetworkViewID.INTERNAL_CALL_Internal_GetOwner(ref value, out player);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_Internal_GetOwner(ref NetworkViewID value, out NetworkPlayer player);

    internal static string Internal_GetString(NetworkViewID value)
    {
      return NetworkViewID.INTERNAL_CALL_Internal_GetString(ref value);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern string INTERNAL_CALL_Internal_GetString(ref NetworkViewID value);

    internal static bool Internal_Compare(NetworkViewID lhs, NetworkViewID rhs)
    {
      return NetworkViewID.INTERNAL_CALL_Internal_Compare(ref lhs, ref rhs);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool INTERNAL_CALL_Internal_Compare(ref NetworkViewID lhs, ref NetworkViewID rhs);

    public static bool operator ==(NetworkViewID lhs, NetworkViewID rhs)
    {
      return NetworkViewID.Internal_Compare(lhs, rhs);
    }

    public static bool operator !=(NetworkViewID lhs, NetworkViewID rhs)
    {
      return !NetworkViewID.Internal_Compare(lhs, rhs);
    }

    public override int GetHashCode()
    {
      return this.a ^ this.b ^ this.c;
    }

    public override bool Equals(object other)
    {
      if (!(other is NetworkViewID))
        return false;
      return NetworkViewID.Internal_Compare(this, (NetworkViewID) other);
    }

    /// <summary>
    ///   <para>True if instantiated by me.</para>
    /// </summary>
    public bool isMine
    {
      get
      {
        return NetworkViewID.Internal_IsMine(this);
      }
    }

    /// <summary>
    ///   <para>The NetworkPlayer who owns the NetworkView. Could be the server.</para>
    /// </summary>
    public NetworkPlayer owner
    {
      get
      {
        NetworkPlayer player;
        NetworkViewID.Internal_GetOwner(this, out player);
        return player;
      }
    }

    /// <summary>
    ///   <para>Returns a formatted string with details on this NetworkViewID.</para>
    /// </summary>
    public override string ToString()
    {
      return NetworkViewID.Internal_GetString(this);
    }
  }
}
