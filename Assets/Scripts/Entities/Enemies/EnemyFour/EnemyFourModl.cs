using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFourModl : MonoBehaviour
{
    private int _atkDmg;

    public bool sigthRad;
    public bool atkRad;
    public bool taunted;

    public float movSpd;

    public float chargeTimer;

    public bool isTackling;

    public GameObject targetObj;

    //
    public NavMeshAgent enemigo;
    //

    public float sightRadius;
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
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sightRadius);
    }
}
