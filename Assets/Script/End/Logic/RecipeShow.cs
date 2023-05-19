using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeShow : MonoBehaviour
{
    public RecipeData dishData;
    private Image image;

    private void Awake()
    {
        image = this.GetComponent<Image>();
    }
    public void ShowDish()
    {
        image.sprite = dishData.dishPic;
        //���ֶ�ȡ��ʾ

        image.enabled = dishData.isShow;
        this.enabled = dishData.isShow;
    }
}
