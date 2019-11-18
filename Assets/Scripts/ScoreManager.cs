using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    protected Level Level;

    public static ScoreManager Instance { get; private set; }

    public static List<int> SavedScores = new List<int>();

    public static float GameTime = 0;
    public static int Score = 0;
    public static int SecFoLevelingUp = 15;
    public static int MaxSpeedLevel = 3;


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

        // Reset Score parameters
        GameTime = 0;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTime();
    }


    private void CheckTime()
    {
        GameTime += Time.deltaTime;

        int speedLevel = Level.GetSpeedLevel();

        if (GameTime / (SecFoLevelingUp * speedLevel) >= 1)
        {
            if (Level.GetSpeedLevel() < MaxSpeedLevel)
            {
                Level.SetSpeedLevel(++speedLevel);
            }
        }
    }


    public void AddScore()
    {
        Score++;
    }
}
