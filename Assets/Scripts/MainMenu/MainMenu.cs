using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Views binding
    [SerializeField]
    private GameObject[] Panels;

    // BackgroundImage binding
    [SerializeField]
    private Image BackgroundImage;

    // Scoreboard
    public List<int> Scoreboard;

    // Menu Sprites
    private Sprite[] MenuSprites;

    // Active panel
    private string ActivePanel;

    // Active menu sprite
    private string ActiveMenuSprite;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;

        LoadScore();

        LoadSprites();

        SetActivePanel("MainPanel");

        if(PlayerPrefs.HasKey("menuSprite"))
        {
            SetMenuSprite(SaveLoad.loadMenuSprite());
        }
        else
        {
            SetMenuSprite("menu-01");
        }
    }


    /*
     * Handlings
     * 
     */
    private void SetActivePanel(string panelNameNew)
    {
        foreach(GameObject Panel in Panels)
        {
            if(Panel.name == panelNameNew)
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


    private void SetMenuSprite(string menuSprite)
    {
        foreach (Sprite MenuSpite in MenuSprites)
        {
            if(MenuSpite.name == menuSprite)
            {
                ActiveMenuSprite = menuSprite;
                BackgroundImage.sprite = MenuSpite;
                SaveLoad.saveMenuSprite(ActiveMenuSprite);
            }
        }
    }


    private void LoadScore()
    {
        SaveLoad.LoadScore();
        Scoreboard = ScoreManager.SavedScores;
        Scoreboard.Sort();
        Scoreboard.Reverse();
    }


    private void LoadSprites()
    {
        MenuSprites = Resources.LoadAll<Sprite>("Sprites/menu");
    }


    public void PlayButtonClick()
    {
        GameMode.ActiveGameMode = Mode.Original;
        SetActivePanel("GameModePanel");
    }


    public void StartGameButtonClick()
    {
        SceneManager.LoadScene("Level");
    }


    public void CustomModeButtonClick()
    {
        GameMode.ActiveGameMode = Mode.Custom;
        SetActivePanel("CustomModePanel");
    }


    public void CheckboxButtonClick(int index)
    {
        GameMode.AddToDeactivated(index);
    }


    public void OptionsButtonClick()
    {
        SetActivePanel("OptionsPanel");
    }


    public void ScoreboardButtonClick()
    {
        SetActivePanel("ScoreboardPanel");
    }


    public void ExitButtonClick()
    {
        Application.Quit();
    }


    public void ChangeStyleButtonClick()
    {
        int i = 0;
        foreach(Sprite MenuSprite in MenuSprites)
        {
            if (MenuSprite.name == ActiveMenuSprite)
            {
                if(i == (MenuSprites.Length - 1))
                {
                    ActiveMenuSprite = MenuSprites[0].name;
                    SetMenuSprite(ActiveMenuSprite);
                }
                else
                {
                    ActiveMenuSprite = MenuSprites[i + 1].name;
                    SetMenuSprite(ActiveMenuSprite);
                }
                return;
            }
            i++;
        }
    }


    public void BackButtonClick()
    {
        if (ActivePanel == "CustomModePanel")
        {
            GameMode.ActiveGameMode = Mode.Original;
            SetActivePanel("GameModePanel");
        }
        else
        {
            SetActivePanel("MainPanel");
        }
    }
}
