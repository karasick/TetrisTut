using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    private Level Level;

    private GamePanel GamePanel;

    private TetrisBlockSpawner TetrisBlockSpawner;

    private TetrisTimer TetrisTimer;

    public float FallSpeed = 0.5f;

    private float PushSpeed = 0.1f;
    private float LevelSpeedAcceleration = 0.25f;
    private float FallTime = 0f;
    private TransformState ActiveTransformState;


    // Start is called before the first frame update
    void Start()
    {
        GamePanel = Level.GetComponent<GamePanel>();
    }

    public void Initialize(TetrisBlockSpawner tetrisBlockSpawner, TetrisTimer tetrisTimer, Level level)
    {
        TetrisBlockSpawner = tetrisBlockSpawner;
        TetrisTimer = tetrisTimer;
        Level = level;

        FallSpeed = FallSpeed - Level.GetSpeedLevel() * LevelSpeedAcceleration;
        TetrisTimer.AddToTimer(this, FallSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(enabled && (Time.timeScale != 0))
        {
            CheckUserInput();

            FallTime = Time.time;
        }
    }

    public void BlockFall()
    {
        transform.position -= new Vector3(0, 1, 0);

        if (TetrisGrid.IsValidGridPosition(transform))
        {
            TetrisGrid.UpdateTetrisGrid(transform);
        }
        else
        {
            transform.position += new Vector3(0, 1, 0);
            TetrisTimer.ResetTimer();

            TetrisGrid.DeleteRows();

            TetrisBlockSpawner.SpawnRandom();

            enabled = false;
        }
    }

    private void CheckUserInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            RotateRight();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            TetrisTimer.ResetTimer();
            TetrisTimer.AddToTimer(this, PushSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            TetrisTimer.ResetTimer();
            TetrisTimer.AddToTimer(this, FallSpeed);
        }
    }


    public void MoveRight()
    {
        Vector3 lastPosition = transform.position;
        transform.position += new Vector3(1, 0, 0);

        if (TetrisGrid.IsValidGridPosition(transform))
        {
            TetrisGrid.UpdateTetrisGrid(transform);
        }
        else
        {
            transform.position = lastPosition;
        }
    }


    public void MoveLeft()
    {
        Vector3 lastPosition = transform.position;
        transform.position -= new Vector3(1, 0, 0);

        if (TetrisGrid.IsValidGridPosition(transform))
        {
            TetrisGrid.UpdateTetrisGrid(transform);
        }
        else
        {
            transform.position = lastPosition;
        }
    }


    public void MoveUp()
    {
        Vector3 lastPosition = transform.position;
        transform.position += new Vector3(0, 1, 0);

        if (TetrisGrid.IsValidGridPosition(transform))
        {
            TetrisGrid.UpdateTetrisGrid(transform);
        }
        else
        {
            transform.position = lastPosition;
        }
    }


    public void MoveDown()
    {
        Vector3 lastPosition = transform.position;
        transform.position -= new Vector3(0, 1, 0);

        if (TetrisGrid.IsValidGridPosition(transform))
        {
            TetrisGrid.UpdateTetrisGrid(transform);
        }
        else
        {
            transform.position = lastPosition;
        }
    }


    public void RotateRight()
    {
        Vector3 lastPosition = transform.position;
        Vector3 lastAngles = transform.eulerAngles;

        transform.Rotate(new Vector3(0, 0, -90));
        foreach (Transform child in transform)
        {
            child.Rotate(new Vector3(0, 0, 90));
        }

        float angle = transform.eulerAngles.z;
        switch (angle)
        {
            case 270:
                {
                    MoveUp();
                    break;
                }
            case 180:
                {
                    MoveRight();
                    break;
                }
            case 90:
                {
                    MoveDown();
                    break;
                }
            case 0:
                {
                    MoveLeft();
                    break;
                }
        }

        if (TetrisGrid.IsValidGridPosition(transform))
        {
            TetrisGrid.UpdateTetrisGrid(transform);
        }
        else
        {
            transform.position = lastPosition;

            transform.eulerAngles = lastAngles;
            foreach (Transform child in transform)
            {
                child.Rotate(new Vector3(0, 0, -90));
            }
        }
    }
}
