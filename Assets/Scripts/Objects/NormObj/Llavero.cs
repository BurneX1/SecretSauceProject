using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llavero : MonoBehaviour
{
    public Transform punto;
    public bool canPickUp;
    bool pickedUp;
    public GameObject HuecoCorrecto;
    int puntos;

    void Start()
    {
        canPickUp = false;
        pickedUp = false;
    }

    void Update()
    {
        if(canPickUp == true && Input.GetKeyDown(KeyCode.E) && pickedUp == false)
        {
            PickUp();
        }
        if (pickedUp == true && Input.GetKeyUp(KeyCode.E))
        {
            Throw();
        }
        if(puntos == 3)
        {
            Debug.Log("Puzzle Completado");
        }
    }
    void PickUp ()
    {
        pickedUp = true;
        this.GetComponent<BoxCollider>().isTrigger = true;
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().MovePosition(new Vector3(0, 0, 0));
        this.GetComponent<Rigidbody>().freezeRotation = true;
        this.transform.position = punto.position;
        this.transform.parent = GameObject.Find("SoldaditoMaderita").transform;
    }
    void Throw()
    {
        pickedUp = false;
        this.transform.parent = null;
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().freezeRotation = false;
        this.GetComponent<BoxCollider>().isTrigger = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == HuecoCorrecto)
        {
            Destroy(other.gameObject);
            puntos++;
        }
    }
}
