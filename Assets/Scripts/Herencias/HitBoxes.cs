using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxes : MonoBehaviour
{
    //[HideInInspector]
    public bool despOnCollision;
    public bool hitDetect;
    public float shtSpd;
    public int dmg;
    public string[] dmgTagsArray;
    public string[] intrcTagsArray;
    public string[] dstroyTagsArray;
    [HideInInspector]
    public Rigidbody cmp_rb;

    public bool destroyOnTime;
    public float timeToDstry;
    public float tim = 0;


    public HitBoxes()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        cmp_rb = GetComponent<Rigidbody>();
        if (shtSpd != 0)
        {
            Movement();
        }
    }
    private void FixedUpdate()
    {
        /*if (shtSpd != 0)
        {
            Movement();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyOnTime == true)
        {
            tim += Time.deltaTime;


            if (tim >= timeToDstry)
            {
                Destroy(gameObject);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < dmgTagsArray.Length; i++)
        {
            if (other.gameObject.CompareTag(dmgTagsArray[i]))
            {
                CallToDamage(other);
                hitDetect = true;

                if (despOnCollision == true)
                {
                    Destroy(gameObject);
                }

            }
            
        }

        for (int i = 0; i < intrcTagsArray.Length; i++)
        {
            if (other.gameObject.CompareTag(intrcTagsArray[i]))
            {
                CallToInteract(other);
                hitDetect = true;
                if (despOnCollision == true)
                {
                    Destroy(gameObject);
                }
            }
            
        }

        for (int i = 0; i < dstroyTagsArray.Length; i++)
        {
            if (other.gameObject.CompareTag(dstroyTagsArray[i]))
            {
                hitDetect = true;
                Destroy(gameObject);
            }
        }
    }

    public void CallToDamage(Collider other)
    {
        if (other.gameObject.GetComponent<Entities>())
        {
            other.gameObject.GetComponent<Entities>().SelfDmg(dmg);
        }
    }

    virtual public void CallToInteract(Collider other)
    {
        //Insertar Funcion de elementos Interactuables
    }

    public void Movement()
    {
        cmp_rb.AddForce(transform.forward * shtSpd, ForceMode.Impulse);
    }
}
