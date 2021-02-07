using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> Fighters;
    [SerializeField] List<GameObject> Corvettes;
    [SerializeField] List<GameObject> Frigates;
    [SerializeField] List<GameObject> Capitalships;
    private List<GameObject> cards = new List<GameObject>();
    void Start()
    {
        int index;
        for(int i = 0; i < 25; i++)
        {
            index = Random.Range(0, Fighters.Count);
            cards.Add(Fighters[index]);
        }
        for (int i = 0; i < 20; i++)
        {
            index = Random.Range(0, Corvettes.Count);
            cards.Add(Corvettes[index]);
        }
        for (int i = 0; i < 15; i++)
        {
            index = Random.Range(0, Frigates.Count);
            cards.Add(Frigates[index]);
        }
        for (int i = 0; i < 10; i++)
        {
            index = Random.Range(0, Capitalships.Count);
            cards.Add(Capitalships[index]);
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
