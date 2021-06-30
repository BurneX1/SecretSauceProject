using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossView : MonoBehaviour
{
    private BossMdl _cmp_mod;
    private BossCtrl _cmp_ctrl;
    public Animator _cmp_anim;
    public bool onAtack;
    public bool onPanic;
    // Start is called before the first frame update
    void Start()
    {
        _cmp_mod = gameObject.GetComponent<BossMdl>();
        _cmp_ctrl = gameObject.GetComponent<BossCtrl>();
        //_cmp_anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(onAtack == true)
        {
            _cmp_anim.SetTrigger("Attack");
            onAtack = false;
        }
        
        if(onPanic == true)
        {
            _cmp_anim.SetTrigger("Panic");
            onPanic = false;
        }

    }
}
