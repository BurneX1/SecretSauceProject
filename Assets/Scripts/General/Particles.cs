using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public GameObject Particulas;
    public bool ActiveParticles;
    // Start is called before the first frame update
    void Start()
    {
        Particulas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ActiveParticles == true)
        {
            Particulas.gameObject.SetActive(true);
        }
        else
        {
            Particulas.gameObject.SetActive(false);
        }
    }
    public void pointerEnter()
    {
        ActiveParticles = true;
    }
    public void pointerExit()
    {
        ActiveParticles = false;
    }
}
