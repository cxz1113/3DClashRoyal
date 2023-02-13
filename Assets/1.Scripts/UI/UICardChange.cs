using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UICardChange : MonoBehaviour
{
    [SerializeField] private UIControllerMain cont;
    Image image;
    [HideInInspector] public int index;

    private void Start()
    {
        cont = FindObjectOfType<UIControllerMain>();

    }

    public void OnDrop()
    {
        Sprite sprite = FindObjectOfType<UICardMove>().GetComponent<Image>().sprite;

        if (cont.CardRedundancy(sprite.name))
        {
            GetComponent<Image>().sprite = FindObjectOfType<UICardMove>().GetComponent<Image>().sprite;
            if (sprite != null)
            {
                cont.myArrayNums[index] = sprite.name;
                cont.DataSave();
                GetComponent<Image>().sprite = sprite;
                GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                FindObjectOfType<UICardMove>().GetComponent<Image>().sprite = null;
            }
        }                    
    }

    public void PointClick()
    {
        cont.myArrayNums[index] = "-1";
        cont.DataSave();
        GetComponent<Image>().sprite = null;
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 125f/255);
    }
}
