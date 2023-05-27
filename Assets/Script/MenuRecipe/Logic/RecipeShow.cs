using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeShow : MonoBehaviour
{
    public RecipeData dishData;
    public Image image;
    public Sprite unknownPic;
    public Sprite unknownBg;

    public void ShowDish()
    {

        if (dishData.isShow)
        {
            
            this.enabled = dishData.isShow;
            this.gameObject.SetActive(dishData.isShow);
            image.sprite = dishData.dishPic;
            
        }else
        {
            this.enabled = true;
            this.gameObject.SetActive(true);
            image.sprite = unknownPic;
            
        }
        
    }

    public void showTextEvent()
    {
        EventHandler.CallTriggerShowRecipeTextEvent(dishData.dishName + ":\n" + dishData.dishDescription);
    }

}
