using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutcomeBehavior : MonoBehaviour
{
    public GameObject OutcomeField;
    // Start is called before the first frame update

    private void Start()
    {
        DisableField();
    }

    public void RoundOutcome(string winner)
    {
        OutcomeField.SetActive(true);
        Text text = OutcomeField.transform.GetChild(1).GetComponent<Text>();
        text.text = winner;
        Invoke("DisableField",5);
    }

    private void DisableField()
    {
        OutcomeField.SetActive(false);
    }
}
