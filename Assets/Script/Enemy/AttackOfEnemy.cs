using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOfEnemy : MonoBehaviour
{
    public int enemyDamage = 25; // Sát thương của mỗi đòn tấn công
    public PlayerHealth playerHealth;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("cac");
            playerHealth = col.transform.GetComponent<PlayerHealth>();
            if (playerHealth != null)    // Kiểm tra xem có đối tượng không
            {
                playerHealth.TakeDamage(enemyDamage);
            }
        }
    }
}
