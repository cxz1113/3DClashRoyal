using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private GameObject card;
    [SerializeField] private Transform parent;

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
        for(int i = 0; i < 4; i++)
        {
            Instantiate(card, parent);
            yield return new WaitForSeconds(1f);
        }
    }
}
