using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NpcData", menuName = "SO_Npc")]
public class NpcData : ScriptableObject
{
    public List<string> playerName;

    public string GetPlayerName(int index)
    {
        return playerName[index];
    }

}