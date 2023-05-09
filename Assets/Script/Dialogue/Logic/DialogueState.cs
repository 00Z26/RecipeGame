using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState : MonoBehaviour
{   //������ÿ���ɶԻ��߲���
    //��ȡ�߲˵ĶԻ�״̬

    public bool isDialogueOnState; //��UI����ȡ����ǰ
    public bool hasAutoDialogue;//�Ƿ��ѽ��й��Զ��Ի�

    private void OnEnable()
    {
        EventHandler.UpdateDialogueState += onUpdateDialogueState;
        EventHandler.ExitDialogueState += onExitDialogueState;
    }
    private void OnDisable()
    {
        EventHandler.UpdateDialogueState += onUpdateDialogueState;
        EventHandler.ExitDialogueState += onExitDialogueState;
    }

    private void onExitDialogueState(bool dialogeState)
    {
        isDialogueOnState = dialogeState;   
    }

    private void onUpdateDialogueState(bool dialogueState, float arg2)
    {
        isDialogueOnState = dialogueState;
    }

    public int getNextDialogueIndex(int index)
    {
        if (!isDialogueOnState)
        {
            //����Ϊ�´ζԻ�����ʼ
            index = 0;
            return index;
        }
        else
        {
            return index;
        }
    }
}
