using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesTracker : MonoBehaviour
{
    public int tempCollectibles;

    void Start ()
    {
        tempCollectibles = 0;
        PlayerPrefs.SetInt("Collectibles", 0);
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Collectible")
        {
            tempCollectibles++;
            PlayerPrefs.SetInt("Collectibles", tempCollectibles);
            Debug.Log(PlayerPrefs.GetInt("Collectibles"));
            Destroy(other.gameObject);
        }
    }
}
