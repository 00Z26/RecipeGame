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
            //修改bool状态
            isInRange = true;
            //弹出操作说明
            Debug.Log("按e");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //修改bool
        isInRange = false;
        //操作说明消失
    }
}
