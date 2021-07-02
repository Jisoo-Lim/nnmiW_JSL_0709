using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 대중이 출현할 위치 저장
    public List<Transform> points = new List<Transform>();
    // 대중을 미리 생성해 저장할 리스트
    public List<GameObject> publicPool = new List<GameObject>();
    // 오브젝트 풀에 생성할 대중 최대 인원
    public int maxPublics = 10;

    public GameObject publicObj;
    // 대중 생성 간격
    public float createTime = 3.0f;

    public GameObject[] glObjs;
    public GameObject gObj;
    public GameObject lObj;
    public Transform obgTr;

    public static GameManager instance = null;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        gObj = GameObject.FindGameObjectWithTag("GOBJ");
        lObj = GameObject.FindGameObjectWithTag("LOBJ");
        glObjs[0] = gObj;
        glObjs[1] = lObj;
    }

    void Start()
    {
        // 대중 오브젝트 풀 생성
        CreatePublicPool();

        Transform spawnPointGroup = GameObject.Find("SpawnPointGroup")?.transform;

        foreach(Transform point in spawnPointGroup)
        {
            points.Add(point);
        }

        InvokeRepeating("CreatePublic", 3.0f, createTime);
    }

    void CreatePublic()
    {
        // 대중의 불규칙한 생성 위치 산출
        int idx = Random.Range(0,points.Count);

        // 오브젝트 풀에서 대중 추출
        GameObject _public = GetPublicInPool();

        _public?.transform.SetPositionAndRotation(points[idx].position, points[idx].rotation);

        // 추출한 대중 활성화
        _public?.SetActive(true);
    }

    void CreatePublicPool()
    {
        for(int i = 0; i<maxPublics; i++)
        {
            // 대중 생성
            var _public = Instantiate<GameObject>(publicObj);
            // 대중 이름 지정
            _public.name = $"Public_{i:00}";
            // 대중 비활성화
            _public.SetActive(false);
            // 생성한 대중을 오브젝트 풀에 추가
            publicPool.Add(_public);
        }
    }

    // 오브젝트 풀에서 사용 가능한 대중을 추출해 반환
    public GameObject GetPublicInPool()
    {
        foreach(var _public in publicPool)
        {
            // 비활성화 여부로 사용 가능 대중 판단
            if(_public.activeSelf == false)
            {
                return _public;
            }
        }
        return null;
    }
}
