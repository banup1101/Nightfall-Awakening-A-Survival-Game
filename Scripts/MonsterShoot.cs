using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootingRate = 1f;
    public float projectileSpeed = 10f; // Speed of the projectile
    public Transform playerTransform; // Reference to the player's transform

    private float nextShootTime;

    public float forwardOffset = 1f; // Forward offset from the monster
    public float upOffset = 1f; // Up offset from the monster


    void Start()
    {

    }

    void Update()
    {
        if (Time.time > nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + shootingRate;
        }
    }

    void Shoot()
    {
        if (playerTransform == null)
            return;

        // Calculate the offset position relative to the monster
        Vector3 offsetPosition = transform.position + transform.forward * forwardOffset + transform.up * upOffset;

        //Direction Towards the Player
        Vector3 directionToPlayer = (playerTransform.position - offsetPosition).normalized;

        // Instantiate the projectile at the offset position so the monster doesnt end up walking into and mess up its velocity like a goofball
        GameObject projectile = Instantiate(projectilePrefab, offsetPosition, Quaternion.identity);

        //Sets velocity of the projectile towards the player
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        if (projectileRb != null)
        {
            projectileRb.velocity = directionToPlayer * projectileSpeed;
        }

    }
}