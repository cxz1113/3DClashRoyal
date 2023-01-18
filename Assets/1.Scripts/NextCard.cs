using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextCard : MonoBehaviour
{
    [SerializeField] private TMP_Text costText;
    public Queue<CardData> nextCardGroup = new Queue<CardData>();

    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < 10; i++)
        {
            CardEnqueue();
        }
        InvokeRepeating("CardEnqueue", 0.1f, 0.1f);
    }

    void Update()
    {
        
    }

    void CardEnqueue()
    {
        if (nextCardGroup.Count >= 4)
            return;
        int rand = Random.Range(0, ControllerManager.Instance.dataCont.datas.Length - 1);
        CardData so = ControllerManager.Instance.dataCont.datas[rand];
        nextCardGroup.Enqueue(so);
    }

    public CardData CardDequeue()
    {
        return nextCardGroup.Dequeue();
    }
}
