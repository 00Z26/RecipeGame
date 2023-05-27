using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //������Ϸ�����л�����䶯������
    public NpcData npcData;
    public RecipeList recipeList;
    public OpenDoorTimes openDoorTimes;

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



    //��ʼ����Ϸʱ������������
    public void GameStartExcu(string str1,string str2,Vector3 vec3)
    {
        //npc״̬�ָ���ѭ�������ָ�
        npcData.loop = 1;
        foreach( NpcStruct anim in npcData.animPrefab)
        {
            anim.isNormal = true;
        }
        //���Ŵ����ָ�
        for( int i = 0;i< openDoorTimes.openTimes.Count;i++)
        {
            openDoorTimes.openTimes[i] = 0;
            openDoorTimes.thisLoopDoorTimes[i] = 0;
        }
        //ʳ����ʾ��ԭ
        foreach(RecipeData dish in recipeList.recipeList)
        {
            dish.isShow = false;
        }
        GameObject.FindWithTag("Player").GetComponent<PhysicsCheck>().thisLoopOpenDoorTimes = 0;


    }
    //����ÿ����Ϸ��ʼʱ�����ݣ�������ֹ��;�˳�
    //�ڿ�ʼ��Ϸ�����������ݱ仯��NPC��״̬
    //��Ŀ�̳е����ݣ�Loop���ܿ��Ŵ�����dish״̬


    //������Ϸ��ѡ�����
    //��������������̣�������Ϸ��Ҫ��npc���и�λ��loop++��
    //���ԣ��л�����+����loop,�������ݱ��ֲ���
    public void ContinueNextLoop(string str1,string str2, Vector3 vec3)
    {
        npcData.loop++;
        for (int i = 0; i < openDoorTimes.openTimes.Count; i++)
        {
            openDoorTimes.thisLoopDoorTimes[i] = 0;
        }
        GameObject.FindWithTag("Player").GetComponent<PhysicsCheck>().thisLoopOpenDoorTimes = 0;
    }



}
