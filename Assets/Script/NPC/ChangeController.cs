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
        //GameObject npc = GameObject.Find(name);
        GameObject npc = null;
        GameObject[] npcObjs = GameObject.FindGameObjectsWithTag("NPC");// Find(name);
        foreach (GameObject obj in npcObjs)
        {
            if (obj.name == name)
            {
                npc = obj;
                break;
            }
        }
        if (npc != null)
        {

            //npc下的子物体换到player下面
            //npc.transform.GetChild(0).gameObject.transform.SetParent(GameObject.FindWithTag("Player").transform);
            if (player.transform.localScale.x > 0)
                npc.transform.localScale = new Vector3(Mathf.Abs(npc.transform.localScale.x), npc.transform.localScale.y, npc.transform.localScale.z);
            else if (player.transform.localScale.x < 0)
                npc.transform.localScale = new Vector3(-Mathf.Abs(npc.transform.localScale.x), npc.transform.localScale.y, npc.transform.localScale.z);
            npc.transform.gameObject.transform.SetParent(GameObject.FindWithTag("Player").transform);

            //关闭触发
            //npc.SetActive(false);
            //npc.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            Destroy(npc.GetComponent<Rigidbody2D>());
            //把当前player的主角删除
            if(dataTools.GetChildWithTag(player, npcData.GetPlayerName(npcData.controllerIndex)).name == "Mushroom")
            {
                dataTools.GetChildWithTag(player, npcData.GetPlayerName(npcData.controllerIndex)).SetActive(false);
            }
            else
            {
                Destroy(dataTools.GetChildWithTag(player, npcData.GetPlayerName(npcData.controllerIndex)));
            }

            npc.transform.localPosition = Vector3.zero;
            if(npc.name == "Lemon")
            {
                npc.transform.localPosition = new Vector3(-1.08000004f, 2.6099999f, 0);
                
            }
            if(npc.name == "Potato")
            {
                //player.transform.Find(name).transform.localPosition = new Vector3(0, -8.94999981f, 0);
            }
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
