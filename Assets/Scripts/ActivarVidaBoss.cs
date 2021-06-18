using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivarVidaBoss : MonoBehaviour
{
    public GameObject icono;
    // Start is called before the first frame update
    void Start()
    {
        icono.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            icono.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            icono.gameObject.SetActive(false);
        }

    


    }
}
