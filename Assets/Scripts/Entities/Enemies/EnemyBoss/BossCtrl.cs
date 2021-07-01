using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : MonoBehaviour
{
    private BossMdl _cmp_mod;
    private BossView _cmp_view;

    public bool onAtack;
    public bool onPanic;

    public bool cooldownActive;
    public float atkCDTimer;
    public Collider hitColl;
    public float hitCD;


    public GameObject[] tables;
    public Transform lookTable;
    public float smoothVel;
    Quaternion rot;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {


        _cmp_mod = gameObject.GetComponent<BossMdl>();
        _cmp_view = gameObject.GetComponent<BossView>();
        hitColl.gameObject.SetActive(false);
        _cmp_mod.waypointIndex = 0;
        _cmp_mod.targetIndex = 0;
        //transform.LookAt(_cmp_mod.waypoints[_cmp_mod.waypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        _cmp_mod.DetectPlayer();
        CDTimer(hitCD);

        if (lookTable != null)
        {
            Rote_in_Y(lookTable.position);
        }
        if (_cmp_mod.atkRad == true)
        {
            HitBoxAtk(1, true, hitColl);
            //_cmp_mod.RotateTo(_cmp_mod.targetObj.transform);
        }
        else if (_cmp_mod.taunted == true)
        {
            //_cmp_mod.targetObj = _cmp_mod.target[1].gameObject;
            //_cmp_mod.RotateTo(_cmp_mod.targetObj.transform);
            //_cmp_mod.MoveTo(_cmp_mod.targetObj.transform.position);
        }
        else if (_cmp_mod.sigthRad == true)
        {
            //_cmp_mod.targetObj = _cmp_mod.target[0].gameObject;
            //_cmp_mod.RotateTo(_cmp_mod.targetObj.transform);
           // _cmp_mod.MoveTo(_cmp_mod.targetObj.transform.position);
        }
        else
        {
           // _cmp_mod.ChangeDirection();
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
            hitColl.gameObject.SetActive(false);
            atkCDTimer = 0;
        }
    }
    public void HitBoxAtk(int dmg, bool oneHitatk, Collider hitBox)
    {
        if (cooldownActive == false)
        {
            cooldownActive = true;
            hitBox.gameObject.GetComponent<HitBoxes>().dmg = dmg;
            //hitBox.gameObject.GetComponent<HitElements>().hitDetect = false;
            hitBox.gameObject.GetComponent<HitBoxes>().despOnCollision = oneHitatk;
            hitBox.gameObject.SetActive(true);
        }
        else
        {
            //hitBox.gameObject.GetComponent<HitElements>().hitDetect = false;
        }
    }
    public void SetLook(Transform platPos)
    {
        lookTable = platPos;
    }

    public void Rote_in_Y(Vector3 move)
    {
        dir = (new Vector3(lookTable.position.x,transform.position.y, lookTable.position.z) - transform.position).normalized;
        rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, smoothVel);

    }
}
