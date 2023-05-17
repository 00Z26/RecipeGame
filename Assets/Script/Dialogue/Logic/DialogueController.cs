using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class DialogueController : MonoBehaviour
{
    //����ű�����ÿ���ɶԻ�npc��
    public float YMoveDis;
    public DialogueData dialoges;
    public DialogueData autoDialoges;
    public int nextIndex;
    public DialogueStruct currentDialogue;
    public string content;
    //public string choice0;
    //public string choice1;
    //public string choice2;
    

    
    private DialogueState dialogueState;
    private Sprite speakerImage;
    private GameObject autoObj;

    [SerializeField]
    private List<int> choiceNextIndex;

    private List<string> choices;
    private List<int> choiceOperation;
    private int buttonVal;


    private void Awake()
    {

        nextIndex = 0;
        buttonVal = -1;
        dialogueState = GetComponent<DialogueState>();
        autoObj = null;
        choiceNextIndex = new List<int>();
        choiceOperation = new List<int>();
        choices = new List<string>();

    }


    private void OnEnable()
    {
        
        EventHandler.SendButtonValEvent += OnSendButtonValEvent;
    }
    private void OnDisable()
    {
        
        EventHandler.SendButtonValEvent -= OnSendButtonValEvent;
    }

    private void OnSendButtonValEvent(int val)
    {
        buttonVal = val;
        ButtonOperation();
    }

    private void ButtonOperation()
    {
        
        if (choiceNextIndex.Count != 0 && choiceNextIndex[buttonVal] > 0)
        {
            //ִ��չʾ��һ��Ĳ���
            
            nextIndex = choiceNextIndex[buttonVal];
            this.ShowDialogue(false);
            Debug.Log("����ѡ����һ��Ի��¼�");

        }

        if (choiceNextIndex.Count != 0 && choiceNextIndex[buttonVal] == -2)
        {
            //nextIndex = -1;
            //this.ShowDialogue(false);
            //��������
            EventHandler.CallTriggerChangeEvent(choiceOperation[buttonVal]);
        }

        if(choices.Count != 0 && choiceNextIndex[buttonVal] == -3)
        {
            ////nextIndex = -1;
            ////this.ShowDialogue(false);
            Debug.Log("ѡ��ִ�и���");
            //������Ӧnpc����
            EventHandler.CallTriggerFollowEvent(choiceOperation[buttonVal]);
        }
    }




    public void ShowDialogue(bool isAuto, GameObject player = null)//���player��ǰû�õ���Ӧ�û���state���ȡ
    {   //��ȡ����ʾ���Ǿ仰 or ����ѡ��
        //�������ݿ�͵�һ����ж�
        if(nextIndex == 0)
        {
            currentDialogue =  dialogueState.GetNextDialogueStart();
            if(currentDialogue == null)
                throw new Exception("δ�ҵ���Ӧ��һ��");
            if (isAuto == false)
                this.GetComponent<DialogueState>().conversations++;
            content = currentDialogue.content;
            nextIndex = currentDialogue.nextIndex;
            speakerImage = currentDialogue.pic;
        } 
        //����0��ʱ��ֱ�Ӱ���index����һ��
        else if(nextIndex != -1)
        {   
            currentDialogue = getDialoguesContent(isAuto);
            content = currentDialogue.content;
            nextIndex = currentDialogue.nextIndex;
            speakerImage = currentDialogue.pic;
        }
        else if(nextIndex == -1)
        {
            content = null;
        }

        //�������������ݣ����ƫ�ƣ�ͷ���Զ��Ի�����رգ���Ҫ��UI�ر�ʱ��ֹͣ�Զ���⣩
        //UI��ʾ��������
        EventHandler.CallShowDialogueEvent(content, YMoveDis, speakerImage, autoObj);
        //�������ѡ����ز���
        if (currentDialogue.choices.Count != 0 && nextIndex != -1 )
        {
            choices = new List<string>();
            choiceNextIndex = new List<int>();
            choiceOperation = new List<int>();
            
            GetChoiceSpilt();
            EventHandler.CallUpdateChoicesEvent(choices);
        }

        //��nextIndex����״̬���ж������ظ�ֵ ����Ӧ��elif ��û��ѡ���ʱ����д���
        if (nextIndex == -1 )//&& currentDialogue.choices.Count == 0)
        {
            if(isAuto == true)
            {
                //�޸��������auto���Ѵ���״̬�����Ѵ�����Ϊtrue
                //��ȡ�Զ�����������
                autoObj = this.gameObject.transform.GetChild(0).gameObject;
                dialogueState.hasAutoDialogue = true;
             
            }
            nextIndex = dialogueState.resetDialogueIndex(nextIndex); //��index��ԭΪ0�����ڶ�״̬ת�������ڱ��λ���´���ʼ
        }
        
    }



    //���ݵ�ǰ�Ի�״̬��ȡ�����ζԻ�����ʼ��Ŀ
    private DialogueStruct getFirstDialogue()
    {
        foreach(var item in dialoges.dialogueList)
        {
            if (dialogueState.CheckFirstDialogue(item)){
                return item;
            }
        }
        return null;
    }
    
    
    //�����޸ĵ�index��ȡ��һ���Ի���index
    private DialogueStruct getDialoguesContent(bool isAuto)
    {
        if (isAuto)
        {
            return autoDialoges.dialogueList[nextIndex];
        } else
        {
            Debug.Log(dialoges.dialogueList[nextIndex].content);
            return dialoges.dialogueList[nextIndex];
            
        }
    }
    //�ָ�ѡ�����һ��
    private void GetChoiceSpilt()
    {
        foreach (var choice in currentDialogue.choices)
        {            
            if(choice != "")
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
    //��ȡ��button�Ĵ�ֵ


    //private void GetChoiceOperation()
    //{
    //    foreach(var )
    //}
}
