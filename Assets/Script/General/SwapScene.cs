using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwapScene : MonoBehaviour
{
    // Start is called before the first frame update
    public string from;
    public string to;
    private bool isDoor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && isDoor)
        {
            GameObject.Find("TransportManager").GetComponent<Transport>().Transition(from, to);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isDoor = false;
    }

}
