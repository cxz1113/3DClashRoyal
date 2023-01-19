using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "MyCardData/CardData")]
public class CardData : ScriptableObject
{
    [SerializeField] Character character;
    public Character Cha { get { return character; } }

    [SerializeField] int speed;
    public int Speed { get { return speed; } }

    [SerializeField] int cost;
    public int Cost { get { return cost; } }
}
