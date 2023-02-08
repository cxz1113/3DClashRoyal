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
        for (int i = 0; i < sprites.Count; i++)
        {
            Instantiate(prefab, parent).sprite = sprites[i];
        }
    }

    void OnButtonScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void DataSave()
    {
        string str = string.Empty;
        for(int j = 0; j < myArrayNums.Length; j++)
        {
            str += myArrayNums[j];
            if(j != (myArrayNums.Length -1))
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
}
