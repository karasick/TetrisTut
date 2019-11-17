using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : LevelPanel
{
    [SerializeField]
    private Button[] InputButtons;

    [SerializeField]
    private Text CurrentScoreText = null;
    [SerializeField]
    private Text CurrentLevelText = null;

    // Start is called before the first frame update
    void Start()
    {
        switch(Level.ActivePlatform)
        {
            case RuntimePlatform.WindowsPlayer:
                {
                    SetInputsVisibility(false);
                    break;
                }
            case RuntimePlatform.Android:
                {
                    SetInputsVisibility(true);
                    break;
                }
            default:
                {
                    SetInputsVisibility(true);
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetTextInformation();
    }


    private void SetTextInformation()
    {
        CurrentLevelText.text = "Lvl: " + Level.GetSpeedLevel();
        CurrentScoreText.text = "Score: " + ScoreManager.Score;
    }


    private void SetInputsVisibility(bool state)
    {
        foreach(Button inputButton in InputButtons)
        {
            inputButton.gameObject.SetActive(state);
        }
    }


    public void PauseButtonClick()
    {
        Level.PauseButtonClick();
    }

    public void RightButtonClick()
    {
        Level.RightButtonClick();
    }

    public void LeftButtonClick()
    {
        Level.LeftButtonClick();
    }

    public void RotateButtonClick()
    {
        Level.RotateButtonClick();
    }

    public void DownButtonClick()
    {
        Level.DownButtonClick();
    }
}
