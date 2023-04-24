using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    AudioSource audsrc;

    StarterAssets.FirstPersonController fpc;

    bool wIsPressed;
    bool aIsPressed;
    bool sIsPressed;
    bool dIsPressed;

    void Start()
    {
        audsrc = GetComponent<AudioSource>();
        fpc = GetComponent<StarterAssets.FirstPersonController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            wIsPressed = true;
        }
        else
        {
            wIsPressed = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            aIsPressed = true;
        }
        else
        {
            aIsPressed = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            sIsPressed = true;
        }
        else
        {
            sIsPressed = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            dIsPressed = true;
        }
        else
        {
            dIsPressed = false;
        }

        if ((wIsPressed || aIsPressed || sIsPressed || dIsPressed) && !audsrc.isPlaying && fpc.Grounded)
        {
            audsrc.Play(); 
        }
        
        if (!wIsPressed && !aIsPressed && !sIsPressed && !dIsPressed || !fpc.Grounded)
        {
            audsrc.Stop();
        }
    }
}
