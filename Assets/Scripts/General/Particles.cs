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
            Particulas.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3);
            Particulas.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

    }
    public void pointerEnter()
    {
        ActiveParticles = true;
        
    }
    public void pointerExit()
    {
        ActiveParticles = false;
        Particulas.gameObject.SetActive(false);
    }
}
