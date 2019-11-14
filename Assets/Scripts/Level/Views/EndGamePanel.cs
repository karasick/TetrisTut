using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField]
    private Level Level;

    [SerializeField]
    private Text EndScoreText = null;

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
        EndScoreText.text = "Score: " + ScoreManager.Score;
    }


    public void RetryButtonClick()
    {
        Level.RetryButtonClick();
    }


    public void ToMenuButtonClick()
    {
        Level.ToMenuButtonClick();
    }
}
