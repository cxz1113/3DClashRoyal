using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private NextCard nextCard;
    public List<CardUI> cards = new List<CardUI>();
    void Start()
    {
        StartCoroutine("CardSpawn");
    }

    IEnumerator CardSpawn()
    {
        // 카드 생성
        for(int i = 0; i < cards.Count; i++)
        {
            cards[i]
                .Enable(true)
                .SetParent(parent)
                .SetCardData(nextCard.CardDequeue());
            yield return new WaitForSeconds(1f);
        }
    }

    public void AddCard()
    {
        // 카드 비었을때 재생성
        for(int i = 0; i < cards.Count; i++)
        {
            if(cards[i].Empty)
            {
                cards[i]
                    .Enable(true)
                    .SetParent(parent)
                    .SetCardData(nextCard.CardDequeue());
                cards[i].Empty = false;
                break;
            }
        }
    }
}
