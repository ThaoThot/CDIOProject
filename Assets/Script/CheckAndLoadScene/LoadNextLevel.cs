using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public float deLaySecond = 2;
    public string nameScene = "Level2";

    public bool hasKey = false;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && hasKey)
        {
            collision.gameObject.SetActive(false);

            ModeSelect();
        } else {
            Debug.Log("Hãy tìm chìa khóa!");
        }
    }

    public void  ModeSelect(){
        StartCoroutine(LoadAfterDelay());
    }

    IEnumerator LoadAfterDelay(){
        yield return new WaitForSeconds(deLaySecond);   
        SceneManager.LoadScene(nameScene); 
    }
   
}
