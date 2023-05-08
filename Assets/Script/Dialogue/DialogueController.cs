using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueController : MonoBehaviour
{
    //这个脚本挂在每个可对话npc上

    public void ShowDialogue()
    {
        EventHandler.CallShowDialogueEvent("hi");
    }
}
