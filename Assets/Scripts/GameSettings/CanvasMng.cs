using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CanvasMng : MonoBehaviour
{
    public AudioCall audioA;
    public SceneChange scenes;

    public GameObject shadowCanvas;
    public GameObject defaultCanvas;
    public CanvasObj[] canvas;

    private float timer;
    public float normalTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActiveCanvas(string canvasName)
    {

        CanvasObj s = Array.Find(canvas, canvasobj => canvasobj.name == canvasName);
        if (s == null)
        {
            Debug.Log("El canvas " + canvasName + " no se ha encontrado");
            return;
        }


        if(shadowCanvas)
        {
            shadowCanvas.GetComponent<Canvas>().sortingOrder = s.canvObj.GetComponent<Canvas>().sortingOrder -1;
        }

        if(s.canvObj.activeSelf == false)
        {
            s.canvObj.SetActive(true);
        }
    }
    public void DesactiveCanvas(string canvasName)
    {
        CanvasObj s = Array.Find(canvas, canvasobj => canvasobj.name == canvasName);
        if (s == null)
        {
            Debug.Log("El canvas " + canvasName + " no se ha encontrado");
            return;
        }

        if (s.canvObj.activeSelf == true)
        {
            s.canvObj.SetActive(false);
        }
    }


    //Specific funtion for specific elemnts, delete if you are not using this...thing in your proyect -BurneX
    public void DisableCanvas(string canvasName)
    {
        CanvasObj s = Array.Find(canvas, canvasobj => canvasobj.name == canvasName);
        if (s == null)
        {
            Debug.Log("El canvas " + canvasName + " no se ha encontrado");
            return;
        }

        if (s.canvObj.activeSelf == true)
        {
            if (s.canvObj.GetComponent<AlphaTransition>())
            {
                s.canvObj.GetComponent<AlphaTransition>().AlternativeDisable();
            }
            else
            {
                s.canvObj.SetActive(false);
            }
            
        }
    }

}
