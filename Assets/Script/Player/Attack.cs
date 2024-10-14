using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage = 25; // Sát thương của mỗi đòn tấn công
    
    private void OnTriggerEnter2D(Collider2D col)
    {
         if (col.gameObject.CompareTag("enemy"))
        {
            Debug.Log("cac");
              EnemyHealth enemyHealth = col.transform.parent.GetComponent<EnemyHealth>();
            if (enemyHealth != null)    // Kiểm tra xem có đối tượng không
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }
}
