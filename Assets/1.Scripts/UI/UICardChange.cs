using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UICardChange : MonoBehaviour
{
    public void OnDrop()
    {
        GetComponent<Image>().sprite = FindObjectOfType<UICardMove>().GetComponent<Image>().sprite;
    }

    public void PointClick()
    {
        GetComponent<Image>().sprite = null;
    }
}
