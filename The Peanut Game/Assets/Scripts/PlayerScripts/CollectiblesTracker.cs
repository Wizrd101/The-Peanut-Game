using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesTracker : MonoBehaviour
{
    int collectibles;

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
