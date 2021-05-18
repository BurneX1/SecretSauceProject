using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyOneModl))]
[RequireComponent(typeof(EnemyOneView))]
public class EnemyOneCtrl : MonoBehaviour
{
    private EnemyOneModl _cmp_mod;
    private EnemyOneView _cmp_view;

    public float timer;
    public float maxTimer;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        _cmp_mod = gameObject.GetComponent<EnemyOneModl>();
        _cmp_view = gameObject.GetComponent<EnemyOneView>();
    }

    // Update is called once per frame
    void Update()
    {
        _cmp_mod.DetectPlayer();
        if (_cmp_mod.activateShoot == true)
        {
            Shoot();
            _cmp_mod.FaceTarget();
        }
    }

    public void Shoot()
    {
            timer += Time.deltaTime;
            if (timer >= maxTimer)
            {
               GameObject newbullet = Instantiate(bullet);
               newbullet.transform.position = _cmp_mod.sphere.position;
               timer = 0;
            }
        
    }
}
