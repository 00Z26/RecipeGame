using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public int buttonReply;
    public TMP_Text button0;
    public TMP_Text button1;
    public TMP_Text button2;

    public void SetButton0Val()
    {
        //Debug.Log("click");
        buttonReply = 0;
        EventHandler.CallSendButtionValEvent(buttonReply);
        
    }
    public void SetButton1Val()
    {
        buttonReply = 1;
        EventHandler.CallSendButtionValEvent(buttonReply);
    }
    public void SetButton2Val()
    {
        buttonReply = 2;
        EventHandler.CallSendButtionValEvent(buttonReply);
    }
    public void Clear()
    {
        button0.text = null;
        button1.text = null;
        button2.text = null;
        button0.gameObject.transform.parent.parent.gameObject.SetActive(false);
        button1.gameObject.transform.parent.parent.gameObject.SetActive(false);
        button2.gameObject.transform.parent.parent.gameObject.SetActive(false);

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
