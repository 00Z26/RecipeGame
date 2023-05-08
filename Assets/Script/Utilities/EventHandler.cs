using System;
using UnityEngine;

public static class EventHandler //�ĳɾ�̬���������κεط������Ժ��ж���
{
    public static event Action<string> updateCameraScale;  //�л������޸��������
    public static void CallUpdateCameraScale(string sceneName)
    {
        updateCameraScale?.Invoke(sceneName);
    }

    public static event Action<string, float> ShowDialogueEvent;//��controller������չʾUI�¼�
    public static void CallShowDialogueEvent(string data, float YMoveDis)
    {
        ShowDialogueEvent?.Invoke(data, YMoveDis);
    }

    public static event Action<bool, float> UpdateDialogueCamera; //�ӶԻ�UI���������Ի���ͷ����
    public static void CallUpdateDialogueCamera(bool isDialogueOn, float YMoveDis)
    {
        UpdateDialogueCamera?.Invoke(isDialogueOn, YMoveDis);
    }

    public static event Action<bool> ExitDialogueCamera; //�ӶԻ�UI����,����״̬�ı䣬����ͷλ�û�ԭ
    public static void CallExitDialogueCamera(bool isDialogueOn)
    {
        ExitDialogueCamera?.Invoke(isDialogueOn);
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
