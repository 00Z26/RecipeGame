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
        EventHandler.ClickUIAudioEvent += OnClickUIAudio; //对话框 提示框 结算框
        EventHandler.ClickSumAudioEvent += OnClickSumAudio;//结算记录
        EventHandler.ClickMenuBtnAudioEvent += OnMenuBtnAudio;//主界面按钮点击
        EventHandler.HoverBtnAudioEvent += OnHoverBtnAudio; //鼠标悬浮按钮音效
        EventHandler.ClickDishAudioEvent += ClickChoicePlay;//食谱界面点击 
    }
    private void OnDisable()
    {
        EventHandler.ClickUIAudioEvent -= OnClickUIAudio;
        EventHandler.ClickSumAudioEvent -= OnClickSumAudio;
        EventHandler.ClickMenuBtnAudioEvent -= OnMenuBtnAudio;
        EventHandler.HoverBtnAudioEvent -= OnHoverBtnAudio;
        EventHandler.ClickDishAudioEvent -= ClickChoicePlay;//食谱界面点击 



    }

    //对话框选项播放音效
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
