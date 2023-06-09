using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //挂载游戏过程中会产生变动的数据
    public NpcData npcData;
    public RecipeList recipeList;
    public OpenDoorTimes openDoorTimes;
    public GameObject player;
    private DataTools dataTools;
    public void OnEnable()
    {
        EventHandler.TriggerSwapNewGameEvent += GameStartExcu;
        EventHandler.TriggerContinue += ContinueNextLoop;
    }
    public void OnDisable()
    {
        EventHandler.TriggerSwapNewGameEvent -= GameStartExcu;
        EventHandler.TriggerContinue -= ContinueNextLoop;
    }
    private void Start()
    {
        dataTools = new DataTools();
    }


    //开始新游戏时更新所有数据
    public void GameStartExcu(string str1,string str2,Vector3 vec3)
    {
        foreach(Transform t in player.transform.GetComponentInChildren<Transform>())
        {
            if(t.gameObject.tag == "NPC")
            {
                Destroy(t.gameObject);
            }
        }

        //npc状态恢复，循环次数恢复
        npcData.loop = 1;
        npcData.controllerIndex = 0;
        dataTools.GetChildWithTag(player, npcData.GetPlayerName(npcData.controllerIndex)).SetActive(true);
        foreach ( NpcStruct anim in npcData.animPrefab)
        {
            anim.isNormal = true;
        }
        //开门次数恢复
        for( int i = 0;i< openDoorTimes.openTimes.Count;i++)
        {
            openDoorTimes.openTimes[i] = 0;
            openDoorTimes.thisLoopDoorTimes[i] = 0;
        }
        //食谱显示复原
        foreach(RecipeData dish in recipeList.recipeList)
        {
            dish.isShow = false;
        }
        GameObject.FindWithTag("Player").GetComponent<PhysicsCheck>().thisLoopOpenDoorTimes = 0;
        player.GetComponent<PlayerController>().teamMembers.Clear();


    }
    //保存每轮游戏开始时的数据，用来防止中途退出
    //在开始游戏后会产生的数据变化：NPC的状态
    //周目继承的数据：Loop，总开门次数，dish状态


    //继续游戏的选项操作
    //如果按照正常流程，继续游戏需要对npc进行复位，loop++，
    //所以，切换场景+增加loop,其他数据保持不变
    public void ContinueNextLoop(string str1,string str2, Vector3 vec3)
    {
        foreach (Transform t in player.transform.GetComponentInChildren<Transform>())
        {
            if (t.gameObject.tag == "NPC")
            {
                Destroy(t.gameObject);
            }
        }
        npcData.loop++;
        npcData.controllerIndex = 0;
        dataTools.GetChildWithTag(player, npcData.GetPlayerName(npcData.controllerIndex)).SetActive(true);
        player.GetComponent<PlayerController>().teamMembers.Clear();
        for (int i = 0; i < openDoorTimes.openTimes.Count; i++)
        {
            openDoorTimes.thisLoopDoorTimes[i] = 0;
        }
        GameObject.FindWithTag("Player").GetComponent<PhysicsCheck>().thisLoopOpenDoorTimes = 0;
    }



}
