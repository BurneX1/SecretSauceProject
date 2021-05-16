using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharTwoModl))]
[RequireComponent(typeof(CharTwoView))]
public class CharTwoCtrl : MonoBehaviour
{
    private CharTwoModl _cmp_mod;
    private CharTwoView _cmp_view;

    private Vector3 rotatioProves;
    // Start is called before the first frame update
    void Start()
    {

        _cmp_mod = gameObject.GetComponent<CharTwoModl>();
        _cmp_view = gameObject.GetComponent<CharTwoView>();
        _cmp_mod.grndDistance = 7;
        _cmp_mod.meleHitCollider.gameObject.SetActive(false);

    }

    private void FixedUpdate()
    {
        if (_cmp_mod.afkMode == true)
        {
            _cmp_mod.AFKmove();
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
            _cmp_mod.HitBoxAtk(1, false, _cmp_mod.meleHitCollider);
        }
    }
}
