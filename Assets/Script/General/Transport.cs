using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transport : MonoBehaviour
{
    private bool isFade;

    private void Update()
    {
        //Transition(from, to);   
    }


    public void Transition(string from, string to)
    {
        
            //Debug.Log("press");
            StartCoroutine(TransitionToScene(from, to));
        
    }

    private IEnumerator TransitionToScene(string from, string to)
    {
        //yield return Fade(1); //场景变化前，先变黑。这里用yield会使fade执行结束后再向下执行，如果下述同步执行使用StartCoroutine
        if (from != string.Empty)
        {
            yield return SceneManager.UnloadSceneAsync(from);
        }
        Debug.Log("press");
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive); //执行后只有常驻和场景to

        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1); //获取新加载场景的序号
        SceneManager.SetActiveScene(newScene);


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
}
