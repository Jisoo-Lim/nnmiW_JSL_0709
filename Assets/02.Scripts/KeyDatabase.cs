using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDatabase : MonoBehaviour
{
    public static KeyDatabase instance;
    
    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject downArrow;
    [SerializeField] private GameObject rightArrow;
    [SerializeField] private GameObject upArrow;
    [SerializeField] private GameObject jump;

    [SerializeField] private GameObject leftArrowPos;
    [SerializeField] private GameObject downArrowPos;
    [SerializeField] private GameObject rightArrowPos;
    [SerializeField] private GameObject upArrowPos;
    [SerializeField] private GameObject jumpPos;

    private Transform playerTr;
    private RaycastHit hit;
    void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    // 키 목록 27개
    public List<GameObject> keyList = new List<GameObject>();
    // 키 다섯개 추출후 저장할 리스트
    public List<GameObject> keyPool = new List<GameObject>();

    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //leftArrowPos = GameObject.FindGameObjectWithTag("KEYBOARD").GetComponent<SceneInfo>().sceneInfo;

        Key();
    }

    void Update()
    {
        CreateKey();
    }

    public void Key()
    {
        for (int i = 0; i < 5; i++) // 5개를 뽑을 것임
        {
            int rand = Random.Range(0, keyList.Count);
            Debug.Log(keyList[rand]);

            GameObject _key = keyList[rand];
            keyPool.Add(_key);
        }
    }

    void CreateKey()
    {
        if (Physics.Raycast(playerTr.position, -playerTr.up, out hit, 2.0f, 1 << 13))
        {
            // _key[0] 1씬 히든 스테이지에 생성 / UI LeftArrow 자리에 생성 >> 좌 기능 부여
            if(hit.collider.GetComponent<SceneInfo>().sceneInfo ==1)
            {   
                GameObject leftKey = Instantiate(keyPool[0], Vector3.zero, Quaternion.Euler(new Vector3(0.0f, -90.0f, 90.0f)));
                leftKey.transform.SetParent(leftArrow.transform);
                leftKey.transform.localScale = new Vector3(50.0f, 50.0f, 50.0f);

                GameObject leftkey2 = Instantiate(keyPool[0], Vector3.zero, Quaternion.Euler(new Vector3(0.0f, -90.0f, 90.0f)));
                leftkey2.transform.SetParent(leftArrowPos.transform);
                leftkey2.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
            // _key[1] 2씬 히든 스테이지에 생성 / UI DownArrow 자리에 생성 >> 아래 기능 부여
            else if(hit.collider.GetComponent<SceneInfo>().sceneInfo ==2)
            {   
                GameObject downKey = Instantiate(keyPool[1]) as GameObject;
                downKey.transform.parent = downArrow.transform;
                downKey.transform.rotation = Quaternion.Euler(new Vector3(0.0f, -90.0f, 90.0f));
                downKey.transform.localScale = new Vector3(50.0f, 50.0f, 50.0f);

                GameObject downKey2 = Instantiate(keyPool[1]) as GameObject;
                downKey2.transform.parent = downArrowPos.transform;
                downKey2.transform.rotation = Quaternion.identity;
                downKey2.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
            // _key[2] 3씬 히든 스테이지에 생성 / UI RightArrow 자리에 생성 >> 우 기능 부여
            else if(hit.collider.GetComponent<SceneInfo>().sceneInfo ==3)
            {   
                GameObject rightKey = Instantiate(keyPool[2]) as GameObject;
                rightKey.transform.parent = rightArrow.transform;
                rightKey.transform.rotation = Quaternion.Euler(new Vector3(0.0f, -90.0f, 90.0f));
                rightKey.transform.localScale = new Vector3(50.0f, 50.0f, 50.0f);
            
                GameObject rightKey2 = Instantiate(keyPool[2]) as GameObject;
                rightKey2.transform.parent = rightArrowPos.transform;
                rightKey2.transform.rotation = Quaternion.identity;
                rightKey2.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
            // _key[3] 4씬 히든 스테이지에 생성 / UI UpArrow 자리에 생성 >> 위 기능 부여
            // _key[4] 5씬 히든 스테이지에 생성 / UI Jump 자리에 생성 >> 점프 기능 부여

        }
    }
}