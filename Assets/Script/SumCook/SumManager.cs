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
        //获取当前组队人员
        //判断出哪个菜
        //修改那个菜的bool
        //循环所有的dish显示总结
        string playerName = playerObj.GetComponent<SpriteRenderer>().sprite.name;
        rawMaterial = new List<int>();

        rawMaterial.Add(npcData.GetPlayerIndex(playerName));
        //把队伍内的index也加到原料组里
        for (int i = 0; i < playerObj.GetComponent<PlayerController>().teamMembers.Count; i++)
        {
            rawMaterial.Add(playerObj.GetComponent<PlayerController>().teamMembers[i]);
        }
        //根据原料判断菜的函数，返回int




        //假设是0
        dishIndex = 0;
        //执行显示和隐藏
        Debug.Log("调用弹出");
        this.GetComponent<HightLightAnim>().ExcuHighlightAnim(dishIndex);

    }
}
