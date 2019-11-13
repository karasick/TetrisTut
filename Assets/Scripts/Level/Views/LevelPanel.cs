using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    [SerializeField]
    private Level level;

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


    public void PauseButtonClick()
    {
        level.PauseButtonClick();
    }
}
