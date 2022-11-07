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
        Debug.Log("Collicion con la cura o mina");
        // Collect all the colliders in a sphere from the shell's current position to a radius of the explosion radius.
        // Go through all the colliders...
        if (other.CompareTag("Player"))
        { // ... and find their rigidbody.

            Debug.Log("Cambiando la vida del jugador");
            TankHealth targetHealth = other.GetComponent<TankHealth>();
            // If there is no TankHealth script attached to the gameobject, go on to the next collider.


            // Calculate the amount of damage the target should take based on it's distance from the shell.

            // Deal this damage to the tank.
            targetHealth.TakeDamage(healthMod);
            Destroy(gameObject);
        }
    }
}
