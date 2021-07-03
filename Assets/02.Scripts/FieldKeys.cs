using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldKeys : MonoBehaviour
{
    public Key key;
    public MeshRenderer meshRenderer;

    public void SetKey(Key _key)
    {
        key.keyName = _key.keyName;
        key.keyObj = _key.keyObj;
        key.keyType = _key.keyType;
    }

    public Key GetKey()
    {
        return key;
    }

    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("Player"))
        {
            Invoke("Anim",3.0f);            
        }
    } 

    void Anim()
    {
        animator.SetTrigger("Add");
    }

    // 키를 회득하면 필드의 키는 Destroy
    public void Destroy()
    {
        SceneLoader.instance.ReturnStage();
        Destroy(this.gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
