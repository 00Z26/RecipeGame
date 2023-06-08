using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TipButton : MonoBehaviour
{
    public GameObject tipButton;
    public bool isShowButton;

    private void OnEnable()
    {
        EventHandler.ShowTipButtonEvent += OnChangeButtonState;
       
    }
    private void OnDisable()
    {
        EventHandler.ShowTipButtonEvent -= OnChangeButtonState;
    }


    // Update is called once per frame
    void Update()
    {
        if((isShowButton && Keyboard.current.eKey.wasPressedThisFrame) || !isShowButton)  //离开范围或者触发过按钮
        {
            if(isShowButton)
                this.GetComponent<AudioSource>().Play();
            isShowButton = false;
            tipButton.SetActive(false);
        }
        if (isShowButton)
        {
            tipButton.SetActive(true);
            if (tipButton.transform.parent.localScale.x < 0)
            {
                tipButton.transform.localScale = new Vector3(-Mathf.Abs(tipButton.transform.localScale.x), tipButton.transform.localScale.y, tipButton.transform.localScale.z);
            }else
            {
                tipButton.transform.localScale = new Vector3(Mathf.Abs(tipButton.transform.localScale.x), tipButton.transform.localScale.y, tipButton.transform.localScale.z);

            }
        }
    }


    private void OnChangeButtonState(bool obj)
    {
        isShowButton = obj;
    }

}
