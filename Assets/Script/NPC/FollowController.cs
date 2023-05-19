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
        Debug.Log("controllerִ�и���");
        string name = npcData.GetPlayerName(npcIndex);
        GameObject npcObj = GameObject.Find(name);
        GameObject player = GameObject.FindWithTag("Player");
        //С����Ա��¼
        player.GetComponent<PlayerController>().teamMembers.Add(npcIndex);
        //�����Ӧnpc�ĸ���͸���ű�
        npcObj.GetComponent<CapsuleCollider2D>().enabled = false;
        npcObj.GetComponent<NpcFollow>().enabled = true;
        
    }
}