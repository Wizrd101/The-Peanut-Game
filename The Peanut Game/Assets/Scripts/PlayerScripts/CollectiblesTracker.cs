using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesTracker : MonoBehaviour
{
    // Temporary Collectibles Variables, to make it easier to transfer to PlayerPrefs
    public int tempCollectibles;

    // Distance that the player can interact with collectibles
    public float colRange = 30;

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
        // Basic Raycasting stuff.
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        // If the Raycast is interacting with something, continue
        // Also make hitTemp down here, it didn't like it with the other stuff for some reason
        if (Physics.Raycast(ray, out hit, colRange))
        {
            // If the hit object is tagged "Collectible", then enable the canvas...
            GameObject hitTemp = hit.collider.gameObject;
            if (hitTemp.tag == "Collectible")
            {
                colCanvas.enabled = true;
                // If you press the "E" key while looking at the collectible, pick it up
                // Also add 1 to the collectibles and destroy the collectible
                if (Input.GetKeyDown(KeyCode.E))
                {
                    tempCollectibles++;
                    Debug.Log(tempCollectibles);
                    PlayerPrefs.SetInt("Collectibles", tempCollectibles);
                    Destroy(hitTemp.gameObject);
                }
            }
            // ...Otherwise, it's a random object, disable the canvas (or keep it disabled)
            else
            {
                colCanvas.enabled = false;
            }
        }
    }
}
