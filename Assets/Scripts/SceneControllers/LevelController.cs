using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private GameObject endGamePanel = null;
    [SerializeField]
    private GameObject pausePanel = null;
    [SerializeField]
    private GameObject pauseButton = null;

    public bool isLose = false;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isLose)
        {
            Time.timeScale = 0f;
            //endGamePanel.SetActive(true);
            pauseButton.SetActive(false);
        }
    }

    void Awake()
    {

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

    public void ToMenuButtonClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
