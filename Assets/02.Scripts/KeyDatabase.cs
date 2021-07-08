using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDatabase : MonoBehaviour
{
    public static KeyDatabase instance;
    private Transform playerTr;
    private RaycastHit hit;

    void Awake()
    {
        instance = this;

<<<<<<< HEAD
    // 키 목록 > 26개
    public GameObject[] keys;
    
    // 추출된 키 저장할 리스트
    public List<Key> randomKey = new List<Key>();

    public Key KeyCard()
    {
        return randomKey[Random.Range(0, randomKey.Count)];
    }

    // 키 생성 위치
    public Transform keyPos;

    void Start()
    {
        //
        keyPos = GameObject.Find("KeyPos")?.GetComponent<Transform>();
        
        //GameObject go = Instantiate(fieldKeyPrefab, keyPos.position, Quaternion.identity);
        //go.GetComponent<FieldKeys>().SetKey(keyDB[Random.Range(0,25)]);
    }

    void ChooseKey()
    {
        while(randomKey.Count == 5)
        {
            for(int i = 0; i<5; i++)
            {
                int idx = Random.Range(0, keys.Length);
                
            }

           
        }

        for(int i = 0; i<keys.Length; i++)
        {
            for (int j= 0; j<i; j++)
            {
                if(keys[i]==keys[j])
                {
                    i--;
                    break;
                }
            }
=======
        DontDestroyOnLoad(this.gameObject);
    }

    // 키 목록 27개
    public List<GameObject> keyList = new List<GameObject>();
    // 키 다섯개 추출후 저장할 리스트
    public List<GameObject> keyPool = new List<GameObject>();

    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        Key();
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
                //Instantiate(keyPool[0], );
            }
            // _key[1] 2씬 히든 스테이지에 생성 / UI DownArrow 자리에 생성 >> 아래 기능 부여
            // _key[2] 3씬 히든 스테이지에 생성 / UI RightArrow 자리에 생성 >> 우 기능 부여
            // _key[3] 4씬 히든 스테이지에 생성 / UI UpArrow 자리에 생성 >> 위 기능 부여
            // _key[4] 5씬 히든 스테이지에 생성 / UI Jump 자리에 생성 >> 점프 기능 부여

>>>>>>> c3b3932bfb48c72ac2dfcb7b3c7fa690ce30fb5b
        }
    }
}