using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasManager : MonoBehaviour
{
    //Referencias
    private TestMov player;

    //Arrays
    public GameObject[] camerasSwitchers0;
    public Camera[] camerasInScene0;

    public bool isIn1 = false; 

    void Start()
    {
        player = GetComponent<TestMov>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitcherEditor()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == camerasSwitchers0[0])
        {
            camerasInScene0[0].gameObject.SetActive(false);
            camerasInScene0[1].gameObject.SetActive(true);
            camerasInScene0[2].gameObject.SetActive(false);
            player.mainCam = camerasInScene0[1];

            camerasSwitchers0[0].gameObject.SetActive(false);
            camerasSwitchers0[1].gameObject.SetActive(true);

            //--VIEJO METODO CON BUGS--//
            /*if (isIn1 == false)
            {
                camerasInScene[0].gameObject.SetActive(false);
                camerasInScene[1].gameObject.SetActive(true);


                player.mainCam = camerasInScene[1];
                isIn1 = true;
            }
            else if (isIn1 == true)
            {
                camerasInScene[0].gameObject.SetActive(true);
                camerasInScene[1].gameObject.SetActive(false);


                player.mainCam = camerasInScene[0];
                isIn1 = false;
            }*/
        }
        if (other.gameObject == camerasSwitchers0[1])
        {
            camerasInScene0[0].gameObject.SetActive(true);
            camerasInScene0[1].gameObject.SetActive(false);
            camerasInScene0[2].gameObject.SetActive(false);
            camerasInScene0[3].gameObject.SetActive(false);
            player.mainCam = camerasInScene0[0];

            camerasSwitchers0[0].gameObject.SetActive(true);
            camerasSwitchers0[1].gameObject.SetActive(false);
        }


        if (other.gameObject == camerasSwitchers0[2])
        {
            camerasInScene0[0].gameObject.SetActive(false);
            camerasInScene0[1].gameObject.SetActive(false);
            camerasInScene0[2].gameObject.SetActive(true);
            camerasInScene0[3].gameObject.SetActive(false);
            player.mainCam = camerasInScene0[2];

            camerasSwitchers0[2].gameObject.SetActive(false);
            camerasSwitchers0[3].gameObject.SetActive(true);
        }
        if (other.gameObject == camerasSwitchers0[3])
        {
            camerasInScene0[0].gameObject.SetActive(false);
            camerasInScene0[1].gameObject.SetActive(true);
            camerasInScene0[2].gameObject.SetActive(false);
            camerasInScene0[3].gameObject.SetActive(false);
            player.mainCam = camerasInScene0[1];

            camerasSwitchers0[2].gameObject.SetActive(true);
            camerasSwitchers0[3].gameObject.SetActive(false);
        }


        if (other.gameObject == camerasSwitchers0[4])
        {
            camerasInScene0[0].gameObject.SetActive(false);
            camerasInScene0[1].gameObject.SetActive(false);
            camerasInScene0[2].gameObject.SetActive(false);
            camerasInScene0[3].gameObject.SetActive(true);
            player.mainCam = camerasInScene0[3];

            camerasSwitchers0[4].gameObject.SetActive(false);
            camerasSwitchers0[5].gameObject.SetActive(true);
        }
        if (other.gameObject == camerasSwitchers0[5])
        {
            camerasInScene0[0].gameObject.SetActive(false);
            camerasInScene0[1].gameObject.SetActive(false);
            camerasInScene0[2].gameObject.SetActive(true);
            camerasInScene0[3].gameObject.SetActive(false);
            player.mainCam = camerasInScene0[2];

            camerasSwitchers0[4].gameObject.SetActive(true);
            camerasSwitchers0[5].gameObject.SetActive(false);
        }
    }
}
