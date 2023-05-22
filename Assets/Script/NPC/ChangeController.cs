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
        GameObject npc = GameObject.Find(name);

        if (npc != null)
        {

            //npc�µ������廻��player����
            npc.transform.GetChild(0).gameObject.transform.SetParent(GameObject.FindWithTag("Player").transform);
            //�رմ���
            npc.SetActive(false);
            //�ѵ�ǰplayer������ɾ��
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
