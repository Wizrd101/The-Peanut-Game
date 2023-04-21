using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesTracker : MonoBehaviour
{
    public int collectibles;

    /*void Start ()
    {
        PlayerPrefs.SetInt(CollectiblesTracker, 0);
    }*/

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Collectible")
        {
            collectibles++;
            Debug.Log(collectibles);
            Destroy(other.gameObject);
        }
    }
}
