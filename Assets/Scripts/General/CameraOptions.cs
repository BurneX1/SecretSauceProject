using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraOptions : MonoBehaviour
{
    public int camType;
    public CinemachineBrain cmBrain;
    public GameObject target;
    public GameObject actualFocus;



    //----------------------------------------//
    //Por mientras dejoe sta webada, borrar mas tarde :3
    public float zoomSpeed;
    public float orthographicSizeMin;
    public float orthographicSizeMax;
    public float fovMin;
    public float fovMax;
    private Camera myCamera;

    public float sensitivity;

    //public GameObject target;//the target object

    public float speedMod = 10.0f;//a speed modifier
    private Vector3 point;//the coord to the point where the camera looks at


    public Vector3 offset = new Vector3(0, 0, 1);

    public float minZoom = 5f;
    public float maxZoom = 15f;


    private float currentZoom = 10f;
    public Vector3 consDir;

    //----------------------------------------//

    private void OnEnable()
    {
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
        cmBrain.enabled = false;
        myCamera.transform.LookAt(obj.transform);
        myCamera.transform.position = Vector3.Lerp(myCamera.transform.position, obj.transform.position, Time.deltaTime);
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

        yield return new WaitForSeconds(delayTime);

        if (changeType <= 0)
        {
            changeType = 1;
        }
        camType = changeType;
    }
}
