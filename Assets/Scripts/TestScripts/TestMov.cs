using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMov : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1;

    public Camera mainCam;
    public Vector3 camForward;
    public Vector3 camRight;

    private Vector3 movePlayer;

    public float jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        Move();
        
    }

    void Move()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        if (hor != 0.0f || ver != 0.0f)
        {
            camDirection();

            movePlayer = hor * camRight + ver * camForward;

            rb.transform.LookAt(rb.transform.position + movePlayer);

            //rb.AddForce(movePlayer.normalized * speed, ForceMode.Acceleration);
            rb.MovePosition(rb.position + movePlayer.normalized * speed * Time.fixedDeltaTime);
        }
    }

    void camDirection()
    {
        camForward = mainCam.transform.forward;
        camRight = mainCam.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    void Jump()
    {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
    }
}
