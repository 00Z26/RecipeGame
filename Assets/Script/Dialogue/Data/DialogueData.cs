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
    public int index; //当前id
    public Sprite pic;
    public string triggerName; //触发对话的人
    public string chatPartnerName; //当前说话的人
    public List<int> teamMembers; //队伍内成员
    public int openDoorTimes; //开启触发对话人这个门的次数
    public int Conversations; //与触发对话的人的交互次数
    public List<State> chatPartnerState; //说话人的状态
    public string content; //说话内容
    public string animiation; //动画
    public int nextIndex;//下一句
    public List<string> choices;//剧情内容 + nextIndex
    //选项更改随便某个人状态
    //选项打开面板
}
public class State
{
    public bool isAbnormal;
    public bool isChanged; //被夺舍
}
