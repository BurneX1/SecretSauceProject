using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvitionalThirdCamera : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    public float lerpValue;
    public float sensibility;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Pj1").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibility, Vector3.up) * offset;

        transform.LookAt(target);

    }
}
