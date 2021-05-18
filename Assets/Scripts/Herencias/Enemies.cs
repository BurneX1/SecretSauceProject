using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Entities
{
    private int _vida;
    private int _atkDmg;

    public float movSpd;

    public GameObject targetObj;

    public float sightRadius;
    public float attackRadius;
    public Transform target;
    public Transform sphere;
    public bool activateShoot;
    public bool activateAttack;

    public Enemies() : base()
    {

    }

    public override void SelfDmg(int dmg)
    {
        Debug.Log(name + ": Auch!");
    }

    public void IncreaseLife(int addLife)
    {

    }

    public void Die()
    {

    }

    public void DetectPlayer()
    {
        float distancePlayer = Vector3.Distance(target.position, sphere.position);
        if (distancePlayer <= sightRadius)
        {
            Debug.Log("te veo bb");
            activateShoot = true;
        }
        else
        {
            activateShoot = false;
        }
        float distanciaAttack = Vector3.Distance(target.position, sphere.position);
        if(distanciaAttack <= attackRadius)
        {
            activateAttack = true;
        }
        else
        {
            activateAttack = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(sphere.position, sightRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(sphere.position, attackRadius);

    }

    public void FaceTarget()
    {
        Vector3 direction = (target.position - sphere.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        sphere.rotation = Quaternion.Slerp(sphere.rotation, lookRotation, Time.deltaTime * 5f);

    }

}
