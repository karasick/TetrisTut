using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModePanel : MonoBehaviour
{
    [SerializeField]
    private MainMenu MainMenu;


    public void StartGameButtonClick()
    {
        MainMenu.StartGameButtonClick();
    }


    public void CustomModeButtonClick()
    {
        MainMenu.CustomModeButtonClick();
    }


    public void BackButtonClick()
    {
        MainMenu.BackButtonClick();
    }
}
