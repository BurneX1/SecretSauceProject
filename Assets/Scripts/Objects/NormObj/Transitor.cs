using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitor : InteractableAction
{
    public GameObject p_one;
    public Animator one_trans;
    public GameObject p_two;
    public Animator two_trans;

    public TrigerButon currentCaller;
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
        if(currentCaller.actlDtcPly == p_one)
        {
            one_trans.SetTrigger("Rigth");
        }
        else if(currentCaller.actlDtcPly == p_two)
        {
            two_trans.SetTrigger("Left");
        }


    }




}
