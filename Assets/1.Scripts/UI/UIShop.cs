using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public struct GoldShop
{
    public string title;
    public int price;
}
public class UIShop : MonoBehaviour
{
    [SerializeField] private UIShopItem[] uIShopItems;
    List<GoldShop> goldShops = new List<GoldShop>();
    [SerializeField] private TMP_Text myGoldTxt;
    [SerializeField] private TMP_Text treasureTxt;
    [SerializeField] private UIControllerMain contUIMain;
    private int myGold = 5000;
    int treasureCard = 5000;


    public int MyGold
    {
        get { return myGold; }
        set { myGold = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        // 상점 보물뽑기 데이터 생성
        treasureTxt.text = string.Format($"{treasureCard}G");
        // 상점 골드 데이터 생성
        string[] titles = { "100G", "5,00G", "1,000G", "3,000G", "5,000G", "10,000G" };
        int[] price = { 100, 500, 1000, 3000, 5000, 10000 };
        for(int i = 0; i < uIShopItems.Length; i++)
        {
            GoldShop gs = new GoldShop();
            gs.title = titles[i];
            gs.price = price[i];
            goldShops.Add(gs);
        }

        // 상점 골드 데이터 적용
        for(int i = 0; i < uIShopItems.Length; i++)
        {
            uIShopItems[i].TitleText(goldShops[i].title);
            uIShopItems[i].PriceText(string.Format("{0:#,###}W", goldShops[i].price));
        }

        myGoldTxt.text = string.Format($"{MyGold}");
    }

    // Update is called once per frame
    void Update()
    {
        myGoldTxt.text = string.Format($"{MyGold}");
    }

    public void OnGoldLotto()
    {               
        int[] coinArray = { 1000, 2000, 3000, 5000, 10000 };
        int rand = Random.Range(0, coinArray.Length);
        Debug.Log(rand);
        MyGold += coinArray[rand];        
    }

    public void OnCardLotto()
    {
        if (myGold < treasureCard)
            return;

        List<Sprite> list = new List<Sprite>();

        foreach(var item in contUIMain.sprites)
        {
            foreach(var card in contUIMain.cardDatas)
            {
                if(item.name != card.Sprite.name)
                {                    
                    list.Add(item);
                }
            }
        }

        for (int i = list.Count - 1; i >= 0; i--)
        {
            for(int j = 0; j < contUIMain.pickList.Count; j++)
            {
                if(list[i].name == contUIMain.pickList[j])
                {
                    list.RemoveAt(i);
                }
            }
        }
        int rand = Random.Range(0, list.Count);
        Debug.Log($"{rand},{list[rand].name}");
        contUIMain.pickList.Add(list[rand].name);
        contUIMain.CardReFresh();
        MyGold -= treasureCard;
    }
}
