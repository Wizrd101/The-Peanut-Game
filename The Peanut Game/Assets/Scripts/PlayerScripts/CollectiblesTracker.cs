using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesTracker : MonoBehaviour
{
    // Temporary Collectibles Variables, to make it easier to transfer to PlayerPrefs
    public int tempCollectibles;

    // Distance that the player can interact with collectibles
    public float collectibleRaycastDistance = 30;

    // Canvas that shows when the player is looking at a collectible
    // Basically tells the player "Hey, you can pick this up!"
    public Canvas colCanvas;

    void Start ()
    {
        tempCollectibles = 0;
        PlayerPrefs.SetInt("Collectibles", 0);
        colCanvas.enabled = false;
    }

    // Old system, outdated. Going to use Raycasts instead.
    /*void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Collectible")
        {
            tempCollectibles++;
            PlayerPrefs.SetInt("Collectibles", tempCollectibles);
            Debug.Log(PlayerPrefs.GetInt("Collectibles"));
            Destroy(other.gameObject);
        }
    }*/

    // New system (with Raycasts)
    void Update ()
    {
        RaycastHit hit;
        Ray CDRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, collectibleRaycastDistance))
        {
            if (hit.collider.gameObject.tag == "Collectible")
            {
                colCanvas.enabled = true;
                if (Input.GetButtonDown("E"))
                {
                    tempCollectibles++;
                    hit.collider.gameObject.Destroy();
                }
            }
            else
            {
                colCanvas.enabled = false;
            }
        }
    }
}
