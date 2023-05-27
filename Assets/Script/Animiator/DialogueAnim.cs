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

    //������Ϊ���涯��-���ᶯ��-�Ի�����
    //�������Ķ�����plaryer��ִ�У��������ж�ʱ��λ�ã��ߣ��ܣ���
    //�Ի�����������obj_anim���и����ֻ��obj����ִ�ж�Ӧ��obj����Ŀ������������
    //��Ҫ�����嶯������-�޸Ķ���ִ���߼�-ȷ����������������-��ֵ

    //�����Ի��ڵĶ���
    //�������������֣�������벿�֣�������
    private void OnDialogueAnim(List<string> objList, List<string> animList, List<string> allList)
    {
       
        Animator[] anims = GameObject.FindObjectsOfType<Animator>();
        for (int i = 0; i < objList.Count; i++)
        {
            GameObject gameObject = GameObject.Find(objList[i]);
            //Debug.Log(gameObject.name);
            Animator animator = gameObject.GetComponentInChildren<Animator>();
            animator?.SetBool(allList[i], true);

            //ɳ�����ɺ���ʧ
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
