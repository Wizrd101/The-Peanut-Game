using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectiblesRecord : MonoBehaviour
{
    // Text object to be changed
    public TextMeshProUGUI collectiblesText;

    // Temporary collectibles variable
    public int cols;

    // Save Data script
    BinarySave binarySave;

    void Awake()
    {
        // Figure out what cols should be
        cols = binarySave.gameData.collectiblesRetrived;
    }

    void Start()
    {
        if (cols == 0)
        {
            // If the player got 0 fragments of research
            collectiblesText.text = "Dr. Raven made it out of that place alive, but had forgotten some much important documents that he couldn't leave behind. No matter, it was too late, as the on-site nuke was to set off. Dr. Raven boarded the helicopter and flew to safety.";
        }
        else if (cols == 1)
        {
            // If the player got 1 fragments of research
            collectiblesText.text = "Dr. Raven made it out of that place alive, clutching one of the most important documents. But there were still four more that he had missed. 'we really need to oragnize better.' he thought as he climbed into the helicopter. As they flew away, they watched the on-site nuke destroy the facility.";
        }
        else if (cols == 2)
        {
            // If the player got 2 fragments of research
            collectiblesText.text = "Dr. Raven made it out of that place alive, grasping at two of the most important documents. Dr. Raven was well aware, however, that there were still three that he had missed. He got into the helocopter and flew away before the on-site nuke went off.";
        }
        else if (cols == 3)
        {
            // If the player got 3 fragments of research
            collectiblesText.text = "Dr. Raven made it out of that place alive, tightly holding onto three of the most important documents. While well aware that there were still two more in the facility, he couldn't go back. He climbed into the helicopter and flew off before the on-site nuke detonated.";
        }
        else if (cols == 4)
        {
            // If the player got 4 fragments of research
            collectiblesText.text = "Dr. Raven barely made it out of that place alive, clinging to four of the most importand documents. Still, there was one left. 'Why didn't we organize the papers?' he thought as he watched the facility blow up from the helicopter";
        }
        else if (cols == 5)
        {
            // If the player got 5 fragments of research
            collectiblesText.text = "Dr. Raven barely made it out of that place alive, neatly holding all of the most inportant documents. he boarded the helicopter and flew away. they were only 15,000 feet away when the on-site nuke went off. 'I will have to organize these' he thought.";
        }
    }
}
