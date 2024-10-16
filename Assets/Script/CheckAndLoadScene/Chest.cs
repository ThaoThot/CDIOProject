using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Chest : MonoBehaviour
    {
        public Animator animator;
        public GameObject Key;
        public Transform KeyPosition;
        public Inventory inventory;

        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;
                animator.SetBool("IsOpened", isOpened);
            }
        }
        private bool isOpened;

        public void Open()
        {
            if (!isOpened)  
        {
            IsOpened = true;
            Debug.Log("Rương đã mở");
          
            GameObject key = Instantiate(Key, KeyPosition.position, Quaternion.identity);
            key.GetComponent<Key>().inventory = inventory; // liên kết với Inventory
        }
        }

        public void Close()
        {
            IsOpened = false;
            Debug.Log("rương đã đóng");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Open();
                
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Close();
            }
        }
    }

