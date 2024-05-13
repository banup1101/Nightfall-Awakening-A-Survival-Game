using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PistolController : MonoBehaviour
{
    public float range = 100f;  // Maximum range of the gun
    public Camera cam;       // Reference to the FPS camera

    // Update is called once per frame
    private InputAction fireAction;

    private void Awake()
    {
        // Create an InputAction for firing
        fireAction = new InputAction("Fire", binding: "<Mouse>/leftButton");
        fireAction.performed += _ => Shoot();
        fireAction.Enable();
    }

    private void Shoot()
    {
        Debug.Log("Pew Pew!");
        // Add your shooting logic here
    }

    private void OnDestroy()
    {
        // Don't forget to disable and dispose of your actions
        fireAction.Disable();
        fireAction.Dispose();
    }
}
