using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler //�ĳɾ�̬���������κεط������Ժ��ж���
{
    public static event Action<string> updateCameraScale;  //�л������޸��������
    public static void CallUpdateCameraScale(string sceneName)
    {
        updateCameraScale?.Invoke(sceneName);
    }

    public static event Action<string, float,Sprite,GameObject> ShowDialogueEvent;//��controller������չʾUI�¼�
    public static void CallShowDialogueEvent(string data, float YMoveDis, Sprite pic, GameObject gameObject)
    {
        ShowDialogueEvent?.Invoke(data, YMoveDis,pic, gameObject);
    }

    public static event Action<bool, float> UpdateDialogueState; //�ӶԻ�UI���������Ի���ͷ����
    public static void CallUpdateDialogueState(bool isDialogueOn, float YMoveDis)
    {
        UpdateDialogueState?.Invoke(isDialogueOn, YMoveDis);
    }

    public static event Action<bool> ExitDialogueState; //�ӶԻ�UI����,����״̬�ı䣬����ͷλ�û�ԭ
    public static void CallExitDialogueState(bool isDialogueOn)
    {
        ExitDialogueState?.Invoke(isDialogueOn);
    }

    public static event Action TriggerAutoDialogue; //���Զ��Ի�����ʱ�������Զ��Ի�
    public static void CallTriggerAutoDialogue()
    {
        TriggerAutoDialogue?.Invoke();
    }

    public static event Action<List<string>> UpdateChoicesEvent; //��ѡ��ʱ�����¼�������ǰ�Ի���ѡ�����ݸ�UI��ʾѡ��
    public static void CallUpdateChoicesEvent(List<string> choices)
    {
        UpdateChoicesEvent?.Invoke(choices);
    }

    public static event Action<int> SendButtonValEvent; //���Ͱ�ť����ֵ
    public static void CallSendButtionValEvent(int val)
    {
        SendButtonValEvent?.Invoke(val);
    }


    public static event Action<int> TriggerChangeEvent; //ѡ��������¼�����ֵ��changeController
    public static void CallTriggerChangeEvent(int val)
    {
        TriggerChangeEvent?.Invoke(val);
    }

    public static event Action<int> TriggerFollowEvent; //ѡ��������¼�������followController
    public static void CallTriggerFollowEvent(int val)
    {
       TriggerFollowEvent?.Invoke(val);
    }

    public static event Action<string, string, Vector3> TriggerSwapNewGameEvent; //���������˵��л���������Ϸ,����Ϸ���ݸ���Ҳ������¼�
    public static void CallTriggerSwapNewGameEvent(string from, string to, Vector3 playerPos)
    {
        TriggerSwapNewGameEvent?.Invoke(from, to, playerPos);
    }

    public static event Action<string> TriggerShowRecipeTextEvent; //����˵���������ʾ
    public static void CallTriggerShowRecipeTextEvent(string text)
    {
        TriggerShowRecipeTextEvent?.Invoke(text);
    }

    public static event Action<string, string, Vector3> TriggerShowRecipeEvent; //���˵��л������׽���
    public static void CallTriggerShowRecipeEvent(string from, string to, Vector3 playerPos)
    {
        TriggerShowRecipeEvent?.Invoke(from, to, playerPos);
    }










    public static event Action BeforeSceneUnloadEvent;
    public static void CallBeforeSceneUnloadEvent()  //�����л�ǰ������Ʒ���ڵ��ֵ���Ϣ
    {
        BeforeSceneUnloadEvent?.Invoke();
    }

    public static event Action AfterSceneLoadedEvent;  //�л�����ر������Ʒ�ֵ���Ϣ
    public static void CallAfterSceneLoadedEvent()
    {
        AfterSceneLoadedEvent?.Invoke();
    }


}
