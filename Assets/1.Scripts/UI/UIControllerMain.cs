using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControllerMain : MonoBehaviour
{
    [SerializeField] private Image prefab;
    [SerializeField] private Transform parent;
    public List<Sprite> sprites = new List<Sprite>();

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            Instantiate(prefab, parent).sprite = sprites[i];
        }
    }
}
