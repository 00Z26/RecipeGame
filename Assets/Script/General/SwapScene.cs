using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwapScene : MonoBehaviour
{
    // Start is called before the first frame update
    public string from;
    public string to;
    private bool isTransport;

    public OpenDoorTimes openDoorTimes;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        if ((Keyboard.current.eKey.wasPressedThisFrame && isTransport) || 
            (Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(mousePos))?.gameObject.tag == "GameExit" && Mouse.current.leftButton.wasPressedThisFrame))
        {
            Debug.Log("Exit");
            GameObject.Find("TransportManager").GetComponent<Transport>().Transition(from, to);
            if(from == "Outside" && openDoorTimes.doors.Contains(this.gameObject.name) )
            {
               openDoorTimes.SetDoorTimes(this.gameObject.name);
                GameObject.FindWithTag("Player").GetComponent<PhysicsCheck>().thisLoopOpenDoorTimes++;
            }
            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isTransport = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTransport = false;
    }

}
