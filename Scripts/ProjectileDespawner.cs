using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDespawner : MonoBehaviour
{
    /*
     * This script despawns the projectiles that the monster shoots
     * Along with this if the monster projectile hits player it is destroyed
     */

    public float despawnTime = 3f; // time projectile despawns
    //public float projectileSpeed = 10f; // Speed of the projectile

    void Start()
    {
        // Destroy the projectile after 'lifetime' seconds
        Destroy(gameObject, despawnTime);
    }

    void Update()
    {
        // Move the projectile forward
        //transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // If collided with the player, delete the projectile
            Destroy(gameObject);
        }
    }
}
