using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TetrisBlockSpawner : MonoBehaviour
{
    private GameObject[] tetrisObjects;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

        if (FindObjectOfType<GameMode>())
        {
            tetrisObjects = FindObjectOfType<GameMode>().GetTetrisObjects();

            SpawnRandom();
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRandom()
    {
        if(TetrisGrid.IsEndGame())
        {
            FindObjectOfType<Level>().SaveLevel();
            TetrisGrid.ClearCurrentHeight();
        }
        else
        {
            int index = Random.Range(0, tetrisObjects.Length);
            Instantiate(tetrisObjects[index], transform.position, Quaternion.identity);
        }
    }
}
