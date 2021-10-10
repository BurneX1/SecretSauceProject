using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObj : InteractableAction
{
    public GameObject activeObj;
    public bool activeStartBy;
    // Start is called before the first frame update
    void OnEnable()
    {
        if(activeObj.activeSelf != activeStartBy)
        {
            activeObj.SetActive(activeStartBy);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activation()
    {
        base.Activation();
        if(activeObj.activeSelf == true)
        {
            activeObj.SetActive(false);
        }
        else
        {
            activeObj.SetActive(true);
        }

    }
}
