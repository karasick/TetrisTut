using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public static List<int> savedScores = new List<int>();

    public static int gameTime = 0;
    public static int speedLevel = 1;
    public static int secFoLevelingUp = 10;
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("checkTime", 0f, 1f);
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Reset gameTime
        gameTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        checkTime();
    }


    public void AddScore()
    {
        score++;
    }


    private void checkTime()
    {
        gameTime = (int)Time.time;

        if (gameTime / (secFoLevelingUp * speedLevel) >= 1)
        {
            if(speedLevel < 3)
            {
                speedLevel++;
            }
        }
    }
}
