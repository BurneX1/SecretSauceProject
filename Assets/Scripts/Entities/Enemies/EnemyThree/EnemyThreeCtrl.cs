using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThreeCtrl : MonoBehaviour
{
    public EnemyThreeModl _cmp_modl;

    // Start is called before the first frame update
    void Start()
    {
        _cmp_modl = gameObject.GetComponent<EnemyThreeModl>();
        _cmp_modl.targetObj = _cmp_modl.target[0].gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        RotateTo(_cmp_modl.targetObj.transform);
        DetectPlayer();
        Explosion();
    }

    public void DetectPlayer()
    {
        float distancePlayer = Vector3.Distance(_cmp_modl.target[0].position, /*sphere.position*/transform.position);
        if (distancePlayer <= _cmp_modl.sightRadius)
        {
            _cmp_modl.enemigo.destination = _cmp_modl.target[0].position;
            _cmp_modl.sigthRad = true;
        }

        if (_cmp_modl.targetObj != null)
        {
            float distanciaAttack = Vector3.Distance(_cmp_modl.targetObj.transform.position, /*sphere.position*/transform.position);
            if (distanciaAttack <= _cmp_modl.attackRadius)
            {
                _cmp_modl.atkRad = true;
            }
            else
            {
                _cmp_modl.atkRad = false;
            }

        }

    }

    public void RotateTo(Transform targetPos)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(targetPos.position.x, transform.position.y, targetPos.position.z) - transform.position), 0.01f);
    }

    public void Explosion()
    {
        if (_cmp_modl.atkRad == true)
        {
            //_cmp_modl.enemigo.destination = transform.position;
            _cmp_modl.explosionTimer += Time.deltaTime;

            if(_cmp_modl.explosionTimer >= 1 && _cmp_modl.explosionTimer < 2)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                _cmp_modl.explosion.SetActive(true);
            }
            if (_cmp_modl.explosionTimer >= 2)
            {
                _cmp_modl.explosion.SetActive(false);
            }
        }
    }
}
