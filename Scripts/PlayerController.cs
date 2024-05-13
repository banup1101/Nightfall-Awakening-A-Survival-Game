using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Player's health
    public int playerHealth = 100;

    //player points
    public int points = 0;
    public int totalScore = 0;
    public bool doublePoints = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a GameObject tagged as "key"
        /*if (collision.gameObject.CompareTag("Key"))
        {
            // Output a message to the console
            Debug.Log("Player has obtained a key");

            // I will make it appear on the screen its just that UI is being dumb rn

            collision.gameObject.SetActive(false); // Disable the key after player gets it
        } */

        // Check if the collision is with a GameObject tagged as "Monster"
        if (collision.gameObject.CompareTag("Monster"))
        {
            // Reduce player's health
            playerHealth -= 10; // Decrease health by 10 (adjust as needed)

            // Output a message to the console
            Debug.Log("Player has collided with a Monster. Player's health decreased to: " + playerHealth);

            if (playerHealth == 0)
            {
                Debug.Log("Game Over");
                gameObject.SetActive(false);

                // do UI stuff here
            }
        }

        //check if monster projectile hits player
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Reduce player's health
            playerHealth -= 10; // Decrease health by 10 (adjust as needed)

            // Output a message to the console
            Debug.Log("Player has collided with monster projectile. Player's health decreased to: " + playerHealth);

            if (playerHealth == 0)
            {
                Debug.Log("Game Over");
                gameObject.SetActive(false);

                // do UI stuff here
            }
        }


    }




        public void addPoints(int addMe)
        {       
            if (doublePoints)
            {
                points += (2 * addMe);
                totalScore += (2 * addMe);
            }
            else
            {
                points += addMe;
                totalScore += addMe;
            }
        }

        public void subtractPoints(int subtractMe)
        {
            points -= subtractMe;
            if (points < 0)
            {
                points = 0;
            }
        }
}

