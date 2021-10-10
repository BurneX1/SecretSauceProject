using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgNrspw : InteractableAction
{
    public Characters cmp_plyr;
    public Transform pos;
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
        cmp_plyr.gameObject.transform.position = pos.position;
        cmp_plyr.SelfDmg(1);



    }
}
