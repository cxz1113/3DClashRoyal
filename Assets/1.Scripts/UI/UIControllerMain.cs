using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIControllerMain : MonoBehaviour
{
    [SerializeField] private Image prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private Button btn;
    [SerializeField] private Image[] myCardImages;
    [SerializeField] private CardData[] cardDatas;
    public List<Sprite> sprites = new List<Sprite>();

    [HideInInspector]
    public string[] myArrayNums = new string[8];

    void Start()
    {
        for (int i = 0; i < myCardImages.Length; i++)
        {
            myCardImages[i].GetComponent<UICardChange>().index = i;
        }

        Spawn();
        if(string.IsNullOrEmpty(PlayerPrefs.GetString("mycard")))
        {
            string[] arrayStr = { "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1" };
            myArrayNums = arrayStr;
            DataSave();
        }
        else
        {
            MyCardSetting();
        }
        btn.onClick.AddListener(OnButtonScene);
    }

    public void Spawn()
    {
        List<Image> myCardImages = new List<Image>();
        for (int i = 0; i < sprites.Count; i++)
        {
            //Instantiate(prefab, parent).sprite = sprites[i];
            Image image = Instantiate(prefab, parent);
            image.sprite = sprites[i];
            image.color = new Color(1f, 1f, 1f, 0.5f);
            image.raycastTarget = false;
            myCardImages.Add(image);
        }

        for (int i = 0; i < cardDatas.Length; i++)
        {
            for (int j = 0; j < myCardImages.Count; j++)
            {
                if (cardDatas[i].Sprite.name == myCardImages[j].sprite.name)
                {
                    myCardImages[j].color = new Color(1f, 1f, 1f, 1f);
                    myCardImages[j].raycastTarget = true;
                    break;
                }
            }
        }

        /*foreach(var item in cardDatas)
        {
            Image image = Instantiate(prefab, parent);
            image.sprite = item.Sprite;
        }*/
    }

    void OnButtonScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void DataSave()
    {
        string str = string.Empty;
        for(int i = 0; i < myArrayNums.Length; i++)
        {
            str += myArrayNums[i];
            if(i != (myArrayNums.Length -1))
            {
                str += ",";
            }
        }

        PlayerPrefs.SetString("mycard", str);
    }

    public void MyCardSetting()
    {
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("mycard")))
        {
            string[] strs = PlayerPrefs.GetString("mycard").Split(",");
            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i] != "-1")
                {
                    Sprite sprite = null;
                    foreach(var item in sprites)
                    {
                        if(strs[i] == item.name)
                        {
                            sprite = item;
                            break;
                        }
                    }

                    if(sprite != null)
                    {
                        myCardImages[i].sprite = sprite;
                        myCardImages[i].color = new Color(1f, 1f, 1f, 1f);
                    }    
                }
                else
                {
                    myCardImages[i].color = new Color(1f, 1f, 1f, 0.5f);
                }
            }
        }
    }

    public bool CardRedundancy(string name)
    {
        /*bool isCheck = true;
        foreach(var item in myCardImages)
        {
            if(item.sprite.name == name)
            {
                isCheck = false;
            }
        }
        return isCheck;*/

        // 카드 중복 확인
        bool isCheck = true;
        for (int i = 0; i < myCardImages.Length - 1; i++)
        {
            if(myCardImages[i].sprite.name == name)
            {
                isCheck = false;
                //return false;
            }
        }
        //return true;
        return isCheck;
    }
}
