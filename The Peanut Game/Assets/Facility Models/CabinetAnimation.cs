using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetAnimation : MonoBehaviour
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
        if (Input.GetKeyDown("up"))
        {
        m_Animator.SetTrigger("Open");
        }

        if (Input.GetKeyDown("down"))
        {
            m_Animator.SetTrigger("Close");
        }
    }

    public void Open()
    {
        m_Animator.SetTrigger("Open");
    }

    public void close()
    {
        m_Animator.SetTrigger("Close");
    }
}
