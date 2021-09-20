using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopActive : MonoBehaviour
{
    public GameObject[] toDevActive;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GmMngr").GetComponent<GameManager>();

        if (gm == null) return;
        if(gm.m_GameMode == GameManager.gameMode.DeveloperMode)
        {
            DevActive();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DevActive()
    {
        if (gm.m_GameMode == GameManager.gameMode.DeveloperMode)
        {
            for (int i = 0; i < toDevActive.Length; i++)
            {
                toDevActive[i].gameObject.SetActive(true);
            }
        }   
    }

    public void ModeChange(GameManager.gameMode newMode)
    {
        if (gm == null) return;
        gm.m_GameMode = newMode;

    }

    public void ChangeDev()
    {
        if (gm == null) return;
        gm.m_GameMode = GameManager.gameMode.DeveloperMode;

    }
    public void ChangeUser()
    {
        if (gm == null) return;
        gm.m_GameMode = GameManager.gameMode.UserMode;

    }
}
