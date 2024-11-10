using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collection", menuName = "ScriptableObjects/CardCollection", order = 2)]
public class Collection : ScriptableObject
{
    public string collectionName;
    public List<SOCard> set; //Divide cards into different raritys?
}
