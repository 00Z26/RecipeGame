using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Linq;

public class DialogueController : MonoBehaviour
{
    //����ű�����ÿ���ɶԻ�npc��
    public float YMoveDis;
    public DialogueData dialoges;
    public DialogueData autoDialoges;
    public int nextIndex;
    public DialogueStruct currentDialogue;
    private string[] textContent = new string[2];


    
    private DialogueState dialogueState;
    private Sprite speakerImage;
    private GameObject autoObj;

    [SerializeField]
    private List<int> choiceNextIndex;
    [SerializeField]
    private List<string> choices;

    private List<int> choiceOperation;
    private int buttonVal;
    private DataTools dataTools;


    private void Awake()
    {

        nextIndex = 0;
        buttonVal = -1;
        dialogueState = GetComponent<DialogueState>();
        autoObj = null;
        choiceNextIndex = new List<int>();
        choiceOperation = new List<int>();
        choices = new List<string>();
        dataTools = new DataTools();    
    }


    private void OnEnable()
    {
        
        EventHandler.SendButtonValEvent += OnSendButtonValEvent;
        EventHandler.ExitDialogueState += OnEmptyList;
    }
    private void OnDisable()
    {
        
        EventHandler.SendButtonValEvent -= OnSendButtonValEvent;
        EventHandler.ExitDialogueState -= OnEmptyList;
    }

    private void OnEmptyList(bool obj)
    {
        //�Ի��˳���ʱ����ղ�������
        choices = new List<string>();
        choiceNextIndex = new List<int>();
        choiceOperation = new List<int>();
    }

    private void OnSendButtonValEvent(int val)
    {
        buttonVal = val;
        Debug.Log(val);
        ButtonOperation();
    }

    private void ButtonOperation()
    {
        
        if (choiceNextIndex.Count != 0 && choiceNextIndex[buttonVal] > 0)
        {
            //ִ��չʾ��һ��Ĳ���
            
            nextIndex = choiceNextIndex[buttonVal];
            Debug.Log(nextIndex);
            this.ShowDialogue(false);
            //choiceNextIndex = new List<int>();
            Debug.Log("����ѡ����һ��Ի��¼�");

        }
        if (choiceNextIndex.Count != 0 && choiceNextIndex[buttonVal] == -2)
        {
            //nextIndex = -1;
            this.ShowDialogue(false);
            //��������
            EventHandler.CallTriggerChangeEvent(choiceOperation[buttonVal]);
        }
        if(choiceNextIndex.Count != 0 && choiceNextIndex[buttonVal] == -3)
        {
            ////nextIndex = -1;
            this.ShowDialogue(false);
            Debug.Log("ѡ��ִ�и���");
            //������Ӧnpc����
            EventHandler.CallTriggerFollowEvent(choiceOperation[buttonVal]);
        }
        if(choiceNextIndex.Count != 0 && choiceNextIndex[buttonVal] == -4)
        {
            Debug.Log("ѡ��ִ���л�״̬");
            this.ShowDialogue(false);
            EventHandler.CallDialogueSwapStateEvent(choiceOperation[buttonVal]);
        }
    }




    public void ShowDialogue(bool isAuto, GameObject player = null)//���player��ǰû�õ���Ӧ�û���state���ȡ
    {   //��ȡ����ʾ���Ǿ仰 or ����ѡ��
        //�������ݿ�͵�һ����ж�
        if (nextIndex == -1)
        {
            textContent[0] = null;
            textContent[1] = null;
            //textContent = new string[2];
        }
        else if (nextIndex == 0)
        {   if (!isAuto)
                currentDialogue =  dialogueState.GetNextDialogueStart();
            if (isAuto)
            {
                Debug.Log("�Զ�");
                currentDialogue = dialogueState.GetAutoBegin();
            }
                
            if(currentDialogue == null)
                throw new Exception("δ�ҵ���Ӧ��һ��");
            if (isAuto == false)
                Debug.Log("�����˴���");
                this.GetComponent<DialogueState>().conversations++;
            Debug.Log(this.gameObject.name);
            textContent[0] = currentDialogue.chatPartnerName;
            textContent[1] = currentDialogue.content;
            nextIndex = currentDialogue.nextIndex;
            speakerImage = GetDialogueImage();
        } 
        //����0��ʱ��ֱ�Ӱ���index����һ��
        else if(nextIndex != -1)
        {   
            currentDialogue = getDialoguesContent(isAuto);
            Debug.Log(this.gameObject.name);
            textContent[0] = currentDialogue.chatPartnerName;
            textContent[1] = currentDialogue.content;
            nextIndex = currentDialogue.nextIndex;
            speakerImage = GetDialogueImage();

        }

        //����ִ�ж������¼�
        ExcuAnimObj();

        //�������������ݣ����ƫ�ƣ�ͷ���Զ��Ի�����رգ���Ҫ��UI�ر�ʱ��ֹͣ�Զ���⣩
        //UI��ʾ��������
        EventHandler.CallShowDialogueEvent(textContent, YMoveDis, speakerImage, autoObj);
        //�������ѡ����ز���
        if (currentDialogue.choices != "" && nextIndex != -1)
        {
            choices = new List<string>();
            choiceNextIndex = new List<int>();
            choiceOperation = new List<int>();

            GetChoiceSpilt();
            EventHandler.CallUpdateChoicesEvent(choices);
        }

        //��nextIndex����״̬���ж������ظ�ֵ ����Ӧ��elif ��û��ѡ���ʱ����д���
        if (nextIndex == -1 && currentDialogue.choices == "")
        {
            if(isAuto == true)
            {
                //�޸��������auto���Ѵ���״̬�����Ѵ�����Ϊtrue
                //��ȡ�Զ�����������
                autoObj = this.gameObject.transform.GetChild(0).gameObject;
                dialogueState.hasAutoDialogue = true;
                autoObj.SetActive(false);
                if(dialogueState.npcData.loop == 1)
                {
                    //EventHandler.CallControllTipEvent();
                }
            }
            //choiceNextIndex = new List<int>();
            nextIndex = dialogueState.resetDialogueIndex(nextIndex); //��index��ԭΪ0�����ڶ�״̬ת�������ڱ��λ���´���ʼ
        }
        
    }



    
    
    //�����޸ĵ�index��ȡ��һ���Ի���index
    private DialogueStruct getDialoguesContent(bool isAuto)
    {
        if (isAuto)
        {
            return autoDialoges.dialogueList[GetDialogueListIndex(nextIndex)];
        } else
        {
            //Debug.Log(nextIndex);
            return dialoges.dialogueList[GetDialogueListIndex(nextIndex)] ;

            
        }
    }

    private int GetDialogueListIndex(int tempIndex)
    {
        //Debug.Log(tempIndex);
        foreach(var item in dialoges.dialogueList)
        {
            if((item.index == tempIndex))
            {
                //Debug.Log(dialoges.dialogueList.IndexOf(item));
                return dialoges.dialogueList.IndexOf(item);
            }
        }
        Debug.Log("û�ҵ���Ӧ����һ��");
        return -1;
    }
    //�ָ�ѡ�����һ��
    private void GetChoiceSpilt()
    {
        List<string> choiceList = dataTools.GetChoicesList(currentDialogue.choices);
        foreach (var choice in choiceList)
        {
            if (choice != "")
            {
                string[] temp = choice.Split("+");

                choices.Add(temp[0]);

                choiceNextIndex.Add(int.Parse(temp[1]));

                //�Ѳ����ǲ��Ķ�������
                if (temp.Length > 2)
                {
                    choiceOperation.Add(int.Parse(temp[2]));
                }
                else
                {
                    choiceOperation.Add(-1);
                }

            }
        }
    }

    //��Դ�ļ���ͼƬת��
    private Sprite GetDialogueImage()
    {
        string temp = null;
        string name =  dialogueState.npcData.GetPlayerName(dialogueState.npcData.controllerIndex);
        if(currentDialogue.pic.Contains("%s"))
        {
            temp = currentDialogue.pic.Replace("%s",name);
        } else
        {
            temp = currentDialogue.pic;
        }
        //Debug.Log(temp);
        //�൱�ڷ��ڸ�Ŀ¼����
        //Sprite img = Resources.Load("pic/" + temp +"/"+temp) as Sprite;
        Texture2D texture2D = Resources.Load("pic/" + temp) as Texture2D;
        Sprite img = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
        Debug.Log(texture2D.name);
        return img;//��ȡ��Ӧ·������Դ
        //Resources.Load<Sprite>("����·��");
    }

    private void ExcuAnimObj()
    {
        
        if(currentDialogue.animiation != String.Empty)
        {
            string[] animArray = currentDialogue.animiation.Split(",");
            //
            List<string> objList = new List<string>();
           List<string> animNameList = new List<string>();
            //List<string> aniList = new List<string>();
            foreach (string str in animArray)
            {
                //Debug.Log(str);
                string[] temp = str.Split("_");
                if(temp[0] == "%s")
                {
                    temp[0] = dialogueState.npcData.GetPlayerName(dialogueState.npcData.controllerIndex);
                }
               
                objList.Add(temp[0]);
                animNameList.Add(temp[1]);
            }
            for(int i = 0; i < objList.Count; i++)
            {
              if(animArray[i].Contains("%s"))
                {
                    animArray[i] = animArray[i].Replace("%s", objList[i]);
                    //Debug.Log(animArray[i]);
                } 
            }

            //�Ե�һ�����������и�
            EventHandler.CallExcuDialogueAnimEvent(objList,animNameList,animArray.ToList<string>()); //animArray.ToList<string>()
        }
        
    }

}
