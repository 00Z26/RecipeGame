using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public GameObject dialogueImage;
    public TMP_Text textBox;
    public TMP_Text nameText;
    public Image headImg;
    public GameObject dialogueChoices;
    public bool isDialogueOn;
   

    private void OnEnable()
    {
        EventHandler.ShowDialogueEvent += onShowDialogueEvent;
        EventHandler.UpdateChoicesEvent += onUpdateChoicesEvent;
    }


    private void OnDisable()
    {
        EventHandler.ShowDialogueEvent -= onShowDialogueEvent;
        EventHandler.UpdateChoicesEvent -= onUpdateChoicesEvent;
    }

    private void onShowDialogueEvent(string[] dialogue, float YMoveDis,Sprite speakerImg,GameObject autoObj)
    {
        if (dialogue != null)
        {
            isDialogueOn = true;
            headImg.sprite = speakerImg;
            dialogueImage.SetActive(true);
            //触发相机下移事件
            EventHandler.CallUpdateDialogueState(isDialogueOn, YMoveDis);
        }

        else
        {
            isDialogueOn = false;
            dialogueImage.SetActive(false);
            headImg.sprite = null;
            autoObj?.SetActive(false);
            //触发相机归位事件
            EventHandler.CallExitDialogueState(isDialogueOn);
        }
        nameText.text = dialogue?[0];
        textBox.text = dialogue?[1].Replace("\\n", "\n");
    }

    private void onUpdateChoicesEvent(List<string> choices)
    {
        dialogueChoices.SetActive(true);
        for (int i = 0;i < choices.Count;i++)
        {
            
            if(choices[i] != "")
            {
                
                GameObject choice = dialogueChoices.transform.GetChild(i).gameObject;
               
                choice.GetComponentInChildren<TMP_Text>().text = choices[i];
                //Debug.Log(choice.GetComponentInChildren<TMP_Text>().name);
                choice.SetActive(true);
            }
        }
        //choices.Clear();
    }

}
