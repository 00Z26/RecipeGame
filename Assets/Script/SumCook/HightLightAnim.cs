using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HightLightAnim : MonoBehaviour
{

    public AnimationCurve showCurve;
    public AnimationCurve hideCurve;
    public float animSpeed;
    public float holdDuration;

    public GameObject highlightPanel;
    public Image image;

    public RecipeList recipeList;

    //private int recIndex;

    IEnumerator HideHighlight(GameObject gameObj, int index)
    {
        float timer = 0;
        while (timer <= 1)
        {
            gameObj.transform.localScale = Vector3.one * hideCurve.Evaluate(timer);
            timer += Time.deltaTime * animSpeed;
            yield return null;
        }
        this.GetComponent<CardShow>().ShowCardInfo(index);
    }

    public void HideHighlightPanel()
    {
        
        
    }


    IEnumerator WaitAndHide(float waitTime, int recipeIndex)
    {
        image.sprite = recipeList.recipeList[recipeIndex].dishPic;        
        yield return new WaitForSeconds(waitTime);  // 等待waitTime秒
        StartCoroutine(HideHighlight(highlightPanel, recipeIndex));
    }

    //由manager调用的入口
    public void ExcuHighlightAnim(int recipeIndex)
    {
        //弹出弹框
        Debug.Log("aaaaa");
        highlightPanel.SetActive(true);
        StartCoroutine(WaitAndHide(holdDuration, recipeIndex));  // 等待2秒后执行某个操作
        //highlightPanel.SetActive(false);
        //弹出结算界面
        
    }

}
