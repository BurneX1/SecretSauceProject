using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
