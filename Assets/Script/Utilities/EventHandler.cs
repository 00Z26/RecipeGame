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

    public static event Action<string[], float,Sprite,GameObject> ShowDialogueEvent;//从controller发出，展示UI事件
    public static void CallShowDialogueEvent(string[] data, float YMoveDis, Sprite pic, GameObject gameObject)
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

    public static event Action<string, string, Vector3> TriggerSumToMenuEvent; //主菜单切换到菜谱界面
    public static void CallTriggerSumToMenuEvent(string from, string to, Vector3 playerPos)
    {
        TriggerSumToMenuEvent?.Invoke(from, to, playerPos);
    }

    public static event Action<bool> SwichLightAnimEvent; //进屋子的时候关灯
    public static void CallSwitchAnimEvent(bool isLight)
    {
        SwichLightAnimEvent?.Invoke(isLight);
    }

    public static event Action<List<string>, List<string>,List<string>> ExcuDialogueAnimEvent;//触发对话的动画时执行
    public static void CallExcuDialogueAnimEvent(List<string> obj, List<string> anim, List<string> all)
    {
        ExcuDialogueAnimEvent?.Invoke(obj,anim,all); 
    }

    public static event Action<string,string,Vector3> TriggerContinue; //按下继续执行gameManager里的数据更新
    public static void CallTriggerContinue(string from, string to, Vector3 playerPos)
    {
        TriggerContinue?.Invoke(from,to,playerPos);
    }

    public static event Action<int> DialogueSwapStateEvent; //切换NPC状态
    public static void CallDialogueSwapStateEvent(int index)
    {
        DialogueSwapStateEvent?.Invoke(index);
    }

    public static event Action<string, string, Vector3> RecipeExitEvent; //菜谱返回主菜单
    public static void CallRecipeExitEvent(string from, string to, Vector3 playerPos)
    {
        RecipeExitEvent?.Invoke(from,to, playerPos);
    }


    public static event Action ControllTipEvent; //控制自动触发对话后，出现的操作提示，在starttip里
    public static void CallControllTipEvent()
    {
        ControllTipEvent?.Invoke();
    }

    public static event Action<bool> ShowTipButtonEvent; //触发player头上的提示框是否显示
    public static void CallShowTipButtonEvent(bool isShow)
    {
        ShowTipButtonEvent?.Invoke(isShow);
    }

    public static event Action ClickUIAudioEvent; //点击对话框、提示框、结算框的音效
    public static void CallPlayClickUIAudioEvent()
    {
        ClickUIAudioEvent?.Invoke();
    }

    public static event Action ClickSumAudioEvent; //结算界面点击记录的音效
    public static void CallPlaySumAudio()
    {
        ClickSumAudioEvent?.Invoke();
    }

    public static event Action ClickMenuBtnAudioEvent; //主界面选项点击的音效
    public static void CallPlayMenuBtnAudio()
    {
        ClickMenuBtnAudioEvent?.Invoke();
    }

    public static event Action HoverBtnAudioEvent; //所有按钮悬浮时触发音效
    public static void CallHoverAudio()
    {
        HoverBtnAudioEvent?.Invoke();
    }


    public static event Action ClickDishAudioEvent; //食谱图鉴点击某个菜音效
    public static void CallDishAudio()
    {
        ClickDishAudioEvent?.Invoke();
    }

    public static event Action<float> ChangeMainAudioVolumeEvent; //修改音量时，把主音量滑动条的数值变化传递给控制器
    public static void CallChangeMainAudioVol(float volVal)
    {
        ChangeMainAudioVolumeEvent?.Invoke(volVal);
    }

    public static event Action<float> ChangeBgAudioVolumeEvent; //修改音量时，把背景音乐滑动条的数值变化传递给控制器
    public static void CallChangeBgAudioVol(float volVal)
    {
        ChangeBgAudioVolumeEvent?.Invoke(volVal);
    }


    public static event Action<float> ChangeUIAudioVolumeEvent; //修改音量时，把音效音乐滑动条的数值变化传递给控制器
    public static void CallChangeUIAudioVol(float volVal)
    {
        ChangeUIAudioVolumeEvent?.Invoke(volVal);
    }


    public static event Action<float> SyncMainVolumeEvent; //打开音量界面时，把当前主音量值同步表现到UI上
    public static void CallSyncMainVolumeEvent(float volVal)
    {
        SyncMainVolumeEvent?.Invoke(volVal);
    }
    public static event Action<float> SyncBGMVolumeEvent; //打开音量界面时，把当前背景音乐音量值同步表现到UI上
    public static void CallSyncBGMVolumeEvent(float volVal)
    {
        SyncBGMVolumeEvent?.Invoke(volVal);
    }

    public static event Action OpenVolumeSettingEvent;//打开esc音量控制，用来触发音量的同步
    public static void CallOpenVolumeSetting()
    {
        OpenVolumeSettingEvent?.Invoke();
    }
    public static event Action<float> SyncUIVolumeEvent; //打开音量界面时，把当前UI音效音乐音量值同步表现到UI上
    public static void CallSyncUIVolumeEvent(float volVal)
    {
        SyncUIVolumeEvent?.Invoke(volVal);
    }

    public static event Action OpenMenuVolumeSettingEvent;//打开Menu音量控制，用来触发音量的同步
    public static void CallOpenMenuVolumeSetting()
    {
        OpenMenuVolumeSettingEvent?.Invoke();
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
