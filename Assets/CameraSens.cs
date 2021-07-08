using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSens : MonoBehaviour
{
    public CinemachineFreeLook cmFree;
    // Start is called before the first frame update
    void Start()
    {
        cmFree = gameObject.GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        cmFree.m_YAxis.m_MaxSpeed = PlayerPrefs.GetFloat("SensVal");
        cmFree.m_XAxis.m_MaxSpeed = PlayerPrefs.GetFloat("SensVal") * 100;
    }
}
