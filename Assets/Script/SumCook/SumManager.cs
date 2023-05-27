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
        //获取当前组队人员
        //判断出哪个菜
        //修改那个菜的bool
        //循环所有的dish显示总结
        //string playerName = playerObj.GetComponent<SpriteRenderer>().sprite.name;
        string playerName = GameObject.FindWithTag("Player").transform.GetChild(0).gameObject.tag;
        Debug.Log(playerName);
        rawMaterial = new List<int>();

        rawMaterial.Add(npcData.GetPlayerIndex(playerName));
        //把队伍内的index也加到原料组里
        for (int i = 0; i < playerObj.GetComponent<PlayerController>().teamMembers.Count; i++)
        {
            rawMaterial.Add(playerObj.GetComponent<PlayerController>().teamMembers[i]);
        }
        //根据原料判断菜的函数，返回int



        dishIndex = GetNewChipIndex();
        //假设是0
        //dishIndex = 0;
        //执行显示和隐藏
        StartCoroutine(WaitForSecondsRealtime(duration,dishIndex,this.gameObject));
        Debug.Log("调用弹出");
        //this.GetComponent<HightLightAnim>().ExcuHighlightAnim(dishIndex);

    }
    /// <summary>
    /// 等待时间（不会受到Time.timeScale的影响）
    /// </summary>
    /// <param name="duration">等待时间</param>
    /// <param name="action">等待后执行的函数</param>
    /// <returns></returns>
    public static IEnumerator WaitForSecondsRealtime(float duration,int dishIndex, GameObject obj)
    {
        yield return new WaitForSecondsRealtime(duration);
        obj.GetComponent<HightLightAnim>().ExcuHighlightAnim(dishIndex);

    }


    private int GetNewChipIndex()
    {
        //有蘑菇
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
        //有鸡蛋
        if(rawMaterial.Contains(3))
        {
            //荷包蛋
            if(rawMaterial.Count == 1)
            {
                return 4;
            }
            //蛋包饭
            if(rawMaterial.Count == 2 && rawMaterial.Contains(4))
            {
                if(npcData.animPrefab[4].isNormal == false)
                {
                    return 2;
                }
            }
            //番茄炒蛋
            if (rawMaterial.Count == 3 && rawMaterial.Contains(6))
            {
                if (rawMaterial.Contains(4) && npcData.animPrefab[4].isNormal == true)
                {
                    return 3;
                }
            }
            return 5;

        }
        //有玉米
        if (rawMaterial.Contains(2))
        {
            //是光明玉米
            if(npcData.animPrefab[2].isNormal)
            {   //烤玉米
                if(rawMaterial.Count == 1)
                    return 6;
                //沙拉
                if(rawMaterial.Contains(1))
                    return 7;
            }
            return 8;
        }
        //有柠檬
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
        //有土豆
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
