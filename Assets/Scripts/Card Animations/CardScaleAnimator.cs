using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScaleAnimator : MonoBehaviour
{
    private GameObject card;
    [Range(0.01f, 1f)] [SerializeField] private float animationSpeed;
    [SerializeField] private Vector2 defaultAnimateToScale;
    private Vector2 animateToScale;
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
        animateToScale = defaultAnimateToScale;
    }

    public void AnimateCardToScale(GameObject card)
    {
        this.card = card;
        animationPartitionedProgress = animationSpeed / 1;
        animationProgress = animationPartitionedProgress;

        incrementX = (animateToScale.x - this.card.transform.localScale.x) * animationPartitionedProgress;
        incrementY = (animateToScale.y - this.card.transform.localScale.y) * animationPartitionedProgress;

        isAnimating = true;
    }

    public void AnimateCardToScale(GameObject card, Vector2 scale)
    {
        animateToScale = scale;
        AnimateCardToScale(card);
    }

    void Update()
    {
        if (card != null && animationProgress <= 1)
        {
            animationProgress += animationPartitionedProgress;
            card.transform.localScale = new Vector2(card.transform.localScale.x + incrementX, card.transform.localScale.y + incrementY);
        }
        else if (card != null && isAnimating == true)
        {
            card.transform.localScale = animateToScale;
            isAnimating = false;
            animateToScale = defaultAnimateToScale;
        }
    }

    public bool IsAnimating()
    {
        return isAnimating;
    }
}
