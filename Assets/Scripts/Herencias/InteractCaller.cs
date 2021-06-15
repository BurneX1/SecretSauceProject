using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCaller : MonoBehaviour
{
    private bool _nearPly;

    public KeyCode key_intrc;
    public GameObject InteractObj;
    public bool onlyOneUse;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_nearPly == true)
        {
            if (Input.GetKeyDown(key_intrc))
            {
                Interact();
            }
        }
    }

    public virtual void Interact()
    {
        InteractObj.GetComponent<InteractableAction>().Action();

        if (onlyOneUse == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _nearPly =  true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _nearPly = false;
        }
    }
}
