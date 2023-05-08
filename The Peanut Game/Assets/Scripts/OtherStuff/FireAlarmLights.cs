using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAlarmLights : MonoBehaviour
{
    // The concept I got was to make the lights be like a fire alarm, constantly blinking on and off

    // Light Component to mess with
    Light light1;

    // Base intensity to return to
    float baseIntensity;

    // Timer to keep the light constant
    float timer;
    public float timerEventTrigger;

    void Start()
    {
        light1 = GetComponent<Light>();
        baseIntensity = light1.intensity;
    }

    void Update()
    {
        timer += Time.fixedDeltaTime;
        Debug.Log(timer);
        if (timer >= timerEventTrigger)
        {
            if (light1.intensity == baseIntensity)
            {
                light1.intensity = 0;
            }
            else
            {
                light1.intensity = baseIntensity;
            }
            timer = 0;
        }
    }
}
