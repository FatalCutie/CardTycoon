using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CardPack", order = 3)]
public class CardPack : ScriptableObject
{
    public string cardSeries;
    public int cardsInPack;
    public Collection collection;
}
