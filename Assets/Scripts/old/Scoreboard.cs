using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    [SerializeField]
    private Text[] topPlayersScoresObjects = null;

    // Start is called before the first frame update
    void Start()
    {
        SaveLoadScore.Load();
        List<int> scoreboard = ScoreManager.savedScores;
        scoreboard.Sort();
        scoreboard.Reverse();

        int i = 0;
        foreach(Text topPlayerScoreObject in topPlayersScoresObjects)
        {
            i++;
            if(i <= scoreboard.Count)
            {
                int topScore = scoreboard[i - 1];
                topPlayerScoreObject.text = "Top " + i + ": " + topScore;
            } else
            {
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
