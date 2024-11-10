using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
public class PackOpener : MonoBehaviour
{
    public CardPack packToOpen;
    System.Random rnd = new System.Random();
    [SerializeField] private SOCard.rarity[] rarities = new SOCard.rarity[4];
    List<List<SOCard>> cardsOrganizedByRarity = new List<List<SOCard>>();

    void Start()
    {
        Debug.Log($"Opening a {packToOpen.cardSeriesName} pack!");
        OpenPack();
    }
    public void OpenPack()
    {
        int cardsInPack = packToOpen.cardsInPack;
        int[] cardRarities = DetermineCardRarity(cardsInPack);
        OrganizeCardsByRarity();

        List<SOCard> cardsPulled = new List<SOCard>();
        for (int i = 0; i < 4; i++)
        {
            if (cardRarities[i] != 0)
            {
                List<SOCard> newCards = PickCardFromRarity(i, cardRarities[i]);
                foreach (SOCard c in newCards) //Add cards from rarity to 
                {
                    cardsPulled.Add(c);
                }
            }
        }

        Debug.Log("Here's what you pulled!");
        foreach (SOCard c in cardsPulled)
        {
            Debug.Log(c.cardName);
        }
    }

    //chooses a random card from the given rarity
    public List<SOCard> PickCardFromRarity(int rarity, int numberOfCards)
    {
        //Debug.Log($"Picking {numberOfCards} cards from rarity {rarity}");
        List<SOCard> returnList = new List<SOCard>();
        int cardsInRarity = cardsOrganizedByRarity[rarity].Count;

        //Loop through all cards in rarity and pick a random one as many times as needed
        for (int i = 0; i < numberOfCards; i++)
        {
            int cardToAdd = rnd.Next(0, cardsInRarity); //Generates card to pick
            //Debug.Log($"Adding card {cardToAdd} from total of {cardsInRarity}");
            try
            {
                returnList.Add(cardsOrganizedByRarity[rarity][cardToAdd]); //Adds generated card to pull
            }
            catch (ArgumentOutOfRangeException)
            {
                Debug.Log($"Tried to add get index {cardToAdd} from rarity {rarity}");
            }

        }
        return returnList;
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
            else
            {
                rarityToReturn[1]++; //Uncommon
            }
        }
        return rarityToReturn;
    }

    //populates cardsOrganizedByRarity
    public void OrganizeCardsByRarity() //populates cardsOrganizedByRarity
    {
        foreach (SOCard.rarity r in rarities)
        {
            List<SOCard> cards = new List<SOCard>();
            foreach (SOCard c in packToOpen.collection.set) //Find all cards of each rarity sort
            {
                if (c.cardRarity == r)
                {
                    cards.Add(c);
                }

            }
            cardsOrganizedByRarity.Add(cards); //Add to list of organized cards
        }
    }
}
