using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NpcData", menuName = "SO_Npc")]
public class NpcData : ScriptableObject
{
    public int loop;//当前开局次数
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