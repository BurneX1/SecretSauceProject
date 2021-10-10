using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaNivel : InteractableAction
{
    public string level;
    public bool open;
    public GameObject sceneMng;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activation()
    {
        base.Activation();
        if (open == false)
        {
            open = true;
            //gameObject.
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (open == true && other.gameObject.CompareTag("Player"))
        {
            sceneMng.GetComponent<SceneChange>().Change(level);
        }
    }
}
