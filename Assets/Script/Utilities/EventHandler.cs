using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler //改成静态方法，在任何地方都可以呼叫订阅
{
    public static event Action<string> updateCameraScale;  //切换场景修改相机限制
    public static void CallUpdateCameraScale(string sceneName)
    {
        updateCameraScale?.Invoke(sceneName);
    }

    public static event Action<string, float,Sprite,GameObject> ShowDialogueEvent;//从controller发出，展示UI事件
    public static void CallShowDialogueEvent(string data, float YMoveDis, Sprite pic, GameObject gameObject)
    {
        ShowDialogueEvent?.Invoke(data, YMoveDis,pic, gameObject);
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

    public static event Action TriggerAutoDialogue; //在自动对话区域时，触发自动对话
    public static void CallTriggerAutoDialogue()
    {
        TriggerAutoDialogue?.Invoke();
    }

    public static event Action<List<string>> UpdateChoicesEvent; //有选项时触发事件，传当前对话的选项内容给UI显示选项
    public static void CallUpdateChoicesEvent(List<string> choices)
    {
        UpdateChoicesEvent?.Invoke(choices);
    }

    public static event Action<int> SendButtonValEvent; //发送按钮给的值
    public static void CallSendButtionValEvent(int val)
    {
        SendButtonValEvent?.Invoke(val);
    }


    public static event Action<int> TriggerChangeEvent; //选项触发夺舍事件，传值给changeController
    public static void CallTriggerChangeEvent(int val)
    {
        TriggerChangeEvent?.Invoke(val);
    }

    public static event Action<int> TriggerFollowEvent; //选项触发跟随事件，传给followController
    public static void CallTriggerFollowEvent(int val)
    {
       TriggerFollowEvent?.Invoke(val);
    }

    public static event Action<string, string, Vector3> TriggerSwapNewGameEvent; //用来从主菜单切换场景到游戏,新游戏数据更新也用这个事件
    public static void CallTriggerSwapNewGameEvent(string from, string to, Vector3 playerPos)
    {
        TriggerSwapNewGameEvent?.Invoke(from, to, playerPos);
    }

    public static event Action<string> TriggerShowRecipeTextEvent; //结算菜单的文字显示
    public static void CallTriggerShowRecipeTextEvent(string text)
    {
        TriggerShowRecipeTextEvent?.Invoke(text);
    }

    public static event Action<string, string, Vector3> TriggerShowRecipeEvent; //主菜单切换到菜谱界面
    public static void CallTriggerShowRecipeEvent(string from, string to, Vector3 playerPos)
    {
        TriggerShowRecipeEvent?.Invoke(from, to, playerPos);
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
