using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject gamePanel = null;
    [SerializeField]
    private GameObject optionsPanel = null;

    // Start is called before the first frame update
    void Start()
    {
        optionsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        SceneManager.LoadScene("Level");
    }

    public void Options()
    {
        optionsPanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ChangeStyle()
    {

    }

    public void ChangeSomething()
    {

    }

    public void Back()
    {
        optionsPanel.SetActive(false);
    }
}
