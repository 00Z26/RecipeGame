using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public GameObject dialogueImage;
    public TMP_Text textBox;
    public bool isDialogueOn;

    private void OnEnable()
    {
        EventHandler.ShowDialogueEvent += onShowDialogueEvent;
    }
    private void OnDisable()
    {
        EventHandler.ShowDialogueEvent -= onShowDialogueEvent;
    }

    private void onShowDialogueEvent(string dialogue, float YMoveDis)
    {
        if (dialogue != string.Empty)
        {
            isDialogueOn = true;
            dialogueImage.SetActive(true);
            //触发相机下移事件
        }

        else
        {
            isDialogueOn = false;
            dialogueImage.SetActive(false);
            //触发相机归位事件
        }

        textBox.text = dialogue;
    }
}
