using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFourCtrl : MonoBehaviour
{
    private EnemyFourModl _cmp_modl;

    void Start()
    {
        _cmp_modl = gameObject.GetComponent<EnemyFourModl>();
        _cmp_modl.targetObj = _cmp_modl.target[0].gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }

    public void RotateTo(Transform targetPos)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(targetPos.position.x, transform.position.y, targetPos.position.z) - transform.position), 0.01f);
    }

    public void DetectPlayer()
    {
        float distancePlayer = Vector3.Distance(_cmp_modl.target[0].position,transform.position);
        if (distancePlayer <= _cmp_modl.sightRadius)
        {
            //_cmp_modl.enemigo.destination = _cmp_modl.target[0].position;
            RotateTo(_cmp_modl.targetObj.transform);
            //_cmp_modl.sigthRad = true;
        }
        else
        {
            transform.rotation = transform.rotation;
        }
    }


}
