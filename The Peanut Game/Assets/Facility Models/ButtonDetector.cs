using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDetector : MonoBehaviour
{
    //public GameObject Button; 
    public float ButtonRange = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Basic Raycasting stuff.
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        // If the Raycast is interacting with something, continue
        // Also make hitTemp down here, it didn't like it with the other stuff for some reason
        if (Physics.Raycast(ray, out hit, ButtonRange))
        {
            // If the hit object is tagged "Button" then run this command
            GameObject hitTemp = hit.collider.gameObject;
            if (hitTemp.tag == "Button")
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Button.GetComponent<DoorButtonAnimation>().Push();
                    hitTemp.GetComponent<DoorButtonAnimation>().Push();
                }
            }
        }
    }
}
