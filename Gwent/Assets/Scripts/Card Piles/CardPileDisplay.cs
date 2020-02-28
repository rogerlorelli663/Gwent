using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CardPileDisplay : MonoBehaviour
{
    //The card spacing between each card
    [SerializeField] private float spacing;

    private CardPileManager cpm;
    private RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        cpm = GetComponent<CardPileManager>();
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Format();
    }

    private void Format()
    {
        //total width of all cards being combined to display
        float totalWidth = spacing * cpm.GetCardAmount();

        //if the total pile width is smaller than the actual pile placeholder width, then all cards can be distributed evenly.
        if (totalWidth > rect.rect.width)
        {
            spacing = rect.rect.width/cpm.GetCardAmount();
        }
        float offset = -(totalWidth / 2) + spacing / 2;
        float popOut = 0;
        GameObject[] cards = cpm.GetCardList().ToArray();
        foreach (GameObject card in cards)
        {
            card.transform.position = new Vector3(offset + rect.transform.position.x, rect.transform.position.y, rect.transform.position.z + popOut);
            offset += spacing;
            popOut += (float)-0.1;
        }
    }
}
