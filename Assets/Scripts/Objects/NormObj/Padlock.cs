using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padlock : MonoBehaviour
{
    public bool open;
    public float upLvl;
    public float dropRotSpd;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if(open == true)
        {
            Drop();
        }
    }

    void Drop()
    {

            if (upLvl >= 4)
            {
                upLvl = 4;
            }
            else if (upLvl <= -4)
            {
                upLvl = -4;
            }
            else
            {
                upLvl -= Time.deltaTime;
            }
            float tmp = upLvl * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y + tmp, transform.position.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + (Time.deltaTime * dropRotSpd), transform.eulerAngles.z + (Time.deltaTime * dropRotSpd));
        //pickerColl.enabled = true;

        timer += Time.deltaTime;
        if(timer>=5)
        {
            gameObject.SetActive(false);
        }
    }

    public void Open()
    {
        open = true;
    }
}
