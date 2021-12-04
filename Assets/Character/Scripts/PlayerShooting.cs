using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform hand;
    public Projectile projectile;
    public bool projectileLaunched = false;

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && projectileLaunched is false)
        {
            Projectile projectileObj = projectile;
            Instantiate(projectileObj.gameObject, new Vector2(hand.position.x, hand.position.y), Quaternion.identity);
            projectileLaunched = true;
        }
    }
}
