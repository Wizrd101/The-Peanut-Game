using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectiblesRecord : MonoBehaviour
{
    public TextMeshProUGUI collectiblesText;

    public CollectiblesTracker ct;

    void Start()
    {
        if (ct.collectibles == 0)
        {
            // If the player got 0 fragments of research
            collectiblesText.text = "You got 0 collectibles";
        }
        else if (ct.collectibles == 1)
        {
            // If the player got 1 fragments of research
            collectiblesText.text = "You got 1 collectible";
        }
        else if (ct.collectibles == 2)
        {
            // If the player got 2 fragments of research
            collectiblesText.text = "You got 2 collectibles";
        }
        else if (ct.collectibles == 3)
        {
            // If the player got 3 fragments of research
            collectiblesText.text = "You got 3 collectibles";
        }
        else if (ct.collectibles == 4)
        {
            // If the player got 4 fragments of research
            collectiblesText.text = "You got 4 collectibles";
        }
        else if (ct.collectibles == 5)
        {
            // If the player got 5 fragments of research
            collectiblesText.text = "You got 5 collectibles";
        }
    }
}
