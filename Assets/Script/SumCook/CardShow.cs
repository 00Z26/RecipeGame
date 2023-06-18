using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardShow : MonoBehaviour
{
    [Header("UI���")]
    public GameObject cardPanel;
    public TMP_Text dishText;
    public TMP_Text chefText;


   [Header("��������")]
    public ChefData chefData;
    public NpcData npcData;
    public RecipeList recipeList;
    private RecipeData dishData;
    public void ShowCardInfo(int recipeIndex)
    {
        cardPanel.SetActive(true);
        dishData = recipeList.recipeList[recipeIndex];
        //ͼ����δ�����Ļ� ����
        if(!dishData.isShow)
        {
            dishData.isShow = true;
        }


        dishText.text = dishData.dishName + "\n\n" + dishData.dishDescription;
        chefText.text = "��ʦ�ʼ�" + npcData.loop +"\n" + chefData.GetChefText(npcData.loop);
    }

    public void PlayLogAudio()
    {
        EventHandler.CallPlaySumAudio();
    }
}
