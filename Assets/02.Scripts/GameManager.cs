using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerTr;
    public GameObject door;

    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Transform>();        
    }

    void Update()
    {
        StageCtrl();
    }

    void StageCtrl()
    {
       
    }

    
}
