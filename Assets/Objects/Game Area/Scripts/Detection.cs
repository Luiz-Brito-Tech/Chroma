using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{

    [SerializeField] PlayerShooting player;

    void OnTriggerExit2D(Collider2D other)
    {
        player = FindObjectOfType<PlayerShooting>();
        if (other.gameObject.tag == "Projectile")
        {
            player.projectileLaunched = false;
            Destroy(other.gameObject);
        }
    }
}
