using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : InteractableAction
{
    public int addedAmmo;
    public InteractCaller caller;

    void Start()
    {
        caller = GetComponent<InteractCaller>();
    }

    void Update()
    {
    }

    public override void Activation()
    {
        if (caller.actlDtcPly.GetComponent<CharOneModl>().currentAmmo < caller.actlDtcPly.GetComponent<CharOneModl>().maxAmmo)
        {
            caller.actlDtcPly.GetComponent<CharOneModl>().currentAmmo += addedAmmo;
            gameObject.SetActive(false);
        }
    }
}
