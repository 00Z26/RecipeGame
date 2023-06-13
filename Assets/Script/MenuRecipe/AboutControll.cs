using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutControll : MonoBehaviour
{
    public GameObject text;
    public Vector3 startPos;
    public void RefreshPos()
    {
        text.transform.localPosition = startPos;
    }
}
