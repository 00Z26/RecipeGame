using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeShow : MonoBehaviour
{
    public RecipeData dishData;
    public Image image;
    public Image bigImage;
    public Sprite unknownPic;
    

    public void ShowDish()
    {

        if (dishData.isShow)
        {
            
            this.enabled = dishData.isShow;
            this.gameObject.SetActive(dishData.isShow);
            image.sprite = dishData.dishPic;
            bigImage.sprite = dishData.dishPic;
            
        }else
        {
            this.enabled = true;
            this.gameObject.SetActive(true);
            image.sprite = unknownPic;
            
        }
        
    }

    public void showTextEvent()
    {
        if (dishData.isShow)
        {
            EventHandler.CallTriggerShowRecipeTextEvent(dishData.dishName + ":\n" + dishData.dishDescription);
        }
        else
        {
            EventHandler.CallTriggerShowRecipeTextEvent(null);
        }
        bigImage.sprite = dishData.isShow ? dishData.dishPic : unknownPic ;
    }

}
