using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : Entities
{
    private float _movSpd;
    [Range(0.0f,20000)]
    public float meleCD;

    [HideInInspector]
    public bool afkMode;

    public Characters(float spd) : base() 
    {
        _movSpd = spd;
     
    }

    public void SelfDmg(int dmg)
    {

    }
    public void Move()
    {

    }
    public void HitBoxAtk(int dmg, bool oneHitatk)
    {

    }

}
