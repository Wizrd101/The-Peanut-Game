using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneNextLevelTrigger : MonoBehaviour
{
    BinarySave bs;

    GameObject colOne;
    GameObject colTwo;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (colOne == null)
            {
                bs.gameData.collectibleOneCollected = true;
            }

            if (colTwo == null)
            {
                bs.gameData.collectibleTwoCollected = true;
            }
            //Debug.Log("Trigger Next Level");
            SceneManager.LoadScene("Levelthreescene");
        }
    }
}