using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private SpriteRenderer sprite;
    public PlayerShooting player;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerShooting>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SpriteRenderer otherSprite = other.GetComponent<SpriteRenderer>();
            otherSprite.color = sprite.color;
            player.canShoot = true;
            Destroy(this.gameObject);
        }
    }
}
