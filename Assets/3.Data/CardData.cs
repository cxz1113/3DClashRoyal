using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardData", menuName = "MyCardData/CardData")]
public class CardData : ScriptableObject
{
    [SerializeField] Character character;
    public Character Cha { get { return character; } }

    [SerializeField] Sprite sprite;
    public Sprite Sprite { get { return sprite; } }

    [SerializeField] int speed;
    public int Speed { get { return speed; } }

    [SerializeField] int cost;
    public int Cost { get { return cost; } }

    [SerializeField] float damage;
    public float Damage { get { return damage; } }

    [SerializeField] float attDelay;
    public float AttDelay { get { return attDelay; } }
}
