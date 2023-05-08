using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSystem : MonoBehaviour
{
    public Transform playerTarget;
    public float moveTime;
    Scene scene;
    GameObject background;
    private PhysicsCheck physicsCheck;

    [Header("��ͼ�������")]
    public float cameraXLeftScale;
    public float cameraXRightScale;
    public float cameraYUpScale;
    public float cameraYDownScale;
    public float deltaYPos;//������˵ĸ߶Ȳ�
    public float YMoveDis;

    private void Awake()
    {
        scene = SceneManager.GetSceneAt(1);
        YMoveDis = 0;


    }

    private void OnEnable()
    {
        EventHandler.updateCameraScale += onUpdateCameraScale;
 
    }



    private void OnDisable()
    {
        EventHandler.updateCameraScale -= onUpdateCameraScale;
    }


    private void Start()
    {   
        //�˴������������˵�֮��ҲҪʹ���¼�����ȡֵ
        background = GameObject.FindGameObjectWithTag(scene.name);
        Debug.Log(background);
        cameraXLeftScale = background.GetComponent<Background>().GetcameraXLeftScale();
        cameraXRightScale = background.GetComponent<Background>().GetcameraXRightScale();
        cameraYUpScale = background.GetComponent<Background>().GetcameraYUpScale();
        cameraYDownScale = background.GetComponent<Background>().GetcameraYDownScale();

    }

    
    private void onUpdateCameraScale(string sceneName)
    {
        //�л�����ʱ����������ȡ�³�����ƫ��ֵ
        background = GameObject.FindGameObjectWithTag(sceneName);
        Debug.Log(sceneName);
        cameraXLeftScale = background.GetComponent<Background>().GetcameraXLeftScale();
        cameraXRightScale = background.GetComponent<Background>().GetcameraXRightScale();
        cameraYUpScale = background.GetComponent<Background>().GetcameraYUpScale();
        cameraYDownScale = background.GetComponent<Background>().GetcameraYDownScale();
    }



    private Vector3 posTarget;
    private void LateUpdate()
    {
        //���¼��л�ȡ��bool״̬�����µ�deltaY��ֵ��if bool YDis����ֵ����Ȼ�͸Ļ�0

        float posY = Mathf.Clamp(playerTarget.position.y + deltaYPos, cameraYDownScale, cameraYUpScale);
        float posX = Mathf.Clamp(playerTarget.position.x, cameraXLeftScale, cameraXRightScale);
        //Debug.Log(posX);
        posTarget = new Vector3(posX, posY, transform.position.z);
        if (playerTarget != null)
        {   if(transform.position != posTarget)
            {
                transform.position = Vector3.Lerp(transform.position, posTarget, moveTime);    
            }
        }
    }
}
