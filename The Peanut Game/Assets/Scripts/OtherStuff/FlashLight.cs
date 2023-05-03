using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light m_light;
    public bool drainOverTime;
    public float maxBrightness;
    public float minBrightness;
    public float drainRate;
    public float rechargeRate;
    void Start()
    {
        m_light = GetComponent<Light>();
    }

    void Update()
    {
        if (drainOverTime == true && m_light.enabled == true)
        {
            m_light.intensity = Mathf.Clamp(m_light.intensity, minBrightness, maxBrightness);
            if (m_light.intensity > minBrightness)
            {
                m_light.intensity -= Time.deltaTime * (drainRate / 1000);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            m_light.enabled = !m_light.enabled;
        }
        if(m_light.intensity < minBrightness)
        {
            m_light.enabled = false;
            drainOverTime = false;
        }
    }
    public void RechargeRate(float rate)
    {
        if(minBrightness == .15f)
        {
          m_light.enabled = false;
        }
        if(m_light.intensity < .15f)
        {
            m_light.enabled = false;
            drainOverTime = false;
            m_light.intensity += Time.deltaTime * (rechargeRate * .2f);
        }
    }
}
