using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public Transform playerTarget;
    public float moveTime;
    public float deltaYPos;
    public float cameraXLeftScale;
    public float cameraXRightScale;

    private Vector3 posTarget;
    private void LateUpdate()
    {
        float posX = Mathf.Clamp(playerTarget.position.x, cameraXLeftScale, cameraXRightScale);
        Debug.Log(posX);
        posTarget = new Vector3(posX, transform.position.y, transform.position.z);//playerTarget.position.y + deltaYPos
        if (playerTarget != null)
        {   if(transform.position != posTarget)
            {
                transform.position = Vector3.Lerp(transform.position, posTarget, moveTime);    
            }
        }
    }
}
