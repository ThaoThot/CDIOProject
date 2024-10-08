using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // cập nhật thanh máu nếu có UI

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  // Sức khỏe tối đa của player
    private int currentHealth;   // Sức khỏe hiện tại của player
    public Slider healthBar;     // Thanh máu UI 

    private Animator anim;       // Animator của player

    void Start() 
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage, current health: " + currentHealth);

        
        if (healthBar != null)       // Cập nhật thanh máu 
        {
            healthBar.value = currentHealth;
        }

        anim.SetTrigger("Hurt");    // Phát hoạt ảnh bị thương

        if (currentHealth <= 0)
        {
            Die();  // Gọi phương thức chết khi máu về 0
        }
    }

   
    void Die()      // Phương thức xử lý khi player chết
    {
        Debug.Log("Player died!");
        anim.SetTrigger("Die");     // Kích hoạt hoạt ảnh chết
    }

                    // Phương thức để hồi máu
                    // public void Heal(int amount)
                    // {
                    //     if (isDead) return;

                    //     currentHealth += amount;// hồi
                    //     if (currentHealth > maxHealth)
                    //     {
                    //         currentHealth = maxHealth;
                    //     }

                    //     // Cập nhật thanh máu nếu có
                    //     if (healthBar != null)
                    //     {
                    //         healthBar.value = currentHealth;
                    //     }

                    //     Debug.Log("Player healed, current health: " + currentHealth);
                    // }

    
}
