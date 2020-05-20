using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    private GameObject MainMenuButton;
    private GameObject TutorialButton;
    private GameObject QuitButton;
    private List<GameObject> buttons;
    private bool pressed;

    private void Start()
    {
        pressed = false;
        MainMenuButton = GameObject.Find("MainMenu Button");
        TutorialButton = GameObject.Find("Tutorial Button");
        QuitButton = GameObject.Find("Quit");
        TurnButtonsOFF(TutorialButton);
        TurnButtonsOFF(MainMenuButton);
        TurnButtonsOFF(QuitButton);
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
    private void TurnButtonsOFF(GameObject button)
    {
        button.SetActive(false);
    }

    private void TurnButtonsON(GameObject button)
    {
        button.SetActive(true);
    }
}
