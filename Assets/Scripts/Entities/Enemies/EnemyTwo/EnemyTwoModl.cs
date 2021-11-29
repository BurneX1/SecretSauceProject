using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoModl : Enemies
{
    private EnemyTwoCtrl _cmp_ctrl;
    private EnemyTwoView _cmp_view;

    public override void Start()
    {
        base.Start();
        targetObj = GameObject.FindGameObjectWithTag("Player");
        _cmp_ctrl = gameObject.GetComponent<EnemyTwoCtrl>();
        _cmp_view = gameObject.GetComponent<EnemyTwoView>();
    }
    public EnemyTwoModl() : base()
    {

    }

    public override void Die()
    {
        _cmp_ctrl.ChangeBody();
    }
    public override void SelfDmg(int dmg)
    {
        base.SelfDmg(dmg);
        _cmp_view.DamageFeedback();
    }
}
