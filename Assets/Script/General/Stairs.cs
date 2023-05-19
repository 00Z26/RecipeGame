using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Stairs : MonoBehaviour
{
    public bool isStairs; //½Ó´¥Â¥ÌÝÅÐ¶Ï
    private GameObject playerGameObj;
    public Vector3 portalPos;
    private void Update()
    {
        if (isStairs && Keyboard.current.eKey.wasPressedThisFrame)
        {
            playerGameObj.SetActive(false);
            playerGameObj.transform.position = portalPos;
            playerGameObj.SetActive(true);
            isStairs = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerGameObj = collision.gameObject;
            isStairs = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isStairs = false;
    }
}
