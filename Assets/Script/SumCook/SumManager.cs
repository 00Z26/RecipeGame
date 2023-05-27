using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumManager : MonoBehaviour
{
    private GameObject playerObj;
    public NpcData npcData;
    public float duration;


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
        //string playerName = playerObj.GetComponent<SpriteRenderer>().sprite.name;
        string playerName = GameObject.FindWithTag("Player").transform.GetChild(0).gameObject.tag;
        Debug.Log(playerName);
        rawMaterial = new List<int>();

        rawMaterial.Add(npcData.GetPlayerIndex(playerName));
        //�Ѷ����ڵ�indexҲ�ӵ�ԭ������
        for (int i = 0; i < playerObj.GetComponent<PlayerController>().teamMembers.Count; i++)
        {
            rawMaterial.Add(playerObj.GetComponent<PlayerController>().teamMembers[i]);
        }
        //����ԭ���жϲ˵ĺ���������int



        dishIndex = GetNewChipIndex();
        //������0
        //dishIndex = 0;
        //ִ����ʾ������
        StartCoroutine(WaitForSecondsRealtime(duration,dishIndex,this.gameObject));
        Debug.Log("���õ���");
        //this.GetComponent<HightLightAnim>().ExcuHighlightAnim(dishIndex);

    }
    /// <summary>
    /// �ȴ�ʱ�䣨�����ܵ�Time.timeScale��Ӱ�죩
    /// </summary>
    /// <param name="duration">�ȴ�ʱ��</param>
    /// <param name="action">�ȴ���ִ�еĺ���</param>
    /// <returns></returns>
    public static IEnumerator WaitForSecondsRealtime(float duration,int dishIndex, GameObject obj)
    {
        yield return new WaitForSecondsRealtime(duration);
        obj.GetComponent<HightLightAnim>().ExcuHighlightAnim(dishIndex);

    }


    private int GetNewChipIndex()
    {
        //��Ģ��
        if(rawMaterial.Contains(0))
        {
            if(rawMaterial.Count == 1)
            {
                return 0;
            } else
            {
                return 1;
            }
        }
        //�м���
        if(rawMaterial.Contains(3))
        {
            //�ɰ���
            if(rawMaterial.Count == 1)
            {
                return 4;
            }
            //������
            if(rawMaterial.Count == 2 && rawMaterial.Contains(4))
            {
                if(npcData.animPrefab[4].isNormal == false)
                {
                    return 2;
                }
            }
            //���ѳ���
            if (rawMaterial.Count == 3 && rawMaterial.Contains(6))
            {
                if (rawMaterial.Contains(4) && npcData.animPrefab[4].isNormal == true)
                {
                    return 3;
                }
            }
            return 5;

        }
        //������
        if (rawMaterial.Contains(2))
        {
            //�ǹ�������
            if(npcData.animPrefab[2].isNormal)
            {   //������
                if(rawMaterial.Count == 1)
                    return 6;
                //ɳ��
                if(rawMaterial.Contains(1))
                    return 7;
            }
            return 8;
        }
        //������
        if(rawMaterial.Contains(5))
        {
            if (rawMaterial.Count == 1)
                return 10;
            if(rawMaterial.Count == 2 && rawMaterial.Contains(8))
            {
                return 9;
            }
            return 11;
        }
        //������
        if(rawMaterial.Contains(1))
        {
            if(rawMaterial.Count == 1)
                return 12;
            if (rawMaterial.Contains(7))
            {
                return 13;
            }
            return 8;
        }
        if(rawMaterial.Contains(4))
        {
            if(rawMaterial.Count == 2 && rawMaterial.Contains(6))
            {
                if(npcData.animPrefab[4].isNormal == true)
                    return 14;
            }
            return 15;
        }
        return -1;
    }

}
