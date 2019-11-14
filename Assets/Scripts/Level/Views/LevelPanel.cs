using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    [SerializeField]
    private Level level;
    [SerializeField]
    private Button[] inputButtons;

    [SerializeField]
    private Text currentScoreText = null;
    [SerializeField]
    private Text currentLevelText = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetTextInformation();
    }


    private void SetTextInformation()
    {
        currentLevelText.text = "Lvl: " + ScoreManager.speedLevel;
        currentScoreText.text = "Score: " + ScoreManager.score;
    }


    public void SetInputsVisibility(bool state)
    {
        foreach(Button inputButton in inputButtons)
        {
            inputButton.gameObject.SetActive(state);
        }
    }


    public void PauseButtonClick()
    {
        level.PauseButtonClick();
    }

    public void RightButtonClick()
    {
        level.RightButtonClick();
    }

    public void LeftButtonClick()
    {
        level.LeftButtonClick();
    }

    public void RotateButtonClick()
    {
        level.RotateButtonClick();
    }

    public void DownButtonClick()
    {
        level.DownButtonClick();
    }
}
