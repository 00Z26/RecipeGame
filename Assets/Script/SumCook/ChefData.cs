using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ChefData", menuName = "SO_Chef")]

public class ChefData : ScriptableObject
{
    public List<string> chefText;
    public string GetChefText(int loop)
    {
        if(loop >= 1 && loop < 16)
        {
            return chefText[loop - 1];
        }
        return null;
    }

}
