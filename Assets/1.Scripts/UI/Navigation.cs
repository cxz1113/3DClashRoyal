using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Navigation : MonoBehaviour
{
    [SerializeField] private Toggle[] toggles;
    [SerializeField] private GameObject[] itemObjs;

    // Start is called before the first frame update
    void Start()
    {
        toggles[1].isOn = true;
        OnToggle(toggles[1]);
    }

    public void OnToggle(Toggle toggle)
    {
        if(toggle.isOn)
        {
            int count = 0;
            foreach(var item in toggles)
            {
                if(item == toggle)
                {
                    itemObjs[count].SetActive(true);
                }
                else
                {
                    itemObjs[count].SetActive(false);
                }
                count++;
            }
        }
        else
        {

        }
    }
}
