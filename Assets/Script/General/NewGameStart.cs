using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewGameStart : MonoBehaviour
{
    public string from;
    public string to;
    public Vector3 playerPos;
    //public TMP_Text time;
    //public TMP_Text predict;

    private void Start()
    {
        //time.enabled = false;
        //predict.enabled = false;
    }
    public void TriggerSwapStart()
    {
        from = "Menu";
        to = "Outside";

        GameObject player = GameObject.FindWithTag("Player");  
        player.transform.position = new Vector3(5.09000015f, -4.17999983f, 0);
        
        EventHandler.CallTriggerSwapNewGameEvent(from, to, playerPos);
    }

    public void TriggerShowRecipe()
    {
        from = "Menu";
        to = "RecipeShow";
        EventHandler.CallTriggerShowRecipeEvent(from, to, playerPos);
    }

    public void TriggerContinue()
    {
        from = "Menu";
        to = "Outside";

        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = new Vector3(5.09000015f, -4.17999983f, 0);

        EventHandler.CallTriggerContinue(from, to, playerPos);
    }
}
