using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharTwoModl))]
[RequireComponent(typeof(CharTwoView))]
public class CharTwoCtrl : MonoBehaviour
{
    private CharTwoModl _cmp_mod;
    private CharTwoView _cmp_view;
    private float _cdTime;
    private float _tauntTime;
    private Pause _cmp_ps;
    

    private Vector3 rotatioProves;
    public GameObject gmMng;
    //[HideInInspector]
    public bool atacking;
    public bool battery;
    public GameObject tempFeedback;


    // Start is called before the first frame update
    void Start()
    {
        _cmp_ps = gmMng.GetComponent<Pause>();
        _cdTime = 0;
        _tauntTime = 0;
        atacking = false;

        _cmp_mod = gameObject.GetComponent<CharTwoModl>();
        _cmp_view = gameObject.GetComponent<CharTwoView>();

        if (gameObject.GetComponent<SphereCollider>())
        {
            _cmp_mod.sphColl = gameObject.GetComponent<SphereCollider>();
        }
        else
        {
            _cmp_mod.sphColl = gameObject.AddComponent<SphereCollider>();
        }
        _cmp_mod.sphColl.isTrigger = true;

        _cmp_mod.sphColl.radius = _cmp_mod.spcRange;



        _cmp_mod.grndDistance = 7;
        _cmp_mod.meleHitCollider.gameObject.SetActive(false);

    }

    private void FixedUpdate()
    {
        if (_cmp_ps.paused == false)
        {
            if (_cmp_mod.afkMode == true)
            {
                if (atacking == false)
                {
                    _cmp_mod.AFKmove();
                }
            }
            else
            {
                _cmp_mod.Move();
            }
        }
    }
    void Update()
    {
        if (_cmp_ps.paused == false)
        {
            if (_cmp_mod.afkMode == true)
            {
                TauntTime();
            }
            else
            {
                _cmp_mod.HitBoxAtk(1, false, _cmp_mod.meleHitCollider);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (atacking == true)
        {
            for (int i = 0; i < _cmp_mod.intrcTagsArray.Length; i++)
            {
                if (other.gameObject.CompareTag(_cmp_mod.intrcTagsArray[i]))
                {
                    _cmp_mod.SpcTauntAtck(other);
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (atacking == true)
        {
            for (int i = 0; i < _cmp_mod.intrcTagsArray.Length; i++)
            {
                if (other.gameObject.CompareTag(_cmp_mod.intrcTagsArray[i]))
                {
                    _cmp_mod.SpcTauntAtck(other);
                }
            }
        }
        else
        {
            for (int i = 0; i < _cmp_mod.intrcTagsArray.Length; i++)
            {
                if (other.gameObject.CompareTag(_cmp_mod.intrcTagsArray[i]))
                {
                    _cmp_mod.Untaunt(other);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < _cmp_mod.intrcTagsArray.Length; i++)
        {
            if (other.gameObject.CompareTag(_cmp_mod.intrcTagsArray[i]))
            {
                _cmp_mod.Untaunt(other);
            }
        }
    }

    public void TauntTime()
    {
        if (atacking == false)
        {
            if (tempFeedback != null)
            {
                tempFeedback.SetActive(false);
            }//Temp Feedback

            _cdTime += Time.deltaTime;
            if( _cdTime >= _cmp_mod.coldTime)
            {
                _cdTime = _cmp_mod.coldTime;
                if(Input.GetKeyDown(_cmp_mod.keyArray_extrAct[2]) && battery == true)
                {
                    atacking = true;
                    _cdTime = 0;
                    battery = false;
                }
            }
        }
        else
        {
            if(tempFeedback != null)
            {
                tempFeedback.SetActive(true);
            }//Temp Feedback


            _tauntTime += Time.deltaTime;
            if(_tauntTime >= _cmp_mod.atkDur)
            {
                atacking = false;
                battery = true;//Borrar esta linea cuando se implementen las baterias
                _tauntTime = 0;

            }
        }
    }

}
