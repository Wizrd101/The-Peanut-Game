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
        // if the player is grounded, continue on
        /*if (!audsrc.isPlaying)
        {
            if (fpc.Grounded)
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
                    Debug.Log("Stopping 1");
                }
            }
            else
            {
                audsrc.Stop();
                Debug.Log("Stopping 2");
            }
        }*/

        if (Input.GetKey(KeyCode.W))
        {
            wIsPressed = true;
            Debug.Log("W is on");
        }
        else
        {
            wIsPressed = false;
            Debug.Log("W is off");
        }

        if (Input.GetKey(KeyCode.A))
        {
            aIsPressed = true;
            Debug.Log("A is on");
        }
        else
        {
            aIsPressed = false;
            Debug.Log("A is off");
        }

        if (Input.GetKey(KeyCode.S))
        {
            sIsPressed = true;
            Debug.Log("S is on");
        }
        else
        {
            sIsPressed = false;
            Debug.Log("S is off");
        }

        if (Input.GetKey(KeyCode.D))
        {
            dIsPressed = true;
            Debug.Log("D is on");
        }
        else
        {
            dIsPressed = false;
            Debug.Log("D is off");
        }

        if ((wIsPressed || aIsPressed || sIsPressed || dIsPressed) && !audsrc.isPlaying && fpc.Grounded)
        {
            audsrc.Play();
            Debug.Log("Playing Sound"); 
        }
        
        if (!wIsPressed && !aIsPressed && !sIsPressed && !dIsPressed || !fpc.Grounded)
        {
            audsrc.Stop();
            Debug.Log("Stopping Sound");
        }
    }
}
