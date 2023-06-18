using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardShow : MonoBehaviour
{
    [Header("UI组件")]
    public GameObject cardPanel;
    public TMP_Text dishText;
    public TMP_Text chefText;


   [Header("数据连接")]
    public ChefData chefData;
    public NpcData npcData;
    public RecipeList recipeList;
    private RecipeData dishData;
    public void ShowCardInfo(int recipeIndex)
    {
        cardPanel.SetActive(true);
        dishData = recipeList.recipeList[recipeIndex];
        //图鉴里未解锁的话 解锁
        if(!dishData.isShow)
        {
            dishData.isShow = true;
        }


        dishText.text = dishData.dishName + "\n\n" + dishData.dishDescription;
        chefText.text = "厨师笔记" + npcData.loop +"\n" + chefData.GetChefText(npcData.loop);
    }

    public void PlayLogAudio()
    {
        EventHandler.CallPlaySumAudio();
    }
}
