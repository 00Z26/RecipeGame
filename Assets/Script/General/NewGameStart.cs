using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameStart : MonoBehaviour
{
    public string from;
    public string to;
    public Vector3 playerPos;
    public void tiggerSwap()
    {
        EventHandler.CallTriggerSwapNewGameEvent(from, to, playerPos);
    }
}
