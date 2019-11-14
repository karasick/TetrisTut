using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModePanel : MonoBehaviour
{
    [SerializeField]
    private MainMenu mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        //name = "gameMode";
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void StartGameButtonClick()
    {
        mainMenu.StartGameButtonClick();
    }


    public void CustomModeButtonClick()
    {
        mainMenu.CustomModeButtonClick();
    }


    public void BackButtonClick()
    {
        mainMenu.BackButtonClick();
    }
}
