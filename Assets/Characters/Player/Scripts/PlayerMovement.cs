using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    private Rigidbody2D body;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
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
        float force = jumpForce * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }
    }

}
