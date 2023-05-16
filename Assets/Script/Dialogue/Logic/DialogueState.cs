using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState : MonoBehaviour
{   //挂载在每个可对话蔬菜上
    //获取蔬菜的对话状态

    public bool isDialogueOnState; //从UI处获取，当前
    public bool hasAutoDialogue;//是否已进行过自动对话
    //public bool hasChanged;//是否已被夺舍过
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

    //获取player的object,用来判断小队内人员
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
            //设置为下次对话的起始
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
            //一个判断小队成员内容是否吻合的函数
            return true;
        }
        return false;
    }


}
