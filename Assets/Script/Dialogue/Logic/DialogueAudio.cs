using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAudio : MonoBehaviour
{
    public AudioSource roomAudio;
    public AudioSource dialogueAudio;
    // Start is called before the first frame update

    private void OnEnable()
    {
        EventHandler.UpdateDialogueState += OnDialogueAudio;
        EventHandler.ExitDialogueState += OffDialogueAudio;
    }
    private void OnDisable()
    {
        EventHandler.UpdateDialogueState -= OnDialogueAudio;
        EventHandler.ExitDialogueState -= OffDialogueAudio;


    }

    private void OnDialogueAudio(bool arg1, float arg2)
    {
        roomAudio.mute = true;
        dialogueAudio.mute = false;
    }
    private void OffDialogueAudio(bool obj)
    {
        roomAudio.mute = false;
        dialogueAudio.mute = true;
    }


}
