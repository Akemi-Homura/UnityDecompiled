﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.Macros.MacroEvaluator
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityScript.Scripting;

namespace UnityEditor.Macros
{
  public static class MacroEvaluator
  {
    private static readonly EvaluationContext EditorEvaluationContext = new EvaluationContext((IEvaluationDomainProvider) new MacroEvaluator.EditorEvaluationDomainProvider());

    public static string Eval(string macro)
    {
      if (macro.StartsWith("ExecuteMethod: "))
        return MacroEvaluator.ExecuteMethodThroughReflection(macro);
      object obj = Evaluator.Eval(MacroEvaluator.EditorEvaluationContext, macro);
      return obj != null ? obj.ToString() : "Null";
    }

    private static string ExecuteMethodThroughReflection(string macro)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      MacroEvaluator.\u003CExecuteMethodThroughReflection\u003Ec__AnonStorey0 reflectionCAnonStorey0 = new MacroEvaluator.\u003CExecuteMethodThroughReflection\u003Ec__AnonStorey0();
      Match match = new Regex("ExecuteMethod: (?<type>.*)\\.(?<method>.*)").Match(macro);
      // ISSUE: reference to a compiler-generated field
      reflectionCAnonStorey0.typename = match.Groups["type"].ToString();
      string name = match.Groups["method"].ToString();
      // ISSUE: reference to a compiler-generated method
      MethodInfo method = ((IEnumerable<Assembly>) EditorAssemblies.loadedAssemblies).Select<Assembly, System.Type>(new Func<Assembly, System.Type>(reflectionCAnonStorey0.\u003C\u003Em__0)).Where<System.Type>((Func<System.Type, bool>) (t => t != null)).First<System.Type>().GetMethod(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
      if (method == null)
      {
        // ISSUE: reference to a compiler-generated field
        throw new ArgumentException(string.Format("cannot find method {0} in type {1}", (object) name, (object) reflectionCAnonStorey0.typename));
      }
      if (method.GetParameters().Length > 0)
        throw new ArgumentException("You can only invoke static methods with no arguments");
      object obj = method.Invoke((object) null, new object[0]);
      return obj != null ? obj.ToString() : "Null";
    }

    private class EditorEvaluationDomainProvider : SimpleEvaluationDomainProvider
    {
      private static readonly string[] DefaultImports = new string[2]{ "UnityEditor", "UnityEngine" };

      public EditorEvaluationDomainProvider()
      {
        this.\u002Ector(MacroEvaluator.EditorEvaluationDomainProvider.DefaultImports);
      }

      public virtual Assembly[] GetAssemblyReferences()
      {
        Assembly[] loadedAssemblies = EditorAssemblies.loadedAssemblies;
        IEnumerable<Assembly> second = ((IEnumerable<Assembly>) loadedAssemblies).SelectMany<Assembly, AssemblyName>((Func<Assembly, IEnumerable<AssemblyName>>) (a => (IEnumerable<AssemblyName>) a.GetReferencedAssemblies())).Select<AssemblyName, Assembly>((Func<AssemblyName, Assembly>) (a => MacroEvaluator.EditorEvaluationDomainProvider.TryToLoad(a))).Where<Assembly>((Func<Assembly, bool>) (a => a != null));
        return ((IEnumerable<Assembly>) loadedAssemblies).Concat<Assembly>(second).ToArray<Assembly>();
      }

      private static Assembly TryToLoad(AssemblyName a)
      {
        try
        {
          return Assembly.Load(a);
        }
        catch (Exception ex)
        {
          return (Assembly) null;
        }
      }
    }
  }
}
