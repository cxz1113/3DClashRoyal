using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] private GameObject cardBackGround;
    [SerializeField] private NextCard nextCard;

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
        ControllerManager.Instance.spawnCont.Spawn();
        SetActive(false);
        //nextCard.CardDequeue(true);
    }

    public void SetActive(bool isActive)
    {
        cardBackGround.SetActive(isActive);
    }
}
