using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Castle : MonoBehaviour
{
    public float MaxHp;
    private float curHP;

    [SerializeField] private Image hpImage;
    
    void Start()
    {
        curHP = MaxHp;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            curHP -= 100;
        }
        hpImage.fillAmount = curHP / MaxHp;

        if(Input.GetKeyDown(KeyCode.F2))
        {
            hpImage.fillAmount += 20;
        }
    }
}
