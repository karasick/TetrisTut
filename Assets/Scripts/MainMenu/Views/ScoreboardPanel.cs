using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardPanel : MonoBehaviour
{
    [SerializeField]
    private MainMenu mainMenu;

    [SerializeField]
    private Text[] topPlayersScoresObjects = null;

    // Start is called before the first frame update
    void Start()
    {
        //name = "scoreboard";

        FillScoresText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FillScoresText()
    {
        int i = 0;
        foreach (Text topPlayerScoreObject in topPlayersScoresObjects)
        {
            i++;
            if (i <= mainMenu.scoreboard.Count)
            {
                int topScore = mainMenu.scoreboard[i - 1];
                topPlayerScoreObject.text = "Top " + i + ": " + topScore;
            }
            else
            {
                return;
            }
        }
    }


    public void BackButtonClick()
    {
        mainMenu.BackButtonClick();
    }
}
