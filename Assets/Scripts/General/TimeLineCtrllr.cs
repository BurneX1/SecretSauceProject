using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeLineCtrllr : MonoBehaviour
{
    public bool runTimer;
    public TimeEvnt[] times;
    public float currentTime;
    public int timeEvInput;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        timeEvInput = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(runTimer == true)
        {
            
            if (times.Length > 0)
            {
                Excecute();
            }
            currentTime += Time.deltaTime;
        }
    }

    public void Excecute()
    {
        if(currentTime >= times[timeEvInput].time)
        {
            times[timeEvInput].timeEvent.Invoke();
            timeEvInput++;
            if(timeEvInput>= times.Length)
            { 
                runTimer = false;
            }
        }
    }


}


[System.Serializable]
public class TimeEvnt
{
    public float time;
    public UnityEvent timeEvent;
}
