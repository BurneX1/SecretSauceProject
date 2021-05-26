using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharOneModl : Characters
{
    public GameObject lifeMngObj;
    public CharOneModl() : base ()
    {

    }

    public void SpcRangeAtck()
    {

    }
    public override void SelfDmg(int dmg)
    {
        base.SelfDmg(dmg);
        lifeMngObj.GetComponent<LifeManager>().Damage(dmg);

    }
}
