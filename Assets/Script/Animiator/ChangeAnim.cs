using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnim : MonoBehaviour
{
    public GameObject eyes;
    public GameObject body;

    public DataTools dataTools;

    private void OnEnable()
    {
        EventHandler.SwichLightAnimEvent += OnSwitchLight;
    }
    private void OnDisable()
    {
        EventHandler.SwichLightAnimEvent -= OnSwitchLight;
    }

    public void OnSwitchLight(bool isLightOff)
    {
        dataTools = new DataTools();
        GameObject player = GameObject.FindWithTag("Player");
        
        //Destroy(player.transform.GetChild(0).gameObject);

        if (isLightOff)
        {
            Destroy(dataTools.GetChildWithTag(player, "Mushroom"));
            GameObject eyeObj = Instantiate(eyes, player.transform);
            Debug.Log(eyeObj.name);
            eyeObj.transform.localPosition = Vector3.zero;
            eyeObj.transform.localScale = Vector3.one;
        }
        else
        {
            Destroy(dataTools.GetChildWithTag(player, "Mushroom_Dark"));
            GameObject bodyObj = Instantiate(body, player.transform);
            //把NPC表控制改为mushroom对应的index
            bodyObj.transform.localPosition = new Vector3(0, -4.4f,0);
            bodyObj.transform.localScale = new Vector3(1.236f,1.246f,0);
        }
        
        

    }

}
