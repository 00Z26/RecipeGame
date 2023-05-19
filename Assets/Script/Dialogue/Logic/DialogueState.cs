using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState : MonoBehaviour
{   //������ÿ���ɶԻ��߲���
    //��ȡ�߲˵ĶԻ�״̬

    public bool isDialogueOnState; //��UI����ȡ����ǰ
    public bool hasAutoDialogue;//�Ƿ��ѽ��й��Զ��Ի�
    //public bool hasChanged;//�Ƿ��ѱ������
    public int openDoorTimes; //�ۼӲ��ֻ�û����Ҫ��transport���ж�


    public int conversations; //controller�ۼӣ����ص�һ����´μ����жϵ�ֵΪ2
    public string npcName;
    public GameObject playerObject;

   
    private DialogueData dialogues;
    public NpcData npcData;

    private DataTools dataTools;

    private void Awake()
    {
        openDoorTimes = 1; //����Ϊ1��Ϊ��ģ��Ի�ʱ�Ѿ�����1���ۼӲ�����transport�в���
        conversations = 1;
    }
    private void Start()
    {
        //��ȡ��ǰ�ľ籾
        dialogues = this.GetComponent<DialogueController>().dialoges;
        dataTools = new DataTools();
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



    //��ǰ���Ǻ�triggerName֮һ�Ǻ�,��ǰ���ǵ�id�Ͷ�Ӧlist[i]��triggername���ĳһ���Ǻϼ���
    //�Ի������͵�ǰ�Ǻ�       
    //���Ŵ����͵�ǰ�Ǻ�        
    //ѭ�������͵�ǰ�Ǻ�
    public DialogueStruct GetNextDialogueStart()
    {
        //Debug.Log(dialogues.name);
        for(int i = 0; i < dialogues.dialogueList.Count; i++)
        {
            Debug.Log(i);
            Debug.Log(conversations == dialogues.dialogueList[i].Conversations);
            
            if (getRightTriggerName(i)
                && conversations == dialogues.dialogueList[i].Conversations
                && openDoorTimes == dialogues.dialogueList[i].openDoorTimes
                && npcData.loop == dialogues.dialogueList[i].loop)
            {
                return dialogues.dialogueList[i];
            }

        }
        return null;
        
    }

    private bool getRightTriggerName(int i)
    {
        string name = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().sprite.name;
        //Debug.Log(name);
        //int playerIndex = npcData.GetPlayerIndex(name);//Ҫ��֤��������
        //�ַ���ת�б�
        List<string> triggerList = dataTools.GetTriggerNameList(dialogues.dialogueList[i].triggerName);       
        if (triggerList.Contains(name))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
