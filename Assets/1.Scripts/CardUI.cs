using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] private GameObject cardBackGround;
    [SerializeField] private TMP_Text costText;

    CardData cardData;
    public int Cost { get; set; }
    void Start()
    {
        btn.onClick.AddListener(OnButtonSpawn);
    }

    void Update()
    {
        
    }
    void OnButtonSpawn()
    {
        Instantiate(cardData.Cha, transform);
        Hide(false);
        //nextCard.CardDequeue(true);
    }

    public CardUI Hide(bool isActive)
    {
        cardBackGround.SetActive(isActive);
        return this;
    }

    public CardUI SetCost(int cost)
    {
        costText.text = cost.ToString();
        return this;
    }

    public CardUI SetCardData(CardData cardData)
    {
        this.cardData = cardData;
        return this;
    }
}
