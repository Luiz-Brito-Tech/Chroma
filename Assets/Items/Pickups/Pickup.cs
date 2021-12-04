using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SpriteRenderer otherSprite = other.GetComponent<SpriteRenderer>();
            otherSprite.color = sprite.color;
            Destroy(this.gameObject);
        }
    }
}
