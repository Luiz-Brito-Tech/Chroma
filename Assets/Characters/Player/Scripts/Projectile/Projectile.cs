using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] PlayerShooting player;

    void Update()
    {
        player = FindObjectOfType<PlayerShooting>();
        Fly();
        DestroyOnClick();
    }

    void Fly()
    {
        transform.Translate(new Vector2(speed * Time.deltaTime, 0));
    }

    void DestroyOnClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            player.projectileLaunched = false;
            Destroy(this.gameObject);
        }
    }
}
