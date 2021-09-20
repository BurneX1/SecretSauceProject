using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValues : MonoBehaviour
{
    public GameObject charOne;
    public GameObject charTwo;
    public GameObject gameCtrll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMaxLive(float live)
    {
        gameCtrll.GetComponent<LifeManager>().maxLive = live;
    }
    public void ChangeLive(float live)
    {
        gameCtrll.GetComponent<LifeManager>().actLive = live;
    }
    public void CharOneJump(float jmp)
    {
        charOne.GetComponent<CharOneModl>().jmpForce = jmp;
    }
    public void CharTwoJump(float jmp)
    {
        charTwo.GetComponent<CharTwoModl>().jmpForce = jmp;
    }
    public void CharTwoSpeed(float spd)
    {
        charTwo.GetComponent<CharTwoModl>().movSpd = spd;
    }
    public void CharOneSpeed(float spd)
    {
        charOne.GetComponent<CharOneModl>().movSpd = spd;
    }
}
