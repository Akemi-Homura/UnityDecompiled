﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.CoroutineTween.TweenRunner`1
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 95F4B50A-137D-4022-9C58-045B696814A0
// Assembly location: C:\Program Files\Unity 5\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

using System.Collections;
using System.Diagnostics;

namespace UnityEngine.UI.CoroutineTween
{
  internal class TweenRunner<T> where T : struct, ITweenValue
  {
    protected MonoBehaviour m_CoroutineContainer;
    protected IEnumerator m_Tween;

    [DebuggerHidden]
    private static IEnumerator Start(T tweenInfo)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new TweenRunner<T>.\u003CStart\u003Ec__Iterator0() { tweenInfo = tweenInfo };
    }

    public void Init(MonoBehaviour coroutineContainer)
    {
      this.m_CoroutineContainer = coroutineContainer;
    }

    public void StartTween(T info)
    {
      if ((Object) this.m_CoroutineContainer == (Object) null)
      {
        UnityEngine.Debug.LogWarning((object) "Coroutine container not configured... did you forget to call Init?");
      }
      else
      {
        this.StopTween();
        if (!this.m_CoroutineContainer.gameObject.activeInHierarchy)
        {
          info.TweenValue(1f);
        }
        else
        {
          this.m_Tween = TweenRunner<T>.Start(info);
          this.m_CoroutineContainer.StartCoroutine(this.m_Tween);
        }
      }
    }

    public void StopTween()
    {
      if (this.m_Tween == null)
        return;
      this.m_CoroutineContainer.StopCoroutine(this.m_Tween);
      this.m_Tween = (IEnumerator) null;
    }
  }
}
