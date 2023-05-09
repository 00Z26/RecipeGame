using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueController : MonoBehaviour
{
    //这个脚本挂在每个可对话npc上
    public float YMoveDis;
    public DialogueData dialoges;
    public DialogueData autoDialoges;
    public int nextIndex;
    public DialogueStruct currentDialogue;
    public string content;
    private DialogueState dialogueState;
    private Sprite speakerImage;
    GameObject autoObj;

    private void Awake()
    {

        nextIndex = 0;
        dialogueState = GetComponent<DialogueState>();
        autoObj = null;

    }
    public void ShowDialogue(bool isAuto, GameObject player)
    {   //获取该显示的那句话 or 两个选项
        //分情况传值到UI
        if(nextIndex != -1)
        {
            currentDialogue = getDialoguesContent(isAuto);
            content = currentDialogue.content;
            nextIndex = currentDialogue.nextIndex;
            speakerImage = currentDialogue.pic;
        }
        else
        {
            content = null;
        }
        //参数：剧情内容，相机偏移，头像，自动对话刚体关闭（需要在UI关闭时，停止自动检测）
        EventHandler.CallShowDialogueEvent(content, YMoveDis, speakerImage, autoObj);
        //在这添加选项相关操作比较好，前面内容读取完,从controller获得触发事件的选项
        //对nextIndex根据状态或判断条件重赋值
        if(nextIndex == -1)
        {
            if(isAuto == true)
            {
                //修改这个物体auto的已触发状态，把已触发改为ftrue
                //获取自动触发的物体
                autoObj = this.gameObject.transform.GetChild(0).gameObject;
                dialogueState.hasAutoDialogue = true;
             
            }
            nextIndex = dialogueState.getNextDialogueIndex(nextIndex);
        }
        
    }
    //根据是否是自动触发来确定剧情库，以后会根据stateCheck修改剧情库
    private DialogueStruct getDialoguesContent(bool isAuto)
    {
        if (isAuto)
        {
            return autoDialoges.dialogueList[nextIndex];
        } else
        {
            return dialoges.dialogueList[nextIndex];
        }
    }
}
