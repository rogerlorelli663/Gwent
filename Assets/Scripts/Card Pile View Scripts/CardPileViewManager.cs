using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPileViewManager : MonoBehaviour
{
    // Start is called before the first frame update


    private GameObject card = null;

    private GameObject cardDisplay = null;

    public List<GameObject> cards = null;




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void GetCardListFromPile(List<GameObject> cardList)
    {

        cards = cardList;
    }

    public List<GameObject> GetCardList()
    {
        return cards;
    }

    /*
    public void SetCardForPlay(GameObject card)
    {
        if (this.card == null)
        {
            this.card = card;
            cardDisplay = Instantiate(this.card);
            cardDisplay.transform.SetParent(gameObject.transform);
            foreach (Transform child in this.card.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
    */





}
