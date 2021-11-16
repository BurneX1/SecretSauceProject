using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharOneModl : Characters
{
    
    public GameObject gun;
    public GameObject plyBullet;
    public GameObject pointer;
    public GameObject bodyPart;
    public RaycastHit shootHitPoint;

    public Ray mouseRay;
    public Vector3 linePos;

    public bool aimState;
    public bool shootable;
    public float coldTime;
    public float atkTime;
    public float aimZoom;
    public float aimSpd;
    public float bulletHitMissDitance = 10000f;
    public LayerMask shootLyr;

    public Transform bulletParent;

    public int maxAmmo;
    public int currentAmmo;

    public bool canReceiveDmg;

    public void FixedUpdate()
    {
        //cmp_rb.velocity = new Vector3(0, cmp_rb.velocity.y, 0);
    }
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
            Vector3 rayShootPoint;
            rayShootPoint = Input.mousePosition;
            mouseRay = myCamera.ScreenPointToRay(rayShootPoint);
            if(Physics.Raycast(mouseRay.origin, mouseRay.direction, out shootHitPoint, Mathf.Infinity, shootLyr))
            {
                linePos = /*pointer.transform.position + pointer.transform.forward; */new Vector3(shootHitPoint.point.x, pointer.transform.position.y, shootHitPoint.point.z);
                
            }
            else
            {
                //linePos = pointer.transform.position + pointer.transform.forward;
            }

            bodyPart.transform.rotation = Quaternion.Slerp(bodyPart.transform.rotation, Quaternion.LookRotation(new Vector3(linePos.x, bodyPart.transform.position.y, linePos.z) - bodyPart.transform.position), 0.5f);


            myCamera.GetComponent<CameraOptions>().ZoomTo(aimZoom, aimSpd);
            shootable = true;
        }
        else
        {
            bodyPart.transform.rotation = Quaternion.Slerp(bodyPart.transform.rotation, Quaternion.LookRotation(bodyPart.transform.parent.forward), 0.5f);
            myCamera.GetComponent<CameraOptions>().DfltZoom(aimSpd);
            shootable = false;
        }

    }
    public void SpcRangeAtck()
    {

        /*GameObject bllt = Instantiate(plyBullet);
        bllt.transform.position = pointer.transform.position;
        bllt.transform.rotation = gun.transform.rotation;*/



        if (shootable)
        {
            GameObject bllt = Instantiate(plyBullet);
            bllt.transform.position = pointer.transform.position;
            bllt.transform.rotation = gun.transform.rotation;

            GameObject sndObj = GameObject.Find("SoundManager");
            if (sndObj != null)
            {
                GameObject.Find("SoundManager").GetComponent<AudioManager>().Play("Disparo");
            }
            //--------------//
            //gameObject.GetComponent<LineRenderer>().SetPosition(0, pointer.transform.position);
            //if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out shootHitPoint, Mathf.Infinity, shootLyr))
            //{
            /*GameObject bullet = GameObject.Instantiate(plyBullet, pointer.transform.position, gun.transform.rotation);
            Bullet bulletController = bullet.GetComponent<Bullet>();
            bulletController.target = new Vector3(shootHitPoint.point.x, pointer.transform.position.y, shootHitPoint.point.z);
            bulletController.hit = true;*/
            //gameObject.GetComponent<LineRenderer>().SetPosition(1, shootHitPoint.point);
            //}

            /*else
            {
                GameObject bullet = GameObject.Instantiate(plyBullet, pointer.transform.position, gun.transform.rotation);
                Bullet bulletController = bullet.GetComponent<Bullet>();
                bulletController.target = myCamera.transform.position + myCamera.transform.forward;
                bulletController.hit = true;
            }*/
        }   
    }
    public override void SelfDmg(int dmg)
    {
        base.SelfDmg(dmg);
        if (canReceiveDmg == true)
        {
            lifeMng.Damage(dmg);
            canReceiveDmg = false;
        }
    }
}
