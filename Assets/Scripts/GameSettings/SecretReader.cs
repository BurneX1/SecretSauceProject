using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SecretReader : MonoBehaviour
{
    public SecretCodes[] codes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VerifyCode(string code)
    {
        SecretCodes s = Array.Find(codes, theCode => theCode.code == code);
        if (s == null)
        {
            Debug.Log("El sonido " + name + " no se ha encontrado");
            return;

        }
        s.codeEvent.Invoke();
    }

}
