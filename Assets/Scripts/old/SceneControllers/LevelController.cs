using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private GameObject EndGamePanel = null;
    [SerializeField]
    private GameObject pausePanel = null;
    [SerializeField]
    private Text currentScoreText = null;
    [SerializeField]
    private Text currentLevelText = null;
    [SerializeField]
    private Text endScoreText = null;
    [SerializeField]
    private GameObject pauseButton = null;

    public bool isLose = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentLevelText.text = "Lvl: " + ScoreManager.speedLevel;
        currentScoreText.text = "Score: " + ScoreManager.score;
    }

    void Awake()
    {
        TetrisGrid.ClearCurrentHeight();
        TetrisGrid.ClearGrid();
        ScoreManager.score = 0;

        Time.timeScale = 1f;
        EndGamePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void SaveLevel()
    {
        Time.timeScale = 0f;

        isLose = true;
        SaveLoadScore.Save();

        endScoreText.text = "Score: " + ScoreManager.score;
        EndGamePanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void PauseButtonClick()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void BackButtonClick()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
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
