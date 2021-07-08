using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public KeyCode escape;
    public bool paused;
    public GameObject Pause_Menu;
    public GameObject Opt_Menu;
    private MouseLocker cmp_msLck;


    //public bool Back_Button;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        //Back_Button = false;
        cmp_msLck = gameObject.GetComponent<MouseLocker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(escape))
        {
            PauseOpt();
        }

        if (paused == false)
        {
            cmp_msLck.msLock = true;
            Pause_Menu.SetActive(false);
            if(Opt_Menu.activeSelf == true)
            {
                Opt_Menu.SetActive(false);
            }
            Time.timeScale = 1;
        }
        if (paused == true)
        {
            cmp_msLck.msLock = false;
            Pause_Menu.SetActive(true);
            Time.timeScale = 0;
        }

        //Button_false();

    }

    public void PauseOpt()
    {
        if (paused == true)
        {
            paused = false;
        }
        else if (paused == false)
        {
            paused = true;
        }
    }

    /*public void Button_false()
    {
        if (Back_Button==true)
        {
            Back_Button = false;
            paused = false;
        }
        
    }*/
}
