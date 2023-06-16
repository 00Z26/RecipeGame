using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InGameMenu : MonoBehaviour
{
    public GameObject setting;
    public bool isSetting;
    // Start is called before the first frame update
    void Start()
    {
       PlayerInputControl inputControl = new PlayerInputControl();
        //inputControl.Gameplay.Cancel.started += Setting;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Keyboard.current.escapeKey.wasPressedThisFrame)
        //{
        //    if(isSetting)
        //    {
        //        setting.SetActive(false);
        //        isSetting = false;
        //    }
        //    if(!isSetting)
        //    {
        //        setting.SetActive(true);
        //        isSetting = true;
        //    }
        //}

    }
    public void Setting()
    {
        if (isSetting)
        {
            setting.SetActive(false);
            isSetting = false;
        }
        if (!isSetting)
        {
            setting.SetActive(true);
            isSetting = true;
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
