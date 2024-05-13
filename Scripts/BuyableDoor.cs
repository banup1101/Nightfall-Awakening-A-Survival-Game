using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyableDoor : MonoBehaviour
{
    public int doorPrice = 300; // The price of the door
    public bool purchased = false; // Flag indicating whether the door is purchased

    // Reference to the PlayerController script
    public PlayerController playerController;

    private void Start()
    {
        // Find the PlayerController script in the scene
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the door is purchased and set it inactive if so
        if (purchased)
        {
            gameObject.SetActive(false);
        }

        // Check for player input to interact with the door
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    // Method to handle interaction with the door
    public void Interact()
    {
        // Check if the player has enough points to purchase the door
        if (playerController.points >= doorPrice)
        {
            // Subtract the door price from the player's points
            playerController.subtractPoints(doorPrice);

            // Set the door as purchased
            purchased = true;
        }
        else
        {
            Debug.Log("Not enough points to purchase the door.");
            // Optionally, display a message to the player indicating they don't have enough points
        }
    }
}