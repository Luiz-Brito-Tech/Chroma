using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    private Rigidbody2D body;
    public bool canJump = false;



    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        Jump();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float Xspeed = x * speed * Time.deltaTime;

        transform.Translate(new Vector2(Xspeed, 0));

    }

    void Jump()
    {
        if (canJump == true)
        {
            float force = jumpForce * Time.deltaTime;
            if (Input.GetKey(KeyCode.Space))
            {
                body.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        canJump = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        canJump = false;
    }

}