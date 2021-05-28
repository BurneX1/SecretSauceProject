using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Range(0f,1f)]
    public float globalVolume;
    public Sound[] soundsArray;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in soundsArray)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume * globalVolume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.effect3D;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Play("Theme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(string name)
    {
        Sound s = Array.Find(soundsArray, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("El sonido " + name + " no se ha encontrado");    
            return;
            
        }
        s.source.Play();
    }
}
