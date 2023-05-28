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
        //���¼���ȡ����Ӧ��npc��object�����������δ����other��
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

            //npc�µ������廻��player����
            npc.transform.GetChild(0).gameObject.transform.SetParent(GameObject.FindWithTag("Player").transform);
            
            //�رմ���
            npc.SetActive(false);
            //�ѵ�ǰplayer������ɾ��
            Destroy(dataTools.GetChildWithTag(player, npcData.GetPlayerName(npcData.controllerIndex)));
            if(npc.name == "Lemon")
            {
                player.transform.Find(name).transform.localPosition = new Vector3(-5.53999996f, -3.1400001f, 0); //���ʶ�����λ��
            }
            if(npc.name == "Potato")
            {
                player.transform.Find(name).transform.localPosition = new Vector3(0, -8.94999981f, 0);
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
