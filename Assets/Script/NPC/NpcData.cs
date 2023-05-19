using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NpcData", menuName = "SO_Npc")]
public class NpcData : ScriptableObject
{
    public int loop;//��ǰ���ִ���
    public List<string> playerName;

    public string GetPlayerName(int index)
    {
        return playerName[index];
    }

    public int GetPlayerIndex(string name)
    {
        return playerName.IndexOf(name);
    }

}