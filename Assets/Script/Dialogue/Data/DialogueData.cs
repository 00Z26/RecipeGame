using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="DialogueData1", menuName ="SO_Data")]
public class DialogueData : ScriptableObject
{
    public List<DialogueStruct> dialogueList;

}
[System.Serializable]
public class DialogueStruct
{
    public int index;
    public string speakerName;
    public string pic;
    public string content;
    public string animiation;
    public int nextIndex;
    public string choice;
}

