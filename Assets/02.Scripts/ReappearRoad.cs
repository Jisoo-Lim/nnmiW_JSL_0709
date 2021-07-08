using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReappearRoad : MonoBehaviour
{
    public GameObject[] reappearRoads;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPublicOn)
        {
            StartCoroutine(Road());
        }
    }

    IEnumerator Road()
    {
        GameManager.instance.isPublicOn = false;

        for (int i = 0; i < reappearRoads.Length; i++)
        {
            reappearRoads[i].SetActive(true);

            yield return new WaitForSeconds(1.0f);
        }
    }
    // 대중이 생성되면
    // 리스트에 있는 길 오브젝트가 순차적으로 생긴다.
}
