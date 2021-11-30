using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// Script encargado de asignar valores y funciones dedicados para entidades.
/// 
/// Las entidades tomadas en cuenta dentro de este FrameWork se crean en base a clases provenientes de la clase “Entities”, la cual les permite heredar sus características.
[RequireComponent(typeof(Rigidbody))]
public class Entities : MonoBehaviour
{
    //[HideInInspector]
    public bool grounded;
    public LayerMask groundLayer;
    //[HideInInspector]
    public float grndDistance;
    [HideInInspector]
    public Rigidbody cmp_rb;

    public virtual void OnEnable()
    {
        cmp_rb = gameObject.GetComponent<Rigidbody>();
    }
    public virtual void Start()
    {

    }

    public Entities ()
    {  
        
    }
    public virtual void SelfDmg(int dmg)
    {

    }
    public bool GroundDetect(LayerMask dtcLayer, float distance)
    {
        bool grnd;
        grnd =
        Physics.Raycast(transform.position,
           Vector3.down,
           distance,
           dtcLayer
           );
        return grnd;
    }
}

