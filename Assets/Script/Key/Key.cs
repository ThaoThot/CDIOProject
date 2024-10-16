using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Inventory inventory;

    // Khi người chơi nhặt được chìa khóa
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  
        {
            Debug.Log("Nhặt Key");

            if (inventory != null)  
            {
                inventory.AddKey();  // Thêm chìa khóa 
            }
            else
            {
                Debug.LogError("Inventory chưa được gán cho Key!");
            }
            
            Destroy(gameObject);  
        }
    }

    void Start()
    {
        // Tìm đối tượng Inventory nếu chưa được gán trong Inspector
        if (inventory == null)
        {
            inventory = FindObjectOfType<Inventory>();  // Tự động tìm đối tượng Inventory
            if (inventory == null)
            {
                Debug.LogError("Không tìm thấy Inventory trong cảnh!");
            }
        }
    }
}
