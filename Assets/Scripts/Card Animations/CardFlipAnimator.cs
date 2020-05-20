using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlipAnimator : MonoBehaviour
{

    private GameObject card;
    [Range(0.1f, 10.0f)] [SerializeField] private float degreesPerFrame;
    private float animationProgress;

    private bool isAnimating;

    private bool isOnFrontSide;

    void Start()
    {
        card = null;
        animationProgress = 0;

        isAnimating = false;
        isOnFrontSide = true;
    }

    public void AnimateCardFlip(GameObject card)
    {
        this.card = card;

        isAnimating = true;
        isOnFrontSide = IsCardOnFrontSide();
        animationProgress = 0;
    }
    
    void Update()
    {
        if (card != null && animationProgress < 180)
        {
            animationProgress += degreesPerFrame;
            card.transform.eulerAngles = new Vector2(card.transform.eulerAngles.x, card.transform.eulerAngles.y + degreesPerFrame);

            if (animationProgress >= 180)
            {
                SetFinishedRotationStateForCard();
                isAnimating = false;
            }

            isOnFrontSide = IsCardOnFrontSide();
        }
    }

    private bool IsCardOnFrontSide()
    {
        if (Math.Abs(card.transform.eulerAngles.y) >= 90)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void SetFinishedRotationStateForCard()
    {
        if (isOnFrontSide)
        {
            card.transform.eulerAngles = new Vector2(card.transform.eulerAngles.x, 0f);
        }
        else
        {
            card.transform.eulerAngles = new Vector2(card.transform.eulerAngles.x, 180f);
        }
    }

    public bool IsAnimating()
    {
        return isAnimating;
    }
}
