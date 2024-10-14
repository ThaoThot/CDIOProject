using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour
{
   
public int healAmount = 20; // Lượng máu mà vật phẩm sẽ hồi

private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
         PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.Heal(healAmount);  // Gọi phương thức hồi máu trong PlayerHealth
            Destroy(gameObject);            // Hủy vật phẩm sau khi nhặt
        }
    }
}

}
