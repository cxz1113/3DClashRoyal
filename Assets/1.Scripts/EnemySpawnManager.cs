using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    
    [SerializeField] private Transform parent;
    List<CardData> cardDatas = new List<CardData>();
    CardData cardData;
    // Update is called once per frame
    void Update()
    {
        EnemySpawn();
    }

    void EnemySpawn()
    {
        Character character = Instantiate(cardData.Cha, parent);
        cardData.Pawn = false;
    }
}
