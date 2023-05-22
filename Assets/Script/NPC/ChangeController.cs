using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeController : MonoBehaviour
{
    private Sprite npcSprite;
    public GameObject player;
    private Sprite playerSprite;
    private GameObject[] previousNpcs;
    private GameObject previousNpc;

    //public Collider2D other;
    public NpcData npcData;
    public DataTools dataTools;

    private void OnEnable()
    {
        EventHandler.TriggerChangeEvent += OnTriggerChangeEvent;
    }
    private void OnDisable()
    {
        EventHandler.TriggerChangeEvent -= OnTriggerChangeEvent;
    }

    private void OnTriggerChangeEvent(int npcIndex)
    {   
        dataTools = new DataTools();
        //用事件获取到对应的npc的object，这样后面就未必用other。
        String name = npcData.GetPlayerName(npcIndex);
        GameObject npc = GameObject.Find(name);

        if (npc != null)
        {

            //npc下的子物体换到player下面
            npc.transform.GetChild(0).gameObject.transform.SetParent(GameObject.FindWithTag("Player").transform);
            //关闭触发
            npc.SetActive(false);
            //把当前player的主角删除
            Destroy(dataTools.GetChildWithTag(player, npcData.GetPlayerName(npcData.controllerIndex)));
            npcData.controllerIndex = npcIndex;

            previousNpc?.SetActive(true);
        }


    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    other = collision;
    //}
    private GameObject getPreviousNpc(string name)
    {
        previousNpcs = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject item in previousNpcs)
        {
            if (item.gameObject.name == name)
            {
                return item;
            }
        }
        return null;
    }
}
