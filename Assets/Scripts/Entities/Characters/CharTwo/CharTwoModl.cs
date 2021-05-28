using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharTwoModl : Characters
{
    [Range(1f,100f)]
    public float spcRange;
    public string[] intrcTagsArray;

    public GameObject restoreTargt;
    public SphereCollider sphColl;
    public CharTwoModl() : base()
    {

    }

    public void SpcTauntAtck(Collider other)
    {
        for (int i = 0; i < other.GetComponent<Enemies>().target.Length; i++)
        {
            Debug.Log(other);
            if (other.GetComponent<Enemies>().target[i] != gameObject.transform)
            {
                other.GetComponent<Enemies>().target[i] = gameObject.transform;
                other.GetComponent<Enemies>().activateShoot = true;
            }
        }
        //Debug.Log(other);
    }

    public void Untaunt(Collider other)
    {
        //Debug.Log(other);
        if (other.GetComponent<Enemies>())
        {
            for (int i = 0; i < other.GetComponent<Enemies>().target.Length; i++)
            {
                if (other.GetComponent<Enemies>().target[i] != restoreTargt.transform)
                {
                    Debug.Log(other);
                    other.GetComponent<Enemies>().target[i] = restoreTargt.transform;
                    other.GetComponent<Enemies>().activateShoot = false;
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gameObject.transform.position, spcRange); 
    }

}
