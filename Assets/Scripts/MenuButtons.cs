using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    public GameObject MainMenuButton;
    public GameObject TutorialButton;
    public GameObject QuitButton;
    private List<GameObject> buttons;
    private bool pressed;

    private void Start()
    {
        pressed = false;
    }
    public void OnPress()
    {
        if(pressed)
        {
            TurnButtonsOFF(TutorialButton);
            TurnButtonsOFF(MainMenuButton);
            TurnButtonsOFF(QuitButton);
        }
        else
        {
            TurnButtonsON(TutorialButton);
            TurnButtonsON(MainMenuButton);
            TurnButtonsON(QuitButton);
        }
        pressed = !pressed;
    }

    public void Reset()
    {
        pressed = false; 
        TurnButtonsOFF(TutorialButton);
        TurnButtonsOFF(MainMenuButton);
        TurnButtonsOFF(QuitButton);

    }
    private void TurnButtonsOFF(GameObject button)
    {
        button.SetActive(false);
    }

    private void TurnButtonsON(GameObject button)
    {
        button.SetActive(true);
    }
}
