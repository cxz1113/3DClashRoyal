using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Castle : MonoBehaviour
{
    [SerializeField] private float maxHp;
    private float curHP;

    [SerializeField] private Image hpImage;
    
    public float HP
    {
        get { return curHP; }
        set
        {
            curHP = value;
            hpImage.fillAmount = curHP / maxHp;
            if(curHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void Start()
    {
        curHP = maxHp;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            curHP -= 100;
        }
        hpImage.fillAmount = curHP / maxHp;

        if(Input.GetKeyDown(KeyCode.F2))
        {
            hpImage.fillAmount += 20;
        }
    }
}
