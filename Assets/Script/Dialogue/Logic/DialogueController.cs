using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueController : MonoBehaviour
{
    //����ű�����ÿ���ɶԻ�npc��
    public float YMoveDis;
    public DialogueData dialoges;
    public int nextIndex;
    public DialogueStruct currentDialogue;
    public string content;


    private void Awake()
    {

        nextIndex = 0;

    }
    public void ShowDialogue()
    {   //��ȡ����ʾ���Ǿ仰 or ����ѡ��
        //�������ֵ��UI
        if(nextIndex != -1)
        {
            currentDialogue = getDialoguesContent();
            content = currentDialogue.content;
            nextIndex = currentDialogue.nextIndex;
        }
        else
        {
            content = null;
        }

        EventHandler.CallShowDialogueEvent(content, YMoveDis);
        //��nextIndex����״̬���ж������ظ�ֵ
        //Debug.Log(dialogueUI.isDialogueOn);
        //if( nextIndex == -1 && dialogueUI.isDialogueOn == false)
        //    nextIndex = 0;
        
    }

    private DialogueStruct getDialoguesContent()
    {
        return dialoges.dialogueList[nextIndex];
    }
}
