using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueController : MonoBehaviour
{
    //����ű�����ÿ���ɶԻ�npc��
    public float YMoveDis;

    public void ShowDialogue()
    {   //��ȡ����ʾ���Ǿ仰 or ����ѡ��
        //�������ֵ��UI
        EventHandler.CallShowDialogueEvent("hi", YMoveDis);
        //�൱��ֻ�жԻ�����ֵʱ���Ż�رնԻ���
    }
}
