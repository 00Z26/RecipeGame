using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVanim : MonoBehaviour
{
    public NpcData npcData;
    public GameObject animObj;
    private Animator anim;
    public void Update()
    {
        //animObj.GetComponent<Animator>().Play("TV_State1");
        anim = animObj.GetComponent<Animator>();
        if (npcData.loop == 1 || npcData.loop == 2 || npcData.loop == 3)
        {           
            anim.SetBool("1", true);
        }
        if (npcData.loop == 4 )
        {
            
            anim.SetBool("2", true);
        }
        if(npcData.loop == 5)
        {
            
            anim.SetBool("3", true);
        }
        if(npcData.loop >= 6)
        {
            anim.SetBool("2", true);

        }

    }
}
