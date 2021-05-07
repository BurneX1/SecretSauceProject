using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitElements : MonoBehaviour
{
    [HideInInspector]
    public bool despOnCollision;
    public bool hitDetect;
    public float shtSpd;
    public int dmg;
    public string[] dmgTagsArray;
    public string[] intrcTagsArray;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (shtSpd != 0)
        {
            Movement();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Desapear();
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < dmgTagsArray.Length; i++)
        {
            if (other.gameObject.CompareTag(dmgTagsArray[i]))
            {
                CallToDamage(other);
                hitDetect = true;
            }
        }

        for (int i = 0; i < intrcTagsArray.Length; i++)
        {
            if (other.gameObject.CompareTag(intrcTagsArray[i]))
            {
                CallToInteract(other);
                hitDetect = true;
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

    public void CallToInteract(Collider other)
    {
        //Insertar Funcion de elementos Interactuables
    }

    public void Movement()
    {

    }

    public void Desapear()
    {
        if (hitDetect == true && despOnCollision == true)
        {
            gameObject.SetActive(false);
        }
    }
}
