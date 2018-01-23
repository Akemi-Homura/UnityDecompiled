﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.AudioMixerGroupViewList
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 53BAA40C-AA1D-48D3-AA10-3FCF36D212BC
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Audio;
using UnityEditorInternal;
using UnityEngine;

namespace UnityEditor
{
  internal class AudioMixerGroupViewList
  {
    private ReorderableListWithRenameAndScrollView m_ReorderableListWithRenameAndScrollView;
    private AudioMixerController m_Controller;
    private List<MixerGroupView> m_Views;
    private readonly ReorderableListWithRenameAndScrollView.State m_State;
    private static AudioMixerGroupViewList.Styles s_Styles;

    public AudioMixerGroupViewList(ReorderableListWithRenameAndScrollView.State state)
    {
      this.m_State = state;
    }

    public void OnMixerControllerChanged(AudioMixerController controller)
    {
      this.m_Controller = controller;
      this.RecreateListControl();
    }

    public void OnUndoRedoPerformed()
    {
      this.RecreateListControl();
    }

    public void OnEvent()
    {
      if ((UnityEngine.Object) this.m_Controller == (UnityEngine.Object) null)
        return;
      this.m_ReorderableListWithRenameAndScrollView.OnEvent();
    }

    public void RecreateListControl()
    {
      if ((UnityEngine.Object) this.m_Controller == (UnityEngine.Object) null)
        return;
      this.m_Views = new List<MixerGroupView>((IEnumerable<MixerGroupView>) this.m_Controller.views);
      if (this.m_Views.Count == 0)
      {
        this.m_Views.Add(new MixerGroupView()
        {
          guids = this.m_Controller.GetAllAudioGroupsSlow().Select<AudioMixerGroupController, GUID>((Func<AudioMixerGroupController, GUID>) (gr => gr.groupID)).ToArray<GUID>(),
          name = "View"
        });
        this.SaveToBackend();
      }
      ReorderableList list = new ReorderableList((IList) this.m_Views, typeof (MixerGroupView), true, false, false, false);
      list.onReorderCallback += new ReorderableList.ReorderCallbackDelegate(this.EndDragChild);
      list.elementHeight = 16f;
      list.headerHeight = 0.0f;
      list.footerHeight = 0.0f;
      list.showDefaultBackground = false;
      list.index = this.m_Controller.currentViewIndex;
      if (this.m_Controller.currentViewIndex >= list.count)
        Debug.LogError((object) ("State mismatch, currentViewIndex: " + (object) this.m_Controller.currentViewIndex + ", num items: " + (object) list.count));
      this.m_ReorderableListWithRenameAndScrollView = new ReorderableListWithRenameAndScrollView(list, this.m_State);
      this.m_ReorderableListWithRenameAndScrollView.onSelectionChanged += new Action<int>(this.SelectionChanged);
      this.m_ReorderableListWithRenameAndScrollView.onNameChangedAtIndex += new Action<int, string>(this.NameChanged);
      this.m_ReorderableListWithRenameAndScrollView.onDeleteItemAtIndex += new Action<int>(this.Delete);
      this.m_ReorderableListWithRenameAndScrollView.onGetNameAtIndex += new Func<int, string>(this.GetNameOfElement);
      this.m_ReorderableListWithRenameAndScrollView.onCustomDrawElement += new ReorderableList.ElementCallbackDelegate(this.CustomDrawElement);
    }

    public float GetTotalHeight()
    {
      if ((UnityEngine.Object) this.m_Controller == (UnityEngine.Object) null)
        return 0.0f;
      return this.m_ReorderableListWithRenameAndScrollView.list.GetHeight() + 22f;
    }

    public void OnGUI(Rect rect)
    {
      if (AudioMixerGroupViewList.s_Styles == null)
        AudioMixerGroupViewList.s_Styles = new AudioMixerGroupViewList.Styles();
      Rect headerRect;
      Rect contentRect;
      using (new EditorGUI.DisabledScope((UnityEngine.Object) this.m_Controller == (UnityEngine.Object) null))
      {
        AudioMixerDrawUtils.DrawRegionBg(rect, out headerRect, out contentRect);
        AudioMixerDrawUtils.HeaderLabel(headerRect, AudioMixerGroupViewList.s_Styles.header, AudioMixerGroupViewList.s_Styles.viewsIcon);
      }
      if (!((UnityEngine.Object) this.m_Controller != (UnityEngine.Object) null))
        return;
      if (this.m_ReorderableListWithRenameAndScrollView.list.index != this.m_Controller.currentViewIndex)
      {
        this.m_ReorderableListWithRenameAndScrollView.list.index = this.m_Controller.currentViewIndex;
        this.m_ReorderableListWithRenameAndScrollView.FrameItem(this.m_Controller.currentViewIndex);
      }
      this.m_ReorderableListWithRenameAndScrollView.OnGUI(contentRect);
      if (GUI.Button(new Rect(headerRect.xMax - 15f, headerRect.y + 3f, 15f, 15f), AudioMixerGroupViewList.s_Styles.addButton, EditorStyles.label))
        this.Add();
    }

    public void CustomDrawElement(Rect r, int index, bool isActive, bool isFocused)
    {
      Event current = Event.current;
      if (current.type == EventType.MouseUp && current.button == 1 && r.Contains(current.mousePosition))
      {
        AudioMixerGroupViewList.ViewsContexttMenu.Show(r, index, this);
        current.Use();
      }
      bool isSelected = index == this.m_ReorderableListWithRenameAndScrollView.list.index && !this.m_ReorderableListWithRenameAndScrollView.IsRenamingIndex(index);
      this.m_ReorderableListWithRenameAndScrollView.DrawElementText(r, index, isActive, isSelected, isFocused);
    }

    private void SaveToBackend()
    {
      this.m_Controller.views = this.m_Views.ToArray();
    }

    private void LoadFromBackend()
    {
      this.m_Views.Clear();
      this.m_Views.AddRange((IEnumerable<MixerGroupView>) this.m_Controller.views);
    }

    private string GetNameOfElement(int index)
    {
      return this.m_Views[index].name;
    }

    private void Add()
    {
      this.m_Controller.CloneViewFromCurrent();
      this.LoadFromBackend();
      int index = this.m_Views.Count - 1;
      this.m_Controller.currentViewIndex = index;
      this.m_ReorderableListWithRenameAndScrollView.BeginRename(index, 0.0f);
    }

    private void Delete(int index)
    {
      if (this.m_Views.Count <= 1)
      {
        Debug.Log((object) "Deleting all views is not allowed");
      }
      else
      {
        this.m_Controller.DeleteView(index);
        this.LoadFromBackend();
      }
    }

    public void NameChanged(int index, string newName)
    {
      this.LoadFromBackend();
      MixerGroupView view = this.m_Views[index];
      view.name = newName;
      this.m_Views[index] = view;
      this.SaveToBackend();
    }

    public void SelectionChanged(int selectedIndex)
    {
      this.LoadFromBackend();
      this.m_Controller.SetView(selectedIndex);
    }

    public void EndDragChild(ReorderableList list)
    {
      this.m_Views = this.m_ReorderableListWithRenameAndScrollView.list.list as List<MixerGroupView>;
      this.SaveToBackend();
    }

    private void Rename(int index)
    {
      this.m_ReorderableListWithRenameAndScrollView.BeginRename(index, 0.0f);
    }

    private void DuplicateCurrentView()
    {
      this.m_Controller.CloneViewFromCurrent();
      this.LoadFromBackend();
    }

    private class Styles
    {
      public GUIContent header = new GUIContent("Views", "A view is the saved visiblity state of the current Mixer Groups. Use views to setup often used combinations of Mixer Groups.");
      public GUIContent addButton = new GUIContent("+");
      public Texture2D viewsIcon = EditorGUIUtility.FindTexture("AudioMixerView Icon");
    }

    internal class ViewsContexttMenu
    {
      public static void Show(Rect buttonRect, int viewIndex, AudioMixerGroupViewList list)
      {
        GenericMenu genericMenu1 = new GenericMenu();
        AudioMixerGroupViewList.ViewsContexttMenu.data data1 = new AudioMixerGroupViewList.ViewsContexttMenu.data() { viewIndex = viewIndex, list = list };
        GenericMenu genericMenu2 = genericMenu1;
        GUIContent content1 = new GUIContent("Rename");
        int num1 = 0;
        // ISSUE: reference to a compiler-generated field
        if (AudioMixerGroupViewList.ViewsContexttMenu.\u003C\u003Ef__mg\u0024cache0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AudioMixerGroupViewList.ViewsContexttMenu.\u003C\u003Ef__mg\u0024cache0 = new GenericMenu.MenuFunction2(AudioMixerGroupViewList.ViewsContexttMenu.Rename);
        }
        // ISSUE: reference to a compiler-generated field
        GenericMenu.MenuFunction2 fMgCache0 = AudioMixerGroupViewList.ViewsContexttMenu.\u003C\u003Ef__mg\u0024cache0;
        AudioMixerGroupViewList.ViewsContexttMenu.data data2 = data1;
        genericMenu2.AddItem(content1, num1 != 0, fMgCache0, (object) data2);
        GenericMenu genericMenu3 = genericMenu1;
        GUIContent content2 = new GUIContent("Duplicate");
        int num2 = 0;
        // ISSUE: reference to a compiler-generated field
        if (AudioMixerGroupViewList.ViewsContexttMenu.\u003C\u003Ef__mg\u0024cache1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AudioMixerGroupViewList.ViewsContexttMenu.\u003C\u003Ef__mg\u0024cache1 = new GenericMenu.MenuFunction2(AudioMixerGroupViewList.ViewsContexttMenu.Duplicate);
        }
        // ISSUE: reference to a compiler-generated field
        GenericMenu.MenuFunction2 fMgCache1 = AudioMixerGroupViewList.ViewsContexttMenu.\u003C\u003Ef__mg\u0024cache1;
        AudioMixerGroupViewList.ViewsContexttMenu.data data3 = data1;
        genericMenu3.AddItem(content2, num2 != 0, fMgCache1, (object) data3);
        GenericMenu genericMenu4 = genericMenu1;
        GUIContent content3 = new GUIContent("Delete");
        int num3 = 0;
        // ISSUE: reference to a compiler-generated field
        if (AudioMixerGroupViewList.ViewsContexttMenu.\u003C\u003Ef__mg\u0024cache2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AudioMixerGroupViewList.ViewsContexttMenu.\u003C\u003Ef__mg\u0024cache2 = new GenericMenu.MenuFunction2(AudioMixerGroupViewList.ViewsContexttMenu.Delete);
        }
        // ISSUE: reference to a compiler-generated field
        GenericMenu.MenuFunction2 fMgCache2 = AudioMixerGroupViewList.ViewsContexttMenu.\u003C\u003Ef__mg\u0024cache2;
        AudioMixerGroupViewList.ViewsContexttMenu.data data4 = data1;
        genericMenu4.AddItem(content3, num3 != 0, fMgCache2, (object) data4);
        genericMenu1.DropDown(buttonRect);
      }

      private static void Rename(object userData)
      {
        AudioMixerGroupViewList.ViewsContexttMenu.data data = userData as AudioMixerGroupViewList.ViewsContexttMenu.data;
        data.list.Rename(data.viewIndex);
      }

      private static void Duplicate(object userData)
      {
        AudioMixerGroupViewList.ViewsContexttMenu.data data = userData as AudioMixerGroupViewList.ViewsContexttMenu.data;
        data.list.m_Controller.currentViewIndex = data.viewIndex;
        data.list.DuplicateCurrentView();
      }

      private static void Delete(object userData)
      {
        AudioMixerGroupViewList.ViewsContexttMenu.data data = userData as AudioMixerGroupViewList.ViewsContexttMenu.data;
        data.list.Delete(data.viewIndex);
      }

      private class data
      {
        public int viewIndex;
        public AudioMixerGroupViewList list;
      }
    }
  }
}
