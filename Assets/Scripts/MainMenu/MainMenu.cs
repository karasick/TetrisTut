using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Views binding
    [SerializeField]
    private GameObject[] panels;

    // BackgroundImage binding
    [SerializeField]
    private Image backgroundImage;

    // Scoreboard
    public List<int> scoreboard;

    // Menu Sprites
    private Sprite[] menuSprites;

    // Active panel
    private string activePanel;

    // Active menu sprite
    private string activeMenuSprite;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;

        LoadScore();

        LoadSprites();

        SetActivePanel("MainPanel");

        SetMenuSprite("menu-01");
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Handlings
     * 
     */
    
    private void SetActivePanel(string panelNameNew)
    {
        foreach(GameObject panel in panels)
        {
            if(panel.name == panelNameNew)
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


    private void SetMenuSprite(string menuSpriteNew)
    {
        foreach (Sprite menuSpite in menuSprites)
        {
            if(menuSpite.name == menuSpriteNew)
            {
                activeMenuSprite = menuSpriteNew;
                backgroundImage.sprite = menuSpite;
            }
        }
    }


    private void LoadScore()
    {
        SaveLoadScore.Load();
        scoreboard = ScoreManager.savedScores;
        scoreboard.Sort();
        scoreboard.Reverse();
    }


    private void LoadSprites()
    {
        menuSprites = Resources.LoadAll<Sprite>("Sprites/menu");
    }

    /*
     * Events
     * 
     */

    public void PlayButtonClick()
    {
        FindObjectOfType<GameMode>().gameMode = "original";
        SetActivePanel("GameModePanel");
    }


    public void StartGameButtonClick()
    {
        SceneManager.LoadScene("Level");
    }


    public void CustomModeButtonClick()
    {
        FindObjectOfType<GameMode>().gameMode = "custom";
        SetActivePanel("CustomModePanel");
    }


    public void CheckboxButtonClick(int index)
    {
        FindObjectOfType<GameMode>().AddToDeactivated(index);
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
        foreach(Sprite menuSprite in menuSprites)
        {
            if (menuSprite.name == activeMenuSprite)
            {
                if(i == (menuSprites.Length - 1))
                {
                    activeMenuSprite = menuSprites[0].name;
                    SetMenuSprite(activeMenuSprite);
                }
                else
                {
                    activeMenuSprite = menuSprites[i + 1].name;
                    SetMenuSprite(activeMenuSprite);
                }
                return;
            }
            i++;
        }
    }


    public void BackButtonClick()
    {
        if (activePanel == "CustomModePanel")
        {
            FindObjectOfType<GameMode>().gameMode = "original";
            SetActivePanel("GameModePanel");
        }
        else
        {
            SetActivePanel("MainPanel");
        }
    }
}
