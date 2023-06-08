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
        Debug.Log(name);
        GameObject npcObj = null;
        GameObject[] npcObjs = GameObject.FindGameObjectsWithTag("NPC");// Find(name);
        foreach(GameObject obj in npcObjs)
        {
            if(obj.name == name)
            {
                npcObj = obj;
                break;
            }           
        }
        Debug.Log(npcObj.tag);
        GameObject player = GameObject.FindWithTag("Player");
        //С����Ա��¼
        player.GetComponent<PlayerController>().teamMembers.Add(npcIndex);
        
        //�����Ӧnpc�ĸ���͸���ű�

        npcObj.GetComponent<CapsuleCollider2D>().enabled = false;
        
        npcObj.GetComponent<NpcFollow>().enabled = true;
        if (npcObj.GetComponent<BoxCollider2D>())
            npcObj.GetComponent<BoxCollider2D>().enabled = false;
        npcObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //�ı䳡��ʱ����ˢ��
        

        if(player.transform.localScale.x > 0)
            npcObj.transform.localScale = new Vector3(Mathf.Abs(npcObj.transform.localScale.x),npcObj.transform.localScale.y,npcObj.transform.localScale.z);
        else if(player.transform.localScale.x < 0)
            npcObj.transform.localScale = new Vector3(-Mathf.Abs(npcObj.transform.localScale.x), npcObj.transform.localScale.y, npcObj.transform.localScale.z);
        npcObj.transform.SetParent(player.transform);

        npcObj.GetComponentInChildren<Collider2D>().excludeLayers = LayerMask.NameToLayer("Player");
    }
}
