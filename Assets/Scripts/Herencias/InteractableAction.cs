using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Script encargado de asignar valores a un nuevo script, para que este sea interactuable.
/// 
/// Para crear un objeto que realice alguna acción como respuesta a alguna interacción utilizando 
/// la clase “InteractableAction”, puede crear un nuevo script que herede las funciones de esta 
/// clase y sobrescribir el método de la interacción a como considere conveniente.
public class InteractableAction : MonoBehaviour
{
    public float delayTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action()
    {
        StartCoroutine(DelayAction());
    }
    public virtual void Activation()
    {

    }
    IEnumerator DelayAction()
    {
        

        yield return new WaitForSeconds(delayTime);
        Activation();
        
    }
}
