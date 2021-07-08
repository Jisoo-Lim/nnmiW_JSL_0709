using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyType
{
    LeftArrow,
    DownArrow,
    RightArrow,
    UpArrow,
    Jump
}

[System.Serializable]
public class Key
{
    public string keyName;
    public GameObject keyObj;
    public KeyType keyType;

    public Key(Key key)
    {
        this.keyName = key.keyName;
        this.keyObj = key.keyObj;
        this.keyType = key.keyType;
    }
}
