using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Script encargado de ocultar la visibilidad del cursor y anular la movilidad del mismo.
/// 
/// Para desactivar la visualización del mouse este script permite ocultar la visibilidad de este y bloquear su posición en el centro de la pantalla.
public class MouseLocker : MonoBehaviour
{
    public KeyCode mouse_key;
    public bool msLock;
    //public static MouseLocker instance;
    // Start is called before the first frame update
    void Start()
    {
        /*if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);*/
        if (msLock == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(mouse_key))
        {
            if (msLock == true)
            {
                msLock = false;
            }
            else
            {
                msLock = true;
            }
        }
        if (msLock == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        /*Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;*/
    }
}
