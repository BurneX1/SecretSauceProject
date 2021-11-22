using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickeable : MonoBehaviour
{
    [HideInInspector]
    public bool picked;
    [HideInInspector]
    public GameObject grabPick;
    [HideInInspector]
    public Sprite objImg;
    public LayerMask grnLyr;
    public bool dropfx;
    public float upLevel;
    public Collider pickerColl;
    public float tmpLvl;
    public Collider mainColl;
    // Start is called before the first frame update
    void Start()
    {
        tmpLvl = upLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if(picked==true)
        {
            //pickerColl.enabled = false;
            transform.position = grabPick.transform.position;
            
        }
        else if(dropfx && Physics.Raycast(transform.position,Vector3.down,0.1f + (mainColl.bounds.size.y/2) ,grnLyr)!= true)
        {
            
            if (tmpLvl >=4)
            {
                tmpLvl = 4;
            }
            else if(tmpLvl <= -4)
            {
                tmpLvl = -4;
            }
            else
            {
                tmpLvl -= Time.deltaTime;
            }
            float tmp = tmpLvl * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y + tmp, transform.position.z);
            //pickerColl.enabled = true;
        }
        else
        {
            tmpLvl = upLevel;
            //pickerColl.enabled = true;
        }

    }

    public void Picked(GameObject point)
    {
        grabPick = point;
        picked = true;

    }

    public void Droped()
    {
        tmpLvl = upLevel;
        picked = false;
    }
}
