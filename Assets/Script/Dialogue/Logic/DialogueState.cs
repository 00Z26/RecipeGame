using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState : MonoBehaviour
{   //������ÿ���ɶԻ��߲���
    //��ȡ�߲˵ĶԻ�״̬

    public bool isDialogueOnState; //��UI����ȡ����ǰ
    public bool hasAutoDialogue;//�Ƿ��ѽ��й��Զ��Ի�
    //public bool hasChanged;//�Ƿ��ѱ������
    public int openDoorTimes;
    public int conversations;
    public string npcName;
    public GameObject playerObject;

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

    //��ȡplayer��object,�����ж�С������Ա
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerObject = collision.gameObject;    
        }
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

    public bool CheckFirstDialogue(DialogueStruct dialogueListItem)
    {
        if (dialogueListItem.triggerName == this.name && dialogueListItem.openDoorTimes == openDoorTimes && dialogueListItem.Conversations == conversations)
        {
            //һ���ж�С�ӳ�Ա�����Ƿ��Ǻϵĺ���
            return true;
        }
        return false;
    }


}
