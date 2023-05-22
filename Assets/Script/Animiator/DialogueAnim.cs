using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueAnim : MonoBehaviour
{
    private bool isExcu = true;
    private void OnEnable()
    {
        EventHandler.ExcuDialogueAnimEvent += OnDialogueAnim;
    }
    private void OnDisable()
    {
        EventHandler.ExcuDialogueAnimEvent -= OnDialogueAnim;
    }

    private void OnDialogueAnim(string[] obj)
    {
       
        Animator[] anims = GameObject.FindObjectsOfType<Animator>();
        //Debug.Log(anims[0]);
        //Debug.Log(anims.Length);
        foreach (Animator anim in anims)
        {   
            
            if (obj.Contains(anim.gameObject.name))
            {
                Debug.Log(anim.name);
                anim.SetBool("isExcu", isExcu);
            }
        }

    }
}
