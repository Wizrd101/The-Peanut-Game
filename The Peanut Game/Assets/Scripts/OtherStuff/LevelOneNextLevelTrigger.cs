using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneNextLevelTrigger : MonoBehaviour
{
    public GameObject Player; 

    BinarySave bs;

    public GameObject colOne;
    public GameObject colTwo;

    void Start()
    {
        bs = Player.GetComponent<BinarySave>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (colOne == null)
            {
                bs.gameData.collectibleOneCollected = true;
                Debug.Log("Collectible 1 Gotten");
            }

            if (colTwo == null)
            {
                bs.gameData.collectibleTwoCollected = true;
                Debug.Log("Collectible 1 Gotten");
            }
            //Debug.Log("Trigger Next Level");
            SceneManager.LoadScene("Levelthreescene");
        }
    }
}