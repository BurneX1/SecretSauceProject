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
    Quaternion rot;
    Vector3 dir;

    [Header("CameraValues")]
    public Transform camTarget;
    public float pLerp = .02f;
    public float rLerp = .01f;
    private Quaternion camRotation;
    public float sensitivity;
    public float maxRot;
    public float minRot;

    [Header("CurveFocusValues")]
    public float curveSg;
    public Transform[] segmts;

    [Header("FocusValues")]
    public GameObject actualFocus;
    public float transitionTime;
    public float nearDist;
    public Vector3 focusOffset;

    [Header("ZoomValues")]
    public float dfltZoom;
    public float newZoomValue;
    public float zoomSpd;

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
        camRotation = transform.localRotation;
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
                CurveFocusObj(segmts, actualFocus);
                break;

            case 4:
                //ZoomTo(newZoomValue, zoomSpd);
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
        /*Vector3 tmp = obj.transform.position - myCamera.transform.position;
        Vector3 rotDif = new Vector3(myCamera.transform.rotation.x - Quaternion.LookRotation(tmp).x, 
            myCamera.transform.rotation.y - Quaternion.LookRotation(tmp).y, 
            myCamera.transform.rotation.z - Quaternion.LookRotation(tmp).z);
        float tempTime = 0; 
        tempTime += Time.deltaTime;*/
        //myCamera.transform.rotation = Quaternion.RotateTowards(myCamera.transform.rotation, Quaternion.LookRotation(tmp), (Mathf.Abs(rotDif.x + rotDif.y + rotDif.z) * Time.deltaTime * 180)  /  (transitionTime*Time.deltaTime * 50));
        //myCamera.transform.LookAt(Vector3.Lerp(myCamera.transform.right, obj.transform.position + focusOffset, Time.deltaTime));
        if(Vector3.Distance(myCamera.transform.position, obj.transform.position + focusOffset) >= nearDist)
        myCamera.transform.position = Vector3.Lerp(myCamera.transform.position, obj.transform.position + focusOffset, Time.deltaTime);
        //---------------------//
        dir = (new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z) - transform.position).normalized;
        rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.05f);


        StartCoroutine(BackToDefault(transitionTime, 1));
        
    }

    void CurveFocusObj(Transform[] points, GameObject obj)
    {
        gmManager.GetComponent<PlayerMangr>().NonActionPly();
        cmBrain.enabled = false;

        if (Vector3.Distance(myCamera.transform.position, obj.transform.position + focusOffset) >= nearDist)
        {

            //myCamera.transform.position = Vector3.Lerp(myCamera.transform.position, obj.transform.position + focusOffset, Time.deltaTime);

            int totalSegments = (points.Length - 1) / 2;
            curveSg += Time.deltaTime / transitionTime;
            int currentSegment = Mathf.Max(Mathf.CeilToInt(totalSegments * curveSg), 1);
            float u = (curveSg * totalSegments) - (currentSegment - 1);
            Vector3 position = MathTools.BezierLerp(
                    points[(currentSegment - 1) * 2].position,
                    points[((currentSegment - 1) * 2) + 1].position,
                    points[((currentSegment - 1) * 2) + 2].position,    
                    u);

            myCamera.transform.position = position;
        }
        //---------------------//
        dir = (new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z) - transform.position + focusOffset).normalized;
        rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.05f / transitionTime);


        StartCoroutine(BackToDefault(transitionTime, 1));
    }
    void FixedCam(GameObject obj)
    {
        //Cambiar este tipo decamara luego, ta fea xD
        cmBrain.enabled = false;
        transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);


        camRotation.x += Input.GetAxisRaw("Mouse Y") * sensitivity * (-1);
        camRotation.y += Input.GetAxisRaw("Mouse X") * sensitivity;

        camRotation.x = Mathf.Clamp(camRotation.x, minRot, maxRot);

        transform.localRotation = Quaternion.Euler(camRotation.x,camRotation.y,camRotation.z);
        //cmBrain.enabled = true;
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

    public void ZoomTo(float zoomLv, float smthVel)
    {
        cmBrain.enabled = false;
        myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, zoomLv, smthVel * Time.deltaTime);
    }

    public void DfltZoom(float smthVel)
    {
        myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, dfltZoom, smthVel * Time.deltaTime);
        if (myCamera.fieldOfView == dfltZoom)
        {
            cmBrain.enabled = true;
        }
    }
}
