using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triger : MonoBehaviour
{
    private Enemy_Behavior enemyParent;

    private void Awake()
    {
        enemyParent = GetComponetInParent<Enemy_Behavior>();

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        gameObject.SetActive(false);    
        enemyParent.target =collider.transform;
        enemyParent.inRange = true;
        enemyParent.hotZone.SetActive(true);    
    }
}
