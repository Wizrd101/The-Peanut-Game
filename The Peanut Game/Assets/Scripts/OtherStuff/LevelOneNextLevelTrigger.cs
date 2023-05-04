using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneNextLevelTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            //Debug.Log("Trigger Next Level");
            SceneManager.LoadScene("Levelthreescene");
        }
    }
}