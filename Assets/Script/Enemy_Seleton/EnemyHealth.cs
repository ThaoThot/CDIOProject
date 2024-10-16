using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;  // Sức khỏe tối đa
    public GameObject healthItemPrefab;  //prefab item hồi máu
    public Transform dropPosition;  // Vị trí xuất hiện item

    private int currentHealth;   // Sức khỏe hiện tại
    private Animator anim;
    private bool hasDropItem = false;

    void Start()
    {
        anim = GetComponent<Animator>();  // Khởi tạo Animator
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy nhận dame"+damage+" máu enemy hiện tại: " + currentHealth);
        anim.SetTrigger("Hurt");  // Phát hoạt ảnh bị thương

        if (currentHealth <= 0)
        {
            Die();  // Gọi phương thức Die khi máu về 0
           
        }
    }

    void Die()
    {
    Debug.Log("Enemy chết, IsDead  true");
    anim.SetTrigger("IsDead");  // Kích hoạt hoạt ảnh chết

    if(!hasDropItem){
    Debug.Log("gọi item");
    Instantiate(healthItemPrefab, dropPosition.position, Quaternion.identity);  
    hasDropItem = true;
    }
    
    Destroy(gameObject, 0.75f);  // Hủy đối tượng sau 0.75 giây
    }
}
