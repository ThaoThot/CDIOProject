using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    public Transform rayCast;
    public LayerMask rayCastMask;
    public float rayCastLength;
    public float attackDistance;    // Khoảng cách tối thiểu để tấn công
    public float moveSpeed;
    public float timer;     // Thời gian hồi chiêu

    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;     //lưu trữ khoảng cách giữa kẻ thù và người chơi
    private bool attackMode;
    private bool inRange;       // kiểm tra xem có đối tượng người chơi trong phạm vi không
    private bool cooling;       // kiểm tra làm mát sau tấn công
    private float intTimer;


    void Awake()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, rayCastMask);
            RayCastDebugger();
        }
        // Khi phát hiện người chơi
        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }

        if (inRange == false)
        {
            anim.SetBool("canWalk", false);
            StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.gameObject;
            inRange = true;
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance > attackDistance)
        {
            Move();
            StopAttack();
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
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);

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
        timer -= Time.deltaTime; 

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    void RayCastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }
    public void TriggerCooling()
    {
        cooling = true;
    }  

}
