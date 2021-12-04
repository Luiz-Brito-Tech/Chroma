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

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        SetUpProjectile();
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if(canShoot is true)
        {
            if (Input.GetMouseButtonDown(0) && projectileLaunched is false)
            {
                projectileSprite.color = sprite.color;
                Instantiate(projectileObj.gameObject, new Vector2(hand.position.x, hand.position.y), Quaternion.identity);
                projectileLaunched = true;
            }
        }
    }

    void SetUpProjectile()
    {
        projectileObj = projectile;
        projectileSprite = projectileObj.gameObject.GetComponent<SpriteRenderer>();
    }
}
