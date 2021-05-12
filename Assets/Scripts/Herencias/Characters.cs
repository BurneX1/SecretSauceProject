using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : Entities
{
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 lookCamPs;
    private Vector3 playerInput;
    private bool cooldownActive;
    private float atkCDTimer;


    public Camera myCamera;
    //-----Escoger Teclas------//
    [HideInInspector]
    public KeyCode key_up;
    [HideInInspector]
    public KeyCode key_down;
    [HideInInspector]
    public KeyCode key_rigth;
    [HideInInspector]
    public KeyCode key_left;
    [HideInInspector]
    public KeyCode key_jump;
    [HideInInspector]
    public KeyCode key_atk;
    [HideInInspector]
    public KeyCode[] keyArray_extrAct;
    //-------------------------//

    [Range(0.0f,3)]
    public float meleCD;
    public Collider meleHitCollider;
    [Range(0.0f, 1000)]
    public float jmpForce;
    [Range(0.0f, 500)]
    public float movSpd;
    [HideInInspector]
    public float smoothVel;
    [HideInInspector]
    public bool afkMode;



    public Characters() : base() 
    {
     
    }

    public void Update()
    {
        grounded = GroundDetect(groundLayer, 1.1f);
        CDTimer(meleCD);
    }

    void CDTimer(float cooldownTime)
    {
        if (cooldownActive == true)
        {
            atkCDTimer += Time.deltaTime;
        }
        if (atkCDTimer >= cooldownTime)
        {
            cooldownActive = false;
            meleHitCollider.gameObject.SetActive(false);
            atkCDTimer = 0;
        }
    }

    /////////////////////////////////////////////////////////////////////////////////
    public override void SelfDmg(int dmg)
    {

    }
    public void Move()
    {
        Walk();
        CamDirection();
        Jump(jmpForce);
    }
    public void HitBoxAtk(int dmg, bool oneHitatk, Collider hitBox)
    {
        if (Input.GetKeyDown(key_atk))
        {
            if(cooldownActive == false)
            {
                cooldownActive = true;
                hitBox.gameObject.GetComponent<HitElements>().dmg = dmg;
                hitBox.gameObject.GetComponent<HitElements>().hitDetect = false;
                hitBox.gameObject.GetComponent<HitElements>().despOnCollision = oneHitatk;
                hitBox.gameObject.SetActive(true);
            }
        }
    }


    void CamDirection()
    {
        camForward = myCamera.transform.forward;
        camRight = myCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    ////////////////////////////////////////////////////////////////////
    public void Move_in_transform(float speed)
    {
        //cmp_rb.velocity = transform.forward * speed * Time.deltaTime;
        cmp_rb.velocity = new Vector3(transform.forward.x * speed * Time.deltaTime, cmp_rb.velocity.y, transform.forward.z * speed * Time.deltaTime);
        //cmp_rb.velocity = new Vector3(transform.forward.x + speed, transform.forward.y, transform.forward.z + speed);
    }

    public void Rote_in_Y(Vector3 move)
    {
        if (move.magnitude >= 0.1f)
        {

            lookCamPs = playerInput.x * camRight + playerInput.z * camForward;

            float targetAngle = Mathf.Atan2(lookCamPs.x, lookCamPs.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVel, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

        }
    }

    private void Walk()
    {
        float hor;
        float ver;
        if (Input.GetKey(key_left))
        {
            hor = -1;
            Move_in_transform(movSpd);
        }
        else if (Input.GetKey(key_rigth))
        {
            hor = 1;
            Move_in_transform(movSpd);
        }
        else
        {
            hor = 0;
        }

        if (Input.GetKey(key_down))
        {
            ver = -1;
            Move_in_transform(movSpd);
        }
        else if (Input.GetKey(key_up))
        {
            ver = 1;
            Move_in_transform(movSpd);
        }
        else
        {
            ver = 0;
        }

        playerInput = new Vector3(hor, 0f, ver);
        Rote_in_Y(playerInput);

    }

    private void Jump(float force)
    {
        if (Input.GetKey(key_jump) && grounded)
        {
            cmp_rb.AddForce(new Vector3(0, force, 0));
        }
    }
    

}
