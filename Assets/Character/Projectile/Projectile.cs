using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 16f;
    SpriteRenderer sprite;
    PlayerShooting player;
    public int direction;
    public bool charged;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerShooting>();
    }

    void Update()
    {
       transform.Translate(new Vector2(speed * Time.deltaTime * direction, 0)); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SpriteRenderer otherSprite = other.GetComponent<SpriteRenderer>();
        if (other.gameObject.tag == "Gray")
        {
            if (otherSprite.color != sprite.color)
            {
                other.isTrigger = false;
                otherSprite.color = sprite.color;
                player.projectileLaunched = false;
            }
            else
            {
                other.isTrigger = true;
                otherSprite.color = Color.gray;
            }
            Destroy(this.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "GameArea")
        {
            player.projectileLaunched = false;
            Destroy(this.gameObject);
        }
    }

}
