using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoNextLevelTrigger : MonoBehaviour
{
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger Next Level");
        }
    }
}
