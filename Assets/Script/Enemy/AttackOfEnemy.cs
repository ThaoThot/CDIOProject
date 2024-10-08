using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOfEnemy : MonoBehaviour
{
    public int enemyDamage = 25; // Sát thương của mỗi đòn tấn công
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("mlem");
            PlayerHealth playerHealth = collision.transform.parent.GetComponent<PlayerHealth>();
            if (playerHealth != null)    // Kiểm tra xem có đối tượng không
            {
                playerHealth.TakeDamage(enemyDamage);
            }
        }
    }
}
