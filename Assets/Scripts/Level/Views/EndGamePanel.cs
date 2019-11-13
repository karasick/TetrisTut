using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField]
    private Level level;

    [SerializeField]
    private Text endScoreText = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Awake()
    {
        endScoreText.text = "Score: " + ScoreManager.score;
    }


    public void RetryButtonClick()
    {
        level.RetryButtonClick();
    }


    public void ToMenuButtonClick()
    {
        level.ToMenuButtonClick();
    }
}
