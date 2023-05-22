using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NpcData", menuName = "SO_Npc")]
public class NpcData : ScriptableObject
{
    public int loop;//当前开局次数
    public int controllerIndex; //当前主角ID
    public List<string> playerName;
    public List<GameObject> animPrefab;

    public string GetPlayerName(int index)
    {
        return playerName[index];
    }

    public int GetPlayerIndex(string name)
    {
        return playerName.IndexOf(name);
    }

    public GameObject GetPlayerPrefab(int index)
    {
        return animPrefab[index];
    }

}