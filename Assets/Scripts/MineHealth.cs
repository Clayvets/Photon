using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MineHealth : MonoBehaviour
{
    [SerializeField]
    private float healthMod;
    [SerializeField]
    private float m_MaxLifeTime = 10;

    [FormerlySerializedAs("mineTank")] [FormerlySerializedAs("mainTank")] [SerializeField] private GameObject myTank;
    [SerializeField] private bool mina = false;

    private bool firstTriggerTank = false;
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
            if (!firstTriggerTank)
            {
                myTank = other.gameObject;
                firstTriggerTank = true;
            }
   
            Debug.Log("Cambiando la vida del jugador");
            Complete.TankHealth targetHealth = other.GetComponent<Complete.TankHealth>();
            // If there is no TankHealth script attached to the gameobject, go on to the next collider.


            // Calculate the amount of damage the target should take based on it's distance from the shell.

            
            // Deal this damage to the tank.
            if (mina)
            {
                if (myTank != other.gameObject)
                {
                    targetHealth.TakeDamage(healthMod);
                    Destroy(this.gameObject);
                }
            }
            else
            {
                targetHealth.TakeDamage(healthMod);
                Destroy(this.gameObject);
            }
         
        }
    }
}
