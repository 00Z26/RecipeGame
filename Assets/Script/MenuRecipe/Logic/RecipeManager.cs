using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour
{
    private GameObject playerObj;
    
    private int dishIndex;
    private Transform[] dishesImage;
    private RecipeList recipeList;

    public NpcData npcData;
    
    public Image grid;

    private void Start()
    {

        //������������ͼƬ
        dishesImage = grid.GetComponentsInChildren<Transform>(true);
        Debug.Log(dishesImage.Length);
        //������ĸ����壬Ӧ���ǰ����˸�����
        foreach (Transform dish in dishesImage)
        {
            Debug.Log(dish.gameObject.name);
            dish.gameObject.GetComponent<RecipeShow>()?.ShowDish();
        }
    }

    public void RecipeExit()
    {
        string from = "RecipeShow";
        string to = "Menu";

        EventHandler.CallRecipeExitEvent(from, to, new Vector3(-1000f,0,0));
    }

}
