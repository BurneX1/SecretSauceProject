using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/// Script encargado de asignar valores y funciones de un player controlable.
/// 
/// Para crear un personaje utilizando la clase “Characters” se recomienda heredar las 
/// funciones de esta mediante la creación de un nuevo script que ejecute las funciones 
/// preestablecidas en base a lo que cada usuario considere conveniente.
[RequireComponent(typeof(NavMeshAgent))]
public class Characters : Entities
{
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 lookCamPs;
    private Vector3 playerInput;
    private bool cooldownActive;
    private float atkCDTimer;
    private RaycastHit _frontHit;
    private bool canJmp;
    private float jmpTimer;
    [HideInInspector]
    public GameObject actualPick;
    private GameObject befPick;
    private float befPckTimer;

    public bool isMovingH;
    public bool isMovingV;


    public LifeManager lifeMng;
    public Camera myCamera;
    [HideInInspector]
    public Transform AFKtarget;
    [HideInInspector]
    public NavMeshAgent cmp_agent;
    public GameObject grabPoint;

    //-----Escoger Teclas------//
    //[HideInInspector]
    public KeyCode key_up;
    //[HideInInspector]
    public KeyCode key_down;
    //[HideInInspector]
    public KeyCode key_rigth;
    //[HideInInspector]
    public KeyCode key_left;
    //[HideInInspector]
    public KeyCode key_jump;
    //[HideInInspector]
    public KeyCode key_atk;
    //[HideInInspector]
    public KeyCode[] keyArray_extrAct;
    //-------------------------//

    [Range(0.0f,3)]
    public float meleCD;
    public Collider meleHitCollider;
    [Range(0.0f, 1500)]
    public float jmpForce;
    public float vertForSpdLimt;
    [Range(0.0f, 500)]
    public float movSpd;
    [HideInInspector]
    public float smoothVel;
    [HideInInspector]
    public bool afkMode;
    [Range(0.0f, 100)]
    public float afkMaxDistance;
    [Range(0.0f, 100)]
    public float afkMinDistance;

    public Transform der;
    public Transform izq;

    public float hor;
    public float ver;

    public bool caminar;

    public override void OnEnable()
    {
        base.OnEnable();
        cmp_agent = gameObject.GetComponent<NavMeshAgent>();
    }
    public override void Start()
    {

        //cmp_agent.autoTraverseOffMeshLink = false;
        //cmp_agent.destination = AFKtarget.position;
    }
    public Characters() : base() 
    {
     
    }

    public void Update()
    {
        grounded = GroundDetect(groundLayer, grndDistance);
        CDTimer(meleCD);
        BeforPickTimer();


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
        //lifeMng.Damage(dmg);
        Debug.Log("Hit");
    }
    public void Move()
    {
        Walk();
        CamDirection();
        Jump(jmpForce);
    }
    /*public void Move2()
    {
        Walk();
        CamDirection();
        Jump(jmpForce);
    }*/
    public void HitBoxAtk(int dmg, bool oneHitatk, Collider hitBox)
    {
        if (Input.GetKeyDown(key_atk))
        {
            if(cooldownActive == false)
            {
                OpenHitbox(dmg, oneHitatk, hitBox);
            }
        }
    }
    public void OpenHitbox(int dmg, bool oneHitatk, Collider hitBox)
    {
        cooldownActive = true;
        hitBox.gameObject.GetComponent<HitElements>().dmg = dmg;
        hitBox.gameObject.GetComponent<HitElements>().hitDetect = false;
        hitBox.gameObject.GetComponent<HitElements>().despOnCollision = oneHitatk;
        hitBox.gameObject.SetActive(true);
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


        //vAxis = transform.forward * speed * Time.deltaTime;
        //Mov();
        //cmp_rb.velocity = transform.forward * speed * Time.deltaTime;
        //Vector3 vctMov = new Vector3(transform.forward.x * speed * Time.deltaTime, cmp_rb.velocity.y, transform.forward.z * speed * Time.deltaTime);

        cmp_rb.velocity = new Vector3(transform.forward.x * speed * Time.deltaTime, cmp_rb.velocity.y, transform.forward.z * speed * Time.deltaTime);

        //cmp_rb.AddForce(new Vector3(transform.forward.x * speed * Time.deltaTime, cmp_rb.velocity.y, transform.forward.z * speed * Time.deltaTime));
        //cmp_rb.velocity = new Vector3(transform.forward.x + speed, transform.forward.y, transform.forward.z + speed);
    }
    public void LateralMovement(float spd)
    {
        //transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(target.position.x, transform.position.y, target.position.z), spd * Time.deltaTime);
        //cmp_rb.MovePosition(new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z + 0.01f));
        //hAxis = transform.right * spd * Time.deltaTime;

        //Mov();
        //cmp_rb.velocity = new Vector3(hAxis.x + vAxis.x, hAxis.y + vAxis.y, hAxis.z + vAxis.z);
        //new Vector3(transform.right.x * spd * Time.deltaTime, cmp_rb.velocity.y, transform.right.z * spd * Time.deltaTime)

    }

    public void MoveBasedOnCam(float speed)
    {
        Vector3 mvPs = playerInput.x * camRight + playerInput.z * camForward;
        cmp_rb.velocity = new Vector3(mvPs.x * speed * Time.deltaTime, cmp_rb.velocity.y, mvPs.z * speed * Time.deltaTime);
    }

    void CompleteFPMovement(float hSpd, float vSpd)
    {
        Vector3 mv = new Vector3((transform.forward.x * vSpd + transform.right.x * hSpd) * Time.deltaTime, 0, (transform.forward.z * vSpd + transform.right.z * hSpd) * Time.deltaTime);
        
        cmp_rb.velocity = new Vector3(mv.x, cmp_rb.velocity.y, mv.z);
    }

    public void Rote_in_Y(Vector3 move)
    {
        if (move.magnitude >= 0.1f)
        {

            lookCamPs = playerInput.x * camRight + playerInput.z * camForward;
            //comentar el camRigth + player.input por si quuieres volver a volver a cambiar el movimiento otra vez al que habia antes

            float targetAngle = Mathf.Atan2(lookCamPs.x, lookCamPs.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVel, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

        }
    }

    private void Walk()
    {
        
        if (Input.GetKey(key_left))
        {
            hor = -1;
            //LateralMovement(-movSpd);
            //Move_in_transform(movSpd);
            MoveBasedOnCam(movSpd);
            isMovingH = true;
        }
        else if (Input.GetKey(key_rigth))
        {
            hor = 1;
            //LateralMovement(movSpd);
            //Move_in_transform(movSpd);
            MoveBasedOnCam(movSpd);
            isMovingH = true;
        }
        else
        {
            hor = 0;
            isMovingH = false;
        }
        
        if (Input.GetKey(key_down))
        {
            ver = -1;
            //Move_in_transform(movSpd);
            MoveBasedOnCam(movSpd);
            isMovingV = true;
        }
        else if (Input.GetKey(key_up) /*&& Physics.BoxCast(transform.position, transform.localScale, transform.forward, transform.rotation, 1.5f, groundLayer) == false*/)
        {
            ver = 1;
            //Move_in_transform(movSpd);
            MoveBasedOnCam(movSpd);
            isMovingV = true;
        }
        else
        {
            ver = 0; 
            isMovingV = false;
        }

        /*if(hor != 0 && ver != 0)
        {
            CompleteFPMovement(movSpd * hor/1.5f, movSpd * ver/1.5f);
        }
        else if(hor != 0 || ver != 0)
        {
            CompleteFPMovement(movSpd * hor, movSpd * ver);
        }*/

        //Mov();
        playerInput = new Vector3(hor, 0f, ver);
        //playerInput = new Vector3(myCamera.transform.rotation.eulerAngles.x, 0, myCamera.transform.rotation.eulerAngles.z);
        Rote_in_Y(playerInput);

    }

    private void Jump(float force)
    {

        JmpTimer(0.3f);
        if (Input.GetKey(key_jump) && canJmp)
        {
            cmp_rb.AddForce(new Vector3(0, force, 0));
            canJmp = false;
        }

        if (cmp_rb.velocity.y < 0 && canJmp == false)
        {
            cmp_rb.velocity = new Vector3(cmp_rb.velocity.x, cmp_rb.velocity.y + (Time.deltaTime * -1), cmp_rb.velocity.z);
        }

        if (cmp_rb.velocity.y > vertForSpdLimt)
        {
            cmp_rb.velocity = new Vector3(cmp_rb.velocity.x ,vertForSpdLimt , cmp_rb.velocity.z);
        }
        else if(cmp_rb.velocity.y < (-1 * vertForSpdLimt))
        {

            cmp_rb.velocity = new Vector3(cmp_rb.velocity.x, vertForSpdLimt * -1, cmp_rb.velocity.z);

        }
    }

    private void JmpTimer(float coyoteTime)
    {
        if(grounded == true)
        {
            canJmp = true;
            jmpTimer = 0;
        }
        else if(jmpTimer <= coyoteTime)
        {
            jmpTimer += Time.deltaTime;
            if(jmpTimer >= coyoteTime)
            {
                canJmp = false;
            }
        }
        else if (canJmp==true)
        {
            canJmp = false;
        }
    }

    public void AFKmove()
    {
        //cmp_agent.speed = movSpd;
        if (Vector3.Distance(AFKtarget.transform.position, transform.position) > afkMaxDistance)
        {
            

            float xValue = 1;
            float zValue = 1;

            if (AFKtarget.transform.position.x > transform.position.x)
            {
                xValue = -1;
            }
            if (AFKtarget.transform.position.z > transform.position.z)
            {
                zValue = -1;
            }

            if(cmp_agent.enabled)
            {
                cmp_agent.enabled = false;
                gameObject.transform.position = new Vector3(AFKtarget.position.x + (afkMinDistance/2 * xValue), AFKtarget.position.y, AFKtarget.position.z + (afkMinDistance/2 * zValue));
                cmp_agent.enabled = true;
            }

        }

        if (Vector3.Distance(AFKtarget.transform.position, transform.position) > afkMinDistance)
        {
            float xValue = 1;
            float zValue = 1;

            if (AFKtarget.transform.position.x > transform.position.x)
            {
                xValue = -1;
            }
            if (AFKtarget.transform.position.z > transform.position.z)
            {
                zValue = -1;
            }


            Vector3 targ = new Vector3(AFKtarget.position.x + ((afkMinDistance /2) - (afkMinDistance/5) * xValue), transform.position.y, AFKtarget.position.z + ((afkMinDistance / 2) - (afkMinDistance / 5) * zValue));
            if (cmp_agent.enabled)
            {
                cmp_agent.destination = targ;
            }
        }
        
        StartCoroutine(AFKjump());
    }

    private IEnumerator AFKjump()
    {
        //cmp_agent.autoTraverseOffMeshLink = false;
        //cmp_agent.
        if (cmp_agent.isOnOffMeshLink)
        {
            
            yield return StartCoroutine(JumpAFK(cmp_agent, 7.5f, 1.5f));
            cmp_agent.enabled = true;
            //cmp_agent.CompleteOffMeshLink();

            //cmp_agent.CompleteOffMeshLink();
            //cmp_agent.updateRotation = true;
        }
        yield return null;

    }

    IEnumerator JumpAFK(NavMeshAgent agnt, float heigth, float duration)
    {
        OffMeshLinkData meshData = agnt.currentOffMeshLinkData;
        Vector3 strPos = agnt.transform.position;
        Vector3 endPos = meshData.endPos;

        float time = 0.0f;

        while(time <= 1.0f)
        {
            float upDist = heigth * (time - time * time);
            agnt.enabled = false;
            time += Time.deltaTime / duration;
            if (Vector3.Distance(agnt.transform.position, endPos + new Vector3(0, agnt.baseOffset, 0)) <= 0.2f)
            {
                agnt.gameObject.transform.position = endPos + new Vector3(0, agnt.baseOffset, 0);
                //cmp_agent.CompleteOffMeshLink();
                yield return null;
            }
            else
            {
                agnt.gameObject.transform.position = Vector3.Lerp(strPos, endPos + new Vector3(0, agnt.baseOffset, 0), time) + upDist * Vector3.up;
                yield return null;
            }
            
        }
        //cmp_agent.CompleteOffMeshLink();
    }

    public virtual void Die()
    {
        gameObject.SetActive(false);
    }
    
    public void pickUp(GameObject pickObj)
    {

        if(pickObj.GetComponent<Pickeable>() && pickObj!=actualPick && pickObj!=befPick)
        {
            if(actualPick!=null)
            {
                Drop();
            }
            actualPick = pickObj;
            Collider[] tmp1 = gameObject.GetComponents<Collider>();
            Collider[] tmp2 = pickObj.GetComponents<Collider>();
            for (int i = 0; i < tmp1.Length; i++)
            {
                for(int e = 0; e < tmp2.Length; e++)
                {
                    Physics.IgnoreCollision(tmp1[i], tmp2[e], true);
                    //Debug.Log(tmp1[i] + " " + tmp2[e]);
                }
            }
            actualPick.GetComponent<Pickeable>().Picked(grabPoint);

        }
    }

    public void Drop()
    {
        if (actualPick != null && actualPick.GetComponent<Pickeable>())
        {
            if(actualPick.GetComponent<Pickeable>().grabPick == grabPoint)
            {
                actualPick.GetComponent<Pickeable>().Droped();
            }
            
            befPick = actualPick;
            Collider[] tmp1 = gameObject.GetComponents<Collider>();
            Collider[] tmp2 = actualPick.GetComponents<Collider>();
            for (int i = 0; i < tmp1.Length; i++)
            {
                for (int e = 0; e < tmp2.Length; e++)
                {
                    Physics.IgnoreCollision(tmp1[i], tmp2[e], false);
                  
                    //Debug.Log(tmp1[i] + " " + tmp2[e]);
                }
            }

        }
        actualPick = null;
    }

    private void BeforPickTimer()
    {
        if(befPick != null)
        {
            befPckTimer += Time.deltaTime;
            if(befPckTimer>=1)
            {
                befPckTimer = 0;
                befPick = null;
            }
        }
    }
}
