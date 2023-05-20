using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameStart : MonoBehaviour
{
    public string from;
    public string to;
    public Vector3 playerPos;
    public void TriggerSwapStart()
    {
        from = "Menu";
        to = "Outside";
        Debug.Log(from);
        EventHandler.CallTriggerSwapNewGameEvent(from, to, playerPos);
    }

    public void TriggerShowRecipe()
    {
        from = "Menu";
        to = "RecipeShow";
        EventHandler.CallTriggerShowRecipeEvent(from, to, playerPos);
    }
}
