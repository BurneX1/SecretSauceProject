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
    public Transform[] target;
    public Transform sphere;
    public bool activateShoot;
    public bool activateAttack;
    public int targetIndex;
    public KeyCode key_change;

    public Transform[] waypoints;
    public int waypointIndex;
    public float dist;
    public bool activatePatrol = true;

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
        float distancePlayer = Vector3.Distance(target[targetIndex].position, sphere.position);
        if (distancePlayer <= sightRadius)
        {
            Debug.Log("te veo bb");
            activateShoot = true;
            activatePatrol = false;
        }
        else
        {
            activateShoot = false;
            activatePatrol = true;

        }
        float distanciaAttack = Vector3.Distance(target[targetIndex].position, sphere.position);
        if (distanciaAttack <= attackRadius)
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
        Vector3 direction = (target[targetIndex].position - sphere.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        sphere.rotation = Quaternion.Slerp(sphere.rotation, lookRotation, Time.deltaTime * 5f);

    }
    public void ChangeTarget()
    {
        if (Input.GetKeyDown(key_change))
        {
            targetIndex++;
            if (targetIndex >= target.Length)
            {
                targetIndex = 0;
            }
        }
    }

    public void ChangeDirection()
    {       
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if (dist < 1f)
        {
            IncreaseIndex();
        }
        Patrol();
    }
 

    public void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, movSpd * Time.deltaTime);
    }

    public void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target[targetIndex].transform.position, movSpd * Time.deltaTime);
    }

}
