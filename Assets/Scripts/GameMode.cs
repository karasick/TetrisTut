using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    [SerializeField]
    private GameObject[] TetrisObjects;

    private List<GameObject> ActiveTetrisObjects = new List<GameObject>();

    private List<int> DeactivatedTetrisObjectsIndexes = new List<int>();

    public string ActiveGameMode = "original";


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
        foreach (int deactivatedTetrisObjectsIndex in DeactivatedTetrisObjectsIndexes)
        {
            if (deactivatedTetrisObjectsIndex == index)
            {
                RemoveFromDeactivated(index);
                return;
            }
        }
        DeactivatedTetrisObjectsIndexes.Add(index);
    }


    public void RemoveFromDeactivated(int index)
    {
        DeactivatedTetrisObjectsIndexes.Remove(index);
    }


    private void SetActiveTetrisObjects()
    {
        ActiveTetrisObjects.Clear();
        for (int i = 0; i < TetrisObjects.Length; i++)
        {
            if (!IsDeactivated(i))
            {
                ActiveTetrisObjects.Add(TetrisObjects[i]);
            }
        }
    }


    private bool IsDeactivated(int index)
    {
        foreach (int deactivatedTetrisObjectsIndex in DeactivatedTetrisObjectsIndexes)
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
        if (ActiveGameMode == "custom")
        {
            SetActiveTetrisObjects();
            DeactivatedTetrisObjectsIndexes.Clear();
            if(ActiveTetrisObjects.Count == 0)
            {
                // TODO: block starting
            }
            return ActiveTetrisObjects.ToArray();
        }
        else
        {
            return TetrisObjects;
        }
    }
}
