using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensScroll : MonoBehaviour
{
    public Slider sld;
    // Start is called before the first frame update
    void Start()
    {
        sld = GetComponent<Slider>();
        sld.value = PlayerPrefs.GetFloat("SensVal");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
