using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPositionAnimator : MonoBehaviour
{
    private GameObject card;
    [Range(0.01f, 1f)] [SerializeField] private float animationSpeed;
    [SerializeField] private Vector2 defaultAnimateToPosition;
    private Vector2 animateToPosition;
    private float animationPartitionedProgress;
    private float animationProgress;

    private float incrementX;
    private float incrementY;

    private bool isAnimating;

    void Start()
    {
        card = null;
        animationProgress = 0;
        isAnimating = true;
        animateToPosition = defaultAnimateToPosition;
    }

    public void AnimateCardToPosition(GameObject card)
    {
        this.card = card;
        animationPartitionedProgress = animationSpeed / 1;
        animationProgress = 0;

        incrementX = (animateToPosition.x - this.card.transform.position.x) * animationPartitionedProgress;
        incrementY = (animateToPosition.y - this.card.transform.position.y) * animationPartitionedProgress;

        isAnimating = true;
    }

    public void AnimateCardToPosition(GameObject card, Vector2 position)
    {
        animateToPosition = position;
        AnimateCardToPosition(card);
    }

    void Update()
    {
        if(card != null && animationProgress < 1)
        {
            animationProgress += animationPartitionedProgress;
            card.transform.position = new Vector2(card.transform.position.x + incrementX, card.transform.position.y + incrementY);

            if(animationProgress >= 1)
            {
                card.transform.position = animateToPosition;
                isAnimating = false;
                animateToPosition = defaultAnimateToPosition;
            }
        }
    }

    public bool IsAnimating()
    {
        return isAnimating;
    }
}
