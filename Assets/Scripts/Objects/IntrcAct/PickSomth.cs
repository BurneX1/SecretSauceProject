using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSomth : InteractableAction
{

    public GameObject toPickObj;
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
        currentCaller.actlDtcPly.GetComponent<CharOneModl>().pickUp(toPickObj);

    }
}
