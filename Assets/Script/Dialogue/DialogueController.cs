using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueController : MonoBehaviour
{
    //这个脚本挂在每个可对话npc上
    public float YMoveDis;

    public void ShowDialogue()
    {   //获取该显示的那句话 or 两个选项
        //分情况传值到UI
        EventHandler.CallShowDialogueEvent("hi", YMoveDis);
        //相当于只有对话传空值时，才会关闭对话框
    }
}
