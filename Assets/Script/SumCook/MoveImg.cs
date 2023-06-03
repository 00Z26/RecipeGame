using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveImg : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 targetPos;
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        
        this.transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
