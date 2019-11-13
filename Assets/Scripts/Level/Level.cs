using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    // Views binding
    [SerializeField]
    private GameObject[] panels;

    // BackgroundImage binding
    [SerializeField]
    private Image backgroundImage;

    // Level Sprites
    private Sprite[] levelSprites;

    // Active panel
    private string activePanel;

    // Active speed level
    private int activeSpeedLevel;

    // Active menu sprite
    private string activeLevelSprite;

    // Is player lose
    public bool isLose = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        activeSpeedLevel = 1;

        LoadSprites();

        SetActivePanel("LevelPanel");

        SetLevelSprite("forest");
    }

    // Update is called once per frame
    void Update()
    {
        CheckLevel();
    }


    /*
     * Handlings
     * 
     */
    private void SetActivePanel(string panelNameNew)
    {
        foreach (GameObject panel in panels)
        {
            if (panel.name == panelNameNew)
            {
                // Show Active panel
                panel.SetActive(true);
                activePanel = panelNameNew;
            }
            else
            {
                // Hide another panels
                panel.SetActive(false);
            }
        }
    }


    private void SetLevelSprite(string levelSpriteNew)
    {
        levelSpriteNew += CheckScreenOrientation();

        foreach (Sprite levelSpite in levelSprites)
        {
            if (levelSpite.name == levelSpriteNew)
            {
                activeLevelSprite = levelSpriteNew;
                backgroundImage.sprite = levelSpite;
            }
        }
    }


    private string CheckScreenOrientation()
    {
        if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            return "-horizontal";
        }
        else if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            return "-vertical";
        }
        else
        {
            return "-square";
        }
    }


    private void LoadSprites()
    {
        levelSprites = Resources.LoadAll<Sprite>("Sprites/tetris_background");
    }


    public void SaveLevel()
    {
        Time.timeScale = 0f;

        isLose = true;
        SetActivePanel("EndGamePanel");
        
        SaveLoadScore.Save();
    }


    private void CheckLevel()
    {
        if(ScoreManager.speedLevel == 1 && activeSpeedLevel != 1)
        {
            activeSpeedLevel = 1;
            SetLevelSprite("forest");
        }
        else if (ScoreManager.speedLevel == 2 && activeSpeedLevel != 2)
        {
            activeSpeedLevel = 2;
            SetLevelSprite("west");
        }
        else if (ScoreManager.speedLevel == 3 && activeSpeedLevel != 3)
        {
            activeSpeedLevel = 3;
            SetLevelSprite("desert");
        }
    }


    /*
     * Events
     * 
     */
    public void PauseButtonClick()
    {
        Time.timeScale = 0f;
        SetActivePanel("PausePanel");
    }


    public void BackButtonClick()
    {
        Time.timeScale = 1f;
        SetActivePanel("LevelPanel");
    }


    public void RetryButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }


    public void ToMenuButtonClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
