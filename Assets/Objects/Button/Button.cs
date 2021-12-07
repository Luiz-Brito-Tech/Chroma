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
            if (other.GetComponent<Projectile>().charged is true)
            {
                GameObject[] grays = GameObject.FindGameObjectsWithTag("Gray");
                foreach(GameObject gray in grays)
                {
                    gray.GetComponent<SpriteRenderer>().color = otherSprite.color;
                }
                GameObject[] plats = GameObject.FindGameObjectsWithTag("Platform");
                foreach(GameObject plat in plats)
                {
                    plat.GetComponent<SpriteRenderer>().color = otherSprite.color;
                    plat.GetComponent<Collider2D>().isTrigger = false;
                }
            }
        }
    }
}
