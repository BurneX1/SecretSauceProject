using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyTwoModl))]
[RequireComponent(typeof(EnemyTwoView))]
public class EnemyTwoCtrl : MonoBehaviour
{
    private EnemyTwoModl _cmp_mod;
    private EnemyTwoView _cmp_view;

    public bool cooldownActive;
    public float atkCDTimer;
    [Range(0.0f, 3)]
    public float meleCD;
    public Collider meleHitCollider;



    // Start is called before the first frame update
    void Start()
    {
        _cmp_mod = gameObject.GetComponent<EnemyTwoModl>();
        _cmp_view = gameObject.GetComponent<EnemyTwoView>();
        meleHitCollider.gameObject.SetActive(false);
        _cmp_mod.waypointIndex = 0;
        transform.LookAt(_cmp_mod.waypoints[_cmp_mod.waypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {        
        _cmp_mod.DetectPlayer();
        CDTimer(meleCD);
        if(_cmp_mod.activateShoot == true)
        {
            _cmp_mod.FollowPlayer();
            _cmp_mod.FaceTarget();
        }
        if(_cmp_mod.activateAttack == true)
        {
            HitBoxAtk(1, true, meleHitCollider);           
        }
        if(_cmp_mod.activatePatrol == true)
        {
            _cmp_mod.ChangeTarget();
        }

    }
    void CDTimer(float cooldownTime)
    {
        if (cooldownActive == true)
        {
            atkCDTimer += Time.deltaTime;
        }
        if (atkCDTimer >= cooldownTime)
        {
            cooldownActive = false;
            meleHitCollider.gameObject.SetActive(false);
            atkCDTimer = 0;
        }
    }
    public void HitBoxAtk(int dmg, bool oneHitatk, Collider hitBox)
    {
        if (cooldownActive == false)
        {
            cooldownActive = true;
            hitBox.gameObject.GetComponent<HitElements>().dmg = dmg;
            hitBox.gameObject.GetComponent<HitElements>().hitDetect = false;
            hitBox.gameObject.GetComponent<HitElements>().despOnCollision = oneHitatk;
            hitBox.gameObject.SetActive(true);
        }
    }

}
