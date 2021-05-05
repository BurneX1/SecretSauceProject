using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[RequireComponent(typeof(Rigidbody))]
public class Entities : MonoBehaviour
{
    //[HideInInspector]
    public bool grounded;
    public LayerMask groundLayer;
    [HideInInspector]
    public float grndDistance;
    [HideInInspector]
    public Rigidbody cmp_rb;

    void Start()
    {
        cmp_rb = gameObject.GetComponent<Rigidbody>();
    }

    public Entities ()
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

