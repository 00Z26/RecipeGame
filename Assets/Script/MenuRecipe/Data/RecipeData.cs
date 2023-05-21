using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="RecipeData", menuName ="SO_Recipe")]

public class RecipeData : ScriptableObject
{
    
    public string dishName;
    public Sprite dishPic;
    public string dishDescription;
    public bool isShow;

}

