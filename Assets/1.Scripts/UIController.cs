using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image energyDump;
    [SerializeField] private Image energyImage;
    [SerializeField] private TMP_Text energyText;
    float time = 0;

    float curEnergy = 0;
    float maxEnergy = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enegy();
        energyText.text = string.Format("{0}:{1}", (int)curEnergy, maxEnergy);

        if(Input.GetKeyDown(KeyCode.F3))
        {
            curEnergy -= 1f;
        }
    }

    void Enegy()
    {
        // energy bar Setting
        curEnergy += Time.deltaTime;
        energyImage.fillAmount = curEnergy / maxEnergy;

        float energy = (curEnergy / maxEnergy) * 10f;
        energy = (float)System.Math.Truncate(energy);
        energyDump.fillAmount = (energy / 10f) + 0.1f;
    }
}
