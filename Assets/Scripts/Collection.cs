using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CardCollection", order = 2)]
public class Collection : MonoBehaviour
{
    public string collectionName;
    public List<SOCard> set; //Divide cards into different raritys?
}
