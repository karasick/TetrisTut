using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    [SerializeField]
    private MainMenu MainMenu;

    public void PlayButtonClick()
    {
        MainMenu.PlayButtonClick();
    }


    public void OptionsButtonClick()
    {
        MainMenu.OptionsButtonClick();
    }


    public void ScoreboardButtonClick()
    {
        MainMenu.ScoreboardButtonClick();
    }


    public void ExitButtonClick()
    {
        MainMenu.ExitButtonClick();
    }
}
