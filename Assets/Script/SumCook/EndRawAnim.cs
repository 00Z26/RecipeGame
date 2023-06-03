using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRawAnim : MonoBehaviour
{
    private void HideRaw()
    {
        GameObject player = GameObject.FindWithTag("Player");
        //player.SetActive(false);
        player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
