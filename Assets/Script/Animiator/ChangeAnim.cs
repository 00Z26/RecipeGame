using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnim : MonoBehaviour
{
    public GameObject eyes;
    public GameObject body;

    public DataTools dataTools;
    public NpcData npcData;

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
        //List<int> list = new List<int>();
        //foreach(int num in player.GetComponent<PlayerController>().teamMembers)
        //{
        //    list.Add(num);
        //}
        //list.Add(npcData.controllerIndex);
        Transform[] objList = player.transform.GetComponentsInChildren<Transform>(true);
        //foreach(Transform obj in objList)
        //{
        //    if (isLightOff)
        //    {
        //        if (obj.gameObject.tag != "eyes" && obj.gameObject.tag != "Bone" && obj.gameObject.GetComponent<SpriteRenderer>())
        //        {
        //            obj.gameObject.SetActive(false);
        //        }
        //    } else
        //    {
        //        if (obj.gameObject.tag != "eyes" && obj.gameObject.tag != "Bone"&& obj.gameObject.GetComponent<SpriteRenderer>())
        //        {
        //            obj.gameObject.SetActive(true);
        //        }
        //    }

        //}

        foreach (Transform obj in objList)
        {
            if(isLightOff)
            {
                if (obj.gameObject.name == "Mushroom") //蘑菇层级不同，单独处理
                {
                    GameObject darkObj = Instantiate(npcData.animPrefab[0].dark, player.transform);
                    darkObj.transform.localScale = new Vector3(0.5f, 0.5f, 1);
                    darkObj.gameObject.tag = "Dark";
                    darkObj.gameObject.name = darkObj.name.Replace("(Clone)", "");
                    obj.gameObject.SetActive(false);
                }
                if (obj.gameObject.tag == "NPC")
                {
                    obj.GetChild(0).gameObject.SetActive(false);
                    GameObject darkObj = Instantiate(npcData.animPrefab[npcData.GetPlayerIndex(obj.gameObject.name)].dark, obj.transform);
                    darkObj.transform.localScale = new Vector3(0.5f, 0.5f, 1);
                    darkObj.gameObject.tag = "Dark";

                    //obj.gameObject.SetActive(false);
                }
            } else
            {
                if(obj.gameObject.tag == "Dark")
                {
                    Destroy(obj.gameObject);
                }

                //if(obj.gameObject.name == "Mushroom")
                //{
                //    if(npcData.controllerIndex == 0)
                //        obj.gameObject.SetActive(true);
                //}
                //if(obj.gameObject.tag == "NPC")
                //{
                //    foreach(Transform npcSon in obj.transform.GetComponentsInChildren<Transform>(true))
                //    {
                //        if(npcSon.tag == obj.gameObject.name) {
                //            npcSon.gameObject.SetActive(true);
                //        }
                //        else
                //        {
                //            npcSon.gameObject.SetActive(false);
                //        }
                //    }
                //}
                //if(obj.gameObject.tag == "Tip")
                //{
                //    continue;
                //}

            }


        }



        //Destroy(player.transform.GetChild(0).gameObject);
        //foreach(int num in list)
        //{
        //    string name = npcData.GetPlayerName(num);
        //    if (isLightOff)
        //    {
        //        Destroy(dataTools.GetChildWithTag(player, npcData.GetPlayerName(npcData.controllerIndex)));
        //       GameObject obj = Instantiate(npcData.animPrefab[num].dark, player.transform);
        //        obj.transform.localPosition = Vector3.zero;
        //        obj.transform.localScale = Vector3.one;

        //    } else
        //    {
        //        Destroy(dataTools.GetChildWithTag(player, npcData.GetPlayerName(npcData.controllerIndex)+"_Dark"));
        //        GameObject obj = Instantiate(npcData.animPrefab[num].normal, player.transform);
        //        obj.transform.localPosition = Vector3.zero;
        //        obj.transform.localScale = Vector3.one;
        //    }
        //}

        //if (isLightOff)
        //{
        //    Destroy(dataTools.GetChildWithTag(player, "Mushroom"));
        //    GameObject eyeObj = Instantiate(eyes, player.transform);
        //    Debug.Log(eyeObj.name);
        //    eyeObj.transform.localPosition = Vector3.zero;
        //    eyeObj.transform.localScale = Vector3.one;
        //}
        //else
        //{
        //    Destroy(dataTools.GetChildWithTag(player, "Mushroom_Dark"));
        //    GameObject bodyObj = Instantiate(body, player.transform);
        //    //把NPC表控制改为mushroom对应的index
        //    bodyObj.transform.localPosition = new Vector3(0, -4.4f,0);
        //    bodyObj.transform.localScale = new Vector3(1.236f,1.246f,0);
        //}



    }

}
