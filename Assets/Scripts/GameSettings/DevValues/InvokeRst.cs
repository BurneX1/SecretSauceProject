using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InvokeRst : MonoBehaviour
{
    public GameObject restoreObj;
    // Start is called before the first frame update
    void Start()
    {
        restoreObj.GetComponent<Button>().onClick.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
