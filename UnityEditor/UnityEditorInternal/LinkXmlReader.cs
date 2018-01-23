﻿// Decompiled with JetBrains decompiler
// Type: UnityEditorInternal.LinkXmlReader
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System.Collections.Generic;
using System.IO;
using System.Xml.XPath;

namespace UnityEditorInternal
{
  internal class LinkXmlReader
  {
    private readonly List<string> _assembliesInALinkXmlFile = new List<string>();

    public LinkXmlReader()
    {
      foreach (string userBlacklistFile in AssemblyStripper.GetUserBlacklistFiles())
      {
        XPathNavigator navigator = new XPathDocument(userBlacklistFile).CreateNavigator();
        navigator.MoveToFirstChild();
        XPathNodeIterator xpathNodeIterator = navigator.SelectChildren("assembly", string.Empty);
        while (xpathNodeIterator.MoveNext())
          this._assembliesInALinkXmlFile.Add(xpathNodeIterator.Current.GetAttribute("fullname", string.Empty));
      }
    }

    public bool IsDLLUsed(string assemblyFileName)
    {
      return this._assembliesInALinkXmlFile.Contains(Path.GetFileNameWithoutExtension(assemblyFileName));
    }
  }
}
