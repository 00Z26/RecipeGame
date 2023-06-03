using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTrigger : MonoBehaviour
{
    public string from;
    public string to;
    public Vector3 pos;
    public void triggerSwap()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.localScale = Vector3.one;
        EventHandler.CallTriggerSumToMenuEvent(from, to, pos);

    }
}
