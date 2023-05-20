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
    //��ȡ��ǰ�����Ա
    //�жϳ��ĸ���
    //�޸��Ǹ��˵�bool
    //ѭ�����е�dish��ʾ�ܽ�
    private void Start()
    {

        playerObj = GameObject.FindWithTag("Player");

        //ͨ����player��sprite��������ȡ������ʲô�߲�
        string playerName = playerObj.GetComponent<SpriteRenderer>().sprite.name;
        rawMaterial = new List<int>();


        //������������ͼƬ
        dishesImage = grid.GetComponentsInChildren<Transform>(true);
        Debug.Log(dishesImage.Length);
        //������ĸ����壬Ӧ���ǰ����˸����壿
        foreach (Transform dish in dishesImage)
        {
            Debug.Log(dish.gameObject.name);
            dish.gameObject.GetComponent<RecipeShow>()?.ShowDish();
        }
    }

    private void Update()
    {

        //rawMaterial.Add(playerIndex);
        ////�Ѷ����ڵ�indexҲ�ӵ�ԭ������
        //for (int i = 0; i < playerObj.GetComponent<PlayerController>().teamMembers.Count; i++)
        //{
        //    rawMaterial.Add(playerObj.GetComponent<PlayerController>().teamMembers[i]);
        //}
        ////����ԭ���жϲ˵ĺ���������int

        ////������0
        //dishIndex = 0;

        //�����������¼�

    }
}
