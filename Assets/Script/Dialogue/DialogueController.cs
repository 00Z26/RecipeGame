using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueController : MonoBehaviour
{
    //����ű�����ÿ���ɶԻ�npc��

    public void ShowDialogue()
    {
        EventHandler.CallShowDialogueEvent("hi");
    }
}
