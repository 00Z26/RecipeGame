using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject setting;
    public bool isSetting = false;
    // Start is called before the first frame update

    private void Awake()
    {
        PlayerInputControl inputControl = new PlayerInputControl();
        inputControl.Gameplay.Cancel.started += Setting;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && SceneManager.GetSceneAt(1).name != "Menu")
        {
            if (isSetting)
            {
                //Debug.Log("关闭");
                setting.SetActive(false);
                isSetting = false;
            }else if (!isSetting)
            {
                //Debug.Log("开启");
                setting.SetActive(true);
                isSetting = true;
            }
        }

    }
    public void OpenVolumeSet()
    {
        EventHandler.CallOpenVolumeSetting();
    }
    public void Setting(InputAction.CallbackContext obj)
    {
        Debug.Log("ESC");
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
        Debug.Log("退出游戏");
        Application.Quit();
    }
}
