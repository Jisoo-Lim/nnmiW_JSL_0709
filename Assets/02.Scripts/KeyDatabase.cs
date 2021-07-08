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

    public List<Key> keyDB = new List<Key>();

    public GameObject fieldKeyPrefab;
    // 키 생성 위치
    public Transform keyPos;

    void Start()
    {
        keyPos = GameObject.Find("KeyPos")?.GetComponent<Transform>();

        GameObject go = Instantiate(fieldKeyPrefab, keyPos.position, Quaternion.identity);
        go.GetComponent<FieldKeys>().SetKey(keyDB[Random.Range(0, 25)]);
    }

    void CreateRandomKey(int min, int max)
    {
        int currentNum = Random.Range(min, max);

        for (int i = 0; i < max;)
        {

        }
    }
}