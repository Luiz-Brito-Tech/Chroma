using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private bool playerInRange = false;
    public bool ladderActivated = false;
    private int uses = 0;
    [SerializeField] private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Rise();
    }

    void Rise()
    {
        if (playerInRange is true && Input.GetMouseButtonDown(1) && uses < 1 && ladderActivated is false)
        {
            uses++;
            ladderActivated = true;
            anim.SetBool("Activated", true);
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
