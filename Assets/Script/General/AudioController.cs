using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioSource clickChoiceAudio;
    public AudioSource clickUiAudio;
    public AudioSource clickSumAudio;
    public AudioSource clickMenuAudio;
    public AudioSource hoverBtnAudio;

    public AudioMixer audioMixer;
    public GameObject volumeSetWin;

    private void OnEnable()
    {
        //音乐播放部分
        EventHandler.ClickUIAudioEvent += OnClickUIAudio; //对话框 提示框 结算框
        EventHandler.ClickSumAudioEvent += OnClickSumAudio;//结算记录
        EventHandler.ClickMenuBtnAudioEvent += OnMenuBtnAudio;//主界面按钮点击
        EventHandler.HoverBtnAudioEvent += OnHoverBtnAudio; //鼠标悬浮按钮音效
        EventHandler.ClickDishAudioEvent += ClickChoicePlay;//食谱界面点击 

        //音量控制部分
        EventHandler.OpenVolumeSettingEvent += ShowVolumeWin;
        EventHandler.OpenVolumeSettingEvent += SyncMainVolumeVal;
        EventHandler.OpenVolumeSettingEvent += SyncBGMVolumeVal;
        EventHandler.OpenVolumeSettingEvent += SyncUIVolumeVal;

        EventHandler.OpenMenuVolumeSettingEvent += SyncMainVolumeVal;
        EventHandler.OpenMenuVolumeSettingEvent += SyncBGMVolumeVal;
        EventHandler.OpenMenuVolumeSettingEvent += SyncUIVolumeVal;


        EventHandler.ChangeMainAudioVolumeEvent += OnChangeMainVol;
        EventHandler.ChangeBgAudioVolumeEvent += OnChangeBgVol;
        EventHandler.ChangeBgAudioVolumeEvent += OnChangeUIVol;

    }



    private void OnDisable()
    {
        EventHandler.ClickUIAudioEvent -= OnClickUIAudio;
        EventHandler.ClickSumAudioEvent -= OnClickSumAudio;
        EventHandler.ClickMenuBtnAudioEvent -= OnMenuBtnAudio;
        EventHandler.HoverBtnAudioEvent -= OnHoverBtnAudio;
        EventHandler.ClickDishAudioEvent -= ClickChoicePlay;//食谱界面点击 

        //音乐控制部分
        EventHandler.OpenVolumeSettingEvent -= ShowVolumeWin;
        EventHandler.OpenVolumeSettingEvent -= SyncMainVolumeVal;
        EventHandler.OpenVolumeSettingEvent -= SyncBGMVolumeVal;
        EventHandler.OpenVolumeSettingEvent -= SyncUIVolumeVal;

        EventHandler.OpenMenuVolumeSettingEvent -= SyncMainVolumeVal;
        EventHandler.OpenMenuVolumeSettingEvent -= SyncBGMVolumeVal;
        EventHandler.OpenMenuVolumeSettingEvent -= SyncUIVolumeVal;


        EventHandler.ChangeMainAudioVolumeEvent -= OnChangeMainVol;
        EventHandler.ChangeBgAudioVolumeEvent -= OnChangeBgVol;
        EventHandler.ChangeBgAudioVolumeEvent -= OnChangeUIVol;




    }


    private void ShowVolumeWin()
    {
        volumeSetWin.SetActive(true);
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

    private void OnChangeMainVol(float amount)
    {
        //Debug.Log(amount);
        audioMixer.SetFloat("MainVolume", amount * 100 - 80);
    }

    private void SyncMainVolumeVal()
    {
        float volume;
        audioMixer.GetFloat("MainVolume",out volume);
        EventHandler.CallSyncMainVolumeEvent(volume);
    }
    private void OnChangeBgVol(float amount)
    {
        audioMixer.SetFloat("BGMVolume", amount * 100 - 80);
    }
    private void SyncBGMVolumeVal()
    {
        float volume;
        audioMixer.GetFloat("BGMVolume", out volume);
        EventHandler.CallSyncBGMVolumeEvent(volume);
    }

    private void OnChangeUIVol(float amount)
    {
        audioMixer.SetFloat("UIVolume", amount * 100 - 80);
    }
    private void SyncUIVolumeVal()
    {
        float volume;
        audioMixer.GetFloat("UIVolume", out volume);
        EventHandler.CallSyncUIVolumeEvent(volume);
    }
}
