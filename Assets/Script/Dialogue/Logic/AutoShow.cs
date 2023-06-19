using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShow : MonoBehaviour
{
    public NpcData npcData;
    // Start is called before the first frame update
    void Start()
    {
        if(npcData.loop > 16)
            this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
