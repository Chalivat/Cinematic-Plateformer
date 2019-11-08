using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Character_Control : MonoBehaviour
{
    private Rigidbody rb;
    [Header("Movement")]
    public float Speed;
    public float maxSpeed;
    private Vector3 direction;
    private bool isGrounded;
    public float groundedDrag;
    public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2))
        {
            isGrounded = true;
            anim.SetBool("IsGrounded",true);
            Debug.Log(hit.collider.gameObject);
        }
        else
        {
            isGrounded = false;
            anim.SetBool("IsGrounded", false);
        }
        float x = Input.GetAxis("Horizontal");
        direction = new Vector3(x,0,0);
        if (rb.velocity.magnitude <= maxSpeed)
        {
            if (isGrounded)
            {
                Quaternion newRot = Quaternion.LookRotation(hit.transform.forward, hit.normal);
                direction = newRot * direction;
                //rb.AddForce(direction * Speed,ForceMode.VelocityChange);
                rb.velocity = new Vector3(direction.x * Speed * Time.fixedDeltaTime, rb.velocity.y, rb.velocity.z);
            }
            else rb.AddForce(direction * Speed / 100, ForceMode.VelocityChange);
        }
        else if (x > 0)
        {
            rb.velocity = new Vector3(direction.x * maxSpeed, rb.velocity.y, rb.velocity.z);
        }
        else if(x < 0)
        {
            rb.velocity = new Vector3(direction.x * maxSpeed, rb.velocity.y, rb.velocity.z);
        }

        
        
    }


    void Rotate()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 lookDirection = transform.right;
        if (x > 0.1f)
        {
            lookDirection = Vector3.forward;
        }
        else if (x < 0.1f)
        {
            lookDirection = Vector3.back;
        }
        else
        {
            
        }
        Quaternion newRot = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, 0.5f);
    }

}
