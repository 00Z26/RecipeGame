using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState : MonoBehaviour
{   //������ÿ���ɶԻ��߲���
    //��ȡ�߲˵ĶԻ�״̬

    public bool isDialogueOnState; //��UI����ȡ����ǰ
    public bool hasAutoDialogue;//�Ƿ��ѽ��й��Զ��Ի�
    //public bool hasChanged;//�Ƿ��ѱ������
    public int openDoorTimes = 1;
    public int conversations;
    public string npcName;
    public GameObject playerObject;
    [SerializeField]
    private DialogueData dialogues;
    private NpcData npcData;

    private void Start()
    {
        //��ȡ��ǰ�ľ籾
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

    //��ȡplayer��object,�����ж�С������Ա
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
            //����Ϊ�´ζԻ�����ʼ
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
            //һ���ж�С�ӳ�Ա�����Ƿ��Ǻϵĺ���
            return true;
        }
        return false;
    }


    //��ǰ���Ǻ�triggerName֮һ�Ǻ�,��ǰ���ǵ�id�Ͷ�Ӧlist[i]��triggername���ĳһ���Ǻϼ���
    //�Ի������͵�ǰ�Ǻ�       
    //���Ŵ����͵�ǰ�Ǻ�        
    //ѭ�������͵�ǰ�Ǻ�
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
        int playerIndex = npcData.GetPlayerIndex(name);//Ҫ��֤��������
        if(dialogues.dialogueList[i].teamMembers.Contains(playerIndex))
        {
            return true;
        }else
        {
            return false;
        }
    }


}
