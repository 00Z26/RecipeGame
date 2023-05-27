using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Linq;

public class DialogueController : MonoBehaviour
{
    //这个脚本挂在每个可对话npc上
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
            //执行展示下一句的操作
            
            nextIndex = choiceNextIndex[buttonVal];
            this.ShowDialogue(false);
            Debug.Log("结束选项下一句对话事件");

        }

        if (choiceNextIndex.Count != 0 && choiceNextIndex[buttonVal] == -2)
        {
            //nextIndex = -1;
            this.ShowDialogue(false);
            //触发夺舍
            EventHandler.CallTriggerChangeEvent(choiceOperation[buttonVal]);
        }

        if(choices.Count != 0 && choiceNextIndex[buttonVal] == -3)
        {
            ////nextIndex = -1;
            this.ShowDialogue(false);
            Debug.Log("选项执行跟随");
            //触发对应npc跟随
            EventHandler.CallTriggerFollowEvent(choiceOperation[buttonVal]);
        }
    }




    public void ShowDialogue(bool isAuto, GameObject player = null)//这个player当前没用到，应该会在state里获取
    {   //获取该显示的那句话 or 两个选项
        //加载数据库和第一句的判断
        if(nextIndex == 0)
        {
            currentDialogue =  dialogueState.GetNextDialogueStart();
            if(currentDialogue == null)
                throw new Exception("未找到对应第一句");
            if (isAuto == false)
                Debug.Log("增加了次数");
                this.GetComponent<DialogueState>().conversations++;
            textContent[0] = currentDialogue.chatPartnerName;
            textContent[1] = currentDialogue.content;
            nextIndex = currentDialogue.nextIndex;
            speakerImage = GetDialogueImage();
        } 
        //不是0的时候，直接按照index找下一句
        else if(nextIndex != -1)
        {   
            currentDialogue = getDialoguesContent(isAuto);
            textContent[0] = currentDialogue.chatPartnerName;
            textContent[1] = currentDialogue.content;
            nextIndex = currentDialogue.nextIndex;
            speakerImage = GetDialogueImage();
        }
        else if(nextIndex == -1)
        {
            textContent = null;
        }
        //触发执行动画的事件
        ExcuAnimObj();

        //参数：剧情内容，相机偏移，头像，自动对话刚体关闭（需要在UI关闭时，停止自动检测）
        //UI显示剧情内容
        EventHandler.CallShowDialogueEvent(textContent, YMoveDis, speakerImage, autoObj);
        //在这添加选项相关操作
        if (currentDialogue.choices != "" && nextIndex != -1)
        {
            choices = new List<string>();
            choiceNextIndex = new List<int>();
            choiceOperation = new List<int>();

            GetChoiceSpilt();
            EventHandler.CallUpdateChoicesEvent(choices);
        }

        //对nextIndex根据状态或判断条件重赋值 这里应该elif 在没有选项的时候进行触发
        if (nextIndex == -1 )//&& currentDialogue.choices.Count == 0)
        {
            if(isAuto == true)
            {
                //修改这个物体auto的已触发状态，把已触发改为true
                //获取自动触发的物体
                autoObj = this.gameObject.transform.GetChild(0).gameObject;
                dialogueState.hasAutoDialogue = true;
             
            }
            nextIndex = dialogueState.resetDialogueIndex(nextIndex); //将index复原为0，由于多状态转换不能在本次获得下次起始
        }
        
    }



    
    
    //根据修改的index获取下一条对话的index
    private DialogueStruct getDialoguesContent(bool isAuto)
    {
        if (isAuto)
        {
            return autoDialoges.dialogueList[nextIndex];
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
        Debug.Log("没找到对应的下一句");
        return -1;
    }
    //分割选项的下一步
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

                //把操作那步的对象拆出来
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

    //资源文件下图片转换
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
        //相当于放在根目录下面
        //Sprite img = Resources.Load("pic/" + temp +"/"+temp) as Sprite;
        Texture2D texture2D = Resources.Load("pic/" + temp) as Texture2D;
        Sprite img = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
        Debug.Log(texture2D.name);
        return img;//获取对应路径下资源
        //Resources.Load<Sprite>("绝对路径");
    }

    private void ExcuAnimObj()
    {
        
        if(currentDialogue.animiation != String.Empty)
        {
            string[] animArray = currentDialogue.animiation.Split(",");
            //
            List<string> objList = new List<string>();
           List<string> animNameList = new List<string>();

            foreach (string str in animArray)
            {
                Debug.Log(str);
                string[] temp = str.Split("_");
                if(temp[0] == "%s")
                {
                    temp[0] = dialogueState.npcData.GetPlayerName(dialogueState.npcData.controllerIndex);
                }
               
                objList.Add(temp[0]);
                animNameList.Add(temp[1]);
            }

            //对单一动画变量的切割
            EventHandler.CallExcuDialogueAnimEvent(objList,animNameList,animArray.ToList<string>());
        }
        
    }

}
