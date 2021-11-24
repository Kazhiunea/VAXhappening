using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Rigidbody2D body;
    private Animator animator;
    private bool grounded = true;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * Speed, body.velocity.y);

        if(horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.05f, 0.05f, 1);
        }else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.05f, 0.05f ,1);
        }

        if (Input.GetKey(KeyCode.Space) && grounded == true)
        {
            Jump();
            
        }

        //Seting the animation when running
        animator.SetBool("Running", horizontalInput != 0);
        animator.SetBool("Grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, Speed*3);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

}
