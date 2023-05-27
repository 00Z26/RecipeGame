using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueStruct
{


        public int index; //当前id
        public int nextIndex;//下一句
        public string chatPartnerName; //当前说话的人
        public string content; //说话内容
        public string choices;//剧情内容 + nextIndex
        public string animiation; //动画
        public string pic;
        public string triggerName; //触发对话的人
        public string teamMembers;
        public int openDoorTimes; //开启触发对话人这个门的次数
        public int loop;
        public string Conversations; //与触发对话的人的交互次数






     //队伍内成员
        
        
                                  //public List<State> chatPartnerState; //说话人的状态
        
        
        
        
                                    //选项更改随便某个人状态
                                    //选项打开面板
    }
    //public class State
    //{
    //    public bool isAbnormal;
    //    public bool isChanged; //被夺舍
    //}
