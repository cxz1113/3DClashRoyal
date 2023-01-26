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
    
    float curEnergy = 0;
    float maxEnergy = 10;

    public bool IsEnergyCheck(int value)
    {
        return curEnergy >= value ? true : false;
    }
    public float Energy
    {
        get { return curEnergy; }
        set
        {
            curEnergy = value;
            energyImage.fillAmount = curEnergy / maxEnergy;
            energyText.text = string.Format("{0}:{1}", (int)curEnergy, maxEnergy);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enegy();
    }

    void Enegy()
    {
        // energy bar Setting
        if (curEnergy >= 10f)
            return;
        Energy += Time.deltaTime;

        float energy = (curEnergy / maxEnergy) * 10f;
        energy = (float)System.Math.Truncate(energy);
        energyDump.fillAmount = (energy / 10f) + 0.1f;
    }
}
