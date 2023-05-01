using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonAnimation : MonoBehaviour
{
    private bool doorstate = false;
    //false = close, true = open
    public GameObject Door;
    Animator m_Animator;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }


    void Update()
    {

    }
    //Animation for the button being pressed
    public void Push()
    {
        m_Animator.SetTrigger("Push");
        if (doorstate == false)
        {
        Door.GetComponent<DoorAnimation>().Open();
            doorstate = true;
        }
        else
        {
        Door.GetComponent<DoorAnimation>().Close();
            doorstate = false;
        }
    }
}
