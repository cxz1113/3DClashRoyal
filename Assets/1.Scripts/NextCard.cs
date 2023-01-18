using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextCard : MonoBehaviour
{
    public Queue<NextCard> nextCardGroup = new Queue<NextCard>();    
    public GameObject CardBackGround;
    public NextCard nextCard;
    // Start is called before the first frame update
    void Start()
    {
        NextCardSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("CardEnqueue", 1f, 1f);
    }

    public void NextCardSpawn()
    {
        for(int i = 0; i < 5; i++)
        {
            nextCardGroup.Enqueue(nextCard);
            Debug.Log(nextCardGroup.Count);
        }
        CardBackGround.SetActive(true);
    }

    void CardEnqueue()
    {
        if (nextCardGroup.Count < 4)
        {
            nextCardGroup.Enqueue(nextCard);
        }
        else
            return;
    }

    public void CardDequeue()
    {
        nextCardGroup.Dequeue();
    }
}
