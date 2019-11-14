using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisGrid : MonoBehaviour
{
    public static int NumberOfRows = 20;
    public static int NumberOfColumns = 10;

    public static int CurrentHeight = 0;

    public static Transform[,] Grid = new Transform[NumberOfColumns, NumberOfRows];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Vector2 RoundVector(Vector2 vector)
    {
        return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
    }

    public static bool IsInsideBorder(Vector2 position)
    {
        return (int)position.x >= 0 && (int)position.x < NumberOfColumns && (int)position.y >= 0;
    }

    private static void DecreaseRow(int y)
    {
        for (int x = 0; x < NumberOfColumns; ++x)
        {
            if (Grid[x, y] != null)
            {
                Grid[x, y - 1] = Grid[x, y];
                Grid[x, y] = null;
                Grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    private static void DecreaseRowsAbove(int y)
    {
        for (int i = y; i < NumberOfRows; ++i)
        {
            DecreaseRow(i);
        }
    }

    private static bool IsRowFull(int y)
    {
        for (int x = 0; x < NumberOfColumns; ++x)
        {
            if (Grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }

    private static void DeleteRow(int y)
    {
        for (int x = 0; x < NumberOfColumns; ++x)
        {
            GameObject.Destroy(Grid[x, y].gameObject);
            Grid[x, y] = null;
        }
    }

    public static void DeleteRows()
    {
        for (int y = 0; y < NumberOfRows; ++y)
        {
            if (IsRowFull(y))
            {
                DeleteRow(y);
                DecreaseRowsAbove(y + 1);
                ScoreManager.Instance.AddScore();
                y--;
            }
        }
    }

    public static void UpdateTetrisGrid(Transform tetrisBLock)
    {
        for (int y = 0; y < NumberOfRows; ++y)
        {
            for (int x = 0; x < NumberOfColumns; ++x)
            {
                if (Grid[x, y] != null)
                {
                    if (Grid[x, y].parent == tetrisBLock)
                    {
                        Grid[x, y] = null;
                    }
                }
            }
        }

        foreach (Transform child in tetrisBLock)
        {
            Vector2 vector = RoundVector(child.position);
            Grid[(int)vector.x, (int)vector.y] = child;
        }
    }

    public static bool IsValidGridPosition(Transform tetrisBLock)
    {
        foreach (Transform child in tetrisBLock)
        {
            Vector2 vector = RoundVector(child.position);

            if (!TetrisGrid.IsInsideBorder(vector))
            {
                return false;
            }

            if (Grid[(int)vector.x, (int)vector.y] != null && Grid[(int)vector.x, (int)vector.y].parent != tetrisBLock)
            {
                return false;
            }
        }
        return true;
    }

    private static void FindCurrentHeight()
    {
        for (int y = 0; y < NumberOfRows; ++y)
        {
            for (int x = 0; x < NumberOfColumns; ++x)
            {
                if (Grid[x, y] != null)
                {
                    if((y + 1) >= CurrentHeight)
                    {
                        CurrentHeight = y + 1;
                    }
                }
            }
        }
    }

    public static bool IsEndGame()
    {
        FindCurrentHeight();

        if (CurrentHeight >= NumberOfRows - 3)
        {
            return true;
        }
        return false;
    }

    public static void ClearGrid()
    {
        System.Array.Clear(Grid, 0, Grid.Length);
    }

    public static void ClearCurrentHeight()
    {
        CurrentHeight = 0;
    }
}
