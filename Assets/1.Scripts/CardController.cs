using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardController : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject nextCard;
    [SerializeField] private TMP_Text priceText;
    public List<CardUI> cards = new List<CardUI>();

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("CardSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CardSpawn()
    {
        for(int i = 0; i < cards.Count; i++)
        {
            cards[i].SetActive(true);
            yield return new WaitForSeconds(1f);
        }
    }
}
