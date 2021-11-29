using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharOneModl))]
public class CharOneView : MonoBehaviour
{
    private CharOneModl _cmp_mod;
    private CharOneCtrl _cmp_ctrl;
    public Animator _cmp_anim;
    public LineRenderer _cmp_lr;
    public ParticleSystem shotgunVfx;

    [Header("HUD")]
    public Text bullNum;
    public Image grabItm;
    public Sprite defaultNoneItm;


    public bool viewMove;
    public bool viewAttack;
    public bool viewEspecial;
    public bool viewGetDamage;
    public bool viewKnockDown;
    public float activationMove2;
    public float activationMove;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        _cmp_mod = gameObject.GetComponent<CharOneModl>();
        _cmp_ctrl = gameObject.GetComponent<CharOneCtrl>();
        //_cmp_anim = GetComponent<Animator>();
        _cmp_lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _cmp_anim.SetBool("Grounded", _cmp_mod.grounded);
        _cmp_anim.SetBool("isMoving", viewMove);
        _cmp_anim.SetBool("Attack 0", viewAttack);

        updateBulletsNum();
        updateGrabHud();

        ActivateAnimationMove();
        ActivateAnimationAttack();
        ActivateAnimationEspecial();
        ActivateAnimationKnockDown();
        ActivateAnimationRecoil();
        //ShowAimLine();

    }
    
    void ActivateAnimationMove()
    {
        if (_cmp_mod.isMovingH == true || _cmp_mod.isMovingV == true)
        {
            viewMove = true;
        }
        else if (_cmp_mod.isMovingH == true && _cmp_mod.isMovingV == true)
        {
            viewMove = true;
        }
        else
        {
            viewMove = false;
        }
    }
    
    void ActivateAnimationAttack()
    {
        if (_cmp_ctrl._atacking == true && _cmp_mod.shootable == true)
        {
            viewAttack = true;
        }
        else
        {
            viewAttack = false;
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

    void ShowAimLine()
    {
        if(_cmp_lr==null)
        {
            _cmp_lr = gameObject.AddComponent<LineRenderer>();
        }
        if(_cmp_mod.shootable)
        {
            _cmp_lr.enabled = true;
            _cmp_lr.SetPosition(0, _cmp_mod.pointer.transform.position);
            _cmp_lr.SetPosition(1, _cmp_mod.linePos);
        }
        else
        {
            _cmp_lr.enabled = false;
        }

    }

    public void PlayShootgunParticles()
    {

        shotgunVfx.Play();
    }
    void updateGrabHud()
    {
        if (_cmp_mod.actualPick != null && _cmp_mod.actualPick.activeSelf!=false)
        {
            grabItm.sprite = _cmp_mod.actualPick.GetComponent<Pickeable>().objImg;
        }
        else
        {
            grabItm.sprite = defaultNoneItm;
            
        }
    }

    void updateBulletsNum()
    {
        bullNum.text = _cmp_mod.currentAmmo + " ";
    }
}
