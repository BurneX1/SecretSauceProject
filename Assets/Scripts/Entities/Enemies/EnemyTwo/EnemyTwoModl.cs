using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoModl : Enemies
{
    private EnemyTwoCtrl _cmp_ctrl;

    public override void Start()
    {
        base.Start();
        _cmp_ctrl = gameObject.GetComponent<EnemyTwoCtrl>();
    }
    public EnemyTwoModl() : base()
    {

    }

    public override void SelfDmg(int dmg)
    {
        base.SelfDmg(dmg);
        if(dmg >= 1)
        {
            _cmp_ctrl.ChangeBody();
        }
    }
}
