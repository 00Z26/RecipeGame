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
        EventHandler.CallTriggerSumToMenuEvent(from, to, pos);
    }
}
