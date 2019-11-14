using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TetrisBlockSpawner : MonoBehaviour
{
    private GameObject[] TetrisObjects;

    // Start is called before the first frame update
    void Start()
    {

        if (FindObjectOfType<GameMode>())
        {
            TetrisObjects = FindObjectOfType<GameMode>().GetTetrisObjects();

            SpawnRandom();
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
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
            int index = Random.Range(0, TetrisObjects.Length);
            GameObject newTetrisBlock = Instantiate(TetrisObjects[index], transform.position, Quaternion.identity);
            FindObjectOfType<Level>().SetActiveTetrisBlock(newTetrisBlock.GetComponent<TetrisBlock>());
        }
    }
}
