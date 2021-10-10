using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveroHitbox : MonoBehaviour
{
    public GameObject llave; 
    Llavero llaveroComp;

    private void Start()
    {
        llaveroComp = llave.GetComponent<Llavero>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Pj1")
        {
            llaveroComp.canPickUp = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Pj1")
        {
            llaveroComp.canPickUp = false;
        }
    }
}
