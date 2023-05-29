using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StartTip : MonoBehaviour
{
    public Image imageBg;
    public TMP_Text text;

    public string tip;
    // Start is called before the first frame update
    private void OnEnable()
    {
        EventHandler.ControllTipEvent += show;
    }
    private void OnDisable()
    {
        EventHandler.ControllTipEvent -= show;
    }

    // Update is called once per frame
    void Update()
    {
        if(imageBg)
        {
            if(Mouse.current.leftButton.wasPressedThisFrame)
            {
                imageBg.gameObject.SetActive(false);
            }
        }
    }

    public void show()
    {
        imageBg.gameObject.SetActive(true);
        text.text = tip;
    }
}
