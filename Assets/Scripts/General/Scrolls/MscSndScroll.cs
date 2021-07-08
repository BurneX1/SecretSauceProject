using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MscSndScroll : MonoBehaviour
{
    public Slider sld;
    // Start is called before the first frame update
    void Start()
    {
        sld = GetComponent<Slider>();
        sld.value = PlayerPrefs.GetFloat("MscVol");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
