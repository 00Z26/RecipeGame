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
        if (npcObj.GetComponent<BoxCollider2D>())
            npcObj.GetComponent<BoxCollider2D>().enabled = false;
        npcObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //改变场景时不被刷掉
        npcObj.transform.SetParent(player.transform);
        npcObj.GetComponentInChildren<Collider2D>().excludeLayers = LayerMask.NameToLayer("Player");
    }
}
