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
    public int index;
    public string speakerName;
    public Sprite pic;
    public string chatPartner;
    public List<State> chatPartnerState;
    public string content;
    public string animiation;
    public int nextIndex;
    public string choice_1;//nextIndex : 剧情内容
    public string choice_2;
    public string choice_3;

    //分周目生成数据，聊天对象作为一个标识保存
}
public class State
{
    public bool isAbnormal;
    public bool isEnableChange;
}
