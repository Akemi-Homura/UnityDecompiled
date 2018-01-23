﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.Experimental.UIElements.CallbackEventHandler
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

namespace UnityEngine.Experimental.UIElements
{
  /// <summary>
  ///   <para>Interface for classes capable of having callbacks to handle events.</para>
  /// </summary>
  public abstract class CallbackEventHandler : IEventHandler
  {
    private EventCallbackRegistry m_CallbackRegistry;

    public void RegisterCallback<TEventType>(EventCallback<TEventType> callback, Capture useCapture = Capture.NoCapture) where TEventType : EventBase<TEventType>, new()
    {
      if (this.m_CallbackRegistry == null)
        this.m_CallbackRegistry = new EventCallbackRegistry();
      this.m_CallbackRegistry.RegisterCallback<TEventType>(callback, useCapture);
    }

    public void RegisterCallback<TEventType, TUserArgsType>(EventCallback<TEventType, TUserArgsType> callback, TUserArgsType userArgs, Capture useCapture = Capture.NoCapture) where TEventType : EventBase<TEventType>, new()
    {
      if (this.m_CallbackRegistry == null)
        this.m_CallbackRegistry = new EventCallbackRegistry();
      this.m_CallbackRegistry.RegisterCallback<TEventType, TUserArgsType>(callback, userArgs, useCapture);
    }

    public void UnregisterCallback<TEventType>(EventCallback<TEventType> callback, Capture useCapture = Capture.NoCapture) where TEventType : EventBase<TEventType>, new()
    {
      if (this.m_CallbackRegistry == null)
        return;
      this.m_CallbackRegistry.UnregisterCallback<TEventType>(callback, useCapture);
    }

    public void UnregisterCallback<TEventType, TUserArgsType>(EventCallback<TEventType, TUserArgsType> callback, Capture useCapture = Capture.NoCapture) where TEventType : EventBase<TEventType>, new()
    {
      if (this.m_CallbackRegistry == null)
        return;
      this.m_CallbackRegistry.UnregisterCallback<TEventType, TUserArgsType>(callback, useCapture);
    }

    /// <summary>
    ///   <para>Handle an event, most often by executing the callbacks associated with the event.</para>
    /// </summary>
    /// <param name="evt">The event to handle.</param>
    public virtual void HandleEvent(EventBase evt)
    {
      if (evt.propagationPhase != PropagationPhase.DefaultAction)
      {
        if (this.m_CallbackRegistry == null)
          return;
        this.m_CallbackRegistry.InvokeCallbacks(evt);
      }
      else
        this.ExecuteDefaultAction(evt);
    }

    /// <summary>
    ///   <para>Return true if event handlers for the event propagation capture phase have been attached on this object.</para>
    /// </summary>
    /// <returns>
    ///   <para>True if object has event handlers for the capture phase.</para>
    /// </returns>
    public bool HasCaptureHandlers()
    {
      return this.m_CallbackRegistry != null && this.m_CallbackRegistry.HasCaptureHandlers();
    }

    /// <summary>
    ///   <para>Return true if event handlers for the event propagation bubble up phase have been attached on this object.</para>
    /// </summary>
    /// <returns>
    ///   <para>True if object has event handlers for the bubble up phase.</para>
    /// </returns>
    public bool HasBubbleHandlers()
    {
      return this.m_CallbackRegistry != null && this.m_CallbackRegistry.HasBubbleHandlers();
    }

    protected internal virtual void ExecuteDefaultAction(EventBase evt)
    {
    }

    /// <summary>
    ///   <para>Called when the element loses the capture. Will be removed in a future version.</para>
    /// </summary>
    public virtual void OnLostCapture()
    {
    }
  }
}
