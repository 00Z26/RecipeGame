using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeController : MonoBehaviour
{
    public Sprite npcSprite;
    public Sprite playerSprite;
    public GameObject[] previousNpcs;
    public GameObject previousNpc;


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        npcSprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;        
        playerSprite = other.gameObject.GetComponent<SpriteRenderer>().sprite;
        Debug.Log(playerSprite.name);
        previousNpc = getPreviousNpc(playerSprite.name);
        other.gameObject.GetComponent<SpriteRenderer>().sprite = npcSprite;

        Debug.Log(previousNpc?.name);
        this.gameObject.SetActive(false);
        previousNpc?.SetActive(true);
    }
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
