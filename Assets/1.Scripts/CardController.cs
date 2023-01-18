using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardController : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private NextCard nextCard;
    public List<CardUI> cards = new List<CardUI>();
    int cost;
    public int Index { get; set; }
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("CardSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("AddCard", 2f, 2f);
    }

    IEnumerator CardSpawn()
    {
        for(int i = 0; i < cards.Count; i++)
        {
            cost = i;
            cards[i].SetActive(true);
            cards[i].gameObject.GetComponent<TMP_Text>().text = string.Format("{0}", cost);
            yield return new WaitForSeconds(1f);
        }
    }

    void AddCard()
    {
        if(!cards[Index].isActiveAndEnabled)
        {
            nextCard.CardDequeue();
        }
    }
}
