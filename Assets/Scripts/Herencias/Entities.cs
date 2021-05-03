using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(Rigidbody))]
public class Entities : MonoBehaviour
{
    [HideInInspector]
    public bool grounded;

    public Entities ()
    {  
        
    }

    public void GroundDetect()
    {

    }
}

