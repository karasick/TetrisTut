using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public static GameMode Instance { get; private set; }

    [SerializeField]
    private TetrisBlocks AllTetrisBlocks;

    private static GameObject[] TetrisObjects;

    private static List<GameObject> ActiveTetrisObjects = new List<GameObject>();

    private static List<int> DeactivatedTetrisObjectsIndexes = new List<int>();

    public static Mode ActiveGameMode = Mode.Original;


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            TetrisObjects = AllTetrisBlocks.GetTetrisObjects();
        }
    }


    public static void DestroyGameObject()
    {
        Destroy(Instance);
    }


    public static void AddToDeactivated(int index)
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


    public static void RemoveFromDeactivated(int index)
    {
        DeactivatedTetrisObjectsIndexes.Remove(index);
    }


    private static void SetActiveTetrisObjects()
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


    private static bool IsDeactivated(int index)
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


    public static GameObject[] GetTetrisObjects()
    {
        if (ActiveGameMode == Mode.Custom)
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
