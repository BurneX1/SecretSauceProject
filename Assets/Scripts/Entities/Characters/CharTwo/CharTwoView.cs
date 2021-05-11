using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharTwoModl))]
public class CharTwoView : MonoBehaviour
{
    private CharTwoModl _cmp_mod;
    private CharTwoCtrl _cmp_ctrl;

    // Start is called before the first frame update
    void Start()
    {
        _cmp_mod = gameObject.GetComponent<CharTwoModl>();
        _cmp_ctrl = gameObject.GetComponent<CharTwoCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
