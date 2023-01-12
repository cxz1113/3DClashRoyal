using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image energyDump;
    [SerializeField] private Image energyImage;

    float time = 0;

    float curEnergy = 0;
    float maxEnergy = 10;

    void Start()
    {
        curEnergy = maxEnergy;
        energyDump.fillAmount = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 1)
        {
            energyImage.fillAmount += 0.03f;
            time = 0;
        }
    }
}
