using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlockSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tetrisObjects = null;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRandom()
    {
        if(TetrisGrid.IsEndGame())
        {
            FindObjectOfType<LevelController>().isLose = true;
        }
        else
        {
            int index = Random.Range(0, tetrisObjects.Length);
            Instantiate(tetrisObjects[index], transform.position, Quaternion.identity);
        }
    }
}
