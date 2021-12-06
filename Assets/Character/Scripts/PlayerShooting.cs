using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform hand;
    public Projectile projectile;
    public bool projectileLaunched = false;
    public bool canShoot = false;
    SpriteRenderer sprite;
    public Projectile projectileObj;
    SpriteRenderer projectileSprite;
    private Animator anim;
    private Rigidbody2D body;
    private PlayerMovement playerMovement;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        SetUpProjectile();
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if(canShoot is true)
        {
            if (Input.GetMouseButtonUp(0) && projectileLaunched is false)
            {
                projectileSprite.color = sprite.color;      
                projectileLaunched = true;
                StartCoroutine(ShootEnum());
            }
        }
    }

    IEnumerator ShootEnum()
    {
        body.constraints = RigidbodyConstraints2D.FreezePosition;
        playerMovement.speed = 0f;
        anim.SetBool("Shooting", true);
        anim.SetBool("isRunning", false);
        Instantiate(projectileObj.gameObject, new Vector2(hand.position.x, hand.position.y + .25f), Quaternion.identity);
        yield return new WaitForSeconds(.3f);
        anim.SetBool("Shooting", false);
        body.constraints = RigidbodyConstraints2D.None;
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerMovement.speed = 5;
    }

    void SetUpProjectile()
    {
        projectileObj = projectile;
        projectileSprite = projectileObj.gameObject.GetComponent<SpriteRenderer>();
    }
}
