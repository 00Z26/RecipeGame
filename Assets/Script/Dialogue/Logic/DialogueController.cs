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
    private DialogueState dialogueState;
    private Sprite speakerImage;
    GameObject autoObj;

    private void Awake()
    {

        nextIndex = 0;
        dialogueState = GetComponent<DialogueState>();
        autoObj = null;

    }
    public void ShowDialogue(bool isAuto, GameObject player)
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
        EventHandler.CallShowDialogueEvent(content, YMoveDis, speakerImage, autoObj);
        //�������ѡ����ز����ȽϺã�ǰ�����ݶ�ȡ��,��controller��ô����¼���ѡ��
        //��nextIndex����״̬���ж������ظ�ֵ
        if(nextIndex == -1)
        {
            if(isAuto == true)
            {
                //�޸��������auto���Ѵ���״̬�����Ѵ�����Ϊftrue
                //��ȡ�Զ�����������
                autoObj = this.gameObject.transform.GetChild(0).gameObject;
                dialogueState.hasAutoDialogue = true;
             
            }
            nextIndex = dialogueState.getNextDialogueIndex(nextIndex);
        }
        
    }
    //�����Ƿ����Զ�������ȷ������⣬�Ժ�����stateCheck�޸ľ����
    private DialogueStruct getDialoguesContent(bool isAuto)
    {
        if (isAuto)
        {
            return autoDialoges.dialogueList[nextIndex];
        } else
        {
            return dialoges.dialogueList[nextIndex];
        }
    }
}
