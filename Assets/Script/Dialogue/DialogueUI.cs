using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public GameObject dialogueImage;
    public TMP_Text textBox;
    public Image headImg;
    public bool isDialogueOn;


    private void OnEnable()
    {
        EventHandler.ShowDialogueEvent += onShowDialogueEvent;
    }
    private void OnDisable()
    {
        EventHandler.ShowDialogueEvent -= onShowDialogueEvent;
    }

    private void onShowDialogueEvent(string dialogue, float YMoveDis,Sprite speakerImg,GameObject autoObj)
    {
        if (dialogue != null)
        {
            isDialogueOn = true;
            headImg.sprite = speakerImg;
            dialogueImage.SetActive(true);
            //触发相机下移事件
            EventHandler.CallUpdateDialogueState(isDialogueOn, YMoveDis);
        }

        else
        {
            isDialogueOn = false;
            dialogueImage.SetActive(false);
            headImg.sprite = null;
            autoObj?.SetActive(false);
            //触发相机归位事件
            EventHandler.CallExitDialogueState(isDialogueOn);
        }

        textBox.text = dialogue;
    }
}
