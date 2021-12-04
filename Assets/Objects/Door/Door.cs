using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private bool playerInRange = false;

    void Update()
    {
        if (playerInRange is true && Input.GetMouseButtonDown(1))
        {
            print("Level complete!");
        }
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D player)
    {
        playerInRange = false;
    }
}
