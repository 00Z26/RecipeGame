using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Times : MonoBehaviour
{
    public TMP_Text tmpText;
    public OpenDoorTimes openDoorTimes;
    public Image point1;
    public Image point2;
    //���ų���
    private void FixedUpdate()
    {
        int currentTimes = openDoorTimes.thisLoopDoorTimes.Sum();
        //int currentTimes = 5 - GameObject.FindWithTag("Player").GetComponent<PhysicsCheck>().thisLoopOpenDoorTimes;
        if(currentTimes == 1)
        {
            point2.gameObject.SetActive(false);
        }
        if(currentTimes == 2)
        {
            point2.gameObject.SetActive(false);
            point1.gameObject.SetActive(false);
            tmpText.text = "�ж������þ�����ǰ��1L�Ҳࡣ";
            tmpText.fontSize = 31f;
        }
        if (currentTimes == 0)
        {
            tmpText.text = "�ж��㣺";
            tmpText.fontSize = 46f;
            point1.gameObject.SetActive(true);
            point2.gameObject.SetActive(true);
        }
        
        
        //int showTime = 2 * currentTimes;
        //tmpText.text = showTime.ToString() + ":00";

    }
}
