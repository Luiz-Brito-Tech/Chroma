using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Projectile projectile;
    private SpriteRenderer sprite;

    void Start()
    {
        projectile = FindObjectOfType<Projectile>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SpriteRenderer otherSprite = other.GetComponent<SpriteRenderer>();
        if (other.gameObject.tag == "Projectile")
        {
            projectile = FindObjectOfType<Projectile>();
            if (projectile.charged is true)
            {
                if (sprite.color == otherSprite.color)
                {
                    GameObject[] greys = GameObject.FindGameObjectsWithTag("Grey");
                    foreach(var grey in greys)
                    {
                        grey.GetComponent<SpriteRenderer>().color = sprite.color;
                    }
                }
            }
        }
    }
}
