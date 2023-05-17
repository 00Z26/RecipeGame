using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState : MonoBehaviour
{   //挂载在每个可对话蔬菜上
    //获取蔬菜的对话状态

    public bool isDialogueOnState; //从UI处获取，当前
    public bool hasAutoDialogue;//是否已进行过自动对话
    //public bool hasChanged;//是否已被夺舍过
    public int openDoorTimes = 1;
    public int conversations;
    public string npcName;
    public GameObject playerObject;
    [SerializeField]
    private DialogueData dialogues;
    private NpcData npcData;

    private void Start()
    {
        //获取当前的剧本
        dialogues = this.GetComponent<DialogueController>().dialoges;
    }

    private void OnEnable()
    {
        EventHandler.UpdateDialogueState += onUpdateDialogueState;
        EventHandler.ExitDialogueState += onExitDialogueState;
    }
    private void OnDisable()
    {
        EventHandler.UpdateDialogueState += onUpdateDialogueState;
        EventHandler.ExitDialogueState += onExitDialogueState;
    }

    //获取player的object,用来判断小队内人员
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerObject = collision.gameObject;    
        }
    }

    private void onExitDialogueState(bool dialogeState)
    {
        isDialogueOnState = dialogeState;   
    }

    private void onUpdateDialogueState(bool dialogueState, float arg2)
    {
        isDialogueOnState = dialogueState;
    }

    public int resetDialogueIndex(int index)
    {
        if (!isDialogueOnState)
        {
            //设置为下次对话的起始
            index = 0;
            return index;
        }
        else
        {
            return index;
        }
    }

    public bool CheckFirstDialogue(DialogueStruct dialogueListItem)
    {
        if (dialogueListItem.triggerName == this.name && dialogueListItem.openDoorTimes == openDoorTimes && dialogueListItem.Conversations == conversations)
        {
            //一个判断小队成员内容是否吻合的函数
            return true;
        }
        return false;
    }


    //当前主角和triggerName之一吻合,当前主角的id和对应list[i]的triggername里的某一个吻合即可
    //对话次数和当前吻合       
    //开门次数和当前吻合        
    //循环次数和当前吻合
    public DialogueStruct GetNextDialogueStart()
    {   for(int i = 0; i < dialogues.dialogueList.Count; i++)
        {
            if(getRightTriggerName(i)
                && conversations == dialogues.dialogueList[i].Conversations 
                && openDoorTimes == dialogues.dialogueList[i].openDoorTimes 
                && npcData.loop == dialogues.dialogueList[i].loop)
            {
                return dialogues.dialogueList[i];
            } else
            {
                return null;
            }
            
        }
        return null;
        
    }

    private bool getRightTriggerName(int i)
    {
        string name =  GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().sprite.name;
        Debug.Log(name);
        int playerIndex = npcData.GetPlayerIndex(name);//要保证索引里有
        if(dialogues.dialogueList[i].teamMembers.Contains(playerIndex))
        {
            return true;
        }else
        {
            return false;
        }
    }


}
