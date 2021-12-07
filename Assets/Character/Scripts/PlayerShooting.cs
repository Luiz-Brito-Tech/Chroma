using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform hand;
    public Projectile projectile;
    public bool projectileLaunched = false;
    public bool canShoot = false;
    [SerializeField] private bool projectileCharged = false;
    [SerializeField] private bool charging = false;
    SpriteRenderer sprite;
    public Projectile projectileObj;
    SpriteRenderer projectileSprite;
    private Animator anim;
    private Rigidbody2D body;
    private PlayerMovement playerMovement;
    [SerializeField] private ParticleSystem particleSystem;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        SetUpProjectile();
    }

    void Update()
    {
        Shoot();
        particleSystem.startColor = sprite.color;
    }

    void Shoot()
    {
        if(canShoot is true && projectileLaunched is false)
        {
            SetUpProjectile();
            if (Input.GetMouseButton(0) && playerMovement.onMovingPlatform is true)
            {
                charging = true;
                StartCoroutine(WaitToCharge());
            }

            if (Input.GetMouseButtonUp(0))
            {
                charging = false;
                projectileSprite.color = sprite.color;      
                projectileLaunched = true;
                StartCoroutine(ShootEnum());
            }
        }
    }

    IEnumerator ShootEnum()
    {
        particleSystem.gameObject.SetActive(false);
        body.constraints = RigidbodyConstraints2D.FreezePosition;
        playerMovement.speed = 0f;
        anim.SetBool("Shooting", true);
        anim.SetBool("isRunning", false);
        if (projectileCharged is true)
        {
            projectileObj.charged = true;
        }
        projectileCharged = false;
        Instantiate(projectileObj.gameObject, new Vector2(hand.position.x, hand.position.y + .25f), Quaternion.identity);
        yield return new WaitForSeconds(.3f);
        anim.SetBool("Shooting", false);
        body.constraints = RigidbodyConstraints2D.None;
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerMovement.speed = 5;
    }

    IEnumerator WaitToCharge()
    {
        yield return new WaitForSeconds(1f);
        if (charging)
        {
            particleSystem.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            projectileCharged = true;
        }
    }

    void SetUpProjectile()
    {
        projectileObj = projectile;
        projectileSprite = projectileObj.gameObject.GetComponent<SpriteRenderer>();
        projectileObj.charged = false;
    }
}
