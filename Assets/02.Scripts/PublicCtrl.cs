using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PublicCtrl : MonoBehaviour
{
    // 대중의 상태 정보
    public enum State
    {
        IDLE,
        WALK,
        LOOK,
        PASS
    }

    // 대중의 현재 상태 
    public State state  = State.IDLE;
    // WALK 사정 거리
    public float walkDist = 10.0f;
    // LOOK 사정 거리
    public float lookDist = 5.0f;
    // 대중의 PASS 여부
    public bool isPass = false;

    private Transform publicTr;
    private Transform playerTr;
    private Transform doorTr;
    private NavMeshAgent agent;
    private Animator animator;
    private RaycastHit hit;

    private readonly int hashWalk  = Animator.StringToHash("IsWalk");
    private readonly int hashLook   = Animator.StringToHash("IsLook");
    private readonly int hashPass   = Animator.StringToHash("IsPass");

    void OnEnable()
    {
        state = State.IDLE;
        isPass = false;

        // 대중의 상태 체크
        StartCoroutine(CheckPublicState());

        // 상태에 따른 대중의 행동
        StartCoroutine(PublicAction());
    }  

    void OnDisable()
    {
    }

    void Awake()
    {
        publicTr = GetComponent<Transform>();
        playerTr = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Transform>();
        doorTr = GameObject.FindGameObjectWithTag("DOOR")?.GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        agent.updateRotation = false;
    }

    void Update()
    {

        Debug.Log($"대중 상태 ={state}");
        if(agent.remainingDistance>=2.0f)
        {
            Vector3 direction = agent.desiredVelocity;

            if(direction.sqrMagnitude >= 0.1f*0.1f)
            {
                Quaternion rot = Quaternion.LookRotation(direction);
                publicTr.rotation = Quaternion.Slerp(publicTr.rotation, rot, Time.deltaTime*10.0f);
            }
        }
    }

    IEnumerator CheckPublicState()
    {
        while(!isPass)
        {
            yield return new WaitForSeconds(0.3f);

            if(state == State.PASS) yield break;
            
            float distance = Vector3.Distance(playerTr.position, publicTr.position);

            if(distance<=lookDist)
            {
                if(Physics.Raycast(playerTr.position, -playerTr.up, out hit, 2.0f, 1<<9))
                {
                    state = State.LOOK;
                }
                else
                {
                    state = State.WALK;
                }
            }
            else if(distance<=walkDist)
            {
               state = State.WALK;
            }
            else
            {
                state = State.IDLE;
            }
        }
    }

    IEnumerator PublicAction()
    {
        while(!isPass)
        {
            switch(state)
            {
                case State.IDLE:
                    agent.isStopped = true;
                    animator.SetBool(hashWalk, false);
                break;

                case State.WALK:
                    agent.SetDestination(doorTr.position);
                    agent.isStopped = false;
                    animator.SetBool(hashWalk, true);
                    animator.SetBool(hashLook, false);
                break;

                case State.LOOK:
                    agent.isStopped = true;
                    publicTr.LookAt(playerTr.position);
                    animator.SetBool(hashLook, true);
                break;

                case State.PASS:
                    isPass = true;
                    agent.isStopped = true;
                    animator.SetTrigger(hashPass);
                    GetComponent<CapsuleCollider>().enabled = false;
                
                yield return new WaitForSeconds(2.0f);

                    GetComponent<CapsuleCollider>().enabled = true;
                    this.gameObject.SetActive(false);
                break;
            }
        yield return new WaitForSeconds(0.3f);

        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("DOOR"))
        {
            state = State.PASS;
        }
    }

    void OnDrawGizmos()
    {
        if(state == State.WALK)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, walkDist);
        }
        if(state == State.LOOK)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, lookDist);
        }
    }
}
