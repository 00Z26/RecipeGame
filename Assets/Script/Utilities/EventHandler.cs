using System;
using UnityEngine;

public static class EventHandler //�ĳɾ�̬���������κεط������Ժ��ж���
{
    public static event Action<string> updateCameraScale;  //���ķ���
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
