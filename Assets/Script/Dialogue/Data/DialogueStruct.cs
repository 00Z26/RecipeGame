using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueStruct
{


        public int index; //��ǰid
        public int nextIndex;//��һ��
        public int loop;
        public string pic;

        public string triggerName; //�����Ի�����

        
        public string chatPartnerName; //��ǰ˵������
        public string teamMembers; //�����ڳ�Ա
        public int openDoorTimes; //���������Ի�������ŵĴ���
        public int Conversations; //�봥���Ի����˵Ľ�������
                                  //public List<State> chatPartnerState; //˵���˵�״̬
        public string content; //˵������
        public string animiation; //����
        
        public string choices;//�������� + nextIndex
                                    //ѡ��������ĳ����״̬
                                    //ѡ������
    }
    //public class State
    //{
    //    public bool isAbnormal;
    //    public bool isChanged; //������
    //}
