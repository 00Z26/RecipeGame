using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumManager : MonoBehaviour
{
    private GameObject playerObj;
    public NpcData npcData;


    private List<int> rawMaterial;
    private int dishIndex;



    private void Awake()
    {
        playerObj = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        //��ȡ��ǰ�����Ա
        //�жϳ��ĸ���
        //�޸��Ǹ��˵�bool
        //ѭ�����е�dish��ʾ�ܽ�
        string playerName = playerObj.GetComponent<SpriteRenderer>().sprite.name;
        rawMaterial = new List<int>();

        rawMaterial.Add(npcData.GetPlayerIndex(playerName));
        //�Ѷ����ڵ�indexҲ�ӵ�ԭ������
        for (int i = 0; i < playerObj.GetComponent<PlayerController>().teamMembers.Count; i++)
        {
            rawMaterial.Add(playerObj.GetComponent<PlayerController>().teamMembers[i]);
        }
        //����ԭ���жϲ˵ĺ���������int




        //������0
        dishIndex = 0;
        //ִ����ʾ������
        Debug.Log("���õ���");
        this.GetComponent<HightLightAnim>().ExcuHighlightAnim(dishIndex);

    }
}
