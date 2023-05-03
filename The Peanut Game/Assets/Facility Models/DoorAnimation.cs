using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    Animator m_Animator;

    bool doorIsOpen;

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
        if (!doorIsOpen)
        {
            m_Animator.SetTrigger("Open");
            GetComponent<BoxCollider>().isTrigger = true;
            doorIsOpen = true;
            Debug.Log("Open");
        }
    }

    public void Close()
    {
        if (doorIsOpen)
        {
            m_Animator.SetTrigger("Close");
            GetComponent<BoxCollider>().isTrigger = false;
            doorIsOpen = false;
        }
    }
}