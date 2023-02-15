using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
                if (gameObject.name.Equals("MainHouse"))
                {
                    Time.timeScale = 0;
                    Debug.Log("Game Over!!");
                    SceneManager.LoadScene("Main");
                }                
            }
        }
    }
    void Start()
    {
        curHP = maxHp;
    }
}
