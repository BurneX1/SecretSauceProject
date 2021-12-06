using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// Script encargado de asignar valores y funciones de un enemigo.
/// 
/// Para crear un enemigo utilizando la clase “Enemies” se recomienda heredar las 
/// funciones de esta mediante la creación de un nuevo script que ejecute las funciones 
/// preestablecidas en base a lo que cada usuario considere conveniente.
public class Enemies : Entities
{
    public int _vida;
    private int _atkDmg;

    public bool sigthRad;
    public bool atkRad;
    public bool taunted;

    public float movSpd;

    public GameObject targetObj;
    public GameObject[]  players;

    //
    public NavMeshAgent enemigo;
    //

    public float sightRadius;
    public float attackRadius;
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
        if (_vida > 0)
        {
            _vida--;
        }
        if (_vida <= 0)
        {
            Die();
        }
        Debug.Log(name + ": Auch!");
    }

    public void IncreaseLife(int addLife)
    {

    }

    public virtual void Die()
    {

    }

    public void DetectPlayer()
    {
        float distancePlayer = Vector3.Distance(targetObj.transform.position, /*sphere.position*/transform.position);

        for (int i = 0; i < players.Length; i++)
        {
            float tmpdist = Vector3.Distance(players[i].transform.position, transform.position);
            if ( players[i]!=targetObj && tmpdist < distancePlayer && tmpdist <= sightRadius)
            {
                targetObj = players[i];
            }
        }


        
        if (distancePlayer <= sightRadius)
        {
            Debug.Log("te veo bb");
            activateShoot = true;
            activatePatrol = false;

            //enemigo.destination = targetObj.transform.position;
            sigthRad = true;
        }
        else
        {
            sigthRad = false;
            activateShoot = false;
            activatePatrol = true;

        }
        if (targetObj != null)
        {
            float distanciaAttack = Vector3.Distance(targetObj.transform.position, /*sphere.position*/transform.position);
            if (distanciaAttack <= attackRadius)
            {
                atkRad = true;
                activateAttack = true;
            }
            else
            {
                atkRad = false;
                activateAttack = false;
            }

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
        /*Vector3 direction = (target[targetIndex].position - sphere.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        sphere.rotation = Quaternion.Slerp(sphere.rotation, lookRotation, Time.deltaTime * 5f);*/

    }

    public void RotateTo(Transform targetPos)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(targetPos.position.x, transform.position.y, targetPos.position.z) - transform.position), 0.01f);
    }
    /*public void ChangeTarget()
    {

        targetIndex++;
        if (targetIndex >= target.Length)
        {
            targetIndex = 0;
        }

    }*/

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
        MoveTo(waypoints[waypointIndex].position);
        RotateTo(waypoints[waypointIndex]);
    }

    public void MoveTo(Vector3 pos)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos.x,transform.position.y, pos.z), movSpd * Time.deltaTime);
    }

    public void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        //transform.LookAt(waypoints[waypointIndex].position);
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetObj.transform.position, movSpd * Time.deltaTime);
    }

}
