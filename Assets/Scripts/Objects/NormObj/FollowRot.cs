using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRot : MonoBehaviour
{
    public GameObject target;
    public float min_angle, max_angle;
    public float spd;

    // Start is called before the first frame update
    void Start()
    {
        min_angle = min_angle % 360;
        max_angle = max_angle % 360;
    }

    // Update is called once per frame
    void Update()
    {
        Rot();
    }

    void Rot()
    {
        /*if(transform.eulerAngles.y < min_angle)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,min_angle, transform.eulerAngles.z);
        }
        else if(transform.eulerAngles.y > max_angle)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, max_angle, transform.eulerAngles.z);
        }
        else
        {*/
            Vector3 dir = (new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z) - transform.position).normalized;

            Quaternion rotate = Quaternion.LookRotation(dir);
            float tmp_y = rotate.eulerAngles.y;

            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, new Vector3(transform.eulerAngles.x, tmp_y, transform.eulerAngles.z), Time.deltaTime * spd);
        //}
        
    }
}
