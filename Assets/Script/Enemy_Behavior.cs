using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    #region Public
    public int maxHealth = 100; // sức khỏe tối đa

    public float attackDistance;    // Khoảng cách tối thiểu để tấn công
    public float moveSpeed;
    public float timer;     // Thời gian hồi chiêu

    public Transform leftLimit;     //giới hạn trái
    public Transform rightLimit;    //giới hạn phải
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;
    public GameObject hotZone;
    public GameObject triggerAera;
    #endregion

    #region Private
    private int currentHealth;  // Sức khởe hiện tại

    private Animator anim;
    private float distance;     //lưu trữ khoảng cách giữa kẻ thù và người chơi
    private bool attackMode;
       
    private bool cooling;       // kiểm tra làm mát sau tấn công
    private float intTimer;
    #endregion

    void Start()
    {
        currentHealth = maxHealth; 
    }
        
    void Awake()
    {
        SelectTarget();
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy took damage, current health: " + currentHealth);
        anim.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

        void Die()
    {
        Debug.Log("Enemy died!");
        anim.SetBool("IsDead", true);
        Destroy(gameObject,2f);
    }

    void Update()
    {   if(!attackMode)
        {
            Move();
        }

        if(!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            SelectTarget();
        }

        if (inRange)
        {
            EnemyLogic();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            StopAttack();
            Debug.Log("ra khỏi phạm vi tấn công");
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
     
    void Attack()
    {
        timer = intTimer;   //đặt lại thời gian khi người chơi vào phạm vi tấn công
        attackMode = true;  // kiểm tra xem có thể tấn công hay không

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }

    void Cooldown()
    {
        if (cooling)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                cooling = false;
                timer = intTimer;
            }
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    public void TriggerCooling()
    {
        cooling = true;
        timer = intTimer;// Đặt lại timer khi bắt đầu cooldown
    }  

    private bool InsideofLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x; 
    }

    public void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position,  rightLimit.position);
       
        target = (distanceToLeft > distanceToRight) ? leftLimit : rightLimit;
        Flip();
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y = transform.position.x > target.position.x ? 180f : 0f;
        transform.eulerAngles = rotation;
    }
}
