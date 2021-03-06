using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// Script encargado de configurar los valores de los personajes jugables.
/// 
/// El PlayerManayer permite configurar las caracterÝsticas de todos los personajes jugables y mantener el modo jugable en solo uno de los personajes.
public class PlayerMangr : MonoBehaviour
{
    private int _inptPly;
    private int _befInp;

    //-----Escoger Teclas------//
    public KeyCode key_up;
    public KeyCode key_down;
    public KeyCode key_rigth;
    public KeyCode key_left;
    public KeyCode key_jump;
    public KeyCode key_atk;
    public KeyCode[] keyArray_extrAct;

    public KeyCode key_switch;
    //-------------------------//

    public GameObject[] playerArray;
    public GameObject vrtCam;
    public GameObject myCam;

    /*private void OnEnable()
    {
        _inptPly = 0;
        _befInp = -1;
        SetPlayer();
    }*/
    // Start is called before the first frame update

    void Start()
    {
        _inptPly = 0;
        _befInp = -1;
        SetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key_switch))
        {
            Switch();
        }
    }

    void Switch()
    {

        int tmpUses = 0;
        while (tmpUses <= playerArray.Length)
        {
            if (_inptPly < playerArray.Length - 1)
            {
                _inptPly++;
                tmpUses++;
            }
            else
            {
                _inptPly = 0;
                tmpUses++;
            }

            if (playerArray[_inptPly] != null)
            {
                if (_befInp != _inptPly)
                {
                    SetPlayer();
                }
                return;
            }
            else
            {
                Debug.Log(name + ": There was some empty CharacterSpaces" + "(" + tmpUses + ")");
            }
        }

    }
    void SetPlayer()
    {
        Debug.Log("Player num in array: " + _inptPly + " of: " + playerArray.Length);

        for(int i = 0; i<playerArray.Length; i++)
        {

            if(playerArray[i] == null)
            {
                //return;
            }
            else if(playerArray[i].GetComponent<Characters>())
            {
                if (i != _inptPly)
                {
                    playerArray[i].GetComponent<Characters>().afkMode = true;
                    if (playerArray[i].GetComponent<Characters>().cmp_agent)
                    {
                        playerArray[i].GetComponent<Characters>().cmp_agent.enabled = true;
                        playerArray[i].GetComponent<Characters>().AFKtarget = playerArray[_inptPly].transform;
                        playerArray[i].GetComponent<Characters>().key_up = key_up;
                        playerArray[i].GetComponent<Characters>().key_down = key_down;
                        playerArray[i].GetComponent<Characters>().key_left = key_left;
                        playerArray[i].GetComponent<Characters>().key_rigth = key_rigth;
                        playerArray[i].GetComponent<Characters>().key_jump = key_jump;
                        playerArray[i].GetComponent<Characters>().key_atk = key_atk;
                        playerArray[i].GetComponent<Characters>().keyArray_extrAct = keyArray_extrAct;
                    }

                }
                else
                {
                    if(vrtCam == null)
                    {
                        Debug.Log(name + ": Please place a VirtualCamera on the Inspector");
                        myCam.GetComponent<CameraOptions>().camTarget = playerArray[i].transform.Find("NewCameraLookAt");
                        return;
                    }
                    else if (vrtCam.GetComponent<CinemachineFreeLook>())
                    {
                        //vrtCam.GetComponent<CinemachineFreeLook>().Follow = playerArray[i].transform;
                        //vrtCam.GetComponent<CinemachineFreeLook>().LookAt = playerArray[i].transform;
                        myCam.GetComponent<CameraOptions>().camTarget = playerArray[i].transform.Find("NewCameraLookAt");
                    }
                    else
                    {
                        myCam.GetComponent<CameraOptions>().camTarget = playerArray[i].transform.Find("NewCameraLookAt");
                        Debug.Log(name + ": Please add a CinemachineFreeLook component on the Inspector");
                        return;
                    }

                    //Change the AFK mode to make able to play
                    playerArray[i].GetComponent<Characters>().afkMode = false;
                    if (playerArray[i].GetComponent<Characters>().cmp_agent)
                    {
                        playerArray[i].GetComponent<Characters>().cmp_agent.enabled = false;
                        
                    }


                    //Set de Controlls of the player
                    playerArray[i].GetComponent<Characters>().key_up = key_up;
                    playerArray[i].GetComponent<Characters>().key_down = key_down;
                    playerArray[i].GetComponent<Characters>().key_left = key_left;
                    playerArray[i].GetComponent<Characters>().key_rigth = key_rigth;
                    playerArray[i].GetComponent<Characters>().key_jump = key_jump;
                    playerArray[i].GetComponent<Characters>().key_atk = key_atk;
                    playerArray[i].GetComponent<Characters>().keyArray_extrAct = keyArray_extrAct;

                }
            }
            else
            {
                //return;
            }
        }
    }

    public void NonActionPly()
    {
        for (int i = 0; i < playerArray.Length; i++)
        {
            if(playerArray[i].GetComponent<CharOneCtrl>())
            {
                playerArray[i].GetComponent<CharOneCtrl>().enabled = false;
                playerArray[i].GetComponent<Animator>().enabled = false;
            }
            else if(playerArray[i].GetComponent<CharTwoCtrl>())
            {
                playerArray[i].GetComponent<CharTwoCtrl>().enabled = false;
                playerArray[i].GetComponent<Animator>().enabled = false;
            }
        }
    }

    public void EnableActionPlayer()
    {
        for (int i = 0; i < playerArray.Length; i++)
        {
            if (playerArray[i].GetComponent<CharOneCtrl>())
            {
                playerArray[i].GetComponent<CharOneCtrl>().enabled = true;
                playerArray[i].GetComponent<Animator>().enabled = true;
            }
            else if (playerArray[i].GetComponent<CharTwoCtrl>())
            {
                playerArray[i].GetComponent<CharTwoCtrl>().enabled = true;
                playerArray[i].GetComponent<Animator>().enabled = true;
            }
        }
    }
}
