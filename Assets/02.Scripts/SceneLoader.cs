using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private Transform playerTr;
    private Transform startPos;
    private Transform doorPos;
    private RaycastHit hit;

    public static SceneLoader instance = null;

    void Awake()
    {
        if(instance == null)
        { 
            instance = this;
        }
        else if(instance !=this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        startPos = GameObject.FindGameObjectWithTag("STARTPOINT")?.GetComponent<Transform>();
        doorPos = GameObject.FindGameObjectWithTag("DOOR")?.GetComponent<Transform>();
    }

    void Update()
    {
        DarkRoom();
        NextStage();
    }
    
    // 플레이어가 OWNROAD를 통해 출구로 진입하면 DARK ROOM으로 이동
    void DarkRoom()
    {
        if(Physics.Raycast(playerTr.position, playerTr.forward, out hit, 0.8f, 1<<11))
        {
            if(hit.collider.GetComponent<SceneInfo>().sceneInfo == 0)
            {
                playerTr.position = doorPos.position;
                SceneManager.LoadScene("Stage0_D");
            }
            else if(hit.collider.GetComponent<SceneInfo>().sceneInfo == 1)
            {
                playerTr.position = doorPos.position;
                SceneManager.LoadScene("Stage1_D");
            }
        }
    }

    // >> DARK 룸에서 아이템 확득 후 다시 기존 스테이지로 이동
    public void ReturnStage()
    {
        if(Physics.Raycast(playerTr.position, -playerTr.up, out hit, 2.0f, 1<<13))
        {
            if(hit.collider.GetComponent<SceneInfo>().sceneInfo == 1)
            {
                playerTr.position = new Vector3(0,0.3f, 3.0f);
                //playerTr.position = startPos.position;
                SceneManager.LoadScene("Stage1");
            }
        }
    }

    // 플레이어가 PUBLIC RAOD를 통해 출구로 진입하면 다음 스테이지 이동
    void NextStage()
    {
        if(Physics.Raycast(playerTr.position, playerTr.forward, out hit, 0.8f, 1<<12))
        {
            if(hit.collider.GetComponent<SceneInfo>().sceneInfo == 1)
            {
                playerTr.position = new Vector3(0,0.3f, 3.0f);
                SceneManager.LoadScene("Stage2");
            }
        }
    }
}
