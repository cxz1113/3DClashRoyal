using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private GameObject card;
    [SerializeField] private Transform parent;

    float time = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CardSpawn()
    {
        Instantiate(card, parent);
        yield return new WaitForSeconds(0.1f);
    }
}
