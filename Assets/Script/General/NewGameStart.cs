using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGameStart : MonoBehaviour
{
    public string from;
    public string to;
    public Vector3 playerPos;

    public Slider mainVolume;
    public Slider bgVolume;
    public Slider UIVolume;
    //public TMP_Text time;
    //public TMP_Text predict;

    private void OnEnable()
    {
        EventHandler.SyncMainVolumeEvent += OnChangeMainSlider;
        EventHandler.SyncBGMVolumeEvent += OnChangeBGMSlider;
        EventHandler.SyncUIVolumeEvent += OnChangeUISlider;


    }
    private void OnDisable()
    {
        EventHandler.SyncMainVolumeEvent -= OnChangeMainSlider;
        EventHandler.SyncBGMVolumeEvent -= OnChangeBGMSlider;
        EventHandler.SyncUIVolumeEvent -= OnChangeUISlider;



    }



    private void Start()
    {
        //time.enabled = false;
        //predict.enabled = false;
        //SceneManager.LoadScene(0);
        mainVolume.onValueChanged.AddListener((amount) => EventHandler.CallChangeMainAudioVol(amount));
        bgVolume.onValueChanged.AddListener((amount) => EventHandler.CallChangeBgAudioVol(amount));
        UIVolume.onValueChanged.AddListener((amount) => EventHandler.CallChangeUIAudioVol(amount));

    }
    public void TriggerSwapStart()
    {
        from = "Menu";
        to = "Outside";

        GameObject player = GameObject.FindWithTag("Player");  
        player.transform.position = new Vector3(4.78999996f, 1.46000004f, 0);
        
        EventHandler.CallTriggerSwapNewGameEvent(from, to, playerPos);
    }

    public void TriggerShowRecipe()
    {
        from = "Menu";
        to = "RecipeShow";
        EventHandler.CallTriggerShowRecipeEvent(from, to, playerPos);
    }

    public void TriggerContinue()
    {
        from = "Menu";
        to = "Outside";

        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = new Vector3(5.09000015f, -4.17999983f, 0);

        EventHandler.CallTriggerContinue(from, to, playerPos);
    }

    public void Exit()
    {
        Application.Quit();

    }

    public void PlayMenuAudio()
    {
        EventHandler.CallPlayMenuBtnAudio();
    }

    public void OpenAudioSetting()
    {
        EventHandler.CallOpenMenuVolumeSetting();
    }

    private void OnChangeMainSlider(float val)
    {
        mainVolume.value = (val + 80) / 100;

    }
    private void OnChangeBGMSlider(float val)
    {
        bgVolume.value = (val + 80) / 100;
    }
    private void OnChangeUISlider(float val)
    {
        UIVolume.value = (val + 80) / 100;
    }
}
