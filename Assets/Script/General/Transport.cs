using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transport : MonoBehaviour
{
    private bool isFade;
    private GameObject player;
    public NpcData npcData;
    public OpenDoorTimes openDoorTimes;
    public Canvas mainCanvas;


    private void Awake()
    {
        //开始时先加载menu场景
        //SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        //mainCanvas.enabled = false;
    }


    private void OnEnable()
    {
        //新游戏开始时加载到outside的事件
        EventHandler.TriggerSwapNewGameEvent += Transition;
        EventHandler.TriggerShowRecipeEvent += Transition;
        EventHandler.TriggerSumToMenuEvent += Transition;
        EventHandler.TriggerContinue += Transition;
    }
    private void OnDisable()
    {
        EventHandler.TriggerSwapNewGameEvent -= Transition;
        EventHandler.TriggerShowRecipeEvent -= Transition;
        EventHandler.TriggerSumToMenuEvent -= Transition;
        EventHandler.TriggerContinue -= Transition;
    }
    public void Transition(string from, string to, Vector3 playerToPos)
    {

        //Debug.Log("press");
        player = GameObject.FindWithTag("Player");
        SwitchUI(to);

        StartCoroutine(TransitionToScene(from, to));

               
        player.transform.position = playerToPos;
    }

    private IEnumerator TransitionToScene(string from, string to)
    {
        //yield return Fade(1); //场景变化前，先变黑。这里用yield会使fade执行结束后再向下执行，如果下述同步执行使用StartCoroutine
        if (from != string.Empty)
        {
            yield return SceneManager.UnloadSceneAsync(from);
        }
        //Debug.Log("press");
        //player.SetActive(false);
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive); //执行后只有常驻和场景to

        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1); //获取新加载场景的序号
        SceneManager.SetActiveScene(newScene);
        //已跟随的npc不加载
        LoadNpc();
        //已经进过的门修改颜色
        DoorSwap(to);
        //触发事件去让相机修改边界值
        EventHandler.CallUpdateCameraScale(to);


        //yield return Fade(0);//变化结束后，渐变白
    }


    //private IEnumerator Fade(float targetAlpha)
    //{
    //    isFade = true;
    //    fadeCanvasGroup.blocksRaycasts = true;
    //    float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration; //防止负数，渐变过程值除以时间

    //    while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
    //    {
    //        fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
    //        yield return null;
    //    }

    //    fadeCanvasGroup.blocksRaycasts = false;
    //    isFade = false;
    //}

    //切换场景时的UI显示控制
    public void SwitchUI(string to)
    {
        if(to == "Menu" || to == "Cook" || to == "RecipeShow" )
        {
            mainCanvas.enabled = false;

        } else
        {
            mainCanvas.enabled = true;
        }
    }

    //切换场景时人物加载
    public void LoadNpc()
    {
        //跟随再进，人物不在
        List<int> teamNpcs = new List<int>();

        foreach(var item in player.GetComponent<PlayerController>().teamMembers)
        {
            teamNpcs.Add(item);
        }
        teamNpcs.Add(npcData.controllerIndex);

        Scene newScene = SceneManager.GetActiveScene();
        GameObject[] npcs = newScene.GetRootGameObjects();


        //GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
        if(npcs.Length > 0)
        {
            foreach (GameObject npc in npcs)
            {
                
                //Debug.Log(npc.name);
                if(npc.tag == "NPC")
                {
                    if (teamNpcs.Contains(npcData.GetPlayerIndex(npc.name)) && npc.transform.parent != player.transform )
                    {
                        //Debug.Log(npc.name);
                        //Debug.Log(npc.transform.parent.name);
                        npc.SetActive(false);
                    }
                }
            }
        }
    }


    public void DoorSwap(string to)
    {
        if (to != "Persisent" && to != "Outside" && to != "Cook" && to != "RecipeShow" && to != "Menu")
        {
            string doorName = to.Replace("Room", "Door");
            openDoorTimes.SetThisLoopTimes(doorName);
        }

        
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");

        foreach (GameObject door in doors)
        {

            if (openDoorTimes.GetThisLoopTimes(door.name) >= 1)
            {
                Debug.Log(door.name);
                door.GetComponent<BoxCollider2D>().enabled = false;
                door.GetComponent<SpriteRenderer>().color = new Color32(152, 92, 92, 255);
            }
        }
    }

}
