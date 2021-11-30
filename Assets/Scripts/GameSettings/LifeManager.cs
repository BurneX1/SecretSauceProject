using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// Script encargado de controlar las vidas del jugador.
/// 
/// Para manejar las vidas del jugador de forma independiente al script del jugador utilice este script para almacenar la vida
public class LifeManager : MonoBehaviour
{
    [SerializeField]
    [Range(1,20)]
    public float maxLive;
    //[HideInInspector]
    public float actLive;
    public Image barLife;

    public GameObject player;
    public SceneChange scnMng;
    public string gameOverScene;


    // Start is called before the first frame update
    void Start()
    {
        actLive = maxLive;
    }

    // Update is called once per frame
    void Update()
    {
        ManageLife();
        gameOver(); 
    }

    public void ManageLife()
    {
        float valueLife = actLive / maxLive;
        barLife.fillAmount = Mathf.Lerp(barLife.fillAmount, valueLife, 0.1f);
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
            scnMng.Change(gameOverScene);
            //Llamar a la funcion de termianr el nivel
        }

    }
}
