using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextCard : MonoBehaviour
{
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Image image;
    public Queue<CardData> nextCardGroup = new Queue<CardData>();

    CardData nextCard = null;
    void Awake()
    {
        // ť�� �̿��Ͽ� ī�� ������ ����
        for(int i = 0; i < 5; i++)
        {
            int rand = Random.Range(0, ControllerManager.Instance.dataCont.datas.Length);
            CardData card = ControllerManager.Instance.dataCont.datas[rand];
            nextCardGroup.Enqueue(card);
        }
        nextCard = nextCardGroup.Dequeue();
        InvokeRepeating("CardEnqueue", 0f, 0.5f);
    }
    void Update()
    {
        if (nextCard != null)
            costText.text = $"{nextCard.Cost}";
    }
    void CardEnqueue()
    {
        // ����ī�带 �����
        if (nextCardGroup.Count >= 5)
            return;

        int rand = Random.Range(0, ControllerManager.Instance.dataCont.datas.Length);
        CardData card = ControllerManager.Instance.dataCont.datas[rand];
        image.sprite = nextCard.Sprite;
        //costText.text = card.Cost.ToString();
        nextCardGroup.Enqueue(card);
    }

    public CardData CardDequeue()
    {
        CardData card = nextCard;
        nextCard = nextCardGroup.Dequeue();
        return card;
    }
}
