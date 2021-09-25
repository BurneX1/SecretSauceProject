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
    public float bulletHitMissDitance = 10000f;

    public Transform bulletParent;
    
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
        //if (shootable)
        //{
            RaycastHit hit;

        if (Physics.Raycast(myCamera.transform.position, myCamera.transform.forward, out hit, Mathf.Infinity))
            {
                GameObject bullet = GameObject.Instantiate(plyBullet, pointer.transform.position, gun.transform.rotation);
                Bullet bulletController = bullet.GetComponent<Bullet>();
                bulletController.target = hit.point;
                bulletController.hit = true;
            }

        else
            {
                GameObject bullet = GameObject.Instantiate(plyBullet, pointer.transform.position, gun.transform.rotation);
                Bullet bulletController = bullet.GetComponent<Bullet>();
                 bulletController.target = myCamera.transform.position + myCamera.transform.forward;
                bulletController.hit = true;
            }
        // }   
    }
    public override void SelfDmg(int dmg)
    {
        base.SelfDmg(dmg);
        lifeMngObj.GetComponent<LifeManager>().Damage(dmg);

    }
}
