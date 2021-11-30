using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Script encargado de darle la funcion de rotación constante a un objeto.
/// 
/// Para mantener un objeto en escena rotando constantemente agregue este script y rellene los valores según lo que considere conveniente.
public class AutoRotate : MonoBehaviour
{
    public bool world;
    public float rotX;
    public float rotY;
    public float rotZ;
    public float loopSpd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (world == true)
        {
            transform.Rotate(new Vector3(rotX, rotY, rotZ) * loopSpd, Space.World); 
        }
        else
        {
            transform.Rotate(new Vector3(rotX, rotY, rotZ) * loopSpd, Space.Self);
        }
        
    }
}
