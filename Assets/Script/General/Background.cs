using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float cameraXLeftScale;
    public float cameraXRightScale;
    public float cameraYUpScale;
    public float cameraYDownScale;

    public float GetcameraXLeftScale()
    {
        return cameraXLeftScale;
    }
    public float GetcameraXRightScale()
    {
        return cameraXRightScale;
    }
    public float GetcameraYUpScale()
    {
        return cameraYUpScale;
    }
    public float GetcameraYDownScale()
    {
        return cameraYDownScale;
    }
}
