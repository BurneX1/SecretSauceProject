using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiveCtrl : MonoBehaviour
{
    public EnemyFiveModl _cmp_modl;

    // Start is called before the first frame update
    void Start()
    {
        _cmp_modl = gameObject.GetComponent<EnemyFiveModl>();
        _cmp_modl.targetObj = _cmp_modl.target[0].gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        RotateTo(_cmp_modl.targetObj.transform);
    }

    public void DetectPlayer()
    {
        float distancePlayer = Vector3.Distance(_cmp_modl.target[0].position, /*sphere.position*/transform.position);
        if (distancePlayer <= _cmp_modl.sightRadius)
        {
            Shoot();
        }
    }

    public void RotateTo(Transform targetPos)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(targetPos.position.x, transform.position.y, targetPos.position.z) - transform.position), 0.01f);
    }

    void Shoot()
    {
        if(!_cmp_modl.alreadyAttacked)
        {
            Rigidbody rb = Instantiate(_cmp_modl.projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            _cmp_modl.alreadyAttacked = true;
            Invoke(nameof(ResetAttack), _cmp_modl.timeBetweenAttacks);
        }
    }

    void ResetAttack()
    {
        _cmp_modl.alreadyAttacked = false;
    }
}
