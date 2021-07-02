using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();    
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("Player"))
        {
            Invoke("Anim",2.0f);            

        }
    }

    void Anim()
    {
        animator.SetTrigger("Add");
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
