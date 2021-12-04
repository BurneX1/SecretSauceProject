using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleporter : InteractableAction
{
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

        if (yAxis == false)
        {
            if(tpObj.GetComponent<NavMeshAgent>())
            {
                tpObj.GetComponent<NavMeshAgent>().enabled = false;
                tpObj.transform.position = new Vector3(tpPosition.position.x, tpObj.transform.position.y, tpPosition.position.z);
                tpObj.GetComponent<NavMeshAgent>().enabled = true;
            }
            else
            {
                tpObj.transform.position = new Vector3(tpPosition.position.x, tpObj.transform.position.y, tpPosition.position.z);
            }
            
        }
        else
        {
            if (tpObj.GetComponent<NavMeshAgent>())
            {
                tpObj.GetComponent<NavMeshAgent>().enabled = false;
                tpObj.transform.position = tpPosition.position;
                tpObj.GetComponent<NavMeshAgent>().enabled = true;
            }
            else
            {
                tpObj.transform.position = tpPosition.position;
            }
        
        }

        if(ableRot==true)
        {
            tpObj.transform.rotation = tpPosition.transform.rotation;
        }
    }
}
