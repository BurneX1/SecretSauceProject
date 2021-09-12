using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveroHitbox : MonoBehaviour
{

    Llavero llaveroComp;

    private void Start()
    {
        llaveroComp = GameObject.Find("Llavero").GetComponent<Llavero>();
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
