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
        //��ʼʱ�ȼ���menu����
        //SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        //mainCanvas.enabled = false;
    }


    private void OnEnable()
    {
        //����Ϸ��ʼʱ���ص�outside���¼�
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
        //yield return Fade(1); //�����仯ǰ���ȱ�ڡ�������yield��ʹfadeִ�н�����������ִ�У��������ͬ��ִ��ʹ��StartCoroutine
        if (from != string.Empty)
        {
            yield return SceneManager.UnloadSceneAsync(from);
        }
        //Debug.Log("press");
        //player.SetActive(false);
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive); //ִ�к�ֻ�г�פ�ͳ���to

        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1); //��ȡ�¼��س��������
        SceneManager.SetActiveScene(newScene);
        //�Ѹ����npc������
        LoadNpc();
        //�Ѿ����������޸���ɫ
        DoorSwap(to);
        //�����¼�ȥ������޸ı߽�ֵ
        EventHandler.CallUpdateCameraScale(to);


        //yield return Fade(0);//�仯�����󣬽����
    }


    //private IEnumerator Fade(float targetAlpha)
    //{
    //    isFade = true;
    //    fadeCanvasGroup.blocksRaycasts = true;
    //    float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration; //��ֹ�������������ֵ����ʱ��

    //    while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
    //    {
    //        fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
    //        yield return null;
    //    }

    //    fadeCanvasGroup.blocksRaycasts = false;
    //    isFade = false;
    //}

    //�л�����ʱ��UI��ʾ����
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

    //�л�����ʱ�������
    public void LoadNpc()
    {
        //�����ٽ������ﲻ��
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
