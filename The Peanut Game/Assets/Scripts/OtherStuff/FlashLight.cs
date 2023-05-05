using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light m_light;
    public bool rechargeTime;
    public bool drainOverTime;
    public float maxBrightness;
    public float minBrightness;
    public float drainRate;

    void Start()
    {
        m_light = GetComponent<Light>();
        m_light.enabled = false;
        drainOverTime = false;
        rechargeTime = false;
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

        if (m_light.enabled == false)
        {
            rechargeTime = true;
			if (rechargeTime == true)
			{
                drainOverTime = false;
                RechargeRate(0.0001f);
			}
            if(m_light.intensity <= maxBrightness)
            {
                rechargeTime = false;
                drainOverTime = true;
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

    public void RechargeRate(float amount)
    {
        m_light.intensity += amount;
        m_light.intensity = Mathf.Clamp(m_light.intensity, minBrightness, maxBrightness);
        //if(m_light.intensity <= .15f)
        //{
        //    m_light.enabled = false;
        //    drainOverTime = false;
        //}
    }
}
