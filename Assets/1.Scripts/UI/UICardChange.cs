using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UICardChange : MonoBehaviour
{
    private UIControllerMain cont;
    [SerializeField] private Sprite defaultSprite;
    Image image;
    [HideInInspector] public int index;

    private void Start()
    {
        cont = FindObjectOfType<UIControllerMain>();
        image = GetComponent<Image>();
    }

    public void OnDrop()
    {
        Sprite sprite = FindObjectOfType<UICardMove>().GetComponent<Image>().sprite;

        if (sprite != null)
        {
            if (cont.CardRedundancy(sprite.name))
            {
                cont.myArrayNums[index] = sprite.name;
                cont.DataSave();
                image.sprite = sprite;
                image.color = new Color(1f, 1f, 1f, 1f);
                FindObjectOfType<UICardMove>().GetComponent<Image>().sprite = null;
            }
        }
    }

    public void PointClick()
    {
        cont.myArrayNums[index] = "-1";
        cont.DataSave();
        image.sprite = defaultSprite;
        image.color = new Color(1f, 1f, 1f, 0.5f);
    }
}
