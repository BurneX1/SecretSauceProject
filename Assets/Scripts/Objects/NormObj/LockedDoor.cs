using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockedDoor : MonoBehaviour
{
    public bool open;
    public UnityEvent onOpen;
    public Padlock[] padlocksArray;
    public InteractCaller mainCall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(open)
        {
            onOpen.Invoke();
        }
        VerifyLock();
    }
    public void VerifyLock()
    {
        if(padlocksArray.Length > 0)
        {
            int openPadlocks = 0;
            for(int i = 0; i < padlocksArray.Length; i++)
            {
                if (padlocksArray[i] != null)
                {
                    if (padlocksArray[i].open == false)
                    {
                        openPadlocks++;
                    }
                }
                
            }

            if(openPadlocks > 0)
            {
                open = false;
                if(mainCall) mainCall.enabled = false;
            }
            else
            {
                open = true;
                if (mainCall) mainCall.enabled = true;
            }
        }
        else
        {
            open = true;
            if (mainCall) mainCall.enabled = true;
        }
    }
}
