using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPregValue : MonoBehaviour
{
    public int levelValue; 
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("LastLevel") == false)
        {
            PlayerPrefs.SetInt("LastLevel",levelValue);
        }
        else
        {
            if(PlayerPrefs.GetInt("LastLevel") < levelValue)
            {
                PlayerPrefs.SetInt("LastLevel", levelValue);
            }
        }

        PlayerPrefs.SetInt("CurLevel", levelValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
