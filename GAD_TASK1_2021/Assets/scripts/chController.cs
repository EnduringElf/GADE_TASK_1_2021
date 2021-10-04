using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using UnityEditor;
using UnityEngine;

public class chController : MonoBehaviour
{
    private Rigidbody rb;
    public float walk;
    public float walkLimit;
    public float sprintLimit;
    public float sprint;
    public float jump;
    public int speedMultiplyer = 1;
    public float turiningSpeed = 0.1f;
    public float turningspeed = 0.1f;
    public Transform cam;
    public float maxVelocity;
    private float sqrMaxVelocity;
    private SphereCollider spCollider;
    float turnsmoothvelocity;
    public GameObject groundcheck;
    private groundcheck Groundcheck;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.5f;
    




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        setMaxVelocity(maxVelocity);
        spCollider = GetComponent<SphereCollider>();
        Groundcheck = groundcheck.GetComponent<groundcheck>();
        
        
    }
    private void setMaxVelocity(float maxVelocity)
    {
        this.maxVelocity = maxVelocity;
        sqrMaxVelocity = maxVelocity * maxVelocity;
    }
    private void FixedUpdate()
    {
        if(rb.velocity.sqrMagnitude > sqrMaxVelocity)
        {
            rb.velocity = rb.velocity.normalized * (maxVelocity - 0.5f);
        }
    }
   
   
    // Update is called once per frame
    void Update()
    {
      
        Cursor.lockState = CursorLockMode.Confined;

        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Verticle = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(Horizontal * -1, 0, Verticle ).normalized;
        if(move.magnitude >= 0.1f)
        {
            float targetangle = Mathf.Atan2(move.z, move.x) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnsmoothvelocity, turningspeed);
            transform.rotation = Quaternion.Euler(0,angle, 0);
            Vector3 moveDir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.left;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                setMaxVelocity(maxVelocity + sprintLimit);
                rb.velocity += moveDir * Time.deltaTime * sprint * speedMultiplyer;
                
            }
            else
            {
                setMaxVelocity(maxVelocity + walkLimit);
                rb.velocity += moveDir * Time.deltaTime * walk * speedMultiplyer;
            }
            
        }
        //Debug.Log(Groundcheck.isGrounded);
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && Groundcheck.isGrounded)
        {
            //Debug.Log(jump);
            rb.velocity = Vector3.up * jump;
            Groundcheck.isGrounded = false;
        }



    }
            
        
    
}
