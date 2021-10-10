using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria : InteractableAction
{
    public GameObject plyrTwoObj;
    private CharTwoCtrl _rbtChr;
    // Start is called before the first frame update
    void Start()
    {
        if (plyrTwoObj)
        {
            _rbtChr = plyrTwoObj.GetComponent<CharTwoCtrl>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activation()
    {
        base.Activation();
        if (_rbtChr.battery == false)
        {
            _rbtChr.battery = true;
            gameObject.SetActive(false);
        }

    }
}
