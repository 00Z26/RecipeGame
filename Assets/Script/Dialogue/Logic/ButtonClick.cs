using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public int buttonReply;
    public void SetButton0Val()
    {
        Debug.Log("click");
        buttonReply = 0;
        
    }
    public void SetButton1Val()
    {
        buttonReply = 1;
    }
    public void SetButton2Val()
    {
        buttonReply = 2;
    }



    //三个功能：下一句，跟随，夺舍
    //button作用：传回来一个int就行
    //根据触发的按钮的index不同，读取相应的nextIndex值
    //根据index触发三个功能。

    //index >= 0 触发下一条对话



    //index < 0 停止对话，切割字符，确认被操作npc

    //调用controller中的函数直接下一句，修改index
    //用事件把reply传回controller 继续对话
    //把值广播回去，但只有有碰撞接触的进行操作，相当于事件只更改值，操作由controller处理，此时选项消失，模拟按下剧情

}
