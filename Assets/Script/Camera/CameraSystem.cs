using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSystem : MonoBehaviour
{

    private Scene scene;
    private GameObject background;
    private PhysicsCheck physicsCheck;
    private bool moveDialogueCamera;

    [Header("��ͼ�������")]
    public Transform playerTarget;
    public float moveTime;


    public float cameraXLeftScale;
    public float cameraXRightScale;
    public float cameraYUpScale;
    public float cameraYDownScale;
    public float deltaYPos;//������˵ĸ߶Ȳ�
    private float YMoveDis;

    private void Awake()
    {
        scene = SceneManager.GetSceneAt(1);
        YMoveDis = 0;


    }

    private void OnEnable()
    {
        EventHandler.updateCameraScale += onUpdateCameraScale;
        EventHandler.UpdateDialogueState += onUpdateDialogueCamera;
        EventHandler.ExitDialogueState += onExitDialogueCamera;


    }



    private void OnDisable()
    {
        EventHandler.updateCameraScale -= onUpdateCameraScale;
        EventHandler.UpdateDialogueState -= onUpdateDialogueCamera;
        EventHandler.ExitDialogueState -= onExitDialogueCamera;
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

    private void onUpdateDialogueCamera(bool isDialogueOn, float delta)
    {
        moveDialogueCamera = isDialogueOn;
        YMoveDis = delta;
    }
    private void onExitDialogueCamera(bool isDialogueOn)
    {
        moveDialogueCamera = isDialogueOn;
    }

    private Vector3 posTarget;
    private void LateUpdate()
    {
        //�Ӵ��������¼��л�ȡ��bool״̬�����µ�deltaY��ֵ��if bool YDis����ֵ����Ȼ�͸Ļ�0
        if(!moveDialogueCamera)
        {
            YMoveDis = 0;
        }

        float posY = Mathf.Clamp(playerTarget.position.y + deltaYPos, cameraYDownScale, cameraYUpScale);
        float posX = Mathf.Clamp(playerTarget.position.x, cameraXLeftScale, cameraXRightScale);
        //Debug.Log(posX);
        posTarget = new Vector3(posX, posY + YMoveDis, transform.position.z);
        if (playerTarget != null)
        {   if(transform.position != posTarget)
            {
                transform.position = Vector3.Lerp(transform.position, posTarget, moveTime);    
            }
        }
    }
}
