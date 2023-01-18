using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardController : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private NextCard nextCard;
    public List<CardUI> cards = new List<CardUI>();
    public int Index { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CardSpawn");
    }

    IEnumerator CardSpawn()
    {
        for(int i = 0; i < cards.Count; i++)
        {
            cards[i].Hide(true);
            cards[i].SetCost(i).SetCardData(nextCard.CardDequeue());
            yield return new WaitForSeconds(1f);
        }
        InvokeRepeating("AddCard", 1f, 1f);
    }

    public void AddCard()
    {
        for(int i = 0; i < cards.Count; i++)
        {
            
        }
    }
}
