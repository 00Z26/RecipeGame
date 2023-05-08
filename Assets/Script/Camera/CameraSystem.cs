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

    [Header("地图相机限制")]
    public float cameraXLeftScale;
    public float cameraXRightScale;
    public float cameraYUpScale;
    public float cameraYDownScale;
    public float deltaYPos;//相机与人的高度差

    private void Awake()
    {
        scene = SceneManager.GetSceneAt(1);


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
        //此处在增加了主菜单之后也要使用事件来获取值
        background = GameObject.FindGameObjectWithTag(scene.name);
        Debug.Log(background);
        cameraXLeftScale = background.GetComponent<Background>().GetcameraXLeftScale();
        cameraXRightScale = background.GetComponent<Background>().GetcameraXRightScale();
        cameraYUpScale = background.GetComponent<Background>().GetcameraYUpScale();
        cameraYDownScale = background.GetComponent<Background>().GetcameraYDownScale();

    }

    private void onUpdateCameraScale(string sceneName)
    {
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
