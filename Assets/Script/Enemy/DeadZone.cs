using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public int enemyDamage = 100; 
    public PlayerHealth playerHealth;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("gây sát thương");
            playerHealth = col.transform.GetComponent<PlayerHealth>();
            if (playerHealth != null)    // Kiểm tra xem có đối tượng không
            {
                playerHealth.TakeDamage(enemyDamage);
            }
        }
    }
}
