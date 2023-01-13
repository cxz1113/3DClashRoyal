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
    float curDump = 0;
    float maxDump = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        energyImage.fillAmount = curEnergy / maxEnergy;
        energyDump.fillAmount = curDump / maxDump;
        curEnergy += Time.deltaTime;
        UseEnergey();
        energyText.text = string.Format("{0}:{1}", (int)energyImage.fillAmount, maxEnergy);
        if (Input.GetKeyDown(KeyCode.F3))
        {
            curDump -= 1f;
            curEnergy -= 1f;
        }
        
    }

    void UseEnergey()
    {
        if (curEnergy > curDump)
        {
            curDump += 1f;
        }
    }
}
