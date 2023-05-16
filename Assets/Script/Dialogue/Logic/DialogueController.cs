using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


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

    [DllImport("user32.dll", EntryPoint = "keybd_event")]
    public static extern void keybd_event(

        byte bVk,    //�����ֵ ��Ӧ������ascll��ʮ����ֵ  

        byte bScan,// 0  

        int dwFlags,  //0 Ϊ���£�1��ס��2Ϊ�ͷ�  

        int dwExtraInfo  // 0  

    );

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
            //Debug.Log(nextIndex);
            //keybd_event(69, 0, 0, 0);
            //keybd_event(101, 0, 0, 0);
            Debug.Log("����ѡ����һ��Ի��¼�");

        }

        if (choiceNextIndex.Count != 0 && choiceNextIndex[buttonVal] == -2)
        {
            nextIndex = -1;
            this.ShowDialogue(false);
            //��������
            EventHandler.CallTriggerChangeEvent(choiceOperation[buttonVal]);
        }
    }




    public void ShowDialogue(bool isAuto, GameObject player = null)//���player��ǰû�õ���Ӧ�û���state���ȡ
    {   //��ȡ����ʾ���Ǿ仰 or ����ѡ��
        //�������ֵ��UI
        if(nextIndex != -1)
        {   
            currentDialogue = getDialoguesContent(isAuto);
            content = currentDialogue.content;
            nextIndex = currentDialogue.nextIndex;
            speakerImage = currentDialogue.pic;
        }
        else
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
            //����list Ҳ��Ҫ���
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
            nextIndex = dialogueState.getNextDialogueIndex(nextIndex); //��index��ԭΪ0�����ڶ�״̬ת�������ڱ��λ���´���ʼ
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
