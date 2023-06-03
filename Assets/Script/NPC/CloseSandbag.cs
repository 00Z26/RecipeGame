using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSandbag : MonoBehaviour
{

    public void CloseTrigger()
    {
        this.transform.parent.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
