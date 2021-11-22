using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCaller : MonoBehaviour
{
    private bool _nearPly;
    private bool onKey;

    public KeyCode key_intrc;
    public GameObject[] InteractObj;
    public bool onlyOneUse;
    public GameObject actlDtcPly;

    public bool singleTarget;
    public GameObject singleObj;
    public int playerNumber;
    GameObject player1;
    GameObject player2;
    
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Pj1");
        player2 = GameObject.Find("Pj3 (1)");

        if(key_intrc != KeyCode.None)
        {
            onKey = true;
        }
        else
        {
            onKey = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_nearPly == true)
        {
            //Si el interact Caller no tiene ninguna letra seleccionada, defrente se activa con collisiones uwu
            if(onKey == true)
            {
                if (Input.GetKeyDown(key_intrc))
                {
                    Interact();
                }
            }
            else
            {
                Interact();
            }    
            
        }
    }

    public virtual void Interact()
    {
        for (int i = 0; i < InteractObj.Length; i++)
        {
            InteractObj[i].GetComponent<InteractableAction>().Action();

            
        }
        if (onlyOneUse == true)
        {
            _nearPly = false;
            gameObject.SetActive(false);

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (singleTarget == true)
        {
            if(other.gameObject == singleObj)
            {
                
                actlDtcPly = other.gameObject;
                _nearPly = true;
            }
            Debug.Log(other.gameObject + " / " + singleObj);
            /*if (playerNumber == 1)
            {
                if(other.gameObject == player1)
                {
                    actlDtcPly = other.gameObject;
                    _nearPly = true;
                }
                else if(other.gameObject == player2)
                {
                    Debug.Log("Personaje incorrecto");
                }
            }
            else if (playerNumber == 2)
            {
                if (other.gameObject == player2)
                {
                    actlDtcPly = other.gameObject;
                    _nearPly = true;
                }
                else if (other.gameObject == player1)
                {
                    Debug.Log("Personaje incorrecto");
                }
            }*/
        }
        else if (singleTarget == false)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                actlDtcPly = other.gameObject;
                _nearPly = true;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(singleTarget == true)
        {
            if (other.gameObject == singleObj)
            {
                actlDtcPly = null;
                _nearPly = false;
            }
            if (other.gameObject == player1)
            {
                if (other.gameObject == actlDtcPly)
                {
                    actlDtcPly = null;
                }
                _nearPly = false;
            }
            else if (other.gameObject == player2)
            {
                if (other.gameObject == actlDtcPly)
                {
                    actlDtcPly = null;
                }
                _nearPly = false;
            }
        }
        if (singleTarget == false)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (other.gameObject == actlDtcPly)
                {
                    actlDtcPly = null;
                }
                _nearPly = false;
            }
        }
    }
}
