using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDatabase : MonoBehaviour
{
    public static KeyDatabase instance;

    void Awake()
    {
        instance = this;
    }

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
        }
    }
}