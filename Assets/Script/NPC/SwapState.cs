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
        //if (npcData.animPrefab[index].isNormal)
        //{
        //    npcData.animPrefab[index].isNormal = false;
        //}

        if (npcData.animPrefab[index].isNormal)
        {
            npcData.animPrefab[index].isNormal = false;
            Transform temp = player.transform.Find(npcData.GetPlayerName(index));
            Debug.Log("实例化不正常状态1");
            Debug.Log(temp.gameObject.name);
            if (temp != null)
            {
                Animator temp2 = temp.GetComponentInChildren<Animator>();
                Vector3 scale = temp.gameObject.transform.localScale;
                Destroy(temp.gameObject);
                Debug.Log("实例化不正常状态");
                GameObject obj = Instantiate(npcData.animPrefab[index].abnormal, player.transform);

                    obj.transform.localPosition = new Vector3(-17.2000008f, -11.5f, 0);
                    obj.transform.localScale = new Vector3(2.21000004f, 2.22781062f, 2.87219882f);
               
            }
        }
        else
        {
            npcData.animPrefab[index].isNormal = true;
            Transform temp = player.transform.Find(npcData.GetPlayerName(index));
            if (temp != null)
            {
                Transform temp2 = temp.Find(npcData.GetPlayerName(index) + "_Crazy");
                Destroy(temp2);
                GameObject obj = Instantiate(npcData.animPrefab[index].abnormal, temp2);
            }
        }
    }
}
