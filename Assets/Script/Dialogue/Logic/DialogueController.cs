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


    private void Awake()
    {

        nextIndex = 0;

    }
    public void ShowDialogue()
    {   //获取该显示的那句话 or 两个选项
        //分情况传值到UI
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
        //对nextIndex根据状态或判断条件重赋值
        //Debug.Log(dialogueUI.isDialogueOn);
        //if( nextIndex == -1 && dialogueUI.isDialogueOn == false)
        //    nextIndex = 0;
        
    }

    private DialogueStruct getDialoguesContent()
    {
        return dialoges.dialogueList[nextIndex];
    }
}
