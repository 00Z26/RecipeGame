using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public GameObject dialogueImage;
    public TMP_Text textBox;
    private void OnEnable()
    {
        EventHandler.ShowDialogueEvent += onShowDialogueEvent;
    }
    private void OnDisable()
    {
        EventHandler.ShowDialogueEvent -= onShowDialogueEvent;
    }

    private void onShowDialogueEvent(string dialogue)
    {
        if (dialogue != string.Empty)
            dialogueImage.SetActive(true);
        else
            dialogueImage.SetActive(false);
        textBox.text = dialogue;
    }
}
