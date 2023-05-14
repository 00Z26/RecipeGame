using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="DialogueData1", menuName ="SO_Data")]
public class DialogueData : ScriptableObject
{
    public string playerName;
    public List<DialogueStruct> dialogueList;

}
[System.Serializable]
public class DialogueStruct
{
    public int index; //��ǰid
    public Sprite pic;
    public string triggerName; //�����Ի�����
    public string chatPartnerName; //��ǰ˵������
    public List<int> teamMembers; //�����ڳ�Ա
    public int openDoorTimes; //���������Ի�������ŵĴ���
    public int Conversations; //�봥���Ի����˵Ľ�������
    public List<State> chatPartnerState; //˵���˵�״̬
    public string content; //˵������
    public string animiation; //����
    public int nextIndex;//��һ��
    public List<string> choices;//�������� + nextIndex
    //ѡ��������ĳ����״̬
    //ѡ������
}
public class State
{
    public bool isAbnormal;
    public bool isChanged; //������
}
