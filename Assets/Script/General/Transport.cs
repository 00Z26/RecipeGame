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
        //yield return Fade(1); //�����仯ǰ���ȱ�ڡ�������yield��ʹfadeִ�н�����������ִ�У��������ͬ��ִ��ʹ��StartCoroutine
        if (from != string.Empty)
        {
            yield return SceneManager.UnloadSceneAsync(from);
        }
        Debug.Log("press");
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive); //ִ�к�ֻ�г�פ�ͳ���to

        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1); //��ȡ�¼��س��������
        SceneManager.SetActiveScene(newScene);


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
}
