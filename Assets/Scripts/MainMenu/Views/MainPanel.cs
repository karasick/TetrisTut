using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    [SerializeField]
    private MainMenu mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        //name = "mainPanel";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonClick()
    {
        mainMenu.PlayButtonClick();
    }


    public void OptionsButtonClick()
    {
        mainMenu.OptionsButtonClick();
    }


    public void ScoreboardButtonClick()
    {
        mainMenu.ScoreboardButtonClick();
    }


    public void ExitButtonClick()
    {
        mainMenu.ExitButtonClick();
    }
}
