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
    [Header("选项设置")]
    public TMP_Text choice0;
    public TMP_Text choice1;
    public TMP_Text choice2;
    private List<TMP_Text> choiceList = new List<TMP_Text>();

    private void Awake()
    {
        choiceList.Add(choice0);
        choiceList.Add(choice1);
        choiceList.Add(choice2);
    }
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
            
            if(choices[i] != "" && choices[i] != null)
            {
                
                //GameObject choice = dialogueChoices.transform.GetChild(i).gameObject;
               
                //choice.GetComponentInChildren<TMP_Text>().text = choices[i];
                ////Debug.Log(choice.GetComponentInChildren<TMP_Text>().name);
                //choice.SetActive(true);

                choiceList[i].text = choices[i];
                choiceList[i].transform.parent.parent.gameObject.SetActive(true);
                //调整图标位置
                Transform bubble = choiceList[i].transform.parent.parent.Find("Image");
                Debug.Log(bubble.gameObject.name);
                bubble.localPosition = new Vector3(choiceList[i].transform.parent.localPosition.x-50f, bubble.localPosition.y, bubble.localPosition.z); ;
                
            }else
            {
                //GameObject choice = dialogueChoices.transform.GetChild(i).gameObject;
                //choice.SetActive(false);
                choiceList[i].transform.parent.parent.gameObject.SetActive(false);
            }
        }
        choices.Clear();
    }

}
