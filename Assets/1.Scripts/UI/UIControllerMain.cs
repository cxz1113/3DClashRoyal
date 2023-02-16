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
    [SerializeField] public CardData[] cardDatas;
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

    public List<string> pickList = new List<string>();
    public List<Image> mySpawnCardImages = new List<Image>();

    public void CardReFresh()
    {
        for (int i = 0; i < mySpawnCardImages.Count; i++)
        {
            for(int j = 0; j < pickList.Count; j++)
            {
                if(mySpawnCardImages[i].sprite.name == pickList[j])
                {
                    mySpawnCardImages[i].color = new Color(1f, 1f, 1f, 1f);
                    mySpawnCardImages[i].raycastTarget = true;
                    break;
                }
            }
        }
    }

    public void Spawn()
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            //Instantiate(prefab, parent).sprite = sprites[i];
            Image image = Instantiate(prefab, parent);
            image.sprite = sprites[i];
            image.color = new Color(1f, 1f, 1f, 0.5f);
            image.raycastTarget = false;
            mySpawnCardImages.Add(image);
            
        }

        for (int i = 0; i < myCardImages.Length; i++)
        {
            for (int j = 0; j < cardDatas.Length; j++)
            {
                if (myCardImages[i].sprite.name == cardDatas[j].Sprite.name)
                {
                    myCardImages[i].color = new Color(1f, 1f, 1f, 1f);
                    myCardImages[i].raycastTarget = true;
                    break;
                }
            }
        }
        CardReFresh();
        
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
            myArrayNums = strs;
        }
    }

    public bool CardRedundancy(string name)
    {
        // 카드 중복 확인
        bool isCheck = true;
        for (int i = 0; i < myCardImages.Length - 1; i++)
        {
            if(myCardImages[i].sprite.name == name)
            {
                isCheck = false;
            }
        }
        return isCheck;
    }
}
