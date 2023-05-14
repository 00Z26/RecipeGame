using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueController : MonoBehaviour
{
    //����ű�����ÿ���ɶԻ�npc��
    public float YMoveDis;
    public DialogueData dialoges;
    public DialogueData autoDialoges;
    public int nextIndex;
    public DialogueStruct currentDialogue;
    public string content;
    public string choice0;
    public string choice1;
    public string choice2;
    

    
    private DialogueState dialogueState;
    private Sprite speakerImage;
    private GameObject autoObj;
    private List<int> choiceNextIndex;
    private List<string> choices;


    private void Awake()
    {

        nextIndex = 0;
        dialogueState = GetComponent<DialogueState>();
        autoObj = null;
        choiceNextIndex = new List<int>();
        choices = new List<string>();

    }
    public void ShowDialogue(bool isAuto, GameObject player)//���player��ǰû�õ���Ӧ�û���state���ȡ
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
        //�������ѡ����ز����ȽϺã�ǰ�����ݶ�ȡ��,��controller��ô����¼���ѡ��
        if (currentDialogue.choices.Count != 0 )
        {
            GetChoiceSpilt();
            EventHandler.CallUpdateChoicesEvent(choices);
        }





        //��nextIndex����״̬���ж������ظ�ֵ ����Ӧ��elif ��û��ѡ���ʱ����д���
        if (nextIndex == -1 && currentDialogue.choices.Count == 0)
        {
            if(isAuto == true)
            {
                //�޸��������auto���Ѵ���״̬�����Ѵ�����Ϊftrue
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

    private void GetChoiceSpilt()
    {
        foreach (var choice in currentDialogue.choices)
        {            
            if(choice != "")
            {
                string[] temp = choice.Split("+");
                
                choices.Add(temp[0]);
                Debug.Log(choices[0]);
                choiceNextIndex.Add(int.Parse(temp[1]));
            }
        }
    }
}
