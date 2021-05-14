using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Entities
{
    private int _vida;
    private int _atkDmg;

    public float movSpd;

    public GameObject targetObj;

    public float sphereRadius;
    public Transform target;
    public Transform sphere;
    public bool ActivateAttack;

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
        if (distancePlayer <= sphereRadius)
        {
            Debug.Log("te veo bb");
            ActivateAttack = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(sphere.position, sphereRadius);
    }

    public void FaceTarget()
    {
        Vector3 direction = (target.position - sphere.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        sphere.rotation = Quaternion.Slerp(sphere.rotation, lookRotation, Time.deltaTime * 5f);

    }

}
