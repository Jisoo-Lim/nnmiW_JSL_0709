using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Transform tr;
    private Animator animator;
    private Rigidbody rigidbody;

    public float moveSpeed = 10.0f;
    public float turnSpeed = 80.0f;
    public float JumpPower = 5.0f;

    // 델리게이트 선언
    public delegate void PlayerDieHandler();
    // 이벤트 선언
    public static event PlayerDieHandler OnPlayerDie;

    void Start()
    {
        tr = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDir = (Vector3.forward*v)+(Vector3.right*h);

        tr.Translate(moveDir.normalized*moveSpeed*Time.deltaTime);

        Animation(h,v);
    }

    void Animation(float h, float v)
    {
        if(v>= 0.1f)
        {
            // 전진 애니메이션
        }
        else if (v<=-0.1f)
        {
            // 후진 애니메이션
        }
        else if (h>=0.1f)
        {   
            // 오른쪽 이동 애니메이션
        }
        else if(h<=-0.1f)
        {
            // 왼쪽 이동 애니메이션
        }
        else
        {
            // Idle
        }
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        // 충돌한 Collider가 키보드이면 인벤토리에 저장
        if(coll.CompareTag("KEYBOARD"))
        {
        }
    }

    void PlayerDie()
    {
        // 플레이어 사망 이벤트 호출(발생)
        OnPlayerDie();
    }
}
