using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource clickChoiceAudio;
    public AudioSource clickUiAudio;
    public AudioSource clickSumAudio;
    public AudioSource clickMenuAudio;
    public AudioSource hoverBtnAudio;

    private void OnEnable()
    {
        EventHandler.ClickUIAudioEvent += OnClickUIAudio; //�Ի��� ��ʾ�� �����
        EventHandler.ClickSumAudioEvent += OnClickSumAudio;//�����¼
        EventHandler.ClickMenuBtnAudioEvent += OnMenuBtnAudio;//�����水ť���
        EventHandler.HoverBtnAudioEvent += OnHoverBtnAudio; //���������ť��Ч
        EventHandler.ClickDishAudioEvent += ClickChoicePlay;//ʳ�׽����� 
    }
    private void OnDisable()
    {
        EventHandler.ClickUIAudioEvent -= OnClickUIAudio;
        EventHandler.ClickSumAudioEvent -= OnClickSumAudio;
        EventHandler.ClickMenuBtnAudioEvent -= OnMenuBtnAudio;
        EventHandler.HoverBtnAudioEvent -= OnHoverBtnAudio;
        EventHandler.ClickDishAudioEvent -= ClickChoicePlay;//ʳ�׽����� 



    }

    //�Ի���ѡ�����Ч
    public void ClickChoicePlay()
    {
        clickChoiceAudio.Play();
    }
    
    private void OnClickUIAudio()
    {
        clickUiAudio.Play();
    }

    private void OnClickSumAudio()
    {
        clickSumAudio.Play();
    }

    private void OnMenuBtnAudio()
    {
        clickMenuAudio.Play();
    }

    private void OnHoverBtnAudio()
    {
        hoverBtnAudio.Play();
    }


}
