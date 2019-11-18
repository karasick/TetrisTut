using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TetrisBlocks")]
public class TetrisBlocks : ScriptableObject
{
    [SerializeField]
    private GameObject[] TetrisObjects;

    public GameObject[] GetTetrisObjects()
    {
        return TetrisObjects;
    }
}
