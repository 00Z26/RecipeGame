using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueController : MonoBehaviour
{
    //这个脚本挂在每个可对话npc上
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
    public void ShowDialogue(bool isAuto, GameObject player)//这个player当前没用到，应该会在state里获取
    {   //获取该显示的那句话 or 两个选项
        //分情况传值到UI
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

      


        //参数：剧情内容，相机偏移，头像，自动对话刚体关闭（需要在UI关闭时，停止自动检测）
        //UI显示剧情内容
        EventHandler.CallShowDialogueEvent(content, YMoveDis, speakerImage, autoObj);
        //在这添加选项相关操作比较好，前面内容读取完,从controller获得触发事件的选项
        if (currentDialogue.choices.Count != 0 )
        {
            GetChoiceSpilt();
            EventHandler.CallUpdateChoicesEvent(choices);
        }





        //对nextIndex根据状态或判断条件重赋值 这里应该elif 在没有选项的时候进行触发
        if (nextIndex == -1 && currentDialogue.choices.Count == 0)
        {
            if(isAuto == true)
            {
                //修改这个物体auto的已触发状态，把已触发改为ftrue
                //获取自动触发的物体
                autoObj = this.gameObject.transform.GetChild(0).gameObject;
                dialogueState.hasAutoDialogue = true;
             
            }
            nextIndex = dialogueState.getNextDialogueIndex(nextIndex); //将index复原为0，由于多状态转换不能在本次获得下次起始
        }
        
    }
    //根据当前对话状态获取到本次对话的起始条目
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
    
    
    //根据修改的index获取下一条对话的index
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
