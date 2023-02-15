using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICard : MonoBehaviour, IDragHandler
{
    [SerializeField] Image image;
    Image targetImg = null;
    public void OnDrag(PointerEventData eventData)
    {
        if (targetImg != null)
            targetImg.transform.position = Input.mousePosition;
    }

    public void OnPointUp()
    {
        if(targetImg != null)
        {
            targetImg.color = new Color(1f, 1f, 1f, 1f/255f);
        }
    }

    public void ClearImage()
    {
        targetImg.sprite = null;
        targetImg = null;
    }

    /*public void ChangeImage()
    {
        changeIma = FindObjectOfType<UICardChange>().GetComponent<Image>();
        changeIma.sprite = GetComponent<Image>().sprite;
    }*/
    public void OnPointDown()
    {
        targetImg = FindObjectOfType<UICardMove>().GetComponent<Image>();
        targetImg.color = new Color(1f, 1f, 1f, 1f);
        targetImg.sprite = GetComponent<Image>().sprite;
        targetImg.transform.position = Input.mousePosition;
        //FindObjectOfType<UICardMove>().GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        //FindObjectOfType<UICardMove>().GetComponent<Image>().sprite = GetComponent<Image>().sprite;
    }
}
