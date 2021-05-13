using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharOneModl))]
public class CharOneView : MonoBehaviour
{
    private CharOneModl _cmp_mod;
    private CharOneCtrl _cmp_ctrl;
    private Animator _cmp_anim;

    public bool viewMove;
    public bool viewAttack;
    public bool viewEspecial;
    public bool viewGetDamage;
    public bool viewKnockDown;
    public float activationMove;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        _cmp_mod = gameObject.GetComponent<CharOneModl>();
        _cmp_ctrl = gameObject.GetComponent<CharOneCtrl>();
        _cmp_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _cmp_anim.SetBool("Grounded", _cmp_mod.grounded);

        ActivateAnimationMove();
        ActivateAnimationAttack();
        ActivateAnimationEspecial();
        ActivateAnimationKnockDown();
        ActivateAnimationRecoil();

    }
    
    void ActivateAnimationMove()
    {
        _cmp_anim.SetFloat("Move", activationMove);
        if (viewMove == true)
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
        if (viewAttack == true)
        {
            _cmp_anim.SetTrigger("Attack");
            timer += Time.deltaTime;
            if (timer >= 0.1f)
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
