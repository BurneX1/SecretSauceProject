using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallAudio(string audioName)
    {
        if (GameObject.Find("SoundManager").GetComponent<AudioManager>())
        {
            GameObject.Find("SoundManager").GetComponent<AudioManager>().Play(audioName);
        }
    }

    public void PauseAudio(string audioName)
    {
        if (GameObject.Find("SoundManager").GetComponent<AudioManager>())
        {
            GameObject.Find("SoundManager").GetComponent<AudioManager>().Stop(audioName);
        }
    }
}
