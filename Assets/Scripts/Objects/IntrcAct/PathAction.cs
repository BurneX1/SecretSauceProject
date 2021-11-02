using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathAction : MonoBehaviour
{
    public Vector3[] wayPoints;
    public float speed;

    private int current;
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position != wayPoints[current])
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, wayPoints[current], speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else current = (current + 1) % wayPoints.Length;
    }
}
