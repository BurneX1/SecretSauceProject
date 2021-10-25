using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharOneModl))]
[RequireComponent(typeof(CharOneView))]
public class CharOneCtrl : MonoBehaviour
{
    private CharOneModl _cmp_mod;
    private CharOneView _cmp_view;
    public bool _atacking;
    private float _tauntTime;
    private float _cdTime;
    private Pause _cmp_ps;

    private Vector3 rotatioProves;

    public GameObject gmMng;

    public float selfDmgTimer = 0;
    public float selfDmgCooldown;
    // Start is called before the first frame update
    void Start()
    {
        _cmp_ps = gmMng.GetComponent<Pause>();
        _cmp_mod = gameObject.GetComponent<CharOneModl>();
        _cmp_view = gameObject.GetComponent<CharOneView>();
        //_cmp_mod.grndDistance = 7;
        _cmp_mod.meleHitCollider.gameObject.SetActive(false);
        _cmp_mod.currentAmmo = _cmp_mod.maxAmmo;
        _cmp_mod.canReceiveDmg = true;
    }

    private void FixedUpdate()
    {
        if (_cmp_ps.paused == false)
        {
            if (_cmp_mod.afkMode == true)
            {

                _cmp_mod.AFKmove();
            }
            else
            {
                _cmp_mod.cmp_agent.enabled = false;
                _cmp_mod.Move();
                //_cmp_mod.cmp_rb.velocity.Set(0,0,0);
                //_cmp_mod.cmp_rb.speed
            }
        }
    }
    void Update()
    {
        if (_cmp_ps.paused == false)
        {

            if (_cmp_mod.afkMode == true)
            {

            }
            else
            {
                SelfDmgTimer();
                _cmp_mod.HitBoxAtk(1, true, _cmp_mod.meleHitCollider);
                if(_cmp_mod.grounded)
                {
                    Shoot();
                }

            }
        }
        if(_cmp_mod.currentAmmo > _cmp_mod.maxAmmo)
        {
            _cmp_mod.currentAmmo = _cmp_mod.maxAmmo;
        }    
    }

    public void SelfDmgTimer()
    {
        if(_cmp_mod.canReceiveDmg == false)
        {
            selfDmgTimer += Time.deltaTime;
            if (selfDmgTimer >= selfDmgCooldown)
            {
                _cmp_mod.canReceiveDmg = true;
                selfDmgTimer = 0;
            }
        }
    }

    public void Shoot()
    {
        _cmp_mod.Aim();
        if(Input.GetKey(_cmp_mod.keyArray_extrAct[1]))
        {
            _cmp_mod.aimState = true;
        }
        else
        {
            _cmp_mod.aimState = false;
        }


        if (_atacking == false)
        {
         
            _cdTime += Time.deltaTime;
            if (_cdTime >= _cmp_mod.coldTime)
            {
                _cdTime = _cmp_mod.coldTime;
                if (Input.GetKeyDown(_cmp_mod.keyArray_extrAct[0]) && _cmp_mod.currentAmmo > 0) 
                {
                    _atacking = true;
                    _cdTime = 0;
                    _cmp_mod.currentAmmo--;
                    Debug.Log(_cmp_mod.currentAmmo);
                    Debug.Log("a");
                }
            }
        }
        else
        {


            _tauntTime += Time.deltaTime;
            if (_tauntTime >= _cmp_mod.atkTime)
            {
                _cmp_mod.SpcRangeAtck();

                _atacking = false;
                _tauntTime = 0;

            }
        }
    }

}
