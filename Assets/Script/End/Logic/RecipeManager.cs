using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour
{
    private GameObject playerObj;
    private List<int> rawMaterial;
    private int dishIndex;
    private Transform[] dishesImage;
    

    public NpcData npcData;
    //public RecipeData recipeData;
    public Image grid;
    //获取当前组队人员
    //判断出哪个菜
    //修改那个菜的bool
    //循环所有的dish显示总结
    private void Start()
    {

        playerObj = GameObject.FindWithTag("Player");

        //通过查player的sprite名字来获取到它是什么蔬菜
        string playerName = playerObj.GetComponent<SpriteRenderer>().sprite.name;
        rawMaterial = new List<int>();


        //获得子物体加载图片
        dishesImage = grid.GetComponentsInChildren<Transform>(true);
        Debug.Log(dishesImage.Length);
        //获得了四个物体，应该是包含了父物体？
        foreach (Transform dish in dishesImage)
        {
            Debug.Log(dish.gameObject.name);
            dish.gameObject.GetComponent<RecipeShow>()?.ShowDish();
        }
    }

    private void Update()
    {

        //rawMaterial.Add(playerIndex);
        ////把队伍内的index也加到原料组里
        //for (int i = 0; i < playerObj.GetComponent<PlayerController>().teamMembers.Count; i++)
        //{
        //    rawMaterial.Add(playerObj.GetComponent<PlayerController>().teamMembers[i]);
        //}
        ////根据原料判断菜的函数，返回int

        ////假设是0
        //dishIndex = 0;

        //这里监听鼠标事件

    }
}
