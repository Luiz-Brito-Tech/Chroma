using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    SpriteRenderer sprite;
    PlayerShooting player;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerShooting>();
    }

    void Update()
    {
       transform.Translate(new Vector2(speed * Time.deltaTime, 0)); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SpriteRenderer otherSprite = other.GetComponent<SpriteRenderer>();
        if (other.gameObject.tag == "Gray")
        {
            otherSprite.color = sprite.color;
            player.projectileLaunched = false;
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