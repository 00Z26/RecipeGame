using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class ScrollText : MonoBehaviour
{
 
    /* 当前时间,用来在Update中固定时间移动字体的,不然移动速度无法控制 */
   private float CurrentTime;
   /* 判断当前字体是否移动 */
   private bool IsMove = false;


    /* 字体移动速度 */
    public float FontMoveSpeed;
    //字幕起始位置
    public Vector3 startPos;
    public Vector3 stopPos;

    public GameObject about;
    private void Awake()
    {
        /* 为了让故事背景字体从下往上播放,不然是从中间开始播放的 */
        this.transform.localPosition = startPos;
     }
 
 
   void Update()
  {
         /* 调用字体移动方法 */
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
     /* 限制每0.2秒移动一次 */
        if (CurrentTime >= 0.01f)
        {
            float y = this.transform.localPosition.y;
            this.transform.localPosition = new Vector3(0, y + FontMoveSpeed, 0);
            IsMove = true;
            /* 循环播放,让字体从显示框上方消失后,在显示框下方再出现,如此循环*/
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