using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("sisällä ollaan");

        if (other.tag == "Player")
        {
            PlayerHealthController.instance.DealDamage(100);
            Debug.Log("Kuole paska");
        }
    }
}
