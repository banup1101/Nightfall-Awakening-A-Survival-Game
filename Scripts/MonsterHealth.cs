using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    //public int points = 0;
    public int health = 100; // Default health
    public PlayerController playerController;

    public void Start()
    {
        // Find the PlayerController script in the scene
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Monster died");
            gameObject.SetActive(false);
            playerController.addPoints(100);
        }
    }
}
