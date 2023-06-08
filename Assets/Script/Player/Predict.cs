using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Predict : MonoBehaviour
{
    public RecipeList recipeList;
    public NpcData npcData;
    [SerializeField]
    public List<Image> preDishes;


    public List<int> rawMaterial;
    public List<int> preChips;
    public GameObject player;
    private int[][] chips = new int[][]
    {
        new int[]{0},
        new int[]{-1},
        new int[]{3,-4},
        new int[]{3,4,6},
        new int[] {3},
        new int[] {-1},
        new int[] {2 },
        new int[] {2,1},
        new int[] {-1},
        new int[] {5,8},
        new int[] {5},
        new int[] {-1},
        new int[] {1},
        new int[] {-1},
        new int[]{4,6}
    };
    //private int[][] Corn = new int[][]
    //{
    //    new int[] {2 },
    //    new int[] {2,1}
    //};
    //private int[][] Lemon = new int[][]
    //{
    //    new int[] {5,8},
    //    new int[] {5}
    //};
    //private int[][] tomato = new int[][]
    //{
    //    new int[]{4,6}
    //};


    public void Start()
    {
        rawMaterial = new List<int>();
        preChips = new List<int>();
    }
    private void Update()
    {
        ShowPredictResult();
    }

    private void ShowPredictResult()
    {
        //获取队伍内成员，把当前主角添加
        rawMaterial = new List<int>();
        preChips = new List<int>();

        rawMaterial.Add(npcData.controllerIndex);
        for (int i = 0; i < player.GetComponent<PlayerController>().teamMembers.Count; i++)
        {
            rawMaterial.Add(player.GetComponent<PlayerController>().teamMembers[i]);
        }
        //存在玉米和番茄则进行正负处理
        for(int i = 0;i < rawMaterial.Count;i++)
        {
            if (rawMaterial[i] == 4)
            {
                if (!npcData.animPrefab[4].isNormal)
                    rawMaterial[i] = -4;
            }
            if(rawMaterial[i] == 2)
            {
                if (!npcData.animPrefab[2].isNormal)
                    rawMaterial[i] = -2;
            }
        }
        //根据主菜谱按照包含关系优先匹配
        //if(rawMaterial.Contains(0) && rawMaterial.Count == 1)
        //{
        //    preChips.Add(0);
        //}

        //if(rawMaterial.Contains(1) && rawMaterial.Count == 1)
        //{
        //    preChips.Add(12);
        //}

        for (int i = 0;i < chips.Length;i++)
        {
            if(rawMaterial.ToArray().All(t => chips[i].Any(b => b==t))) {
                //子集或相同
                preChips.Add(i);
            }
        }
        //按优先级匹配附菜
        if(rawMaterial.Contains(1) && rawMaterial.Contains(8))
        {
            preChips.Add(13);
        }
        if (rawMaterial.Contains(0))
        {
            preChips.Add(1);
        }
        if(rawMaterial.Contains(2) || rawMaterial.Contains(1))
        {
            preChips.Add(8);
        }
        if(rawMaterial.Contains(4))
        {
            preChips.Add(15);
        }
        if (rawMaterial.Contains(5))
            preChips.Add(11);
        if(rawMaterial.Contains(3))
            preChips.Add(5);
        //去重
        preChips.Distinct();
        //显示前三个
        int num = preChips.Count >= 3 ? 3 : preChips.Count;
        for (int i = 0; i < num; i++)
        {
            if(i < preChips.Count)
            {
                if (recipeList.recipeList[preChips[i]].isShow)
                {
                    
                    preDishes[i].sprite = recipeList.recipeList[preChips[i]].dishPic;
                    
                }
                else
                {
                    preDishes[i].sprite = recipeList.recipeList[preChips[i]].dishPic;
                    preDishes[i].color = new Color32(63, 63, 63, 255);
                }
                preDishes[i].color = new Color(preDishes[i].color.r, preDishes[i].color.g, preDishes[i].color.b,255);
            }            
        }
    }
}
