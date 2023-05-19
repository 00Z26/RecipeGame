using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowController : MonoBehaviour
{
    public GameObject player;
    public NpcData npcData;
    private void OnEnable()
    {
        EventHandler.TriggerFollowEvent += OnTriggerFollowEvent;
    }
    private void OnDisable()
    {
        EventHandler.TriggerFollowEvent -= OnTriggerFollowEvent;
    }

    private void OnTriggerFollowEvent(int npcIndex)
    {
        Debug.Log("controller执行跟随");
        string name = npcData.GetPlayerName(npcIndex);
        GameObject npcObj = GameObject.Find(name);
        GameObject player = GameObject.FindWithTag("Player");
        //小队人员记录
        player.GetComponent<PlayerController>().teamMembers.Add(npcIndex);
        //激活对应npc的刚体和跟随脚本
        npcObj.GetComponent<CapsuleCollider2D>().enabled = false;
        npcObj.GetComponent<NpcFollow>().enabled = true;
        
    }
}
