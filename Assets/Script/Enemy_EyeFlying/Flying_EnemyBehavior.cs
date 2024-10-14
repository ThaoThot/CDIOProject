using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying_EnemyBehavior : MonoBehaviour
{
    #region Public

    public float attackDistance;    // Khoảng cách tối thiểu để tấn công
    public float moveSpeed;
    public float dashSpeed;         // Tốc độ lao tới
    public float explosionRadius;   // Bán kính vụ nổ

    public Transform leftLimit;     // Giới hạn trái
    public Transform rightLimit;    // Giới hạn phải
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea;  // Khu vực kích hoạt nổ

    #endregion

    #region Private

    private Animator anim;
    private float distance;         // Lưu trữ khoảng cách giữa kẻ thù và người chơi
    private bool dashing;           // Trạng thái đang lao tới
    private float intTimer;

    #endregion

    void Awake()
    {
        SelectNewTarget();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!dashing) 
        {
            Move();
        }

        if (!InsideOfLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Explode"))
        {
            SelectNewTarget();
        }

        if (inRange && !dashing)
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
        }
        else if (attackDistance >= distance)
        {
            DashTowardsTarget();
        }
    }

    void Move()
    {
        Vector2 targetPosition = new Vector2(target.position.x, target.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void DashTowardsTarget()
    {
        anim.SetBool("dashing", true);   // Trigger dash animation

        // Lao tới người chơi
        Vector2 targetPosition = new Vector2(target.position.x, target.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, dashSpeed * Time.deltaTime);

        // Kiểm tra khoảng cách đến mục tiêu, khi đến gần sẽ thực hiện nổ
        if (distance <= explosionRadius)
        {
            Explode();  // Thực hiện hiệu ứng nổ khi đến gần người chơi
        }
    }

    void Explode()
    {  
        anim.SetTrigger("Explode");  //boom
        Debug.Log("đã nổ!!");

        // Sau khi nổ, kẻ thù biến mất
        Destroy(gameObject, 0.68f);
    }

    void StopAttack()
    { 
        dashing = false; 
        anim.SetBool("dashing", false);  // Dừng animation dash
    }

    private bool InsideOfLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    public void SelectNewTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

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
