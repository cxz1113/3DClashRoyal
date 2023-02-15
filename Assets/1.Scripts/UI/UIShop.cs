using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public struct GoldShop
{
    public string title;
    public int price;
}
public class UIShop : MonoBehaviour
{
    [SerializeField] private UIShopItem[] uIShopItems;
    List<GoldShop> goldShops = new List<GoldShop>();
    [SerializeField] private Button goldBtn;
    [SerializeField] private TMP_Text myGoldTxt;
    [SerializeField] private TMP_Text treasureTxt;
    private int myGold = 5000;
    int treasureCard = 5000;
    float time = 0;
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
        goldBtn.onClick.AddListener(OnGoldLotto);
    }

    // Update is called once per frame
    void Update()
    {
        myGoldTxt.text = string.Format($"{MyGold}");
    }

    public void OnGoldLotto()
    {       
        if (MyGold < treasureCard)
            return;
        MyGold -= treasureCard;
        int[] coinArray = { 1000, 2000, 3000, 5000, 10000 };
        int rand = Random.Range(0, coinArray.Length);
        Debug.Log(rand);
        MyGold += coinArray[rand];        
    }
}
