﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.NetworkPlayer
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>The NetworkPlayer is a data structure with which you can locate another player over the network.</para>
  /// </summary>
  [RequiredByNativeCode(Optional = true)]
  public struct NetworkPlayer
  {
    internal int index;

    public NetworkPlayer(string ip, int port)
    {
      Debug.LogError((object) "Not yet implemented");
      this.index = 0;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern string Internal_GetIPAddress(int index);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int Internal_GetPort(int index);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern string Internal_GetExternalIP();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int Internal_GetExternalPort();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern string Internal_GetLocalIP();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int Internal_GetLocalPort();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int Internal_GetPlayerIndex();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern string Internal_GetGUID(int index);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern string Internal_GetLocalGUID();

    public static bool operator ==(NetworkPlayer lhs, NetworkPlayer rhs)
    {
      return lhs.index == rhs.index;
    }

    public static bool operator !=(NetworkPlayer lhs, NetworkPlayer rhs)
    {
      return lhs.index != rhs.index;
    }

    public override int GetHashCode()
    {
      return this.index.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (!(other is NetworkPlayer))
        return false;
      return ((NetworkPlayer) other).index == this.index;
    }

    /// <summary>
    ///   <para>The IP address of this player.</para>
    /// </summary>
    public string ipAddress
    {
      get
      {
        if (this.index == NetworkPlayer.Internal_GetPlayerIndex())
          return NetworkPlayer.Internal_GetLocalIP();
        return NetworkPlayer.Internal_GetIPAddress(this.index);
      }
    }

    /// <summary>
    ///   <para>The port of this player.</para>
    /// </summary>
    public int port
    {
      get
      {
        if (this.index == NetworkPlayer.Internal_GetPlayerIndex())
          return NetworkPlayer.Internal_GetLocalPort();
        return NetworkPlayer.Internal_GetPort(this.index);
      }
    }

    /// <summary>
    ///   <para>The GUID for this player, used when connecting with NAT punchthrough.</para>
    /// </summary>
    public string guid
    {
      get
      {
        if (this.index == NetworkPlayer.Internal_GetPlayerIndex())
          return NetworkPlayer.Internal_GetLocalGUID();
        return NetworkPlayer.Internal_GetGUID(this.index);
      }
    }

    /// <summary>
    ///   <para>Returns the index number for this network player.</para>
    /// </summary>
    public override string ToString()
    {
      return this.index.ToString();
    }

    /// <summary>
    ///   <para>Returns the external IP address of the network interface.</para>
    /// </summary>
    public string externalIP
    {
      get
      {
        return NetworkPlayer.Internal_GetExternalIP();
      }
    }

    /// <summary>
    ///   <para>Returns the external port of the network interface.</para>
    /// </summary>
    public int externalPort
    {
      get
      {
        return NetworkPlayer.Internal_GetExternalPort();
      }
    }

    internal static NetworkPlayer unassigned
    {
      get
      {
        NetworkPlayer networkPlayer;
        networkPlayer.index = -1;
        return networkPlayer;
      }
    }
  }
}
