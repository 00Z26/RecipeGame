using System;
using UnityEngine;

public static class EventHandler //改成静态方法，在任何地方都可以呼叫订阅
{
    public static event Action<string> updateCameraScale;  //订阅方法
    public static void CallUpdateCameraScale(string sceneName)
    {
        updateCameraScale?.Invoke(sceneName);
    }

    public static event Action<string> ShowDialogueEvent;
    public static void CallShowDialogueEvent(string data)
    {
        ShowDialogueEvent?.Invoke(data);
    }


    public static event Action BeforeSceneUnloadEvent;
    public static void CallBeforeSceneUnloadEvent()  //场景切换前保存物品存在的字典信息
    {
        BeforeSceneUnloadEvent?.Invoke();
    }

    public static event Action AfterSceneLoadedEvent;  //切换后加载保存的物品字典信息
    public static void CallAfterSceneLoadedEvent()
    {
        AfterSceneLoadedEvent?.Invoke();
    }


}
