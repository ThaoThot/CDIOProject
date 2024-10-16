using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int keyCount = 0;
    public Text keyText;
    public LoadNextLevel nextLevel;
    
    public void AddKey()
    {
        keyCount++;  // Tăng số lượng chìa khóa lên 1
        Debug.Log("Chìa khóa hiện có: " + keyCount);  // In ra số lượng chìa khóa hiện tại
        nextLevel.hasKey = true;
        UpdateKeyText(); 
    }

    private void UpdateKeyText(){
        if(keyText != null){
            keyText.text = keyCount.ToString();
        }
    }
}