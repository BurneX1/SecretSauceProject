using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraOptions : MonoBehaviour
{
    private bool enumeratorAct;
    public GameObject gmManager;
    public int camType;
    public CinemachineBrain cmBrain;
    public GameObject target;


    [Header("FocusValues")]
    public GameObject actualFocus;
    public float transitionTime;
    public float nearDist;
    public Vector3 focusOffset;

    private Camera myCamera;



    //----------------------------------------//
    //Por mientras dejoe sta webada, borrar mas tarde :3
    /*public float zoomSpeed;
    public float orthographicSizeMin;
    public float orthographicSizeMax;
    public float fovMin;
    public float fovMax;


    public float sensitivity;


    public float speedMod = 10.0f;
    private Vector3 point;


    public Vector3 offset = new Vector3(0, 0, 1);

    public float minZoom = 5f;
    public float maxZoom = 15f;


    private float currentZoom = 10f;
    public Vector3 consDir;*/

    //----------------------------------------//

    private void OnEnable()
    {
        enumeratorAct = false;
        myCamera = GetComponent<Camera>();
        cmBrain = GetComponent<CinemachineBrain>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CamTypes();
    }

    void CamTypes()
    {
        switch(camType)
        {
            //Camara Fija
            case 1:
                FixedCam(target);
                break;
            //Enfoque a Obj
            case 2:
                FocusObj(actualFocus);
                break;

            case 3:

                break;

            default:
                FixedCam(target);
                break;
        }
    }

    void FocusObj(GameObject obj)
    {
        gmManager.GetComponent<PlayerMangr>().NonActionPly();
        cmBrain.enabled = false;
        myCamera.transform.LookAt(obj.transform);
        if(Vector3.Distance(myCamera.transform.position, obj.transform.position + focusOffset) >= nearDist)
        myCamera.transform.position = Vector3.Lerp(myCamera.transform.position, obj.transform.position + focusOffset, Time.deltaTime);
        StartCoroutine(BackToDefault(transitionTime, 1));
        
    }

    void FixedCam(GameObject obj)
    {
        //Cambiar este tipo decamara luego, ta fea xD
        cmBrain.enabled = true;
    }

    void FreeCam()
    {

    }

    public IEnumerator BackToDefault(float delayTime, int changeType)
    {
        if (enumeratorAct == true)
        {
            yield return 0;
        }
        else
        {
            enumeratorAct = true;
            yield return new WaitForSeconds(delayTime);

            if (changeType <= 0)
            {
                changeType = 1;
                
            }
            gmManager.GetComponent<PlayerMangr>().EnableActionPlayer();
            camType = changeType;
            enumeratorAct = false;
        }
    }


    public void ChangeToFocus(GameObject obj,float moveTime)
    {
        actualFocus = obj;
        transitionTime = moveTime;
        camType = 2;
    }
}
