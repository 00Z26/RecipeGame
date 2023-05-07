using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public Transform playerTarget;
    public float moveTime;
    public float deltaYPos;

    private Vector3 posTarget;
    private void LateUpdate()
    {
        posTarget = new Vector3(playerTarget.position.x, transform.position.y, transform.position.z);//playerTarget.position.y + deltaYPos
        if (playerTarget != null)
        {   if(transform.position != posTarget)
            {
                transform.position = Vector3.Lerp(transform.position, posTarget, moveTime);    
            }
        }
    }
}
