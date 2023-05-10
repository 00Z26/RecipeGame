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

    private void Update()
    {
        PenImg.transform.localScale = Vector3.one * 0.8f * MyWidth;
        if (Mouse.current.leftButton.wasPressedThisFrame) //&& !EventSystem.current.IsPointerOverGameObject()) 
        {
            //实例化对象
            lrender = Instantiate(Prefabs).GetComponent<LineRenderer>();
            Lrender.Add(lrender.gameObject);
            lrender.material = mat;
            //获得该物体上的LineRender组件

            //设置起始和结束的颜色
            //lrender.SetColors(Color.red, Color.blue);

            //设置起始和结束的宽度
            lrender.startWidth = MyWidth;
            lrender.endWidth = MyWidth;

            //计数
            _Number = 0;
        }
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        //if (Input.GetKeyDown(KeyCode.Escape))
        {
            Return();
        }
        if (Mouse.current.leftButton.isPressed  && lrender)//&& !EventSystem.current.IsPointerOverGameObject()
        {
            //PenImg.GetComponent<CanvasGroup>().alpha =0.2f;
            //每一帧检测，按下鼠标的时间越长，计数越多
            _Number++;

            //设置顶点数
            lrender.positionCount = _Number;

            //设置顶点位置(顶点的索引，将鼠标点击的屏幕坐标转换为世界坐标)
            lrender.SetPosition(_Number - 1, Camera.main.ScreenToWorldPoint(new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, -(Camera.main.transform.position.z+3))));


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
