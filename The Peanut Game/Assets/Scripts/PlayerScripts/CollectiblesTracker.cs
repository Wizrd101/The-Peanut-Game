using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectiblesTracker : MonoBehaviour
{

    // Distance that the player can interact with collectibles
    public float colRange = 30;

    // Canvas that shows when the player is looking at a collectible
    // Basically tells the player "Hey, you can pick this up!"
    public Canvas colCanvas;

    // Accessing the Save function to tell it what collectibles have been picked up.
    //BinarySave binarySave;

    // Public access to the collectibles in the level
    public GameObject levelColOne;
    public GameObject levelColTwo;

    Scene currentScene;

    void Start ()
    {
        colCanvas.enabled = false;

        currentScene = SceneManager.GetActiveScene();

        if (currentScene.buildIndex == 2)
        {
            if (PlayerPrefs.GetInt("ColOneCollected") == 1)
            {
                Destroy(levelColOne);
            }

            if (PlayerPrefs.GetInt("ColTwoCollected") == 1)
            {
                Destroy(levelColTwo);
            }
        }

        if (currentScene.buildIndex == 3)
        {
            if (PlayerPrefs.GetInt("ColThreeCollected") == 1)
            {
                Destroy(levelColOne);
            }

            if (PlayerPrefs.GetInt("ColFourCollected") == 1)
            {
                Destroy(levelColTwo);
            }
        }

        if (currentScene.buildIndex == 4 && PlayerPrefs.GetInt("ColFiveCollected") == 1)
        {
            Destroy(levelColOne);
        }
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
                    //hit.collider.enabled = false;

                    if (currentScene.buildIndex == 2)
                    {
                        if (hitTemp == levelColOne)
                        {
                            PlayerPrefs.SetInt("ColOneCollected", 1);
                        }

                        if (hitTemp == levelColTwo)
                        {
                            PlayerPrefs.SetInt("ColTwoCollected", 1);
                        }
                    }

                    if (currentScene.buildIndex == 3)
                    {
                        if (hitTemp == levelColOne)
                        {
                            PlayerPrefs.SetInt("ColThreeCollected", 1);
                        }

                        if (hitTemp == levelColTwo)
                        {
                            PlayerPrefs.SetInt("ColFourCollected", 1);
                        }
                    }
                    
                    if (currentScene.buildIndex == 4)
                    {
                        PlayerPrefs.SetInt("ColFiveCollected", 1);
                    }

                    Destroy(hitTemp);
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
