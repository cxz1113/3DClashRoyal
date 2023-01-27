using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] private GameObject cardBackGround;
    [SerializeField] private Transform parent;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Image image;
    CardData cardData;
    public int Cost { get; set; }
    public bool Empty { get; set; }

    /*private float maxHP;
    private float curHP;
    public float HP
    {
        get { return curHP; }
        set { curHP = value; }
    }
    Image image;
    public void HP1(int value, bool isPlus = true)
    {
        if(isPlus)
            curHP += value;
        else
            curHP -= value;
        float curTmpHP = curHP / maxHP;
        image.fillAmount = curTmpHP;
        costText.text = $"{curHP}/{maxHP}";
    }*/
    void Start()
    {
        btn.onClick.AddListener(OnButtonSpawn);
    }

    void Update()
    {
        costText.text = Cost.ToString();
    }
    void OnButtonSpawn()
    {
        // 카드 생성 및 몬스터 생성
        if(ControllerManager.Instance.uiCont.IsEnergyCheck(cardData.Cost) == true)
        {
            ControllerManager.Instance.uiCont.Energy -= cardData.Cost;
            Character character = Instantiate(cardData.Cha, parent);
            character.cardData = cardData;
            character.tag = "my";
            character.charData.findTag = "enemy";
            Enable(false);
            Empty = true;           
        }        
        ControllerManager.Instance.cardCont.Invoke("AddCard", 1f);
    }


    public CardUI Enable(bool isActive)
    {
        cardBackGround.SetActive(isActive);        
        return this;
    }

    public CardUI SetParent(Transform parent)
    {
        this.parent = parent;
        return this;
    }

    public CardUI SetCardData(CardData cardData)
    {
        this.cardData = cardData;
        image.sprite = cardData.Sprite;
        Cost = cardData.Cost;
        Empty = false;
        return this;
    }
}
