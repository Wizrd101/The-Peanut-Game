using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    AudioSource audsrc;

    StarterAssets.FirstPersonController fpc;

    void Start()
    {
        audsrc = GetComponent<AudioSource>();
        fpc = GetComponent<StarterAssets.FirstPersonController>();
    }

    void Update()
    {
        // if the player is grounded, continue on
        if (fpc.Grounded && !audsrc.isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                audsrc.Play();
                Debug.Log("W & Sound");
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                audsrc.Play();
                Debug.Log("A & Sound");
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                audsrc.Play();
                Debug.Log("S & Sound");
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                audsrc.Play();
                Debug.Log("D & Sound");
            }
            else
            {
                audsrc.Stop();
                Debug.Log("Stopping");
            }
        }
    }
}
