using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyType
{
    LeftArrow,
    DownArrow,
    RightArrow,
    UpArrow
}

[System.Serializable]
public class Key
{
    public KeyType keyType;
    public string keyName;
    public GameObject keyObj;

    public bool Use()
    {
        return false;
    }
}
