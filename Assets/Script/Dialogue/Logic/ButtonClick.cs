using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public int buttonReply;
    public void SetButton0Val()
    {
        Debug.Log("click");
        buttonReply = 0;
        
    }
    public void SetButton1Val()
    {
        buttonReply = 1;
    }
    public void SetButton2Val()
    {
        buttonReply = 2;
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
