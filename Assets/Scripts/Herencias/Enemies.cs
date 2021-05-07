using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Entities
{
    private int _vida;
    private int _atkDmg;

    public float movSpd;

    public GameObject targetObj;

    public Enemies(int life, int dmg) : base()
    {
        _vida = life;
        _atkDmg = dmg;
    }

    public override void SelfDmg(int dmg)
    {
        Debug.Log(name + ": Auch!");
    }

    public void IncreaseLife(int addLife)
    {

    }

    public void Die()
    {

    }
}
