using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : InteractableAction
{
    public int addedAmmo;
    CharOneModl compChar;

    void Start()
    {
        compChar = GameObject.FindGameObjectWithTag("Player").GetComponent<CharOneModl>();
    }

    void Update()
    {
    }

    public override void Activation()
    {
        if (compChar.currentAmmo < compChar.maxAmmo)
        {
            compChar.currentAmmo += addedAmmo;
            Destroy(gameObject);
        }
    }
}
