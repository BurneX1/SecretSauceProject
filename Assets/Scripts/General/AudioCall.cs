using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCall : MonoBehaviour
{
    AudioManager aud;
    // Start is called before the first frame update
    void Start()
    {
        aud = GameObject.Find("SoundManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallAudio(string audioName)
    {
        if (aud)
        {
            aud.Play(audioName);
        }
    }

    public void PauseAudio(string audioName)
    {
        if (aud)
        {
            aud.Stop(audioName);
        }
    }
}
