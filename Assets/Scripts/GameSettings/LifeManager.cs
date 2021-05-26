using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField]
    [Range(1,20)]
    private int maxLive;
    private int actLive;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        actLive = maxLive;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int dmg)
    {
        if (actLive > 0)
        {
            actLive = actLive - dmg;
        }
        if(actLive<0)
        {
            actLive = 0;
        }
    }

    public void AddLife(int life)
    {
        if (actLive < maxLive)
        {
            actLive = actLive + life;
        }
        if (actLive > maxLive)
        {
            actLive = maxLive;
        }
    }

    private void gameOver()
    {
        if (actLive <= 0)
        {
            player.GetComponent<Characters>().Die();
            //Llamar a la funcion de termianr el nivel
        }

    }
}
