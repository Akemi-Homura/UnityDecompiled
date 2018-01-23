﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.Networking.DownloadHandlerScript
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine.Networking
{
  [StructLayout(LayoutKind.Sequential)]
  public class DownloadHandlerScript : DownloadHandler
  {
    public DownloadHandlerScript()
    {
      this.InternalCreateScript();
    }

    public DownloadHandlerScript(byte[] preallocatedBuffer)
    {
      if (preallocatedBuffer == null || preallocatedBuffer.Length < 1)
        throw new ArgumentException("Cannot create a preallocated-buffer DownloadHandlerScript backed by a null or zero-length array");
      this.InternalCreateScript();
      this.SetPreallocatedBuffer(preallocatedBuffer);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern IntPtr Create(DownloadHandlerScript obj);

    private void InternalCreateScript()
    {
      this.m_Ptr = DownloadHandlerScript.Create(this);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetPreallocatedBuffer(byte[] buffer);
  }
}
