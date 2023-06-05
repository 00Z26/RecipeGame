using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcFollow : MonoBehaviour
{
    public float followSpeed;
    private Transform playerTransform;
    private GameObject player;
    public NpcData npcData;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
        //this.GetComponent<CapsuleCollider2D>().enabled = false;
    }
    private void Update()
    {
        if (playerTransform != null)
        {
            //�ж�С������
            int index = npcData.GetPlayerIndex(this.name);
            int teamNum = player.GetComponent<PlayerController>().teamMembers.IndexOf(index);
            Debug.Log(teamNum);
            //�ж��Լ�λ��
            float distance = (transform.position - playerTransform.position).sqrMagnitude;
            //���npcʱ����λ��
            if(player.transform.localScale.x < 0)
            {
                Vector2 targetPosition = new Vector2(playerTransform.position.x + (teamNum * 3 + 3), this.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
            }
            else if(player.transform.localScale.x> 0)
            {
                Vector2 targetPosition = new Vector2(playerTransform.position.x - (teamNum * 3 + 3), this.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
            }
            
            
        }
    }

}
