using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UnitCard;
    public GameObject WeatherCard;
    public GameObject SpecialUnitCard;
    [SerializeField] List<GameObject> UnitCards;
    [SerializeField] List<GameObject> SpecialCards;
    private List<GameObject> cards = new List<GameObject>();
    void Start()
    {
        int index;
        for(int i = 0; i < 4; i++)
        {
            cards.Add(WeatherCard);
        }
        for (int i = 0; i < 9; i++)
        {
            index = Random.Range(0, SpecialCards.Count);
            cards.Add(SpecialCards[index]);
        }
        for (int i = 0; i < 17; i++)
        {
            index = Random.Range(0, UnitCards.Count);
            cards.Add(UnitCards[index]);
        }
    }

    // Update is called once per frame
    public List<GameObject> GetCards()
    {
        List<GameObject> tempCards = new List<GameObject>();
        for(int i = 0; i < cards.Count; i++)
        {
            tempCards.Add(cards[i]);
        }
        return tempCards;
    }
}
