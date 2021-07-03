using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Transform tr;
    public Transform objPos;

    private Animator animator;
    private new Rigidbody rigidbody;
    private bool onStart;

    public float moveSpeed = 10.0f;
    public float turnSpeed = 150.0f;
    public float JumpPower = 5.0f;

    // 델리게이트 선언
    public delegate void PlayerDieHandler();
    // 이벤트 선언
    public static event PlayerDieHandler OnPlayerDie;

    void Awake()
    {
        tr = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>(); 
    }

    void Start()
    {
        onStart = false;
    }

    void Update()
    {
        if(!onStart)
        {
            Move();
            Jump();
        }

        Debug.DrawRay(tr.position, -tr.up *2.0f, Color.green);
        Debug.DrawRay(tr.position, tr.forward *0.8f, Color.blue);
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        tr.Translate(Vector3.forward*Time.deltaTime*moveSpeed*v);

        if(Input.GetKeyDown(KeyCode.A)||(Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            transform.Rotate(0,-90,0);
        }
        else if(Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0, 90, 0);
        }
        //tr.Rotate(Vector3.up * Time.deltaTime *turnSpeed*h);
   
        // Vector3 moveDir = (Vector3.forward*v)+(Vector3.right*h);
        // tr.Translate(moveDir.normalized*moveSpeed*Time.deltaTime);

        Animation(v, h);
    }

    void Animation(float v, float h)
    {
        if(v>=0.1f||v<=-0.1f||h>=0.1f||h<=-0.1f)
        {
            animator.SetBool("IsWalk", true);
        }
        else
        {
            animator.SetBool("IsWalk", false);
        }
        // if(v>= 0.1f)
        // {
        //     // 전진 애니메이션
        // }
        // else if (v<=-0.1f)
        // {
        //     // 후진 애니메이션
        // }
        // else if (h>=0.1f)
        // {   
        //     // 오른쪽 회전 애니메이션
        // }
        // else if(h<=-0.1f)
        // {
        //     // 왼쪽 회전 애니메이션
        // }
        // else
        // {
        //     // Idle
        // }
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            //animator.SetTrigger("Jump");
        }
    }

    void OnCollisionEnter(Collision coll)
    {
    }

    void OnTriggerEnter(Collider coll)
    {
        // if(coll.CompareTag("STARTPOINT"))
        // {
        //     onStart = true;

        //     int idx = Random.Range(0, GameManager.instance.glObjs.Length);
        //     GameObject ogj = Instantiate(GameManager.instance.glObjs[idx], GameManager.instance.obgTr.position, Quaternion.identity);
        // }
        // else if(coll.CompareTag("GOBJ")||coll.CompareTag("LOBJ"))
        // {
        //     onStart = false;
        //     coll.gameObject.transform.parent = this.gameObject.transform;
        //     coll.gameObject.transform.position = objPos.transform.position;
        // }

        // // 충돌한 Collider가 키보드이면 인벤토리에 저장
        // if(coll.CompareTag("KEYBOARD"))
        // {
        // }
    }

    void PlayerDie()
    {
        // 플레이어 사망 이벤트 호출(발생)
        OnPlayerDie();
    }
}
