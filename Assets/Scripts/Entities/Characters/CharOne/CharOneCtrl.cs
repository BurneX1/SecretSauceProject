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
        _cmp_mod.meleHitCollider.gameObject.SetActive(false);

    }

    private void FixedUpdate()
    {
        if (_cmp_mod.afkMode == true)
        {

        }
        else
        {
            _cmp_mod.Move();
        }
    }
    void Update()
    {
        if (_cmp_mod.afkMode == true)
        {

        }
        else
        {
            _cmp_mod.HitBoxAtk(1, true, _cmp_mod.meleHitCollider);
        }
    }
   
}
