using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharOneModl : Characters
{
    public GameObject lifeMngObj;
    public GameObject gun;
    public GameObject plyBullet;
    public GameObject pointer;

    public bool aimState;
    public bool shootable;
    public float coldTime;
    public float atkTime;
    public float aimZoom;
    public float aimSpd;
    
    public CharOneModl() : base ()
    {

    }
    public void GunPoint()
    {

    }
    public void Aim()
    {
        if (aimState)
        {
            myCamera.GetComponent<CameraOptions>().ZoomTo(aimZoom, aimSpd);
            if (myCamera.GetComponent<Camera>().fieldOfView == aimZoom)
            {
                shootable = true;
            }
            else
            {
                shootable = false;
            }
        }
        else
        {
            myCamera.GetComponent<CameraOptions>().DfltZoom(aimSpd);
            shootable = false;
        } 

    }
    public void SpcRangeAtck()
    {
        /*if (shootable)
        {*/
            GameObject bllt = Instantiate(plyBullet);
            bllt.transform.position = pointer.transform.position;
            bllt.transform.rotation = gun.transform.rotation;
        //}   
    }
    public override void SelfDmg(int dmg)
    {
        base.SelfDmg(dmg);
        lifeMngObj.GetComponent<LifeManager>().Damage(dmg);

    }
}
