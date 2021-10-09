using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasManager : MonoBehaviour
{
    //Referencias
    private TestMov player;

    //Arrays
    public GameObject[] camerasSwitchers0;
    public GameObject[] camerasInScene0;
    public Collider[] cameraConfiners;



    void Start()
    {
        player = GetComponent<TestMov>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == camerasSwitchers0[0])
        {

            camerasInScene0[1].SetActive(true);
            camerasInScene0[0].SetActive(false);
            //camerasInScene0[2].SetActive(false);

            //camerasSwitchers0[0].gameObject.SetActive(false);
            //camerasSwitchers0[1].gameObject.SetActive(true);

        }
        if (other.gameObject == camerasSwitchers0[1])
        {
            camerasInScene0[1].SetActive(false);
            camerasInScene0[0].SetActive(true);
            //camerasInScene0[2].SetActive(false);

            //camerasSwitchers0[1].gameObject.SetActive(false);
            //camerasSwitchers0[0].gameObject.SetActive(true);
        }


        if (other.gameObject == camerasSwitchers0[2])
        {
            camerasInScene0[2].SetActive(true);
            camerasInScene0[1].SetActive(false);
            camerasInScene0[0].SetActive(false);

            camerasSwitchers0[2].gameObject.SetActive(false);
            camerasSwitchers0[3].gameObject.SetActive(true);
        }

        if (other.gameObject == camerasSwitchers0[3])
        {
            camerasInScene0[2].SetActive(false);
            camerasInScene0[1].SetActive(true);
            camerasInScene0[0].SetActive(false);

            camerasSwitchers0[2].gameObject.SetActive(true);
            camerasSwitchers0[3].gameObject.SetActive(false);
        }


        if (other.gameObject == camerasSwitchers0[4])
        {
            camerasInScene0[0].transform.position = new Vector3(5.772781f, 5.333163f, -5.386351f);
            camerasInScene0[0].transform.rotation = Quaternion.Euler(46.753f, -105.37f, -0.005f);

            camerasSwitchers0[4].gameObject.SetActive(false);
            camerasSwitchers0[5].gameObject.SetActive(true);
        }
        if (other.gameObject == camerasSwitchers0[5])
        {
            camerasInScene0[0].transform.position = new Vector3(6.977396f, 4.74105f, -0.8858073f);
            camerasInScene0[0].transform.rotation = Quaternion.Euler(36.784f, -146.895f, 0f);

            camerasSwitchers0[4].gameObject.SetActive(true);
            camerasSwitchers0[5].gameObject.SetActive(false);
        }
    }
}
