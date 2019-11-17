using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TetrisBlockSpawner : MonoBehaviour
{
    [SerializeField]
    private Level Level;

    [SerializeField]
    private TetrisTimer TetrisTimer;

    private GameObject[] TetrisObjects;

    // Start is called before the first frame update
    void Start()
    {

        if (GameMode.Instance)
        {
            TetrisObjects = GameMode.GetTetrisObjects();

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
            Level.SaveLevel();
            TetrisGrid.ClearCurrentHeight();
        }
        else
        {
            int index = Random.Range(0, TetrisObjects.Length);
            GameObject newGameObject = Instantiate(TetrisObjects[index], transform.position, Quaternion.identity);
            TetrisBlock newTetrisBlock = newGameObject.GetComponent<TetrisBlock>();
            newTetrisBlock.Initialize(this, TetrisTimer, Level);
            Level.SetActiveTetrisBlock(newTetrisBlock);

        }
    }
}
