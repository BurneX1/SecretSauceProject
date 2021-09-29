using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTrapdoor : MonoBehaviour
{
    public GameObject door;

    
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        anim.SetBool("Open", true);
    }

    public void Close()
    {
        anim.SetBool("Open", false);
    }
}
