using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> loopsUI;
    public NpcData npcData;
    public RecipeList recipeList;
    private void Start()
    {
        int num = 0;
        foreach(RecipeData recipeData in recipeList.recipeList)
        {
            if(recipeData.isShow)
                num++;                
        }
        if(num >= 1)
        {
            foreach(GameObject UI in loopsUI)
            {
                UI.SetActive(true);
            }
        }
    }
}
