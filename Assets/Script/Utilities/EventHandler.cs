using System;
using UnityEngine;

public static class EventHandler //�ĳɾ�̬���������κεط������Ժ��ж���
{
    public static event Action<string> updateCameraScale;  //�л������޸��������
    public static void CallUpdateCameraScale(string sceneName)
    {
        updateCameraScale?.Invoke(sceneName);
    }

    public static event Action<string, float,Sprite> ShowDialogueEvent;//��controller������չʾUI�¼�
    public static void CallShowDialogueEvent(string data, float YMoveDis, Sprite pic)
    {
        ShowDialogueEvent?.Invoke(data, YMoveDis,pic);
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
