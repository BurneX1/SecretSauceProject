using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFiveModl : MonoBehaviour
{
    public bool sigthRad;
    public bool atkRad;
    public bool taunted;

    public GameObject targetObj;

    //
    public NavMeshAgent enemigo;
    //

    public GameObject projectile;
    public float timeBetweenAttacks;
    public bool alreadyAttacked;

    public float sightRadius;
    public float attackRadius;
    public Transform[] target;
    public int targetIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, sightRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);

    }
}
