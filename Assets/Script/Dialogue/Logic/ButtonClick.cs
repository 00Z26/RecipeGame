using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public int buttonReply;
    public TMP_Text button0;
    public TMP_Text button1;
    public TMP_Text button2;

    public void SetButton0Val()
    {
        //Debug.Log("click");
        buttonReply = 0;
        EventHandler.CallSendButtionValEvent(buttonReply);
        
    }
    public void SetButton1Val()
    {
        buttonReply = 1;
        EventHandler.CallSendButtionValEvent(buttonReply);
    }
    public void SetButton2Val()
    {
        buttonReply = 2;
        EventHandler.CallSendButtionValEvent(buttonReply);
    }
    public void Clear()
    {
        button0.text = null;
        button1.text = null;
        button2.text = null;
        button0.gameObject.transform.parent.parent.gameObject.SetActive(false);
        button1.gameObject.transform.parent.parent.gameObject.SetActive(false);
        button2.gameObject.transform.parent.parent.gameObject.SetActive(false);

    }


    //�������ܣ���һ�䣬���棬����
    //button���ã�������һ��int����
    //���ݴ����İ�ť��index��ͬ����ȡ��Ӧ��nextIndexֵ
    //����index�����������ܡ�

    //index >= 0 ������һ���Ի�



    //index < 0 ֹͣ�Ի����и��ַ���ȷ�ϱ�����npc

    //����controller�еĺ���ֱ����һ�䣬�޸�index
    //���¼���reply����controller �����Ի�
    //��ֵ�㲥��ȥ����ֻ������ײ�Ӵ��Ľ��в������൱���¼�ֻ����ֵ��������controller������ʱѡ����ʧ��ģ�ⰴ�¾���

}
