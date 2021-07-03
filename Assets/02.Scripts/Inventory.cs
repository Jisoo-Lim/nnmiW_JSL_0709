using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<KeyData> keys = new List<KeyData>();
    private int maxKeys = 4;
    public GameObject keyPrefab;
    private GameObject keyPanel;

    void Start()
    {
        // keyPanel = GameObject.Find("PANEL");

        // for(int i = 0; i<maxKeys; i++)
        // {
        //     GameObject go = Instantiate(keyPrefab, keyPanel.transform, false);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
