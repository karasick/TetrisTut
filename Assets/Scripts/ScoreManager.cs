using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public static int gameTime;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score++;
        gameTime = (int)Time.time;
    }
}
