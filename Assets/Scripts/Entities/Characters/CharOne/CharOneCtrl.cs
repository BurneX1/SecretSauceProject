using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharOneModl))]
[RequireComponent(typeof(CharOneView))]
public class CharOneCtrl : MonoBehaviour
{
    private CharOneModl _cmp_mod;
    private CharOneView _cmp_view;

    private Vector3 rotatioProves;
    // Start is called before the first frame update
    void Start()
    {

        _cmp_mod = gameObject.GetComponent<CharOneModl>();
        _cmp_view = gameObject.GetComponent<CharOneView>();
        _cmp_mod.grndDistance = 7;
    }

    private void FixedUpdate()
    {
        _cmp_mod.Move();
    }
    // Update is called once per frame
    void Update()
    {
        _cmp_mod.grounded = _cmp_mod.GroundDetect(_cmp_mod.groundLayer, 1.1f);
    }
   
}
