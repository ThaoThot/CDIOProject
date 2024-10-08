using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int attackDamage = 25; // Sát thương của mỗi đòn tấn công
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("mlem");
            EnemyHealth enemyHealth = collision.transform.parent.GetComponent<EnemyHealth>();
            if (enemyHealth != null)    // Kiểm tra xem có đối tượng không
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }
}
