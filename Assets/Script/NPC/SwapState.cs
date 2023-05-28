using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapState : MonoBehaviour
{
    public NpcData npcData;
    public GameObject player;
    public DataTools dataTools;

    private void OnEnable()
    {
        EventHandler.DialogueSwapStateEvent += OnSwapState;
    }
    private void OnDisable()
    {
        EventHandler.DialogueSwapStateEvent -= OnSwapState;
    }

    private void OnSwapState(int index)
    {
        if(npcData.animPrefab[index].isNormal)
        {
            npcData.animPrefab[index].isNormal = false;
            Transform temp = player.transform.Find(npcData.GetPlayerName(index));
            if(temp != null)
            {
                Transform temp2 = temp.Find(npcData.GetPlayerName(index));
                Destroy(temp2);
                GameObject obj = Instantiate(npcData.animPrefab[index].abnormal, temp2);
            }
        } else
        {
            npcData.animPrefab[index].isNormal = true;
            Transform temp = player.transform.Find(npcData.GetPlayerName(index));
            if (temp != null)
            {
                Transform temp2 = temp.Find(npcData.GetPlayerName(index)+"_Crazy");
                Destroy(temp2);
                GameObject obj = Instantiate(npcData.animPrefab[index].abnormal, temp2);
            }
        }
    }
}
