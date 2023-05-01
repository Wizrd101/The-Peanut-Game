using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Open()
    {
        m_Animator.SetTrigger("Open");
        GetComponent<BoxCollider>().isTrigger = true;
    }

    public void Close()
    {
        m_Animator.SetTrigger("Close");
        GetComponent<BoxCollider>().isTrigger = false;
    }
}