using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaderAnimation : MonoBehaviour
{
    //Debug.Log("Working");
    Animator m_Animator;
    public float ReaderRange = 30;
    public InventoryManager inventoryManager;
    private bool Ready = false;
    public GameObject Door;
    AudioSource audioData;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("up"))
        //{
        //m_Animator.SetTrigger("Swipe");
        //}

        // Basic Raycasting stuff.
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        // If the Raycast is interacting with something, continue
        // Also make hitTemp down here, it didn't like it with the other stuff for some reason
        if (Physics.Raycast(ray, out hit, ReaderRange))
        {
            // If the hit object is tagged "Button" then run this command
            GameObject hitTemp = hit.collider.gameObject;
            if (hitTemp.tag == "Reader")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (inventoryManager._inventoryItems.Contains(InventoryManager.AllItems.KeyCard1))
                    {
                        if (Ready == false)
                        {
                            audioData.Play(0);
                            m_Animator.SetTrigger("Swipe");
                            Ready = true;
                           Door.GetComponent<DoorAnimation>().Open();
                        }
                    }
                }
            }
        }
    }
}
