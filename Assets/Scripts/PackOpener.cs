using UnityEngine;
using System;
public class PackOpener : MonoBehaviour
{
    public CardPack packToOpen;
    System.Random rnd = new System.Random();
    [SerializeField] private SOCard.rarity[] rarities = new SOCard.rarity[4];

    void Start()
    {
    }
    public void OpenPack()
    {
        int cardsInPack = packToOpen.cardsInPack;
        int[] cardRarities = DetermineCardRarity(cardsInPack);

        SOCard[] cardsPulled = new SOCard[cardsInPack];
        for (int i = 0; i < 3; i++)
        {
            PickCardFromRarity(rarities[i], cardRarities[i]);
        }

    }

    //chooses a random card from the given rarity
    public SOCard[] PickCardFromRarity(SOCard.rarity rarity, int cardNumber)
    {
        packToOpen.cardSeries
    }
    //Returns array with [Common, Uncommon, Rare, URare]
    public int[] DetermineCardRarity(int cardsInPack)
    {

        int[] rarityToReturn = new int[4];

        //Populate array with card results
        for (int i = 0; i < cardsInPack; i++)
        {
            int pullNumber = rnd.Next(1, 101); //Random number between 1-100
            if (pullNumber <= 60)
            {
                rarityToReturn[0]++; //Common
            }
            else if (pullNumber <= 65)
            {
                rarityToReturn[3]++; //URare
            }
            else if (pullNumber <= 75)
            {
                rarityToReturn[2]++; //Rare
            }
            else rarityToReturn[1]++; //Uncommon
        }


        return rarityToReturn;
    }
}
