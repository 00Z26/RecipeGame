using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeShow : MonoBehaviour
{
    public RecipeData dishData;
    public Image image;

    public void ShowDish()
    {

        if (dishData.isShow)
        {
            
            this.enabled = dishData.isShow;
            this.gameObject.SetActive(dishData.isShow);
            image.sprite = dishData.dishPic;
            
        }
        
    }

    public void showTextEvent()
    {
        EventHandler.CallTriggerShowRecipeTextEvent(dishData.dishName + ":\n" + dishData.dishDescription);
    }

}
