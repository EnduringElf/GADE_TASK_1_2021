using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    private CharacterController controller;
    public Transform cam;
    public float walkspeed = 6f;
    public float SprintSpeed = 10f;
    public float turningspeed = 0.1f;
    public float Wgravity = -9.8f;
    public float jumpSpeed = 6f;
    public bool Isgrounded;
    
    

    float turnsmoothvelocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }
    private bool Grounded()
    {
        return controller.isGrounded;
    }
   
    // Update is called once per frame
    void Update()
    {
        Isgrounded = Grounded();
       
        float horizontal = Input.GetAxisRaw("Horizontal");
        float verticle = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(horizontal, 0, verticle).normalized;
        Vector3 jump = new Vector3(0f, jumpSpeed, 0f);
        Vector3 gravity = new Vector3(0f, Wgravity, 0f);
        if(Grounded() == false)
        {
            
            controller.Move(gravity * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
            controller.Move(jump * Time.deltaTime);
        }
        if(move.magnitude >= 0.1f)
        {
            float targetangle = Mathf.Atan2(move.x, move.z)*Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnsmoothvelocity, turningspeed);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            Vector3 moveDir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                controller.Move(moveDir * Time.deltaTime * SprintSpeed);
            }
            else
            {
                controller.Move(moveDir * Time.deltaTime * walkspeed);
            }
        }
        
    }
}
