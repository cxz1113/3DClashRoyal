using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UICardChange : MonoBehaviour
{
    [SerializeField] private UIControllerMain cont;
    [HideInInspector] public int index;

    private void Start()
    {
        cont = FindObjectOfType<UIControllerMain>();
    }

    public void OnDrop()
    {
        GetComponent<Image>().sprite = FindObjectOfType<UICardMove>().GetComponent<Image>().sprite;
        Sprite sprite = FindObjectOfType<UICardMove>().GetComponent<Image>().sprite;
        if (sprite != null)
        {
            Debug.Log(cont.myArrayNums[index]);
            cont.myArrayNums[index] = sprite.name;
            cont.DataSave();
            GetComponent<Image>().sprite = sprite;
            
            FindObjectOfType<UICardMove>().GetComponent<Image>().sprite = null;
        }
    }

    public void PointClick()
    {
        cont.myArrayNums[index] = "-1";
        cont.DataSave();
        GetComponent<Image>().sprite = null;
    }
}
