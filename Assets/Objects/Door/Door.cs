using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    [SerializeField] private bool playerInRange = false;

    void Update()
    {
        if (playerInRange is true && Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("EndScreen");
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
