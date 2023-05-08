using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonAnimation : MonoBehaviour
{
    private bool doorstate = false;
    //false = close, true = open
    public GameObject Door;
    Animator m_Animator;
    //public InventoryManager inventoryManager;
    AudioSource audioData;

    bool openable;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
    }


    void Update()
    {

    }
    //Animation for the button being pressed
    public void Push()
    {
        m_Animator.SetTrigger("Push");
        audioData.Play(0);

        //if (inventoryManager._inventoryItems.Contains(InventoryManager.AllItems.KeyCard1))
        //{
        //    openable = true;
        //}

        if (doorstate == false) //&& openable)
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
