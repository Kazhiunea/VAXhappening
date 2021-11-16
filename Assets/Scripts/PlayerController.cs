using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * Speed, body.velocity.y);

        if(horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1 ,1);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, Speed);
        }



    }


}
