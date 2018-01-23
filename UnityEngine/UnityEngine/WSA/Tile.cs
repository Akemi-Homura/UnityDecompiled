﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.WSA.Tile
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

namespace UnityEngine.WSA
{
  /// <summary>
  ///         <para>Represents tile on Windows start screen
  /// </para>
  ///       </summary>
  public sealed class Tile
  {
    private string m_TileId;
    private static Tile s_MainTile;

    private Tile(string tileId)
    {
      this.m_TileId = tileId;
    }

    /// <summary>
    ///         <para>Returns applications main tile
    /// </para>
    ///       </summary>
    public static Tile main
    {
      get
      {
        if (Tile.s_MainTile == null)
          Tile.s_MainTile = new Tile("");
        return Tile.s_MainTile;
      }
    }

    /// <summary>
    ///   <para>Get template XML for tile notification.</para>
    /// </summary>
    /// <param name="templ">A template identifier.</param>
    /// <returns>
    ///   <para>String, which is an empty XML document to be filled and used for tile notification.</para>
    /// </returns>
    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetTemplate(TileTemplate templ);

    /// <summary>
    ///   <para>Send a notification for tile (update tiles look).</para>
    /// </summary>
    /// <param name="xml">A string containing XML document for new tile look.</param>
    /// <param name="medium">An uri to 150x150 image, shown on medium tile.</param>
    /// <param name="wide">An uri to a 310x150 image to be shown on a wide tile (if such issupported).</param>
    /// <param name="large">An uri to a 310x310 image to be shown on a large tile (if such is supported).</param>
    /// <param name="text">A text to shown on a tile.</param>
    public void Update(string xml)
    {
      Tile.Update(this.m_TileId, xml);
    }

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Update(string tileId, string xml);

    /// <summary>
    ///   <para>Send a notification for tile (update tiles look).</para>
    /// </summary>
    /// <param name="xml">A string containing XML document for new tile look.</param>
    /// <param name="medium">An uri to 150x150 image, shown on medium tile.</param>
    /// <param name="wide">An uri to a 310x150 image to be shown on a wide tile (if such issupported).</param>
    /// <param name="large">An uri to a 310x310 image to be shown on a large tile (if such is supported).</param>
    /// <param name="text">A text to shown on a tile.</param>
    public void Update(string medium, string wide, string large, string text)
    {
      Tile.UpdateImageAndText(this.m_TileId, medium, wide, large, text);
    }

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void UpdateImageAndText(string tileId, string medium, string wide, string large, string text);

    /// <summary>
    ///         <para>Starts periodic update of a tile.
    /// </para>
    ///       </summary>
    /// <param name="uri">a remote location fromwhere to retrieve tile update</param>
    /// <param name="interval">a time interval in minutes, will be rounded to a value, supported by the system</param>
    public void PeriodicUpdate(string uri, float interval)
    {
      Tile.PeriodicUpdate(this.m_TileId, uri, interval);
    }

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void PeriodicUpdate(string tileId, string uri, float interval);

    /// <summary>
    ///   <para>Stops previously started periodic update of a tile.</para>
    /// </summary>
    public void StopPeriodicUpdate()
    {
      Tile.StopPeriodicUpdate(this.m_TileId);
    }

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void StopPeriodicUpdate(string tileId);

    /// <summary>
    ///   <para>Sets or updates badge on a tile to an image.</para>
    /// </summary>
    /// <param name="image">Image identifier.</param>
    public void UpdateBadgeImage(string image)
    {
      Tile.UpdateBadgeImage(this.m_TileId, image);
    }

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void UpdateBadgeImage(string tileId, string image);

    /// <summary>
    ///   <para>Set or update a badge on a tile to a number.</para>
    /// </summary>
    /// <param name="number">Number to be shown on a badge.</param>
    public void UpdateBadgeNumber(float number)
    {
      Tile.UpdateBadgeNumber(this.m_TileId, number);
    }

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void UpdateBadgeNumber(string tileId, float number);

    /// <summary>
    ///   <para>Remove badge from tile.</para>
    /// </summary>
    public void RemoveBadge()
    {
      Tile.RemoveBadge(this.m_TileId);
    }

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void RemoveBadge(string tileId);

    /// <summary>
    ///         <para>Starts periodic update of a  badge on a tile.
    /// </para>
    ///       </summary>
    /// <param name="uri">A remote location from where to retrieve tile update</param>
    /// <param name="interval">A time interval in minutes, will be rounded to a value, supported by the system</param>
    public void PeriodicBadgeUpdate(string uri, float interval)
    {
      Tile.PeriodicBadgeUpdate(this.m_TileId, uri, interval);
    }

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void PeriodicBadgeUpdate(string tileId, string uri, float interval);

    /// <summary>
    ///   <para>Stops previously started periodic update of a tile.</para>
    /// </summary>
    public void StopPeriodicBadgeUpdate()
    {
      Tile.StopPeriodicBadgeUpdate(this.m_TileId);
    }

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void StopPeriodicBadgeUpdate(string tileId);

    /// <summary>
    ///   <para>A unique string, identifying secondary tile</para>
    /// </summary>
    public string id
    {
      get
      {
        return this.m_TileId;
      }
    }

    /// <summary>
    ///         <para>Whether secondary tile was approved (pinned to start screen) or rejected by user.
    /// </para>
    ///       </summary>
    public bool hasUserConsent
    {
      get
      {
        return Tile.HasUserConsent(this.m_TileId);
      }
    }

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool HasUserConsent(string tileId);

    /// <summary>
    ///         <para>Whether secondary tile is pinned to start screen.
    /// </para>
    ///       </summary>
    public bool exists
    {
      get
      {
        return Tile.Exists(this.m_TileId);
      }
    }

    /// <summary>
    ///   <para>Whether secondary tile is pinned to start screen.</para>
    /// </summary>
    /// <param name="tileId">An identifier for secondary tile.</param>
    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool Exists(string tileId);

    private static string[] MakeSecondaryTileSargs(SecondaryTileData data)
    {
      return new string[10]{ data.arguments, data.displayName, data.lockScreenBadgeLogo, data.phoneticName, data.square150x150Logo, data.square30x30Logo, data.square310x310Logo, data.square70x70Logo, data.tileId, data.wide310x150Logo };
    }

    private static bool[] MakeSecondaryTileBargs(SecondaryTileData data)
    {
      return new bool[6]{ data.backgroundColorSet, data.lockScreenDisplayBadgeAndTileText, data.roamingEnabled, data.showNameOnSquare150x150Logo, data.showNameOnSquare310x310Logo, data.showNameOnWide310x150Logo };
    }

    /// <summary>
    ///   <para>Creates new or updates existing secondary tile.</para>
    /// </summary>
    /// <param name="data">The data used to create or update secondary tile.</param>
    /// <param name="pos">The coordinates for a request to create new tile.</param>
    /// <param name="area">The area on the screen above which the request to create new tile will be displayed.</param>
    /// <returns>
    ///   <para>New Tile object, that can be used for further work with the tile.</para>
    /// </returns>
    public static Tile CreateOrUpdateSecondary(SecondaryTileData data)
    {
      string[] sargs = Tile.MakeSecondaryTileSargs(data);
      bool[] bargs = Tile.MakeSecondaryTileBargs(data);
      Color32 backgroundColor = data.backgroundColor;
      string updateSecondaryTile = Tile.CreateOrUpdateSecondaryTile(sargs, bargs, ref backgroundColor, (int) data.foregroundText);
      if (string.IsNullOrEmpty(updateSecondaryTile))
        return (Tile) null;
      return new Tile(updateSecondaryTile);
    }

    [ThreadAndSerializationSafe]
    private static string CreateOrUpdateSecondaryTile(string[] sargs, bool[] bargs, ref Color32 backgroundColor, int foregroundText)
    {
      return Tile.INTERNAL_CALL_CreateOrUpdateSecondaryTile(sargs, bargs, ref backgroundColor, foregroundText);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern string INTERNAL_CALL_CreateOrUpdateSecondaryTile(string[] sargs, bool[] bargs, ref Color32 backgroundColor, int foregroundText);

    /// <summary>
    ///   <para>Creates new or updates existing secondary tile.</para>
    /// </summary>
    /// <param name="data">The data used to create or update secondary tile.</param>
    /// <param name="pos">The coordinates for a request to create new tile.</param>
    /// <param name="area">The area on the screen above which the request to create new tile will be displayed.</param>
    /// <returns>
    ///   <para>New Tile object, that can be used for further work with the tile.</para>
    /// </returns>
    public static Tile CreateOrUpdateSecondary(SecondaryTileData data, Vector2 pos)
    {
      string[] sargs = Tile.MakeSecondaryTileSargs(data);
      bool[] bargs = Tile.MakeSecondaryTileBargs(data);
      Color32 backgroundColor = data.backgroundColor;
      string secondaryTilePoint = Tile.CreateOrUpdateSecondaryTilePoint(sargs, bargs, ref backgroundColor, (int) data.foregroundText, pos);
      if (string.IsNullOrEmpty(secondaryTilePoint))
        return (Tile) null;
      return new Tile(secondaryTilePoint);
    }

    [ThreadAndSerializationSafe]
    private static string CreateOrUpdateSecondaryTilePoint(string[] sargs, bool[] bargs, ref Color32 backgroundColor, int foregroundText, Vector2 pos)
    {
      return Tile.INTERNAL_CALL_CreateOrUpdateSecondaryTilePoint(sargs, bargs, ref backgroundColor, foregroundText, ref pos);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern string INTERNAL_CALL_CreateOrUpdateSecondaryTilePoint(string[] sargs, bool[] bargs, ref Color32 backgroundColor, int foregroundText, ref Vector2 pos);

    /// <summary>
    ///   <para>Creates new or updates existing secondary tile.</para>
    /// </summary>
    /// <param name="data">The data used to create or update secondary tile.</param>
    /// <param name="pos">The coordinates for a request to create new tile.</param>
    /// <param name="area">The area on the screen above which the request to create new tile will be displayed.</param>
    /// <returns>
    ///   <para>New Tile object, that can be used for further work with the tile.</para>
    /// </returns>
    public static Tile CreateOrUpdateSecondary(SecondaryTileData data, Rect area)
    {
      string[] sargs = Tile.MakeSecondaryTileSargs(data);
      bool[] bargs = Tile.MakeSecondaryTileBargs(data);
      Color32 backgroundColor = data.backgroundColor;
      string secondaryTileArea = Tile.CreateOrUpdateSecondaryTileArea(sargs, bargs, ref backgroundColor, (int) data.foregroundText, area);
      if (string.IsNullOrEmpty(secondaryTileArea))
        return (Tile) null;
      return new Tile(secondaryTileArea);
    }

    [ThreadAndSerializationSafe]
    private static string CreateOrUpdateSecondaryTileArea(string[] sargs, bool[] bargs, ref Color32 backgroundColor, int foregroundText, Rect area)
    {
      return Tile.INTERNAL_CALL_CreateOrUpdateSecondaryTileArea(sargs, bargs, ref backgroundColor, foregroundText, ref area);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern string INTERNAL_CALL_CreateOrUpdateSecondaryTileArea(string[] sargs, bool[] bargs, ref Color32 backgroundColor, int foregroundText, ref Rect area);

    /// <summary>
    ///   <para>Returns the secondary tile, identified by tile id.</para>
    /// </summary>
    /// <param name="tileId">A tile identifier.</param>
    /// <returns>
    ///   <para>A Tile object or null if secondary tile does not exist (not pinned to start screen and user request is complete).</para>
    /// </returns>
    public static Tile GetSecondary(string tileId)
    {
      if (Tile.Exists(tileId))
        return new Tile(tileId);
      return (Tile) null;
    }

    /// <summary>
    ///   <para>Gets all secondary tiles.</para>
    /// </summary>
    /// <returns>
    ///   <para>An array of Tile objects.</para>
    /// </returns>
    public static Tile[] GetSecondaries()
    {
      string[] allSecondaryTiles = Tile.GetAllSecondaryTiles();
      Tile[] tileArray = new Tile[allSecondaryTiles.Length];
      for (int index = 0; index < allSecondaryTiles.Length; ++index)
        tileArray[index] = new Tile(allSecondaryTiles[index]);
      return tileArray;
    }

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern string[] GetAllSecondaryTiles();

    /// <summary>
    ///   <para>Show a request to unpin secondary tile from start screen.</para>
    /// </summary>
    /// <param name="pos">The coordinates for a request to unpin tile.</param>
    /// <param name="area">The area on the screen above which the request to unpin tile will be displayed.</param>
    public void Delete()
    {
      Tile.DeleteSecondary(this.m_TileId);
    }

    /// <summary>
    ///   <para>Show a request to unpin secondary tile from start screen.</para>
    /// </summary>
    /// <param name="tileId">An identifier for secondary tile.</param>
    /// <param name="pos">The coordinates for a request to unpin tile.</param>
    /// <param name="area">The area on the screen above which the request to unpin tile will be displayed.</param>
    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void DeleteSecondary(string tileId);

    /// <summary>
    ///   <para>Show a request to unpin secondary tile from start screen.</para>
    /// </summary>
    /// <param name="pos">The coordinates for a request to unpin tile.</param>
    /// <param name="area">The area on the screen above which the request to unpin tile will be displayed.</param>
    public void Delete(Vector2 pos)
    {
      Tile.DeleteSecondaryPos(this.m_TileId, pos);
    }

    /// <summary>
    ///   <para>Show a request to unpin secondary tile from start screen.</para>
    /// </summary>
    /// <param name="tileId">An identifier for secondary tile.</param>
    /// <param name="pos">The coordinates for a request to unpin tile.</param>
    /// <param name="area">The area on the screen above which the request to unpin tile will be displayed.</param>
    public static void DeleteSecondary(string tileId, Vector2 pos)
    {
      Tile.DeleteSecondaryPos(tileId, pos);
    }

    [ThreadAndSerializationSafe]
    private static void DeleteSecondaryPos(string tileId, Vector2 pos)
    {
      Tile.INTERNAL_CALL_DeleteSecondaryPos(tileId, ref pos);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_DeleteSecondaryPos(string tileId, ref Vector2 pos);

    /// <summary>
    ///   <para>Show a request to unpin secondary tile from start screen.</para>
    /// </summary>
    /// <param name="pos">The coordinates for a request to unpin tile.</param>
    /// <param name="area">The area on the screen above which the request to unpin tile will be displayed.</param>
    public void Delete(Rect area)
    {
      Tile.DeleteSecondaryArea(this.m_TileId, area);
    }

    /// <summary>
    ///   <para>Show a request to unpin secondary tile from start screen.</para>
    /// </summary>
    /// <param name="tileId">An identifier for secondary tile.</param>
    /// <param name="pos">The coordinates for a request to unpin tile.</param>
    /// <param name="area">The area on the screen above which the request to unpin tile will be displayed.</param>
    public static void DeleteSecondary(string tileId, Rect area)
    {
      Tile.DeleteSecondary(tileId, area);
    }

    [ThreadAndSerializationSafe]
    private static void DeleteSecondaryArea(string tileId, Rect area)
    {
      Tile.INTERNAL_CALL_DeleteSecondaryArea(tileId, ref area);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_DeleteSecondaryArea(string tileId, ref Rect area);
  }
}
