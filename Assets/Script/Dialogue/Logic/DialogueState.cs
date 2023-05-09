using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState : MonoBehaviour
{   //挂载在每个可对话蔬菜上
    //获取蔬菜的对话状态

    public bool isDialogueOnState; //从UI处获取，当前
    public bool hasAutoDialogue;//是否已进行过自动对话

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
            //设置为下次对话的起始
            index = 0;
            return index;
        }
        else
        {
            return index;
        }
    }
}
