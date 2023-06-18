using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isSetting)
            {
                //Debug.Log("¹Ø±Õ");
                setting.SetActive(false);
                isSetting = false;
            }else if (!isSetting)
            {
                //Debug.Log("¿ªÆô");
                setting.SetActive(true);
                isSetting = true;
            }
        }

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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
