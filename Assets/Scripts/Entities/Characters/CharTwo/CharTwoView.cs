using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharTwoModl))]
public class CharTwoView : MonoBehaviour
{
    private CharTwoModl _cmp_mod;
    private CharTwoCtrl _cmp_ctrl;
    private Animator anim;

    public bool viewMove;
    public bool viewAttack;
    public bool viewEspecial;
    public bool viewGetDamage;
    public bool viewKnockDown;
    public float move;
    public int viewLife;

    // Start is called before the first frame update
    void Start()
    {
        _cmp_mod = gameObject.GetComponent<CharTwoModl>();
        _cmp_ctrl = gameObject.GetComponent<CharTwoCtrl>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Move", move);
        anim.SetBool("Grounded", _cmp_mod.grounded);
        anim.SetBool("Attack", viewAttack);
        anim.SetBool("Especial", viewEspecial);
        anim.SetBool("KnockDown", viewKnockDown);
        anim.SetBool("GetDamage", viewGetDamage);
        
        if(viewMove == true)
        {
            move = 1;
        }
        else
        {
            move = 0;
        }

        if(viewLife == 0)
        {
            viewKnockDown = true;
        }
    }
}
