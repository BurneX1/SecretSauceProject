using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private float _shtSpeed;
    public string[] dmgTagsArray;
    public string[] interactTagsArray;

    public Projectiles(float spd)
    {
        _shtSpeed = spd;
    }

    public void CallToDamage()
    {

    }

    public void CallToInteract()
    {

    }
}
