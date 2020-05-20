using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LongButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool pointerDown;
    private float pointerDownTimer;

    public float requiredTimeDown;

    public UnityEvent onLongClick;

/*    [SerializeField]
    private Image fillImage;*/

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        Debug.Log("OnPointerUp");
    }
    public 
    // Update is called once per frame
    void Update()
    {
        if(pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if(pointerDownTimer <= requiredTimeDown)
            {
                if(onLongClick != null)
                {
                    onLongClick.Invoke();
                }
                Reset();
            }
            //fillImage.fillAmount = pointerDownTimer / requiredTimeDown;
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        //fillImage.fillAmount = pointerDownTimer / requiredTimeDown;
        gameObject.SetActive(true);
    }

}
