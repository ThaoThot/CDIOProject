using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int attackDamage = 25; // Sát thương của mỗi đòn tấn công

    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)    // Kiểm tra xem có đối tượng không
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }
}
