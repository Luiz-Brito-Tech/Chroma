using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    private Rigidbody2D body;
    public bool canJump = false;
    [SerializeField] private bool onLadderRange = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Climb();
    }

    void FixedUpdate()
    {
        Jump();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float xSpeed = x * speed * Time.deltaTime;

        transform.Translate(new Vector2(xSpeed, 0));

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

    void Climb()
    {
        if (onLadderRange is true)
        {
            canJump = false;
            float y = Input.GetAxisRaw("Vertical");
            float ySpeed = y * speed * Time.deltaTime;
            body.gravityScale = 0;

            transform.Translate(new Vector2(0, ySpeed));
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            onLadderRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            onLadderRange = false;
            body.gravityScale = 8;
            if (canJump is false)
            {
                canJump = true;
            }
        }
    }

}