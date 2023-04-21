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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_Animator.SetTrigger("Open");
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_Animator.SetTrigger("Close");
        }
    }
}
