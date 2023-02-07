using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GoldShop
{
    public string title;
    public int price;
}
public class UIShop : MonoBehaviour
{
    [SerializeField] private UIShopItem[] uIShopItems;
    List<GoldShop> goldShops = new List<GoldShop>();
    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
