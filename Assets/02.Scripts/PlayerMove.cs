using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    private Transform tr;
    public float speed = 10.0f;
    public GameObject door;
    public GameObject returnRoad;
    public HingeJoint hinge;
    public JointLimits limits;
    private NavMeshAgent agent;
    public GameObject hole;
    
    public GameObject returnStart;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        tr = GetComponent<Transform>();
        hinge = door.GetComponent<HingeJoint>();
        limits = hinge.limits;
        hinge.useLimits = true;

    }

    void Start()
    {
        limits.min = 120.0f;
        limits.max = 120.0f;

        hinge.limits = limits;
    }

    // Update is called once per frame
    void Update()
    {

        Move();
    }

    void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 moveDir = (Vector3.forward*v)+(Vector3.right*h);

        tr.Translate(moveDir.normalized*speed*Time.deltaTime);
  
    }

    void OnTriggerExit(Collider coll)
    {
        if(coll.CompareTag("BASICENDPOS"))
        {
            door.SetActive(false);
        }
        else if(coll.CompareTag("OWNENDPOS"))
        {
            Debug.Log("내 길");
            // 문 안보이게
            door.transform.parent.gameObject.SetActive(false);
            // 리턴길 생성 
            returnRoad.SetActive(true);
            // 리턴길 위로 플레이어 이동
            agent.updatePosition = false;
            agent.updateRotation = false;
            tr.position = returnStart.transform.position;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.CompareTag("RETURNEND"))
        {

            door.transform.parent.gameObject.SetActive(true);
            returnRoad.SetActive(false);
            hole.SetActive(false);
        }

    }
}
