using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Times : MonoBehaviour
{
    public TMP_Text tmpText;
    //���ų���
    private void Update()
    {
        int currentTimes = 5 - GameObject.FindWithTag("Player").GetComponent<PhysicsCheck>().thisLoopOpenDoorTimes;
        int showTime = 2 * currentTimes;
        tmpText.text = showTime.ToString() + ":00";

    }
}
