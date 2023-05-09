using System;
using UnityEngine;

public static class EventHandler //改成静态方法，在任何地方都可以呼叫订阅
{
    public static event Action<string> updateCameraScale;  //切换场景修改相机限制
    public static void CallUpdateCameraScale(string sceneName)
    {
        updateCameraScale?.Invoke(sceneName);
    }

    public static event Action<string, float,Sprite> ShowDialogueEvent;//从controller发出，展示UI事件
    public static void CallShowDialogueEvent(string data, float YMoveDis, Sprite pic)
    {
        ShowDialogueEvent?.Invoke(data, YMoveDis,pic);
    }

    public static event Action<bool, float> UpdateDialogueState; //从对话UI发出，将对话镜头下移
    public static void CallUpdateDialogueState(bool isDialogueOn, float YMoveDis)
    {
        UpdateDialogueState?.Invoke(isDialogueOn, YMoveDis);
    }

    public static event Action<bool> ExitDialogueState; //从对话UI发出,给出状态改变，将镜头位置还原
    public static void CallExitDialogueState(bool isDialogueOn)
    {
        ExitDialogueState?.Invoke(isDialogueOn);
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
