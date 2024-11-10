using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardPack", menuName = "ScriptableObjects/CardPack", order = 3)]
public class CardPack : ScriptableObject
{
    public string cardSeriesName;
    public int cardsInPack;
    public Collection collection;
}
