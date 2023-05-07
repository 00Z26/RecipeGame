using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFood : MonoBehaviour
{

    public bool isInRange;
    
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("11");
        if (collision.gameObject.name == "Player")
        {
            //ÐÞ¸Äbool×´Ì¬
            isInRange = true;
            Debug.Log("°´e");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //ÐÞ¸Äbool
        isInRange = false;
    }

}
