using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] SpawnManager spawn;
    
    void Start()
    {
        btn.onClick.AddListener(OnButtonSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnButtonSpawn()
    {
        spawn.Spawn();
    }
}
