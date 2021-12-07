using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    [SerializeField] float jumpForce;
    private Rigidbody2D body;
    public bool canJump = false;
    [SerializeField] private bool onLadderRange = false;
    [SerializeField] private bool onMovingPlatform = false;
    private SpriteRenderer sprite;
    private PlayerShooting playerShooting;
    private Animator anim;
    [SerializeField] private Transform deathMark;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        playerShooting = GetComponent<PlayerShooting>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        GameFunctions();
    }

    void FixedUpdate()
    {
        Jump();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float xSpeed = x * speed * Time.deltaTime;
        if(x > 0)
        {
            sprite.flipX = false;
            playerShooting.projectileObj.direction = 1;
            anim.SetBool("isRunning", true);
        }
        else if(x < 0)
        {
            playerShooting.projectileObj.direction = -1;
            sprite.flipX = true;
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }  
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

    void MovePlatform()
    {
        if (onMovingPlatform is true)
        {
            float y = Input.GetAxisRaw("Vertical");
            float ySpeed = y * speed * Time.deltaTime;
            GameObject platform = GameObject.FindWithTag("MovingPlatform");
            transform.Translate(new Vector2(0, ySpeed));
            platform.transform.Translate(new Vector2(0, ySpeed));
        }
    }

    void Climb()
    {
        if (onLadderRange is true && FindObjectOfType<Ladder>().ladderActivated is true)
        {
            float y = Input.GetAxisRaw("Vertical");
            float ySpeed = y * speed * Time.deltaTime;
            if(y != 0)
            {
                anim.SetBool("isRlyClimbing", true);
            }
            else
            {
                anim.SetBool("isRlyClimbing", false);
            }  
            transform.Translate(new Vector2(0, ySpeed));
        }
    }

    void DetectFall()
    {
        if (transform.position.y < deathMark.position.y)
        {
            DeathOrRestart();
        }
    }

    void SceneInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DeathOrRestart();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform" || other.gameObject.tag == "Black" || other.gameObject.tag == "MovingPlatform")
        {
            canJump = true;
            if (other.gameObject.tag == "MovingPlatform")
            {
                onMovingPlatform = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform" || other.gameObject.tag == "Black" || 
        other.gameObject.tag ==  "MovingPlatform" || onLadderRange is false)
        {
            canJump = false;
            onMovingPlatform = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            if (other.GetComponent<Ladder>().ladderActivated is true)
            {
                canJump = false;
                onLadderRange = true;
                body.gravityScale = 0;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            if (other.GetComponent<Ladder>().ladderActivated is true)
            {
                canJump = false;
                onLadderRange = true;
                body.gravityScale = 0;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            onLadderRange = false;
            body.gravityScale = 8;
        }
    }

    void DeathOrRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void GameFunctions()
    {
        Move();
        Climb();
        MovePlatform();
        DetectFall();
        SceneInput();
        anim.SetBool("isJumping", !canJump);
        anim.SetBool("isClimbing", onLadderRange);
    }

}