using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyOneModl))]
public class EnemyOneView : MonoBehaviour
{
    private EnemyOneModl _cmp_mod;
    private EnemyOneCtrl _cmp_ctrl;
    private Animator _cmp_anim;

    public bool viewAttack;
    public bool viewGetDamage;
    public bool viewKnockDown;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        _cmp_mod = gameObject.GetComponent<EnemyOneModl>();
        _cmp_ctrl = gameObject.GetComponent<EnemyOneCtrl>();
        _cmp_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ActivateAnimationAttack();
        ActivateAnimationRecoil();
        ActivateAnimationKnockDown();
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
}
