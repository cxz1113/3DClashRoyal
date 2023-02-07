using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIShopItem : MonoBehaviour
{
    TMP_Text titleText;
    TMP_Text priceText;

    public void TitleText(string str)
    {
        if(titleText == null)
            titleText = transform.GetChild(0).GetComponent<TMP_Text>();
        titleText.text = str;
    }

    public void PriceText(string str)
    {
        if(priceText == null)
            priceText = transform.GetChild(2).GetComponent<TMP_Text>();
        priceText.text = str;
    }
    /*public string TitleText
    {
        get { return titleText.text; }
        set 
        { 
            if(titleText != null)
                titleText.text += value; 
        }
    }

    public string PriceText
    {
        get { return priceText.text; }
        set 
        { 
            if(priceText != null)
                priceText.text = value; 
        }
    }*/
}
