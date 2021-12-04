using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    SpriteRenderer sprite;
    PlayerMovement player;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerMovement>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        SpriteRenderer otherSprite = other.gameObject.GetComponent<SpriteRenderer>();
        if (other.gameObject.tag != "Black")
        {
            if (otherSprite.color != sprite.color)
            {
                player.canJump = false;
                other.gameObject.GetComponent<Collider2D>().isTrigger = true;
            }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            other.isTrigger = false;
        }
    }
}
