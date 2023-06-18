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
        //���ֲ��Ų���
        EventHandler.ClickUIAudioEvent += OnClickUIAudio; //�Ի��� ��ʾ�� �����
        EventHandler.ClickSumAudioEvent += OnClickSumAudio;//�����¼
        EventHandler.ClickMenuBtnAudioEvent += OnMenuBtnAudio;//�����水ť���
        EventHandler.HoverBtnAudioEvent += OnHoverBtnAudio; //���������ť��Ч
        EventHandler.ClickDishAudioEvent += ClickChoicePlay;//ʳ�׽����� 

        //�������Ʋ���
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
        EventHandler.ClickDishAudioEvent -= ClickChoicePlay;//ʳ�׽����� 

        //���ֿ��Ʋ���
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
