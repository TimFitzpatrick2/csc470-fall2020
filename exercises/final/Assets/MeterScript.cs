using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterScript : MonoBehaviour
{
    public GameObject powerBarGO;
    public Image PowerBarMask;
    public float barChangeSpeed = 1;
    float maxPowerBarValue = 100;
    float currentPowerBarValue;
    bool powerIsIncreasing;
    bool PowerBarON;

    
    

    // Start is called before the first frame update
    void Start()
    {
        currentPowerBarValue = 0;
        powerIsIncreasing = false;
        PowerBarON = true;
        StartCoroutine(UpdatePowerBar());
    }

    IEnumerator UpdatePowerBar()
    {
        while (PowerBarON)
        {
            if (!powerIsIncreasing)
            {
                currentPowerBarValue -= barChangeSpeed;
                if(currentPowerBarValue <= 0)
                {
                    powerIsIncreasing = true;
                }
            }
            if (powerIsIncreasing)
            {
                currentPowerBarValue += barChangeSpeed;
                if (currentPowerBarValue >= maxPowerBarValue)
                {
                    powerIsIncreasing = false;
                }
            }
            
            float fill = currentPowerBarValue / maxPowerBarValue;
            PowerBarMask.fillAmount = fill;
            yield return new WaitForSeconds(0.02f);

            if (Input.GetKeyDown(KeyCode.P))
            {
                PowerBarON = false;
                ShootArrow();
                StartCoroutine(TurnOffPowerBar());
            }
        }
        yield return null;
    }
    IEnumerator TurnOffPowerBar()
    {
        yield return new WaitForSeconds(0.5f);
        powerBarGO.SetActive(false);
        
    }

    public void ShootArrow()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
