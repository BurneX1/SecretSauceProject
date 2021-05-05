using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharOneModl))]
public class CharOneView : MonoBehaviour
{
    private CharOneModl _cmp_mod;
    private CharOneCtrl _cmp_ctrl;

    // Start is called before the first frame update
    void Start()
    {
        _cmp_mod = gameObject.GetComponent<CharOneModl>();
        _cmp_ctrl = gameObject.GetComponent<CharOneCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
