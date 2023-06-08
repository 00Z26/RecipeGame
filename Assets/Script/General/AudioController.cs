using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource clickChoiceAudio;
    public AudioSource clickUiAudio;

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

    //对话框选项播放音效
    public void ClickChoicePlay()
    {
        clickChoiceAudio.Play();
    }
}
