using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCamChange : InteractableAction
{

    public GameObject camObj;
    public GameObject grabPoint;
    public bool smooth;
    public bool autoRot;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activation()
    {
        base.Activation();
        camObj.GetComponent<CameraOptions>().smoothChange = smooth;
        camObj.GetComponent<CameraOptions>().autoRotate = autoRot;
        camObj.GetComponent<CameraOptions>().actualGrabPoint = grabPoint;

    }
}
