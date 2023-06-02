using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwapScene : MonoBehaviour
{
    // Start is called before the first frame update
    public string from;
    public string to;
    public Vector3 playerToPos;//���Ž�����λ��
    
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
            switchLight();
            GameObject.Find("TransportManager").GetComponent<Transport>().Transition(from, to, playerToPos);
            
            
            //���������ܴ����ͱ��غϳ����л�����
            Debug.Log(this.gameObject.name);
            if (openDoorTimes.doors.Contains(this.gameObject.name))
            {
                if (from == "Outside")
                {
                    Debug.Log(this.gameObject.name);
                   openDoorTimes.SetDoorTimes(this.gameObject.name);
                }
            }
            GameObject.FindWithTag("Player").GetComponent<PhysicsCheck>().thisLoopOpenDoorTimes++;
            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isTransport = true;
            EventHandler.CallShowTipButtonEvent(isTransport);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTransport = false;
        EventHandler.CallShowTipButtonEvent(isTransport);
    }

    private void switchLight()
    {
        if(from == "CornRoom" )
        {

            EventHandler.CallSwitchAnimEvent(false);
        } 
        if(to == "CornRoom")
        {
            EventHandler.CallSwitchAnimEvent(true);
        }

    }

}
