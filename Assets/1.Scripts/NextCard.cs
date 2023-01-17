using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextCard : MonoBehaviour
{
    public Queue<NextCard> nextCards;
    public NextCard next;
    // Start is called before the first frame update
    void Start()
    {
        NextCardSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextCardSpawn()
    {
        for(int i = 0; i < 5; i++)
        {
            nextCards.Enqueue(Instantiate(next,transform));
        }
    }
}
