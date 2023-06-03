using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SumManager : MonoBehaviour
{
    private GameObject playerObj;
    public NpcData npcData;
    public float duration;
    public GameObject chipBg;
    public GameObject chipImg;
    public RecipeList recipeList;
    public bool isDishShow;

    private List<int> rawMaterial;
    private int dishIndex;

    private Animator chipBgAnim;



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
        chipBgAnim = chipBg.GetComponent<Animator>();  

        rawMaterial = new List<int>();

        //////rawMaterial.Add(npcData.GetPlayerIndex(playerName));
        //�Ѷ����ڵ�indexҲ�ӵ�ԭ������
        for (int i = 0; i < playerObj.GetComponent<PlayerController>().teamMembers.Count; i++)
        {
            rawMaterial.Add(playerObj.GetComponent<PlayerController>().teamMembers[i]);
        }
        rawMaterial.Add(npcData.controllerIndex);
        //����ԭ���жϲ˵ĺ���������int



        dishIndex = GetNewChipIndex();
        //������0
        //dishIndex = 0;
        //ִ����ʾ������
        StartCoroutine(WaitForSecondsRealtime(duration, chipBg));
        
        chipImg.GetComponent<SpriteRenderer>().sprite = recipeList.recipeList[dishIndex].dishPic;

    }

    private void Update()
    {
        if (isDishShow)
            chipImg.SetActive(true);
        if(isDishShow && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("info");
            //���ŷŴ󶯻�
            //�ƶ������
            chipBgAnim.SetBool("isInfo", true);
            chipImg.GetComponent<MoveImg>().enabled = true;
            //��ʾ��������
            this.GetComponent<CardShow>().ShowCardInfo(dishIndex);
        }
    }


    /// <summary>
    /// �ȴ�ʱ�䣨�����ܵ�Time.timeScale��Ӱ�죩
    /// </summary>
    /// <param name="duration">�ȴ�ʱ��</param>
    /// <param name="action">�ȴ���ִ�еĺ���</param>
    /// <returns></returns>
    public static IEnumerator WaitForSecondsRealtime(float duration, GameObject chipBg)
    {
        yield return new WaitForSecondsRealtime(duration);
        chipBg.SetActive(true);

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
