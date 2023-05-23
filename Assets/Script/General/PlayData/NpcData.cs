using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NpcData", menuName = "SO_Npc")]
public class NpcData : ScriptableObject
{
    public int loop;//��ǰ���ִ���
    public int controllerIndex;//��ǰ����ID
    public List<string> playerName;
    public List<NpcStruct> animPrefab;

    public string GetPlayerName(int index)
    {
        return playerName[index];
    }

    public int GetPlayerIndex(string name)
    {
        return playerName.IndexOf(name);
    }

    public GameObject GetPlayerPrefab(int index, int state ,bool change = false)
    {
        //ҹ������
        if(state == 2)
        {
            return animPrefab[index].dark;     
        }
        //�ı�
        if (change == true)
        {
            animPrefab[index].isNormal = !animPrefab[index].isNormal;
        }

        if(animPrefab[index].isNormal) 
            return animPrefab[index].normal;
        else if(!animPrefab[index].isNormal)
            return animPrefab[index].abnormal;
        
        return null;
    }

}