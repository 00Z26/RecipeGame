using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueState : MonoBehaviour
{   //������ÿ���ɶԻ��߲���
    //��ȡ�߲˵ĶԻ�״̬

    public bool isDialogueOnState; //��UI����ȡ����ǰ
    public bool hasAutoDialogue;//�Ƿ��ѽ��й��Զ��Ի�
    //public bool hasChanged;//�Ƿ��ѱ������
    public OpenDoorTimes openDoorData;
    private int openDoorTimes; 


    public int conversations; //controller�ۼӣ����ص�һ����´μ����жϵ�ֵΪ2
    public string npcName;
    public GameObject playerObject;

   
    private DialogueData dialogues;
    public NpcData npcData;

    private DataTools dataTools;

    private void Awake()
    {
        openDoorTimes = 0; //�ۼӲ�����swap�ڴ���
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
        Scene scene = SceneManager.GetActiveScene();
        openDoorTimes = openDoorData.GetDoorTimes(scene.name.Replace("Room","Door"));
        Debug.Log(openDoorTimes);
        for(int i = 0; i < dialogues.dialogueList.Count; i++)
        {
            //Debug.Log(i);
            //Debug.Log(conversations == dialogues.dialogueList[i].Conversations);
            
            if (dialogues.dialogueList[i].index == 0
                && getRightTriggerName(i)
                && GetCorrectTeam(i)
                && GetCorrectConTimes(i)
                && openDoorTimes == dialogues.dialogueList[i].openDoorTimes)
                //&& npcData.loop == dialogues.dialogueList[i].loop)
            {
                return dialogues.dialogueList[i];
            }

        }
        return null;
        
    }

    private bool getRightTriggerName(int i)
    {
        
        string name = npcData.GetPlayerName(npcData.controllerIndex);
        
        Debug.Log(name);
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

    //���Ӷ�>n�ζԻ����ж�
    private bool GetCorrectConTimes(int i)
    {
        Debug.Log(dialogues.dialogueList[i].Conversations);
        if(dialogues.dialogueList[i].Conversations.Contains(">"))
        {
            string prefix = ">";
            string temp = dialogues.dialogueList[i].Conversations.Replace(prefix,"");
            //Debug.Log(int.Parse(temp));
            
            if (conversations >= int.Parse(temp))
            {
                Debug.Log(conversations);
                return true;
            } else
            {
                return false;
            }

        }else if(conversations == int.Parse(dialogues.dialogueList[i].Conversations))
        {
            return true;
        }
        return false;
    }
    //�ж϶�Ա�Ƿ��Ǻ�
    private bool GetCorrectTeam(int i)
    {
        //���ö���Ҫ��
        if(dialogues.dialogueList[i].teamMembers == string.Empty)
        {
            return true;
        }
        int teamReuire = int.Parse(dialogues.dialogueList[i].teamMembers);
        //��ǰ��������
        List<int> teamList = GameObject.FindWithTag("Player").GetComponent<PlayerController>().teamMembers;
        teamList.Add(npcData.controllerIndex);
        if(teamReuire >= 0)
        {
            if(teamList.Contains(teamReuire))
            {
                return true;
            }
            else { return false; }
        }
        if(teamReuire < 0)
        {
            teamReuire = Mathf.Abs(teamReuire);
            if(teamList.Contains(teamReuire))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        return false;

    }

}
