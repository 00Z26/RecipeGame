using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVanim : MonoBehaviour
{

    public OpenDoorTimes openDoorTimes;
    public GameObject animObj;
    private Animator anim;
    public void Start()
    {
        //animObj.GetComponent<Animator>().Play("TV_State1");
        anim = animObj.GetComponent<Animator>();
        if (openDoorTimes.openTimes[2] == 1 || openDoorTimes.openTimes[2] == 2 || openDoorTimes.openTimes[2] == 3)
        {
            anim.Play("Tv_State1");
            
        }
        if (openDoorTimes.openTimes[2] == 4 )
        {
            anim.Play("Tv_State2");
            
        }
        if(openDoorTimes.openTimes[2] == 5)
        {
            anim.Play("Tv_State3");
            
        }
        if(openDoorTimes.openTimes[2] >= 6)
        {
            anim.Play("Tv_State2");
            

        }

    }
}
