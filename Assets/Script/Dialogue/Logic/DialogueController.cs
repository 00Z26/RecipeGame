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
    private DialogueState dialogueState;
    private Sprite speakerImage;

    private void Awake()
    {

        nextIndex = 0;
        dialogueState = GetComponent<DialogueState>();

    }
    public void ShowDialogue()
    {   //��ȡ����ʾ���Ǿ仰 or ����ѡ��
        //�������ֵ��UI
        if(nextIndex != -1)
        {
            currentDialogue = getDialoguesContent();
            content = currentDialogue.content;
            nextIndex = currentDialogue.nextIndex;
            speakerImage = currentDialogue.pic;
        }
        else
        {
            content = null;
        }

        EventHandler.CallShowDialogueEvent(content, YMoveDis,speakerImage);
        //��nextIndex����״̬���ж������ظ�ֵ
        if(nextIndex == -1)
        {
            nextIndex = dialogueState.getNextDialogueIndex(nextIndex);
        }
        
    }

    private DialogueStruct getDialoguesContent()
    {
        return dialoges.dialogueList[nextIndex];
    }
}
