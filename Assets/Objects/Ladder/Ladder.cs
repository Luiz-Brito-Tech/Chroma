using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private bool playerInRange = false;
    [SerializeField] private bool activated = false;
    private int uses = 0;

    void Update()
    {
        Rise();
    }

    void Rise()
    {
        if (playerInRange is true && Input.GetMouseButtonDown(1) && uses < 1 && activated is false)
        {
            uses++;
            activated = true;
            transform.Translate(new Vector2(0, 200 * Time.deltaTime));
        }
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

}
