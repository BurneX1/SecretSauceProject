using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyTwoModl))]
public class EnemyTwoView : MonoBehaviour
{
    private EnemyTwoModl _cmp_mod;
    private EnemyTwoCtrl _cmp_ctrl;
    public Animator _cmp_anim;

    public bool viewAttack;
    public bool viewGetDamage;
    public bool viewKnockDown;
    public bool viewHaveShield;
    public bool viewDetectPlayer;
    public bool viewProtect;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        _cmp_mod = gameObject.GetComponent<EnemyTwoModl>();
        _cmp_ctrl = gameObject.GetComponent<EnemyTwoCtrl>();

    }

    // Update is called once per frame
    void Update()
    {
        ActivateAnimationAttack();
        ActivateAnimationRecoil();
        ActivateAnimationKnockDown();
        ActivateAnimationProtect();
    }

    void ActivateAnimationAttack()
    {
        if (_cmp_ctrl.cooldownActive == true)
        {
            _cmp_anim.SetTrigger("Attack");
            /*timer += Time.deltaTime;
            if (timer >= 0.1f)
            {
                viewAttack = false;
                timer = 0;
            }*/
        }
    }

    void ActivateAnimationRecoil()
    {
        if (viewGetDamage == true)
        {
            _cmp_anim.SetTrigger("GetDamage");
            timer += Time.deltaTime;
            if (timer >= 0.1f)
            {
                viewGetDamage = false;
                timer = 0;
            }
        }
    }

    void ActivateAnimationKnockDown()
    {
        if (viewKnockDown == true)
        {
            _cmp_anim.SetTrigger("KnockDown");
            timer += Time.deltaTime;
            if (timer >= 0.1f)
            {
                viewKnockDown = false;
                timer = 0;
            }
        }
    }

    void ActivateAnimationProtect()
    {
        _cmp_anim.SetBool("Protect", viewProtect);
        if (viewHaveShield == true && viewDetectPlayer == true)
        {
            viewProtect = true;
        }
        else
        {
            viewProtect = false;
        }
    }

    public void DamageFeedback()
    {
        _cmp_anim.SetTrigger("GetDamage");
    }
}
