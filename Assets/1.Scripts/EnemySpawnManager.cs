using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    
    [SerializeField] private Transform parent;
    float spawnDelay = 0;
    CardData cardData;
    // Update is called once per frame
    void Update()
    {
        spawnDelay += Time.deltaTime;
        if(spawnDelay > 5)
        {
            spawnDelay = 0;
            EnemySpawn();
        }
    }

    void EnemySpawn()
    {
        int rand = Random.Range(0, ControllerManager.Instance.dataCont.datas.Length);
        Character character = Instantiate(ControllerManager.Instance.dataCont.datas[rand].Cha, parent);
        character.cardData = ControllerManager.Instance.dataCont.datas[rand];
        character.tag = "enemy";
        character.charData.findTag = "my";
    }
}
