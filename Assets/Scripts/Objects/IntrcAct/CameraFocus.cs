using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : InteractableAction
{
    public GameObject camObj;
    public GameObject objetivo;
    public float transTime;
    public float dist;
    public Vector3 offset;
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
        camObj.GetComponent<CameraOptions>().actualFocus = objetivo;
        camObj.GetComponent<CameraOptions>().transitionTime = transTime;
        camObj.GetComponent<CameraOptions>().nearDist = dist;
        camObj.GetComponent<CameraOptions>().focusOffset = offset;

        camObj.GetComponent<CameraOptions>().camType = 2;
    }
}
