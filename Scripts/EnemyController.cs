using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public float speed = 20.0f;
	public float minDist = 1f;
	public Transform target;
	public GameObject loseText;

	public Camera playerCamera;
	public Color screenFlashColor = Color.red;
	public float screenFlashDuration = 0.25f;

	//public float health = 100.0f;


	// Use this for initialization
	void Start()
	{
		// if no target specified, assume the player
		if (target == null)
		{

			if (GameObject.FindWithTag("Player") != null)
			{
				target = GameObject.FindWithTag("Player").GetComponent<Transform>();
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (target == null)
			return;

		// face the target
		transform.LookAt(target);

		//get the distance between the chaser and the target
		float distance = Vector3.Distance(transform.position, target.position);

		if (distance > minDist)
			transform.position += transform.forward * speed * Time.deltaTime;
	}

	// Set the target of the chaser
	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.gameObject.SetActive(false);
			loseText.SetActive(true);

		}

	}

	private void OnCollisionEnter(Collision collision)
	{
		// Check if the collision is with the player
		if (collision.gameObject.CompareTag("Player"))
		{
			// Log to the console that the enemy has hit the player
			Debug.Log("Enemy has hit the player");

			// Trigger screen flash effect
			//StartCoroutine(ScreenFlash());
		}
	}
	/*
	private IEnumerator ScreenFlash()
	{
		Debug.Log("Starting screen flash coroutine");

		// Get the initial background color of the camera
		Color initialColor = playerCamera.backgroundColor;
		Debug.Log("Initial background color: " + initialColor);

		// Change the camera background color to the flash color
		playerCamera.backgroundColor = screenFlashColor;
		Debug.Log("Screen flash color: " + screenFlashColor);

		// Wait for the duration of the screen flash
		yield return new WaitForSeconds(screenFlashDuration);

		// Revert the camera background color back to its initial color
		playerCamera.backgroundColor = initialColor;
		Debug.Log("Reverted to initial background color: " + initialColor);
	} */
}
