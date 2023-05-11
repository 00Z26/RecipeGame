using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DrawLine : MonoBehaviour
{
    public GameObject Prefabs;
    public LineRenderer lrender;
    public List<Vector3> PenTrail = new List<Vector3>();
    public int _Number;
    public float MyWidth = 1;
    public Color MyColor;
    public Material mat;
    public List<GameObject> Lrender = new List<GameObject>();
    public Transform PenImg;
    private Collider2D temp;

    private void Update()
    {

        //PenImg.transform.localScale = Vector3.one * 0.8f * MyWidth;
        if (Mouse.current.leftButton.wasPressedThisFrame) //&& !EventSystem.current.IsPointerOverGameObject()) 
        {
 
                //ʵ��������
                lrender = Instantiate(Prefabs).GetComponent<LineRenderer>();
                Lrender.Add(lrender.gameObject);
                lrender.material = mat;
                //��ø������ϵ�LineRender���

                //������ʼ�ͽ�������ɫ
                //lrender.SetColors(Color.red, Color.blue);

                //������ʼ�ͽ����Ŀ��
                lrender.startWidth = MyWidth;
                lrender.endWidth = MyWidth;

                //����
                _Number = 0;


        }
        if(Mouse.current.rightButton.wasPressedThisFrame)
        //if(Keyboard.current.escapeKey.wasPressedThisFrame)
        //if (Input.GetKeyDown(KeyCode.Escape))
        {
            Return();
        }


        Vector2 mousePos = Mouse.current.position.ReadValue();
        Collider2D[] col = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(mousePos));
        if (col.Length > 0)
        {
            if (Mouse.current.leftButton.isPressed && lrender)//&& !EventSystem.current.IsPointerOverGameObject()
            {

                //PenImg.GetComponent<CanvasGroup>().alpha =0.2f;
                //ÿһ֡��⣬��������ʱ��Խ��������Խ��
                _Number++;

                //���ö�����
                lrender.positionCount = _Number;

                //���ö���λ��(����������������������Ļ����ת��Ϊ��������)
                lrender.SetPosition(_Number - 1, Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, -(Camera.main.transform.position.z + 3))));
                GameObject[] objs = GameObject.FindGameObjectsWithTag("DrawLine"); //Ѱ�ҵ�����������
                foreach (var obj in objs)
                {
                    obj.transform.parent = col[0].transform;//���ص���ǰ��ײ����
                    obj.tag = col[0].tag; //���Ѿ����ص��������tag�޸ĵ�
                }
            }
        }
        else
        {
            _Number = 0;
        }


    }
    public void Return()
    {
        if (Lrender.Count > 0)
        {
            if (lrender)
            {
                Lrender.Remove(lrender.gameObject);
                Destroy(lrender.gameObject);
            }
            else
            {
                Destroy(Lrender[Lrender.Count - 1]);
                Lrender.Remove(Lrender[Lrender.Count - 1]);
            }
        }
    }
}
