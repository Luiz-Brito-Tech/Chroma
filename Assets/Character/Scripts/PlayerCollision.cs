using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        SpriteRenderer otherSprite = other.gameObject.GetComponent<SpriteRenderer>();
        if (other.gameObject.tag != "Black")
        {
            if (otherSprite.color != sprite.color)
            {
                other.gameObject.GetComponent<Collider2D>().isTrigger = true;
            }
        }

    }
}
