using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueAnim : MonoBehaviour
{
    private bool isExcu = true;
    private void OnEnable()
    {
        EventHandler.ExcuDialogueAnimEvent += OnDialogueAnim;
    }
    private void OnDisable()
    {
        EventHandler.ExcuDialogueAnimEvent -= OnDialogueAnim;
    }

    //动画分为跟随动画-夺舍动画-对话动画
    //跟随夺舍的动画在plaryer下执行，来控制行动时的位置，走，跑，跳
    //对话动画命名：obj_anim，切割名字获得obj，再执行对应的obj下面的控制器传入变量
    //需要：定义动画变量-修改动画执行逻辑-确认物体和组件子物体-传值

    //触发对话内的动画
    //变量：物体名字，动画后半部分，动画名
    private void OnDialogueAnim(List<string> objList, List<string> animList, List<string> allList)
    {
       
        Animator[] anims = GameObject.FindObjectsOfType<Animator>();
        for (int i = 0; i < objList.Count; i++)
        {
            GameObject gameObject = GameObject.Find(objList[i]);
            //Debug.Log(gameObject.name);
            Animator animator = gameObject.GetComponentInChildren<Animator>();
            animator?.SetBool(allList[i], true);

            //沙袋击飞后消失
            if (allList[i] == "Sandbag_HangFly")
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

    }

    //private void LemonAnim(GameObject lemon, string animName)
    //{
    //    Animator animator = lemon.GetComponentInChildren<Animator>();
    //    animator.SetBool(animName, true);
    //}
}
