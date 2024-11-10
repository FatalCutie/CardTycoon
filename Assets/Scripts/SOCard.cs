using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card", order = 1)]
public class SOCard : ScriptableObject
{
    public string cardName;
    public string cardDescription;
    public enum rarity {
        COMMON, UNCOMMON, RARE, URARE
    }
    public rarity cardRarity;
}
