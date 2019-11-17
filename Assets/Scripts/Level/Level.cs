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

    // Active platform
    public RuntimePlatform ActivePlatform;

    // Is player lose
    public bool IsLose = false;

    // Start is called before the first frame update
    void Start()
    {
        CheckPlatform();

        Time.timeScale = 1f;

        ActiveSpeedLevel = 1;

        LoadSprites();

        SetActivePanel("GamePanel");

        SetSpeedLevel(1);
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


    private GameObject GetPanel(string panelName)
    {
        foreach (GameObject Panel in Panels)
        {
            if (Panel.name == panelName)
            {
                return Panel;
            }
        }
        return null;
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


    public void SetSpeedLevel(int speedLevel)
    {
        switch(speedLevel)
        {
            case 1:
            {
                ActiveSpeedLevel = speedLevel;
                SetLevelSprite("forest");
                break;
            }
            case 2:
            {
                ActiveSpeedLevel = speedLevel;
                SetLevelSprite("west");
                break;
            }
            case 3:
            {
                ActiveSpeedLevel = speedLevel;
                SetLevelSprite("desert");
                break;
            }
            default:
            {
                ActiveSpeedLevel = 1;
                SetLevelSprite("forest");
                break;
            }
        }
    }


    public int GetSpeedLevel()
    {
        return ActiveSpeedLevel;
    }


    public void CheckPlatform()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            ActivePlatform = RuntimePlatform.WindowsPlayer;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            ActivePlatform = RuntimePlatform.Android;
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
        SetActivePanel("GamePanel");
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
