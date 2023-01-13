using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] private SpawnManager spawn;
    void Start()
    {
        btn.onClick.AddListener(OnSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSpawn()
    {
        spawn.Spawn();
    }
}
