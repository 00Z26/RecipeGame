using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class ScrollText : MonoBehaviour
{
 
    /* ��ǰʱ��,������Update�й̶�ʱ���ƶ������,��Ȼ�ƶ��ٶ��޷����� */
   private float CurrentTime;
   /* �жϵ�ǰ�����Ƿ��ƶ� */
   private bool IsMove = false;


    /* �����ƶ��ٶ� */
    public float FontMoveSpeed;
    //��Ļ��ʼλ��
    public Vector3 startPos;
    public Vector3 stopPos;

    public GameObject about;
    private void Awake()
    {
        /* Ϊ���ù��±�������������ϲ���,��Ȼ�Ǵ��м俪ʼ���ŵ� */
        this.transform.localPosition = startPos;
     }
 
 
   void Update()
  {
         /* ���������ƶ����� */
         if(this.transform.localPosition.y < stopPos.y)
        {
            FontMoveUp();
        }
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            about.SetActive(false);
        }

    }

    private void FontMoveUp()
    {
        CurrentTime += Time.deltaTime;
     /* ����ÿ0.2���ƶ�һ�� */
        if (CurrentTime >= 0.01f)
        {
            float y = this.transform.localPosition.y;
            this.transform.localPosition = new Vector3(0, y + FontMoveSpeed, 0);
            IsMove = true;
            /* ѭ������,���������ʾ���Ϸ���ʧ��,����ʾ���·��ٳ���,���ѭ��*/
            //if (y >= stopPos.y)
            //{
            //    this.transform.localPosition = startPos;
            //}
        }

         if (IsMove == true)
       {
            CurrentTime = 0;
            IsMove = false;
         }

     }
}