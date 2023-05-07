using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public Transform playerTarget;
    public float moveTime;

    [Header("地图相机限制")]
    public float cameraXLeftScale;
    public float cameraXRightScale;
    public float cameraYUpScale;
    public float cameraYDownScale;
    public float deltaYPos;//相机与人的高度差

    private Vector3 posTarget;
    private void LateUpdate()
    {   float posY = Mathf.Clamp(playerTarget.position.y + deltaYPos, cameraYDownScale, cameraYUpScale);
        float posX = Mathf.Clamp(playerTarget.position.x, cameraXLeftScale, cameraXRightScale);
        Debug.Log(posX);
        posTarget = new Vector3(posX, posY, transform.position.z);
        if (playerTarget != null)
        {   if(transform.position != posTarget)
            {
                transform.position = Vector3.Lerp(transform.position, posTarget, moveTime);    
            }
        }
    }
}
