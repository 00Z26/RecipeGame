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

    //�Ի���ѡ�����Ч
    public void ClickChoicePlay()
    {
        clickChoiceAudio.Play();
    }
}
