using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject gameModePanel = null;
    [SerializeField]
    private GameObject customModePanel = null;
    [SerializeField]
    private GameObject optionsPanel = null;
    [SerializeField]
    private GameObject scoreboardPanel = null;

    // Start is called before the first frame update
    void Start()
    {
        optionsPanel.SetActive(false);
        scoreboardPanel.SetActive(false);
        customModePanel.SetActive(false);
        gameModePanel.SetActive(false);

        LoadScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayButtonClick()
    {
        gameModePanel.SetActive(true);
    }

    public void StartGameButtonClick()
    {
        SceneManager.LoadScene("Level");
    }

    public void CustomModeButtonClick()
    {
        customModePanel.SetActive(true);
    }

    public void OptionsButtonClick()
    {
        optionsPanel.SetActive(true);
    }

    public void ScoreboardButtonClick()
    {
        scoreboardPanel.SetActive(true);
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }

    public void ChangeStyleButtonClick()
    {

    }

    public void BackButtonClick()
    {
        if (customModePanel.activeSelf)
        {
            customModePanel.SetActive(false);
        }
        else
        {
            gameModePanel.SetActive(false);
        }
        optionsPanel.SetActive(false);
        scoreboardPanel.SetActive(false);
    }

    private void LoadScore()
    {

    }
}
