using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharTwoModl))]
public class CharTwoView : MonoBehaviour
{
    private CharTwoModl _cmp_mod;
    private CharTwoCtrl _cmp_ctrl;
    public Animator _cmp_anim;

    public bool viewMove;
    public bool viewAttack;
    public bool viewEspecial;
    public bool viewGetDamage;
    public bool viewKnockDown;
    public float activationMove;
    public float timer;
    public float prueba;
    // Start is called before the first frame update
    void Start()
    {
        _cmp_mod = gameObject.GetComponent<CharTwoModl>();
        _cmp_ctrl = gameObject.GetComponent<CharTwoCtrl>();
        _cmp_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _cmp_anim.SetBool("Grounded", _cmp_mod.grounded);
        _cmp_anim.SetBool("Attack", viewAttack);

        ActivateAnimationMove();
        ActivateAnimationAttack();
        ActivateAnimationEspecial();
        ActivateAnimationKnockDown();
        ActivateAnimationRecoil();

    }

    void ActivateAnimationMove()
    {
        _cmp_anim.SetFloat("Move", activationMove);
        if (prueba != _cmp_mod.cmp_agent.remainingDistance)
        {
            activationMove = 1;
        }
        else
        {
            activationMove = 0;
        }
    }

    void ActivateAnimationAttack()
    {
        
        if (Input.GetKeyDown(_cmp_mod.keyArray_extrAct[2]) && _cmp_ctrl.battery == true)
        {
            viewAttack = true;
        }
        if(viewAttack ==true)
        {
            timer += Time.deltaTime;
            if (timer >= 7)
            {
                viewAttack = false;
                timer = 0;
            }
        }
    }

    void ActivateAnimationEspecial()
    {
        if (viewEspecial == true)
        {
            _cmp_anim.SetTrigger("Especial");
            timer += Time.deltaTime;
            if (timer >= 0.1f)
            {
                viewEspecial = false;
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
}
