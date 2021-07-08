using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Opciones : MonoBehaviour
{

    [Header("ShowOnly Volumes")]
    public float genVolume;
    public float mscVolume;
    public float sndVolume;
    [Header("ShowOnly Sensibility")]
    public float sensVal;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("GenVol") == false)
        {
            PlayerPrefs.SetFloat("GenVol", 0.5f);
        }
        if (PlayerPrefs.HasKey("MscVol") == false)
        {
            PlayerPrefs.SetFloat("MscVol", 0.5f);
        }
        if (PlayerPrefs.HasKey("SndVol") == false)
        {
            PlayerPrefs.SetFloat("SndVol", 0.5f);
        }
        if (PlayerPrefs.HasKey("SensVal") == false)
        {
            PlayerPrefs.SetFloat("SensVal", 0.5f);
        }

        genVolume = PlayerPrefs.GetFloat("GenVol");
        mscVolume = PlayerPrefs.GetFloat("MscVol");
        sndVolume = PlayerPrefs.GetFloat("SndVol");
        sensVal = PlayerPrefs.GetFloat("SensVal");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGenVolume(float vol)
    {
        PlayerPrefs.SetFloat("GenVol", vol);
        genVolume = PlayerPrefs.GetFloat("GenVol");

        
    }
    public void SetSndVolume(float vol)
    {
        sndVolume = PlayerPrefs.GetFloat("SndVol");
        PlayerPrefs.SetFloat("SndVol", vol);

    }
    public void SetMscVolume(float vol)
    {
        PlayerPrefs.SetFloat("MscVol", vol);
        mscVolume = PlayerPrefs.GetFloat("MscVol");
    }

    public void SetSenseValue(float val)
    {
        PlayerPrefs.SetFloat("SensVal", val);
        sensVal = PlayerPrefs.GetFloat("SensVal");
    }
}
