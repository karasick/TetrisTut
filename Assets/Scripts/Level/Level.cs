using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    // Views binding
    [SerializeField]
    private GameObject[] Panels;

    // BackgroundImage binding
    [SerializeField]
    private Image BackgroundImage;

    // Level Sprites
    private Sprite[] LevelSprites;

    // Active tetris block
    private TetrisBlock ActiveTetrisBlock;

    // Active panel
    private string ActivePanel;

    // Active speed level
    private int ActiveSpeedLevel;

    // Active menu sprite
    private string ActiveLevelSprite;

    // Is player lose
    public bool IsLose = false;

    // Start is called before the first frame update
    void Start()
    {
        CheckPlatform();

        Time.timeScale = 1f;

        ActiveSpeedLevel = 1;

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
        foreach (GameObject Panel in Panels)
        {
            if (Panel.name == panelNameNew)
            {
                // Show Active panel
                Panel.SetActive(true);
                ActivePanel = panelNameNew;
            }
            else
            {
                // Hide another Panels
                Panel.SetActive(false);
            }
        }
    }


    private void SetLevelSprite(string levelSprite)
    {
        levelSprite += "-" + CheckScreenOrientation();

        foreach (Sprite LevelSpite in LevelSprites)
        {
            if (LevelSpite.name == levelSprite)
            {
                ActiveLevelSprite = levelSprite;
                BackgroundImage.sprite = LevelSpite;
            }
        }
    }


    private string CheckScreenOrientation()
    {
        if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            return "horizontal";
        }
        else if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            return "vertical";
        }
        else
        {
            return "square";
        }
    }


    private void LoadSprites()
    {
        LevelSprites = Resources.LoadAll<Sprite>("Sprites/tetris_background");
    }


    public void SaveLevel()
    {
        Time.timeScale = 0f;

        IsLose = true;
        SetActivePanel("EndGamePanel");
        
        SaveLoad.SaveScore();
    }


    private void CheckLevel()
    {
        if(ScoreManager.SpeedLevel == 1 && ActiveSpeedLevel != 1)
        {
            ActiveSpeedLevel = 1;
            SetLevelSprite("forest");
        }
        else if (ScoreManager.SpeedLevel == 2 && ActiveSpeedLevel != 2)
        {
            ActiveSpeedLevel = 2;
            SetLevelSprite("west");
        }
        else if (ScoreManager.SpeedLevel == 3 && ActiveSpeedLevel != 3)
        {
            ActiveSpeedLevel = 3;
            SetLevelSprite("desert");
        }
    }


    public void CheckPlatform()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            FindObjectOfType<LevelPanel>().SetInputsVisibility(false);
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            FindObjectOfType<LevelPanel>().SetInputsVisibility(true);
        }
    }


    public void SetActiveTetrisBlock(TetrisBlock newTetrisBlock)
    {
        ActiveTetrisBlock = newTetrisBlock;
    }


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
        FindObjectOfType<GameMode>().DestroyGameObject();
        SceneManager.LoadScene("MainMenu");
    }


    public void RightButtonClick()
    {
        ActiveTetrisBlock.MoveRight();
    }

    public void LeftButtonClick()
    {
        ActiveTetrisBlock.MoveLeft();
    }

    public void RotateButtonClick()
    {
        ActiveTetrisBlock.RotateRight();
    }

    public void DownButtonClick()
    {
        ActiveTetrisBlock.MoveDown();
    }
}
