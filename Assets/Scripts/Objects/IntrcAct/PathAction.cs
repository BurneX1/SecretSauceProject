using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathAction : MonoBehaviour
{
    public Vector3[] wayPoints;
    //Rigidbody rb;
    public float speed;
    int dir;

    private int current;
    void Start()
    {
        /*if(gameObject.GetComponent<Rigidbody>())
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }
        else
        {
            rb = gameObject.AddComponent<Rigidbody>();
            
        }*/

        dir = -1;
    }

    void Update()
    {
        if (transform.position != wayPoints[current])
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, wayPoints[current], speed * Time.deltaTime);

            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, wayPoints[current], speed * Time.deltaTime);


            //GetComponent<Rigidbody>().MovePosition(pos);
        }
        //else NextPoint();
    }

    public void NextPoint()
    {
        if (current >= wayPoints.Length - 1 || current <= 0)
        {
            dir = dir * -1;
        }

        current = (current + dir) % wayPoints.Length;
    }
}
