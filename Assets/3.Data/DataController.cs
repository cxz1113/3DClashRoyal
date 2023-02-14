using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public CardData[] datas;
    public List<CardData> pickupCDs;

    //public Dictionary<string, ScriptableObject> dicDatas = new Dictionary<string, ScriptableObject>();

    public void Init()
    {
        string[] strs = PlayerPrefs.GetString("mycard").Split(",");

        foreach(var str in strs)
        {
            if (str == "-1")
                return;

            foreach(var data in datas)
            {
                if (str == data.Sprite.name)
                {
                    pickupCDs.Add(data);
                    break;
                }
            }
        }
    }
}
