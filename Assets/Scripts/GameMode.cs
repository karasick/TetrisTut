using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tetrisObjects;

    private List<GameObject> activeTetrisObjects = new List<GameObject>();

    private List<int> deactivatedTetrisObjectsIndexes = new List<int>();

    public string gameMode = "original";


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
        DontDestroyOnLoad(gameObject);
    }


    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }


    public void AddToDeactivated(int index)
    {
        foreach (int deactivatedTetrisObjectsIndex in deactivatedTetrisObjectsIndexes)
        {
            if (deactivatedTetrisObjectsIndex == index)
            {
                RemoveFromDeactivated(index);
                return;
            }
        }
        deactivatedTetrisObjectsIndexes.Add(index);
    }


    public void RemoveFromDeactivated(int index)
    {
        deactivatedTetrisObjectsIndexes.Remove(index);
    }


    private void SetActiveTetrisObjects()
    {
        activeTetrisObjects.Clear();
        for (int i = 0; i < tetrisObjects.Length; i++)
        {
            if (!IsDeactivated(i))
            {
                activeTetrisObjects.Add(tetrisObjects[i]);
            }
        }
    }


    private bool IsDeactivated(int index)
    {
        foreach (int deactivatedTetrisObjectsIndex in deactivatedTetrisObjectsIndexes)
        {
            if (index == deactivatedTetrisObjectsIndex)
            {
                return true;
            }
        }
        return false;
    }


    public GameObject[] GetTetrisObjects()
    {
        if (gameMode == "custom")
        {
            SetActiveTetrisObjects();
            deactivatedTetrisObjectsIndexes.Clear();
            if(activeTetrisObjects.Count == 0)
            {
                // TODO: block starting
            }
            return activeTetrisObjects.ToArray();
        }
        else
        {
            return tetrisObjects;
        }
    }
}
