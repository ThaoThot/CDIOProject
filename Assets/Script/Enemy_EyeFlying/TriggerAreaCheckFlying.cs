using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAeraCheckFlying : MonoBehaviour
{
    private Flying_EnemyBehavior enemyParent;

    private void Awake()
    {
        enemyParent = GetComponentInParent<Flying_EnemyBehavior>();

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        gameObject.SetActive(false);    
        enemyParent.target =collider.transform;
        enemyParent.inRange = true;
        enemyParent.hotZone.SetActive(true);    
    }
}
