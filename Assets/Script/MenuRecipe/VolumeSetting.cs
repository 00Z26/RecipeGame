using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    public Slider mainVolume;
    public Slider bgVolume;
    public Slider UIVolume;

    //public GameObject audioManager;
    // Start is called before the first frame update
    void Start()
    {
        //AudioController controller = audioManager.GetComponent<AudioController>();
        mainVolume.onValueChanged.AddListener((amount) => EventHandler.CallChangeMainAudioVol(amount));
        bgVolume.onValueChanged.AddListener((amount) => EventHandler.CallChangeBgAudioVol(amount));
        UIVolume.onValueChanged.AddListener((amount) => EventHandler.CallChangeUIAudioVol(amount));

    }
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
