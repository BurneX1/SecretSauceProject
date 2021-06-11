using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharOneModl : Characters
{
    public GameObject lifeMngObj;
    public GameObject gun;
    public GameObject plyBullet;
    public GameObject pointer;

    public float coldTime;
    public float atkTime;
    public CharOneModl() : base ()
    {

    }
    public void GunPoint()
    {

    }
    public void SpcRangeAtck()
    {
        GameObject bllt = Instantiate(plyBullet);
        bllt.transform.position = pointer.transform.position;
        bllt.transform.rotation = gun.transform.rotation;
    }
    public override void SelfDmg(int dmg)
    {
        base.SelfDmg(dmg);
        lifeMngObj.GetComponent<LifeManager>().Damage(dmg);

    }
}
