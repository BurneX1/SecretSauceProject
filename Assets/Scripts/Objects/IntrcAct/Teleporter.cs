using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleporter : InteractableAction
{
    public InteractCaller intCaller;
    public bool useBtn;
    public TrigerButon btnCaller;
    public bool useCaller;
    public Transform tpPosition;
    public GameObject tpObj;
    public bool yAxis;
    public bool ableRot;

    // Start is called before the first frame update
    void OnEnable()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }

    public override void Activation()
    {
        GameObject tmpObj;
        if(useCaller==true)
        {
            if(useBtn == true)
            {
                tmpObj = btnCaller.actlDtcPly;
            }
            else
            {
                tmpObj = intCaller.actlDtcPly;
            }
            
        }
        else
        {
            tmpObj = tpObj;
        }
        
        if (yAxis == false)
        {
            if(tmpObj.GetComponent<NavMeshAgent>().enabled)
            {
                tmpObj.GetComponent<NavMeshAgent>().enabled = false;
                tmpObj.transform.position = new Vector3(tpPosition.position.x, tmpObj.transform.position.y, tpPosition.position.z);
                tmpObj.GetComponent<NavMeshAgent>().enabled = true;
            }
            else
            {
                tmpObj.transform.position = new Vector3(tpPosition.position.x, tmpObj.transform.position.y, tpPosition.position.z);
            }
            
        }
        else
        {
            if (tmpObj.GetComponent<NavMeshAgent>().enabled)
            {
                tmpObj.GetComponent<NavMeshAgent>().enabled = false;
                tmpObj.transform.position = tpPosition.position;
                tmpObj.GetComponent<NavMeshAgent>().enabled = true;
            }
            else
            {
                tmpObj.transform.position = tpPosition.position;
            }
        
        }

        if(ableRot==true)
        {
            tmpObj.transform.rotation = tpPosition.transform.rotation;
        }
    }
}
