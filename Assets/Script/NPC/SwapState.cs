using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapState : MonoBehaviour
{
    public NpcData npcData;
    public GameObject player;
    public DataTools dataTools;

    private void OnEnable()
    {
        EventHandler.DialogueSwapStateEvent += OnSwapState;
    }
    private void OnDisable()
    {
        EventHandler.DialogueSwapStateEvent -= OnSwapState;
    }

    private void OnSwapState(int index)
    {
        //if (npcData.animPrefab[index].isNormal)
        //{
        //    npcData.animPrefab[index].isNormal = false;
        //}

        if (npcData.animPrefab[index].isNormal)
        {
            npcData.animPrefab[index].isNormal = false;
            if(index == 2) //玉米变
            {

                Transform temp = player.transform.GetComponentInChildren<Transform>();
                foreach (Transform t in temp)
                {
                    if(t.gameObject.tag == "NPC" && t.gameObject.name == "Corn")
                    {
                        Destroy(t.transform.GetChild(0).gameObject);
                        GameObject crazy = Instantiate(npcData.animPrefab[2].abnormal, t.transform);
                        crazy.transform.localScale = new Vector3(0.5f, 0.5f, 1);
                    }
                }
                //Debug.Log("实例化不正常状态1");
                //Debug.Log(temp.gameObject.name);
                //if (temp != null)
                //{
                //    Animator temp2 = temp.GetComponentInChildren<Animator>();
                //    Vector3 scale = temp.gameObject.transform.localScale;
                //    Destroy(temp.gameObject);
                //    Debug.Log("实例化不正常状态");
                //    GameObject obj = Instantiate(npcData.animPrefab[index].abnormal, player.transform);

                //    obj.transform.localPosition = new Vector3(-17.2000008f, -11.5f, 0); //玉米切换状态
                //    obj.transform.localScale = new Vector3(2.21000004f, 2.22781062f, 2.87219882f);//玉米切换状态

                //}

            }
            if (index == 4) //番茄变 夺舍鸡蛋去见番茄
            {
                GameObject[] tomatoes = GameObject.FindGameObjectsWithTag("NPC");
                Debug.Log("番茄黑化");
                foreach (GameObject obj in tomatoes)
                {
                    if (obj.name == "Tomato")
                    {
                        Destroy(obj.transform.GetChild(0).gameObject);
                        GameObject crazy = Instantiate(npcData.animPrefab[4].abnormal, obj.transform);
                        crazy.transform.localScale = new Vector3(0.6f, 0.6f, 1);

                    }
                }
            }

        }
        else
        {
            npcData.animPrefab[index].isNormal = true;
            Transform temp = player.transform.Find(npcData.GetPlayerName(index));
            if (temp != null)
            {
                Transform temp2 = temp.Find(npcData.GetPlayerName(index) + "_Crazy");
                Destroy(temp2);
                GameObject obj = Instantiate(npcData.animPrefab[index].abnormal, temp2);
            }
        }
    }
}
