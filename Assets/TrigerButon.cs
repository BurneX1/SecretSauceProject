using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrigerButon : MonoBehaviour
{
    private bool _nearPly;
    public UnityEvent enterEv;
    public UnityEvent exitEv;
    bool canMakeAct;
    public GameObject[] InteractObj;
    public bool onlyOneUse;
    public GameObject actlDtcPly;
    public bool onWait;
    float timer;
    float time;

    public bool singleTarget;
    public int playerNumber;
    GameObject player1;
    GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        timer = 0.1f;
        canMakeAct = false;
        player1 = GameObject.Find("Pj1");
        player2 = GameObject.Find("Pj3 (1)");


    }

    // Update is called once per frame
    void Update()
    {
        if (_nearPly == true)
        {     
            ActOnEnter();
        }
        else if(_nearPly == false)
        {
            ActOnExit();
        }
        theTime();
    }

    public void theTime()
    {
        if(onWait == false)
        {
            if (time <= timer)
            {
                time += Time.deltaTime;
            }
            else
            {
                onWait = true;
                time = 0;
            }
        }

    }
    public void ActOnEnter()
    {
        if (canMakeAct == true && onWait == true)
        {
            enterEv.Invoke();
            canMakeAct = false;
            onWait = false;
        }
    }

    public void ActOnExit()
    {
        if (canMakeAct == true && onWait == true)
        {
            Debug.Log("EXIT");
            exitEv.Invoke();
            canMakeAct = false;
            onWait = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (singleTarget == true)
        {
            if (playerNumber == 1)
            {
                if (other.gameObject == player1)
                {
                    actlDtcPly = other.gameObject;
                    _nearPly = true;
                    canMakeAct = true;
                }
                else if (other.gameObject == player2)
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
                    canMakeAct = true;
                }
                else if (other.gameObject == player1)
                {
                    Debug.Log("Personaje incorrecto");
                }
            }
        }
        else if (singleTarget == false)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                actlDtcPly = other.gameObject;
                _nearPly = true;
                canMakeAct = true;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject);
        if (singleTarget == true)
        {
            if (other.gameObject == player1)
            {
                if (other.gameObject == actlDtcPly)
                {
                    actlDtcPly = null;
                    canMakeAct = true;
                }
                _nearPly = false;

            }
            else if (other.gameObject == player2)
            {
                if (other.gameObject == actlDtcPly)
                {
                    actlDtcPly = null;
                    canMakeAct = true;
                }
                _nearPly = false;
                
            }
        }
        else if (singleTarget == false)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (other.gameObject == actlDtcPly)
                {
                    actlDtcPly = null;
                    canMakeAct = true;
                }
                _nearPly = false;

            }
        }
    }
}
