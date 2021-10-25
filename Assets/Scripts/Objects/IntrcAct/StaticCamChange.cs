using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StaticCamChange : InteractableAction
{
    public bool dontAutoSelectCam;

    public GameObject camObj;
    public GameObject grabPoint;
    public Riel riel;
    public bool smooth;
    public bool autoRot;

    public InteractCaller currentCaller;




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


        

        if (dontAutoSelectCam == true)
        {
            camObj.GetComponent<CameraOptions>().smoothChange = smooth;
            camObj.GetComponent<CameraOptions>().autoRotate = autoRot;
            camObj.GetComponent<CameraOptions>().actualGrabPoint = grabPoint;
        }
        else
        {
            GrabPreset g = Array.Find(riel.targetArrays, grabpreset => grabpreset.target.name == currentCaller.actlDtcPly.name);
            if (g == null)
            {
                Debug.Log("No se encontró un target para " + currentCaller.actlDtcPly.name + " en el riel seleccionado . . ." + riel.targetArrays[0].target.name);
                return;

            }

            currentCaller.actlDtcPly.GetComponent<CharOneModl>().myCamera.GetComponent<CameraOptions>().smoothChange = smooth;
            currentCaller.actlDtcPly.GetComponent<CharOneModl>().myCamera.GetComponent<CameraOptions>().autoRotate = autoRot;
            currentCaller.actlDtcPly.GetComponent<CharOneModl>().myCamera.GetComponent<CameraOptions>().actualGrabPoint = g.point;

        }

    }
}
