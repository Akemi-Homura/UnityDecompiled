﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.LocalNotification
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System;
using System.Collections;

namespace UnityEngine
{
  [Obsolete("LocalNotification is deprecated. Please use iOS.LocalNotification instead (UnityUpgradable) -> UnityEngine.iOS.LocalNotification", true)]
  public sealed class LocalNotification
  {
    public DateTime fireDate
    {
      get
      {
        return new DateTime();
      }
      set
      {
      }
    }

    public string timeZone
    {
      get
      {
        return (string) null;
      }
      set
      {
      }
    }

    public CalendarUnit repeatInterval
    {
      get
      {
        return CalendarUnit.Era;
      }
      set
      {
      }
    }

    public CalendarIdentifier repeatCalendar
    {
      get
      {
        return CalendarIdentifier.GregorianCalendar;
      }
      set
      {
      }
    }

    public string alertBody
    {
      get
      {
        return (string) null;
      }
      set
      {
      }
    }

    public string alertAction
    {
      get
      {
        return (string) null;
      }
      set
      {
      }
    }

    public bool hasAction
    {
      get
      {
        return false;
      }
      set
      {
      }
    }

    public string alertLaunchImage
    {
      get
      {
        return (string) null;
      }
      set
      {
      }
    }

    public int applicationIconBadgeNumber
    {
      get
      {
        return 0;
      }
      set
      {
      }
    }

    public string soundName
    {
      get
      {
        return (string) null;
      }
      set
      {
      }
    }

    public static string defaultSoundName
    {
      get
      {
        return (string) null;
      }
    }

    public IDictionary userInfo
    {
      get
      {
        return (IDictionary) null;
      }
      set
      {
      }
    }
  }
}
