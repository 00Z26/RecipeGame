using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueController : MonoBehaviour
{
    //这个脚本挂在每个可对话npc上
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
    {   //获取该显示的那句话 or 两个选项
        //分情况传值到UI
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
        //对nextIndex根据状态或判断条件重赋值
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
