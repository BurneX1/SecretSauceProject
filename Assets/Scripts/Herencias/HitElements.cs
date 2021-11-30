using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Script que al ser asignado a un objeto crea elementos con collisiones de da�o.
/// 
/// Agregar este script como componente a un objeto permite crear �reas de impacto y/o proyectiles que hagan da�o o interact�en con cualquier tipo de entidad con el tag seleccionado.
public class HitElements : MonoBehaviour
{
    [HideInInspector]
    public bool despOnCollision;
    public bool hitDetect;
    public float shtSpd;
    public int dmg;
    public string[] dmgTagsArray;
    public string[] intrcTagsArray;
    public Transform sphere;
    public Rigidbody cmp_rb;

    // Start is called before the first frame update
    void Start()
    {
        cmp_rb = GetComponent<Rigidbody>();
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
        cmp_rb.AddForce(sphere.forward * shtSpd, ForceMode.Impulse);
    }

    public void Desapear()
    {
        if (hitDetect == true && despOnCollision == true)
        {
            gameObject.SetActive(false);
        }
    }
}
