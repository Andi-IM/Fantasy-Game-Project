using System;
using Andi_Scripts;
using UnityEditor;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public Item item;
    private bool playerDetect;
    
    // Detect trigger with player
    private void OnTriggerEnter2D(Collider2D col)
    {
        // If we trigger the player enable playerDetect and show indicator
        if (col.CompareTag("Player"))
        {
            playerDetect = true;
            item.ToggleIndicator(playerDetect);
        }
    }
    
    // Player away from trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        // if we lost trigger with the player disable playerDetect and hide indicator
        if (other.CompareTag("Player"))
        {
            playerDetect = false;
            item.ToggleIndicator(playerDetect);
        }
    }
    
    // While detect if we interact to start
    private void Update()
    {
        if (playerDetect) // && Input.GetKeyDown(KeyCode.E) )
        {
            // Start Some Action
        }
    }
}