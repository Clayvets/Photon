using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineHealth : MonoBehaviour
{
    [SerializeField]
    private float healthMod;
    [SerializeField]
    private float m_MaxLifeTime = 10;
    // Start is called before the first frame update

    private void Start()
    {
        Destroy (gameObject, m_MaxLifeTime);
    }
    private void OnTriggerEnter (Collider other)
    {
        // Collect all the colliders in a sphere from the shell's current position to a radius of the explosion radius.
        // Go through all the colliders...
        if (other.GetComponent<TankHealth>())
        { // ... and find their rigidbody.
            Rigidbody targetRigidbody = GetComponent<Rigidbody>();

            // If they don't have a rigidbody, go on to the next collider.
            // Add an explosion force.

            // Find the TankHealth script associated with the rigidbody.
            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

            // If there is no TankHealth script attached to the gameobject, go on to the next collider.


            // Calculate the amount of damage the target should take based on it's distance from the shell.

            // Deal this damage to the tank.
            targetHealth.TakeDamage(healthMod);
            Destroy(gameObject);
        }
    }
}
