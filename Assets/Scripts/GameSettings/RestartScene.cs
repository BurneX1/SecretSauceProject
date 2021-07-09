using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScene : MonoBehaviour
{
    public SceneChange sceneMng;
    public string[] scenes;
    public int toBackScene;
    public int highScene;
    // Start is called before the first frame update
    void Start()
    {
        toBackScene = PlayerPrefs.GetInt("CurLevel", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Retry()
    {
        if (toBackScene < scenes.Length)
        {
            sceneMng.Change(scenes[toBackScene]);
        }
        else
        {
            sceneMng.Change(scenes[0]);
        }
    }

    public void Continue()
    {

    }
}
