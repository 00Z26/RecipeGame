using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTrigger : MonoBehaviour
{
    public GameObject sumObj;
    public GameObject exit;
    private void ShowChip()
    {
        sumObj.GetComponent<SumManager>().isDishShow = true;
    }

    private void ShowExit()
    {
        exit.SetActive(true);
    }
}
