using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeController : MonoBehaviour
{
    private Sprite npcSprite;
    public GameObject player;
    private Sprite playerSprite;
    private GameObject[] previousNpcs;
    private GameObject previousNpc;

    //public Collider2D other;
    public NpcData npcData;

    private void OnEnable()
    {
        EventHandler.TriggerChangeEvent += OnTriggerChangeEvent;
    }
    private void OnDisable()
    {
        EventHandler.TriggerChangeEvent -= OnTriggerChangeEvent;
    }

    private void OnTriggerChangeEvent(int npcIndex)
    {
        //用事件获取到对应的npc的object，这样后面就未必用other。
        String name = npcData.GetPlayerName(npcIndex);
        GameObject gameObject = GameObject.Find(name);
        //Debug.Log(name);

        if (gameObject != null)
        {
            npcSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            playerSprite = player.GetComponent<SpriteRenderer>().sprite;
            //Debug.Log(playerSprite.name);
            previousNpc = getPreviousNpc(playerSprite.name);
            player.GetComponent<SpriteRenderer>().sprite = npcSprite;

            //Debug.Log(previousNpc?.name);
            gameObject.SetActive(false);
            previousNpc?.SetActive(true);
        }


    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    other = collision;
    //}
    private GameObject getPreviousNpc(string name)
    {
        previousNpcs = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject item in previousNpcs)
        {
            if (item.gameObject.name == name)
            {
                return item;
            }
        }
        return null;
    }
}
