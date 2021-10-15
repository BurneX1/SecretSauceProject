using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoModl : Enemies
{
    private EnemyTwoCtrl _cmp_ctrl;

    public override void Start()
    {
        base.Start();
        targetObj = GameObject.FindGameObjectWithTag("Player");
        _cmp_ctrl = gameObject.GetComponent<EnemyTwoCtrl>();
    }
    public EnemyTwoModl() : base()
    {

    }

    public override void Die()
    {
        _cmp_ctrl.ChangeBody();
    }
}
