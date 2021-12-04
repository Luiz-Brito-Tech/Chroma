using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform hand;
    public Projectile projectile;
    public bool projectileLaunched = false;
    SpriteRenderer sprite;
    //Projectile
    Projectile projectileObj;
    SpriteRenderer projectileSprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && projectileLaunched is false)
        {
            projectileObj = projectile;
            projectileSprite = projectileObj.gameObject.GetComponent<SpriteRenderer>();
            projectileSprite.color = sprite.color;
            Instantiate(projectileObj.gameObject, new Vector2(hand.position.x, hand.position.y), Quaternion.identity);
            projectileLaunched = true;
        }
    }
}
